using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace SharedWebComponents.VirtualFileRouting {
    public class CustomVirtualFile : System.Web.Hosting.VirtualFile {
        readonly string _path;
        readonly VirtualFileStreamFetcher _streamFetcher;

        public CustomVirtualFile(string virtualPath) : base(virtualPath) {
            _path = VirtualPathUtility.ToAppRelative(virtualPath);
            _streamFetcher = new VirtualFileStreamFetcher();
        }

        public override Stream Open() {
            var parts = _path.Split('/');
            var resourceName = _path.Replace("~/", "").Replace("/", ".");
            var assembly = Assembly.GetExecutingAssembly();
            return _streamFetcher.GetStream(assembly, resourceName, parts.Last());
        }
    }
}