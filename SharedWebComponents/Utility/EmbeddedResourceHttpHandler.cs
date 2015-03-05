using System.Reflection;
using System.Web;
using System.Web.Routing;

namespace SharedWebComponents.Utility {
    public class EmbeddedResourceHttpHandler : IHttpHandler {
        readonly RouteData _routeData;

        public EmbeddedResourceHttpHandler(RouteData routeData) {
            _routeData = routeData;
        }

        public bool IsReusable {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context) {
            var routeDataValues = _routeData.Values;
            var fileName = routeDataValues["file"].ToString();
            var fileExtension = routeDataValues["extension"].ToString();
            var nameSpace = typeof (EmbeddedResourceHttpHandler).Assembly.GetName().Name; // Mostly the default namespace and assembly name are same
            var prefix = GetPrefix(fileExtension);
            var manifestResourceName = string.Format("{0}.{1}{2}.{3}", nameSpace, prefix, fileName, fileExtension);
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(manifestResourceName);
            context.Response.Clear();
            context.Response.ContentType = "text/css"; // default
            if (fileExtension == "js") {
                context.Response.ContentType = "text/javascript";
            }
            stream.CopyTo(context.Response.OutputStream);
        }

        string GetPrefix(string fileExtension) {
            //todo: make this better... extract from route info instead of duplicating here or at least share the same logical string
            if (fileExtension.EndsWith("js")) {
                return "Scripts.";
            }
            if (fileExtension.EndsWith("css")) {
                return "Content.";
            }
            return string.Empty;
        }
    }
}