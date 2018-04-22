using System;

namespace GLFW.Net
{
    public static partial class GLFW
    {
        /// <summary>
        /// Converts a GLFW error into an exception that can be handled by C#.
        /// </summary>
        /// <param name="code">Error code from GLFW.</param>
        /// <param name="description">UTF-8 encoded string containing the error message.</param>
        /// <returns>Corresponding exception representing the GLFW error.</returns>
        /// <exception cref="ArgumentOutOfRangeException">An unrecognized GLFW code was given.</exception>
        private static GLFWException TranslateError(ErrorCode code, IntPtr description)
        {
            var managedDescription = description.FromNativeUtf8();
            switch (code)
            {
            case ErrorCode.NotInitialized:
                return new NotInitializedGLFWException(managedDescription);
            case ErrorCode.NoCurrentContext:
                return new NoCurrentContextGLFWException(managedDescription);
            case ErrorCode.InvalidEnum:
                return new InvalidEnumGLFWException(managedDescription);
            case ErrorCode.InvalidValue:
                return new InvalidValueGLFWException(managedDescription);
            case ErrorCode.OutOfMemory:
                return new OutOfMemoryGLFWException(managedDescription);
            case ErrorCode.ApiUnavailable:
                return new ApiUnavailableGLFWException(managedDescription);
            case ErrorCode.VersionUnavailable:
                return new VersionUnavailableGLFWException(managedDescription);
            case ErrorCode.PlatformError:
                return new PlatformErrorGLFWException(managedDescription);
            case ErrorCode.FormatUnavailable:
                return new FormatUnavailableGLFWException(managedDescription);
            case ErrorCode.NoWindowContext:
                return new NoWindowContextGLFWException(managedDescription);
            default:
                throw new ArgumentOutOfRangeException(nameof(code), code, "Unrecognized GLFW error code");
            }
        }

        /// <summary>
        /// Wraps a GLFW method call so that errors can be converted to exceptions and be thrown.
        /// </summary>
        /// <param name="func">Code to execute that has a GLFW call.</param>
        /// <typeparam name="T">Return type of <paramref name="func"/>.</typeparam>
        /// <returns>Value returned from <paramref name="func"/>.</returns>
        /// <exception cref="GLFWException">A GLFW error occurred.</exception>
        /// <remarks>It is important that only one GLFW call be invoked in <paramref name="func"/>.</remarks>
        internal static T CheckedCall<T>(Func<T> func)
        {
            // Set the GLFW error callback to the error translator.
            // ex will be set to an exception if a GLFW error occurred.
            // The previous callback is stored so that it can be reset later.
            GLFWException ex = null;
            var prevCallback = SetErrorCallback((code, description) => ex = TranslateError(code, description));
            T result;
            
            // Wrap the code that might throw an exception.
            try
            {
                result = func();
                // It's important that GLFW function call is finished
                // and that an exception isn't thrown from the error callback.
                // Some GLFW functions perform additional cleanup after an error,
                // and throwing an exception during the callback would interrupt it, never letting it finish.
            }
            finally
            {
                // Ensure that the previous error callback is reset.
                // This allows nested calls to GLFW functions.
                SetErrorCallback(prevCallback);
            }

            // Throw the translated exception if an error occurred.
            if (ex != null)
                throw ex;
            
            // Otherwise, return the result of the function.
            return result;
        }
        
        /// <summary>
        /// Initializes GLFW.
        /// </summary>
        /// <returns><c>true</c> if the initialization finished successfully, <c>false</c> otherwise.</returns>
        /// <exception cref="PlatformErrorGLFWException">GLFW encounted a problem
        /// initializing on this platform.</exception>
        /// <remarks>If initialization fails, there's no need to call <see cref="Terminate"/>.</remarks>
        public static bool Initialize()
        {
            return CheckedCall(Init);
        }
    }
}
