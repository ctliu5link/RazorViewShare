using System;
using System.IO;
using System.Web.Mvc;

namespace MVC_fw.Models
{
    public static class ViewRenderer
    {
        public static string RenderViewToString(ControllerContext context, string viewName, bool isPartialView = false, object model = null)
        {
            ViewEngineResult viewEngineResult = (isPartialView
            ? ViewEngines.Engines.FindPartialView(context, partialViewName: viewName)
            : ViewEngines.Engines.FindView(context, viewName: viewName, null))
            ?? throw new FileNotFoundException("View cannot be found.");

            var view = viewEngineResult.View;

#if DEBUG
            if (viewEngineResult.SearchedLocations != null)
                foreach (var ve in viewEngineResult.SearchedLocations)
                {
                    Console.WriteLine(((Controller)context.Controller).Server.MapPath(ve));
                }
#endif

            context.Controller.ViewData.Model = model;

            string result = null;

            using (var sw = new StringWriter())
            {
                var ctx = new ViewContext(context, view, context.Controller.ViewData, context.Controller.TempData, sw);
                view.Render(ctx, sw);
                result = sw.ToString();
            }

            return result;
        }
    }
}