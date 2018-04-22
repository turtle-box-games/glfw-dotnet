namespace GLFW.Net
{
    /// <summary>
    /// The requested format is not supported or available.
    /// <para>If emitted during window creation, the requested pixel format is not supported.</para>
    /// <para>If emitted when querying the clipboard,
    /// the contents of the clipboard could not be converted to the requested format.</para>
    /// </summary>
    /// <remarks><para>If emitted during window creation,
    /// one or more hard constraints did not match any of the available pixel formats.
    /// If your application is sufficiently flexible,
    /// downgrade your requirements and try again.
    /// Otherwise, inform the user that their machine does not match your requirements.</para>
    /// <para>If emitted when querying the clipboard,
    /// ignore the error or report it to the user, as appropriate.</para></remarks>
    public class FormatUnavailableGLFWException : GLFWException
    {
        /// <inheritdoc cref="GLFWException"/>
        public FormatUnavailableGLFWException(string description)
            : base(description)
        {
            // ...
        }
    }
}