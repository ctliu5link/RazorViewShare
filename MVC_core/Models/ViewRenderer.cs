using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;

namespace MVC_core.Models
{
    public static class ViewRenderer
    {
        public static async Task<string> RenderViewToStringAsync(IServiceProvider serviceProvider, string viewName, bool isPartialView, object model = null)
        {
            var httpContext = new DefaultHttpContext { RequestServices = serviceProvider };
            var actionContext = new ActionContext(httpContext, new Microsoft.AspNetCore.Routing.RouteData(), new Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor());

            var viewEngine = serviceProvider.GetRequiredService<ICompositeViewEngine>();
            var tempDataProvider = serviceProvider.GetRequiredService<ITempDataProvider>();
            var viewResult = isPartialView
                ? viewEngine.FindView(actionContext, viewName, false)
                : viewEngine.GetView(null, viewName, false);

            if (!viewResult.Success)
                throw new FileNotFoundException($"View '{viewName}' cannot be found.");

            var view = viewResult.View;

            using var stringWriter = new StringWriter();
            var viewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary()) { Model = model };
            var tempData = new TempDataDictionary(actionContext.HttpContext, tempDataProvider);
            var viewContext = new ViewContext(actionContext, view, viewData, tempData, stringWriter, new HtmlHelperOptions());
            await view.RenderAsync(viewContext);
            return stringWriter.ToString();
        }
    }
}
