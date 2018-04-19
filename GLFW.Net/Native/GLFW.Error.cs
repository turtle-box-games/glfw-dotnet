using System.Runtime.InteropServices;

namespace GLFW.Net.Native
{
    internal static partial class GLFW
    {
        public const int NotInitialized = 0x00010001;
        public const int NoCurrentContext = 0x00010002;
        public const int InvalidEnum = 0x00010003;
        public const int InvalidValue = 0x00010004;
        public const int OutOfMemory = 0x00010005;
        public const int ApiUnavailable = 0x00010006;
        public const int VersionUnavailable = 0x00010007;
        public const int PlatformError = 0x00010008;
        public const int FormatUnavailable = 0x00010009;
        public const int NoWindowContext = 0x0001000A;
        
        /// <summary>
        /// The function signature for error callbacks.
        /// </summary>
        /// <param name="errorCode">An error code.</param>
        /// <param name="description">A UTF-8 encoded string describing the error.</param>
        /// <seealso cref="SetErrorCallback"/>
        public delegate void ErrorHandler(int errorCode, [MarshalAs(UnmanagedType.LPStr)] string description);

        /// <summary>
        /// Sets the error callback.
        /// <para>This function sets the error callback,
        /// which is called with an error code and a human-readable description each time a GLFW error occurs.</para>
        /// <para>The error callback is called on the thread where the error occurred.
        /// If you are using GLFW from multiple threads, your error callback needs to be written accordingly.</para>
        /// <para>Because the description string may have been generated specifically for that error,
        /// it is not guaranteed to be valid after the callback has returned.
        /// If you wish to use it after the callback returns, you need to make a copy.</para>
        /// <para>Once set, the error callback remains set even after the library has been terminated.</para>
        /// </summary>
        /// <param name="callback">The new callback, or <c>null</c> to remove the currently set callback.</param>
        /// <returns>The previously set callback, or <c>null</c> if no callback was set.</returns>
        /// <remarks>This function may be called before <see cref="Init"/>.</remarks>
        [DllImport(DllName, EntryPoint = "glfwSetErrorCallback")]
        [return: MarshalAs(UnmanagedType.FunctionPtr)]
        public static extern ErrorHandler SetErrorCallback([MarshalAs(UnmanagedType.FunctionPtr)] ErrorHandler callback);
    }
}