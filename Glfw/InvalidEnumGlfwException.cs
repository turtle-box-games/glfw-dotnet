namespace Glfw3
{
    /// <summary>
    /// One of the arguments to the function was an invalid enum value.
    /// <para>One of the arguments to the function was an invalid enum value,
    /// for example requesting <c>GLFW_RED_BITS</c> with <see cref="Glfw.GetWindowAttrib"/>.</para>
    /// </summary>
    /// <remarks>Application programmer error.
    /// Fix the offending call.</remarks>
    public class InvalidEnumGlfwException : GlfwException
    {
        /// <inheritdoc cref="GlfwException"/>
        public InvalidEnumGlfwException(string description)
            : base(description)
        {
            // ...
        }
    }
}