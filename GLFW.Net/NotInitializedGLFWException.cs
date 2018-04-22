namespace GLFW.Net
{
    /// <summary>
    /// GLFW has not been initialized.
    /// <para>This occurs if a GLFW function was called
    /// that must not be called unless the library is initialized.</para>
    /// </summary>
    /// <remarks>Application programmer error.
    /// Initialize GLFW before calling any function that requires initialization.</remarks>
    public class NotInitializedGLFWException : GLFWException
    {
        /// <inheritdoc cref="GLFWException"/>
        public NotInitializedGLFWException(string description)
            : base(description)
        {
            // ...
        }
    }
}