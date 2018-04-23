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
        /// Wraps a GLFW method call so that errors can be converted to exceptions and be thrown.
        /// </summary>
        /// <param name="func">Code to execute that has a GLFW call.</param>
        /// <exception cref="GLFWException">A GLFW error occurred.</exception>
        /// <remarks>It is important that only one GLFW call be invoked in <paramref name="func"/>.</remarks>
        internal static void CheckedCall(Action func)
        {
            // Set the GLFW error callback to the error translator.
            // ex will be set to an exception if a GLFW error occurred.
            // The previous callback is stored so that it can be reset later.
            GLFWException ex = null;
            var prevCallback = SetErrorCallback((code, description) => ex = TranslateError(code, description));
            
            // Wrap the code that might throw an exception.
            try
            {
                func();
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
        }
        
        /// <summary>
        /// Initializes GLFW.
        /// <para>This function initializes the GLFW library.
        /// Before most GLFW functions can be used, GLFW must be initialized,
        /// and before an application terminates GLFW should be terminated
        /// in order to free any resources allocated during or after initialization.</para>
        /// <para>If this function fails, it calls <see cref="Terminate"/> before returning.
        /// If it succeeds, you should call <see cref="Terminate"/> before the application exits.</para>
        /// <para>Additional calls to this function after successful initialization
        /// but before termination will return <see cref="True"/> immediately.</para>
        /// </summary>
        /// <returns><c>true</c> if the initialization finished successfully, <c>false</c> otherwise.</returns>
        /// <exception cref="PlatformErrorGLFWException">GLFW encounted a problem
        /// initializing on this platform.</exception>
        /// <remarks>If initialization fails, there's no need to call <see cref="Terminate"/>.</remarks>
        /// <seealso cref="Terminate"/>
        public static bool Initialize()
        {
            return CheckedCall(Init);
        }

        /// <summary>
        /// Terminates GLFW.
        /// <para>This function destroys all remaining windows and cursors,
        /// restores any modified gamma ramps and frees any other allocated resources.
        /// Once this function is called, you must again call <see cref="Initialize"/> successfully
        /// before you will be able to use most GLFW functions.</para>
        /// <para>If GLFW has been successfully initialized,
        /// this function should be called before the application exits.
        /// If initialization fails, there is no need to call this function,
        /// as it is called by <see cref="Initialize"/> before it returns failure.</para>
        /// </summary>
        /// <exception cref="PlatformErrorGLFWException">GLFW encounted a problem
        /// terminating on this platform.</exception>
        /// <remarks>This function may be called before <see cref="Initialize"/>.
        /// <para>Warning: The contexts of any remaining windows
        /// must not be current on any other thread when this function is called.</para>
        /// <para>This function must not be called from a callback.</para></remarks>
        /// <seealso cref="Initialize"/>
        public static void Terminate()
        {
            CheckedCall(Terminate);
        }
    }
}
