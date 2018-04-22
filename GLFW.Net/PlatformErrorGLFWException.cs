namespace GLFW.Net
{
    /// <summary>
    /// A platform-specific error occurred that does not match any of the more specific categories.
    /// </summary>
    /// <remarks>A bug or configuration error in GLFW,
    /// the underlying operating system or its drivers,
    /// or a lack of required resources.
    /// Report the issue to the GLFW issue tracker.</remarks>
    public class PlatformErrorGLFWException : GLFWException
    {
        /// <inheritdoc cref="GLFWException"/>
        public PlatformErrorGLFWException(string description)
            : base(description)
        {
            // ...
        }
    }
}