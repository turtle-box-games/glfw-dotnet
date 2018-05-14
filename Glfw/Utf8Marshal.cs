using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Glfw3
{
    public static class Utf8Marshal
    {
        /// <summary>
        /// Reads a UTF-8 null-terminated string from a native pointer.
        /// The string will be copied so that managed memory can take ownership of it.
        /// </summary>
        /// <param name="nativeString">Pointer to an unmanaged string containing the UTF-8 string.</param>
        /// <returns>Managed string copied from unmanaged memory,
        /// or <c>null</c> if <paramref name="nativeString"/> is <see cref="IntPtr.Zero"/>.</returns>
        public static string FromNativeUtf8(this IntPtr nativeString)
        {
            if (nativeString == IntPtr.Zero)
                return null;
            
            // Find out how long the string is.
            // It will be null-terminated, so look for that.
            var length = 0;
            while (Marshal.ReadByte(nativeString, length) != '\0')
                length++;
            
            // Allocate managed memory and copy the string into it.
            var buffer = new byte[length];
            Marshal.Copy(nativeString, buffer, 0, length);
            
            // Convert the UTF-8 string into the native format.
            return Encoding.UTF8.GetString(buffer);
        }

        /// <summary>
        /// Creates a null-terminated UTF-8 string that can be used in unmanaged code.
        /// The string will be copied and the GC will not cleanup the unmanaged copy.
        /// </summary>
        /// <param name="managedString">Managed string to copy to unmanaged memory.</param>
        /// <returns>Pointer to an unmanaged string containing the UTF-8 string,
        /// or <see cref="IntPtr.Zero"/> if <paramref name="managedString"/> is <c>null</c>.</returns>
        public static IntPtr ToNativeUtf8(this string managedString)
        {
            if(managedString == null)
                return IntPtr.Zero;
            
            // Get the length of the string as it would appear in UTF-8 and allocate memory for that amount.
            var length = Encoding.UTF8.GetByteCount(managedString);
            var buffer = new byte[length + 1]; // +1 to leave space for the null-terminator.

            // Encode the string in UTF-8.
            Encoding.UTF8.GetBytes(managedString, 0, managedString.Length, buffer, 0);
            
            // Allocate unmanaged memory and copy the buffer to it.
            var nativeString = Marshal.AllocHGlobal(buffer.Length);
            Marshal.Copy(buffer, 0, nativeString, buffer.Length);
            
            return nativeString;
        }
    }
}
