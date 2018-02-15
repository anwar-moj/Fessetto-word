using System;
using System.Runtime.InteropServices;
using System.Security;
namespace Fasseto.Word.Core
{
    /// <summary>
    /// Helpers for <see cref="SecureString"/> class
    /// </summary>
    public static class SecureStringHelpers
    {
        /// <summary>
        /// Unsecure <see cref="SecureString"/> to plain text
        /// </summary>
        /// <param name="secureString"></param>
        /// <returns></returns>
        public static string Unsecure (this SecureString secureString)
        {
            if(secureString == null)
                return string.Empty;
            //Get pointer for unsecure string in memory
            var unmanagedString = IntPtr.Zero;

            try
            {
                //Unsecure the password
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                //Clean up any memory allocation
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
