namespace GLFW.Net
{
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
    /// also fail with this error and not <see cref="InvalidValueGLFWException"/>,
    /// because GLFW cannot know what future versions will exist.</para></remarks>
    public class VersionUnavailableGLFWException : GLFWException
    {
        /// <inheritdoc cref="GLFWException"/>
        public VersionUnavailableGLFWException(string description)
            : base(description)
        {
            // ...
        }
    }
}