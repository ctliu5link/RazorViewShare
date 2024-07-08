using MVC_fw.Models;
using System.Web.Mvc;

namespace MVC_fw.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string reportContent = ViewRenderer.RenderViewToString(ControllerContext, "TempReport", true, null);
            ViewBag.Message = reportContent;
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