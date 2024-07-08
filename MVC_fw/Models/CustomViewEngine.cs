using System.Linq;
using System.Web.Mvc;

namespace MVC_fw.Models
{
    public class CustomViewEngine : RazorViewEngine
    {
        public CustomViewEngine()
        {
            string[] locationFormats = new string[] {
                "~/bin/Views/{1}/{0}.cshtml",
                "~/bin/Views/Report/{0}.cshtml",
            };
#if Concatenate
            // Concatenate the location formats
            ConcatLocationFormats(locationFormats);
#else
            // Set the location formats for the view engine
            MasterLocationFormats = PartialViewLocationFormats = ViewLocationFormats = locationFormats;
#endif
        }

        public void ConcatLocationFormats(string[] locationFormats)
        {
            MasterLocationFormats = MasterLocationFormats.Concat(locationFormats).ToArray();
            PartialViewLocationFormats = PartialViewLocationFormats.Concat(locationFormats).ToArray();
            ViewLocationFormats = ViewLocationFormats.Concat(locationFormats).ToArray();
        }
    }
}