namespace GLFW.Net
{
    /// <summary>
    /// A memory allocation failed.
    /// </summary>
    /// <remarks>A bug in GLFW or the underlying operating system.
    /// Report the bug to the GLFW issue tracker.</remarks>
    public class OutOfMemoryGLFWException : GLFWException
    {
        /// <inheritdoc cref="GLFWException"/>
        public OutOfMemoryGLFWException(string description)
            : base(description)
        {
        }
    }
}