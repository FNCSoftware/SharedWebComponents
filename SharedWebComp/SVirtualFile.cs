using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Hosting;

public class SVirtualFile : VirtualFile
{
    readonly string _path;

    public SVirtualFile(string virtualPath)
        : base(virtualPath)
    {
        _path = VirtualPathUtility.ToAppRelative(virtualPath);
    }

    public override Stream Open()
    {
        var parts = _path.Split('/');
        var assemblyName = parts[1];
        var resourceName = _path.Replace("~/", "").Replace("/", ".");

        assemblyName = Path.Combine(HttpRuntime.BinDirectory, assemblyName);
        var assembly = Assembly.LoadFile(assemblyName + ".dll");

        if (assembly != null) {
            var manifestResourceStream = assembly.GetManifestResourceStream(resourceName);
            if (manifestResourceStream == null) {
                var names = assembly.GetManifestResourceNames();
                var matchingNames = names.Where(x => {
                                                    var fileName = parts.Last();
                                                    return x.EndsWith("." + fileName);
                                                }).ToList();
                if (matchingNames.Count() == 1) {
                    manifestResourceStream = assembly.GetManifestResourceStream(matchingNames.First());
                }
                
            }
            return manifestResourceStream;
        }
        return null;
    }
}