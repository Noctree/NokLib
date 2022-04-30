using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NokLib
{
    public static class MiscellaneousExtensions
    {
        /// <summary>
        /// Performs all the null checks to guarantee that a string will be returned.
        /// If null should be returned it will return a string "null", which is a constant, so no allocations will occur
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SafeToString(this object? obj)
        {
            return obj is null? Constants.NULL : (obj.ToString() ?? Constants.NULL);
        }
    }
}
