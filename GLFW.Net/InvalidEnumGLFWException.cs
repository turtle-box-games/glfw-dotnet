namespace GLFW.Net
{
    /// <summary>
    /// One of the arguments to the function was an invalid enum value.
    /// <para>One of the arguments to the function was an invalid enum value,
    /// for example requesting <c>GLFW_RED_BITS</c> with <see cref="GLFW.GetWindowAttrib"/>.</para>
    /// </summary>
    /// <remarks>Application programmer error.
    /// Fix the offending call.</remarks>
    public class InvalidEnumGLFWException : GLFWException
    {
        /// <inheritdoc cref="GLFWException"/>
        public InvalidEnumGLFWException(string description)
            : base(description)
        {
            // ...
        }
    }
}