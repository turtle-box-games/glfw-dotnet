namespace Glfw3
{
    /// <summary>
    /// The specified window does not have an OpenGL or OpenGL ES context.
    /// <para>A window that does not have an OpenGL or OpenGL ES context
    /// was passed to a function that requires it to have one.</para>
    /// </summary>
    /// <remarks>Application programmer error.
    /// Fix the offending call.</remarks>
    public class NoWindowContextGlfwException : GlfwException
    {
        /// <inheritdoc cref="GlfwException"/>
        public NoWindowContextGlfwException(string description)
            : base(description)
        {
            // ...
        }
    }
}