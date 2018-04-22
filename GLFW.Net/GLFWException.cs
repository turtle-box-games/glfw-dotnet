using System;

namespace GLFW.Net
{
    /// <summary>
    /// Base class for all GLFW exception types.
    /// </summary>
    public abstract class GLFWException : Exception
    {
        /// <summary>
        /// Creates the exception.
        /// </summary>
        /// <param name="description">Description provided from GLFW.</param>
        protected GLFWException(string description)
            : base(description)
        {
            // ...
        }
    }
}