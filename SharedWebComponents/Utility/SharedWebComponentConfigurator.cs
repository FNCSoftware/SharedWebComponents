using System.Web.Hosting;
using System.Web.Mvc;
using SharedWebComponents.VirtualFileRouting;

namespace SharedWebComponents.Utility {
    public class SharedWebComponentConfigurator {
        public static void Configure() {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new CustomViewEngine());
            HostingEnvironment.RegisterVirtualPathProvider(new CustomVirtualPathProvider());
            EmbeddedResourceRouteConfigurator.Configure();
        }
    }
}