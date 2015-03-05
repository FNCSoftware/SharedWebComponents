using System.Web.Routing;

namespace SharedWebComponents.Utility {
    public static class EmbeddedResourceRouteConfigurator {
        public static void Configure() {
            RouteTable.Routes.Insert(0,
                new Route("Content/{file}.{extension}",
                    new RouteValueDictionary(new { }),
                    new RouteValueDictionary(new { extension = "css" }),
                    new EmbeddedResourceRouteHandler()
                ));
            
            RouteTable.Routes.Insert(0,
                new Route("Scripts/{file}.{extension}",
                    new RouteValueDictionary(new { }),
                    new RouteValueDictionary(new { extension = "js" }),
                    new EmbeddedResourceRouteHandler()
                ));
        }
    }
}