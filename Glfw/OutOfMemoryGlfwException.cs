namespace Glfw3
{
    /// <summary>
    /// A memory allocation failed.
    /// </summary>
    /// <remarks>A bug in GLFW or the underlying operating system.
    /// Report the bug to the GLFW issue tracker.</remarks>
    public class OutOfMemoryGlfwException : GlfwException
    {
        /// <inheritdoc cref="GlfwException"/>
        public OutOfMemoryGlfwException(string description)
            : base(description)
        {
        }
    }
}