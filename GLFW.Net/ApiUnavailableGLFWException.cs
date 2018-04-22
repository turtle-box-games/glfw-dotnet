namespace GLFW.Net
{
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
    public class ApiUnavailableGLFWException : GLFWException
    {
        /// <inheritdoc cref="GLFWException"/>
        public ApiUnavailableGLFWException(string description)
            : base(description)
        {
            // ...
        }
    }
}