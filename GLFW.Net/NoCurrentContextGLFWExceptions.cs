namespace GLFW.Net
{
    /// <summary>
    /// No context is current for this thread.
    /// <para>This occurs if a GLFW function was called that needs and operates on
    /// the current OpenGL or OpenGL ES context but no context is current on the calling thread.
    /// One such function is <see cref="GLFW.SwapInterval"/>.</para>
    /// </summary>
    /// <remarks>Application programmer error.
    /// Ensure a context is current before calling functions that require a current context. </remarks>
    public class NoCurrentContextGLFWExceptions : GLFWException
    {
        /// <inheritdoc cref="GLFWException"/>
        public NoCurrentContextGLFWExceptions(string description)
            : base(description)
        {
            // ...
        }
    }
}