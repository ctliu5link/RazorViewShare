using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RazorLibApi.Controllers
{
    public class ReportController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Report Page";

            return View();
        }
    }
}
