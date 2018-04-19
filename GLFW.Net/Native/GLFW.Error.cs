using System.Runtime.InteropServices;

namespace GLFW.Net.Native
{
    internal static partial class GLFW
    {
        #region Error Codes
        
        /// <summary>
        /// GLFW has not been initialized.
        /// <para>This occurs if a GLFW function was called
        /// that must not be called unless the library is initialized.</para>
        /// </summary>
        /// <remarks>Application programmer error.
        /// Initialize GLFW before calling any function that requires initialization.</remarks>
        public const int NotInitialized = 0x00010001;
        
        /// <summary>
        /// No context is current for this thread.
        /// <para>This occurs if a GLFW function was called that needs and operates on
        /// the current OpenGL or OpenGL ES context but no context is current on the calling thread.
        /// One such function is <see cref="SwapInterval"/>.</para>
        /// </summary>
        /// <remarks>Application programmer error.
        /// Ensure a context is current before calling functions that require a current context. </remarks>
        public const int NoCurrentContext = 0x00010002;
        
        /// <summary>
        /// One of the arguments to the function was an invalid enum value.
        /// <para>One of the arguments to the function was an invalid enum value,
        /// for example requesting <c>GLFW_RED_BITS</c> with <see cref="GetWindowAttrib"/>.</para>
        /// </summary>
        /// <remarks>Application programmer error.
        /// Fix the offending call. </remarks>
        public const int InvalidEnum = 0x00010003;
        
        /// <summary>
        /// One of the arguments to the function was an invalid value.
        /// <para>One of the arguments to the function was an invalid value,
        /// for example requesting a non-existent OpenGL or OpenGL ES version like 2.7.</para>
        /// <para>Requesting a valid but unavailable OpenGL or OpenGL ES version
        /// will instead result in a <see cref="VersionUnavailable"/> error.</para>
        /// </summary>
        /// <remarks>Application programmer error.
        /// Fix the offending call.</remarks>
        public const int InvalidValue = 0x00010004;
        
        /// <summary>
        /// A memory allocation failed.
        /// </summary>
        /// <remarks>A bug in GLFW or the underlying operating system.
        /// Report the bug to the GLFW issue tracker.</remarks>
        public const int OutOfMemory = 0x00010005;
        
        /// <summary>
        /// GLFW could not find support for the requested API on the system.
        /// </summary>
        /// <remarks><para>The installed graphics driver does not support the requested API,
        /// or does not support it via the chosen context creation backend.
        /// Below are a few examples.</para>
        /// <para>Some pre-installed Windows graphics drivers do not support OpenGL.
        /// AMD only supports OpenGL ES via EGL, while Nvidia and Intel only support it via a WGL or GLX extension.
        /// OS X does not provide OpenGL ES at all.
        /// The Mesa EGL, OpenGL and OpenGL ES libraries do not interface with the Nvidia binary driver.
        /// Older graphics drivers do not support Vulkan.</para></remarks>
        public const int ApiUnavailable = 0x00010006;
        
        /// <summary>
        /// The requested OpenGL or OpenGL ES version is not available.
        /// <para>The requested OpenGL or OpenGL ES version
        /// (including any requested context or framebuffer hints) is not available on this machine.</para>
        /// </summary>
        /// <remarks><para>The machine does not support your requirements.
        /// If your application is sufficiently flexible, downgrade your requirements and try again.
        /// Otherwise, inform the user that their machine does not match your requirements.</para>
        /// <para>Future invalid OpenGL and OpenGL ES versions,
        /// for example OpenGL 4.8 if 5.0 comes out before the 4.x series gets that far,
        /// also fail with this error and not <see cref="InvalidValue"/>,
        /// because GLFW cannot know what future versions will exist.</para></remarks>
        public const int VersionUnavailable = 0x00010007;
        
        /// <summary>
        /// A platform-specific error occurred that does not match any of the more specific categories.
        /// </summary>
        /// <remarks>A bug or configuration error in GLFW,
        /// the underlying operating system or its drivers,
        /// or a lack of required resources.
        /// Report the issue to the GLFW issue tracker.</remarks>
        public const int PlatformError = 0x00010008;
        
        /// <summary>
        /// The requested format is not supported or available.
        /// <para>If emitted during window creation, the requested pixel format is not supported.</para>
        /// <para>If emitted when querying the clipboard,
        /// the contents of the clipboard could not be converted to the requested format.</para>
        /// </summary>
        /// <remarks><para>If emitted during window creation,
        /// one or more hard constraints did not match any of the available pixel formats.
        /// If your application is sufficiently flexible,
        /// downgrade your requirements and try again.
        /// Otherwise, inform the user that their machine does not match your requirements.</para>
        /// <para>If emitted when querying the clipboard,
        /// ignore the error or report it to the user, as appropriate.</para></remarks>
        public const int FormatUnavailable = 0x00010009;
        
        /// <summary>
        /// The specified window does not have an OpenGL or OpenGL ES context.
        /// <para>A window that does not have an OpenGL or OpenGL ES context
        /// was passed to a function that requires it to have one.</para>
        /// </summary>
        /// <remarks>Application programmer error.
        /// Fix the offending call.</remarks>
        public const int NoWindowContext = 0x0001000A;
        
        #endregion
        
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