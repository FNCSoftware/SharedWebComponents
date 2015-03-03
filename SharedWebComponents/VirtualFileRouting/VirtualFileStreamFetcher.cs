using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SharedWebComponents.VirtualFileRouting {
    internal class VirtualFileStreamFetcher {
        public Stream GetStream(Assembly assembly, string resourceName, string fileName) {
            var manifestResourceStream = assembly.GetManifestResourceStream(resourceName);
            if (manifestResourceStream == null) {
                manifestResourceStream = GetByResourceName(assembly, fileName);
            }
            if (manifestResourceStream == null) {
                throw new Exception("Failed to find resource: " + resourceName);
            }

            //var stream = new MemoryStream();
            //manifestResourceStream.CopyTo(stream);
            //stream.Position = 0;
            //manifestResourceStream.Position = 0;
            var result = GetPrependedViewStream(manifestResourceStream);
            return result;
        }

        static Stream GetByResourceName(Assembly assembly, string resourceName) {
            var names = assembly.GetManifestResourceNames();
            var matchingNames = names.Where(x => x.EndsWith("." + resourceName)).ToList();
            if (matchingNames.Count() == 1) {
                return assembly.GetManifestResourceStream(matchingNames.First());
            }
            return null;
        }

        static MemoryStream GetPrependedViewStream(Stream stream) {
            var view = VirtualFileRazorViewHelper.GetViewString(stream);
            var result = new MemoryStream();
            var writer = new StreamWriter(result);
            writer.Write(view);
            writer.Flush();
            result.Position = 0;
            //using (var reader = new StreamReader(memoryStream))
            //{
            //    var view = reader.ReadToEnd();
            //}

            return result;
        }
    }
}