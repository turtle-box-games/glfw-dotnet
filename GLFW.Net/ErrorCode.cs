namespace GLFW.Net
{
    /// <summary>
    /// Error codes that can be returned from GLFW.
    /// </summary>
    /// <seealso cref="GLFW.ErrorCallback"/>
    internal enum ErrorCode : uint
    {
        /// <summary>
        /// GLFW has not been initialized.
        /// <para>This occurs if a GLFW function was called
        /// that must not be called unless the library is initialized.</para>
        /// </summary>
        /// <remarks>Application programmer error.
        /// Initialize GLFW before calling any function that requires initialization.</remarks>
        NotInitialized = 0x00010001,
        
        /// <summary>
        /// No context is current for this thread.
        /// <para>This occurs if a GLFW function was called that needs and operates on
        /// the current OpenGL or OpenGL ES context but no context is current on the calling thread.
        /// One such function is <see cref="GLFW.SwapInterval"/>.</para>
        /// </summary>
        /// <remarks>Application programmer error.
        /// Ensure a context is current before calling functions that require a current context. </remarks>
        NoCurrentContext = 0x00010002,
        
        /// <summary>
        /// One of the arguments to the function was an invalid enum value.
        /// <para>One of the arguments to the function was an invalid enum value,
        /// for example requesting <c>GLFW_RED_BITS</c> with <see cref="GetWindowAttrib"/>.</para>
        /// </summary>
        /// <remarks>Application programmer error.
        /// Fix the offending call.</remarks>
        InvalidEnum = 0x00010003,
        
        /// <summary>
        /// One of the arguments to the function was an invalid value.
        /// <para>One of the arguments to the function was an invalid value,
        /// for example requesting a non-existent OpenGL or OpenGL ES version like 2.7.</para>
        /// <para>Requesting a valid but unavailable OpenGL or OpenGL ES version
        /// will instead result in a <see cref="VersionUnavailable"/> error.</para>
        /// </summary>
        /// <remarks>Application programmer error.
        /// Fix the offending call.</remarks>
        InvalidValue = 0x00010004,
        
        /// <summary>
        /// A memory allocation failed.
        /// </summary>
        /// <remarks>A bug in GLFW or the underlying operating system.
        /// Report the bug to the GLFW issue tracker.</remarks>
        OutOfMemory = 0x00010005,
        
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
        ApiUnavailable = 0x00010006,
        
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
        VersionUnavailable = 0x00010007,
        
        /// <summary>
        /// A platform-specific error occurred that does not match any of the more specific categories.
        /// </summary>
        /// <remarks>A bug or configuration error in GLFW,
        /// the underlying operating system or its drivers,
        /// or a lack of required resources.
        /// Report the issue to the GLFW issue tracker.</remarks>
        PlatformError = 0x00010008,
        
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
        FormatUnavailable = 0x00010009,
        
        /// <summary>
        /// The specified window does not have an OpenGL or OpenGL ES context.
        /// <para>A window that does not have an OpenGL or OpenGL ES context
        /// was passed to a function that requires it to have one.</para>
        /// </summary>
        /// <remarks>Application programmer error.
        /// Fix the offending call.</remarks>
        NoWindowContext = 0x0001000A
    }
}