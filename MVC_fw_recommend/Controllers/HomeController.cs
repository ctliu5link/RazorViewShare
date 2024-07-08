using MVC_fw_recommend.Models;
using System.Web.Mvc;

namespace MVC_fw_recommend.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string reportContent = ViewRenderer.RenderViewToString(ControllerContext, "LinkedReport", true, null);
            ViewBag.Message = reportContent;
            string reportContent2 = ViewRenderer.RenderViewToString(GenericController.CreateController<ReportController>().ControllerContext, "LinkedReportWithoutController", true, null);
            ViewBag.Message2 = reportContent2;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}