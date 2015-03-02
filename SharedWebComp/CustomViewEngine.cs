using System.Web.Mvc;

namespace SharedWebComponents {
    public class CustomViewEngine : RazorViewEngine {
        public CustomViewEngine() {
            var viewLocations = new[] {
                    "~/Views/{1}/{0}.cshtml",
                    "~/Views/Shared/{0}.cshtml",
                    "~/SharedWebComponents/{1}/{0}.cshtml",
                    "~/SharedWebComponents/Views/{1}/{0}.cshtml",
                    "~/SharedWebComponents/Shared/{1}/{0}.cshtml"
                };

            PartialViewLocationFormats = viewLocations;
            ViewLocationFormats = viewLocations;
        }
    }
}