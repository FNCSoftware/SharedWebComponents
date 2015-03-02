using System;
using System.Collections;
using System.Web;
using System.Web.Caching;
using System.Web.Hosting;

namespace SharedWebComponents.VirtualFileRouting {
    public class CustomVirtualPathProvider : VirtualPathProvider {
        static bool IsEmbeddedResourcePath(string virtualPath) {
            var checkPath = VirtualPathUtility.ToAppRelative(virtualPath);
            var result = checkPath.StartsWith("~/SharedWebComponents/", StringComparison.InvariantCultureIgnoreCase);
            return result;
        }

        public override bool FileExists(string virtualPath) {
            return IsEmbeddedResourcePath(virtualPath) || base.FileExists(virtualPath);
        }

        public override VirtualFile GetFile(string virtualPath) {
            if (IsEmbeddedResourcePath(virtualPath)) {
                return new CustomVirtualFile(virtualPath);
            }
            return base.GetFile(virtualPath);
        }

        public override CacheDependency GetCacheDependency(string virtualPath, IEnumerable virtualPathDependencies, DateTime utcStart) {
            return IsEmbeddedResourcePath(virtualPath) ? null : base.GetCacheDependency(virtualPath, virtualPathDependencies, utcStart);
        }
    }
}