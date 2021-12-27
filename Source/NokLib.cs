using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NokLib
{
    public static class NokLibBase
    {
        public static Version Version => new Version(1, 0, 0);
        public static string VersionName => "GitHub Initial";

        public static string FullVersionName => $"{Version} ({VersionName})";
    }
}
