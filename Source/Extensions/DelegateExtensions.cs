using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NokLib
{
    public static class DelegateExtensions
    {
        /// <summary>
        /// Invokes every delegate from the GetInvocationList method regardless of any exceptions that might happen during invocation
        /// </summary>
        /// <param name="deleg"></param>
        /// <param name="logExceptions">Log thrown exceptions using System.Diagnostics.Debug class?</param>
        /// <param name="arg">Arguments for the delegate</param>
        public static void InvokeSafely(this MulticastDelegate deleg, bool logExceptions, params object[] arg)
        {
            var invokList = deleg.GetInvocationList(); //Could get optimised by accessing the internal delegate array directly trough reflection
            foreach (var target in invokList) {
                target.InvokeSafely(logExceptions, arg);
            }
        }

        /// <summary>
        /// Invokes the delegate and logs any exceptions caught during invocation using System.Diagnostics.Debug class
        /// </summary>
        /// <param name="deleg"></param>
        /// <param name="logExceptions">Log thrown exceptions using System.Diagnostics.Debug class?</param>
        /// <param name="arg">Arguments for the delegate</param>
        public static void InvokeSafely(this Delegate deleg, bool logExceptions, params object[] arg)
        {
            try {
                deleg.DynamicInvoke(arg);
            } catch (Exception ex) {
                Debug.WriteLineIf(logExceptions, ex.ToString());
            }
        }
    }
}
