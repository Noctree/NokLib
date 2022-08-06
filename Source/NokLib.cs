using System;

namespace NokLib
{
    /// <summary>
    /// Class for storing version info about the library
    /// </summary>
    public static class NokLibBase
    {
        /// <summary>
        /// Version of the class
        /// </summary>
        public static readonly Version Version = new Version(1, 2);
        /// <summary>
        /// Name of the build
        /// </summary>
        public static readonly string VersionName = "GitHub";

        /// <summary>
        /// Full name of the build
        /// </summary>
        public static readonly string FullVersionName = $"{Version} ({VersionName})";
    }
}
