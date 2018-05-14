namespace Glfw3
{
    /// <summary>
    /// One of the arguments to the function was an invalid value.
    /// <para>One of the arguments to the function was an invalid value,
    /// for example requesting a non-existent OpenGL or OpenGL ES version like 2.7.</para>
    /// <para>Requesting a valid but unavailable OpenGL or OpenGL ES version
    /// will instead result in a <see cref="VersionUnavailableGlfwException"/> error.</para>
    /// </summary>
    /// <remarks>Application programmer error.
    /// Fix the offending call.</remarks>
    public class InvalidValueGlfwException : GlfwException
    {
        /// <inheritdoc cref="GlfwException"/>
        public InvalidValueGlfwException(string description)
            : base(description)
        {
            // ...
        }
    }
}