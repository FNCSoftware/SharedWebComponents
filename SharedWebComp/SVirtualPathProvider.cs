using System;
using System.Collections;
using System.Web;
using System.Web.Caching;
using System.Web.Hosting;

namespace SharedWebComponents {
    public class SVirtualPathProvider : VirtualPathProvider
    {
        private bool IsEmbeddedResourcePath(string virtualPath)
        {
            var checkPath = VirtualPathUtility.ToAppRelative(virtualPath);
            return checkPath.StartsWith("~/SharedWebComponents/", StringComparison.InvariantCultureIgnoreCase);
        }

        public override bool FileExists(string virtualPath)
        {
            return IsEmbeddedResourcePath(virtualPath) || base.FileExists(virtualPath);
        }

        public override VirtualFile GetFile(string virtualPath) {
            if (IsEmbeddedResourcePath(virtualPath))
            {
                return new SVirtualFile(virtualPath);
            }
            return base.GetFile(virtualPath);
        }

        public override CacheDependency GetCacheDependency(string virtualPath, IEnumerable virtualPathDependencies, DateTime utcStart) {
            if (IsEmbeddedResourcePath(virtualPath))
            {
                return null;
            }
            return base.GetCacheDependency(virtualPath, virtualPathDependencies, utcStart);
        }
    }
}