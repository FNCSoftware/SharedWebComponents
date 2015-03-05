using System.Web;
using System.Web.Routing;

namespace SharedWebComponents.Utility {
    public class EmbeddedResourceRouteHandler : IRouteHandler {
        IHttpHandler IRouteHandler.GetHttpHandler(RequestContext requestContext) {
            return new EmbeddedResourceHttpHandler(requestContext.RouteData);
        }
    }
}