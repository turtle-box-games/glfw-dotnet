using System;

namespace Glfw3
{
    /// <summary>
    /// Base class for all GLFW exception types.
    /// </summary>
    public abstract class GlfwException : Exception
    {
        /// <summary>
        /// Creates the exception.
        /// </summary>
        /// <param name="description">Description provided from GLFW.</param>
        protected GlfwException(string description)
            : base(description)
        {
            // ...
        }
    }
}