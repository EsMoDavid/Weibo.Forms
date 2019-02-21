using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EsMo.Weibo.Core
{
    internal static class FileUtil
    {
        public static async Task<Stream> ReadEmbeddedResourceAsync(string path)
        {
            return await Task.Run<Stream>(() => ReadEmbeddedResource(path));
        }
        public static Stream ReadEmbeddedResource(string path)
        {
            return Assembly.GetCallingAssembly().GetManifestResourceStream(path);
        }
    }
}
