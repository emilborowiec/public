using System;
using System.Reflection;

namespace PP.VersionServiceApi
{
    public class VersionService
    {
        public string GetFileVersion()
        {
            return Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyFileVersionAttribute>().Version;
        }
    }
}
