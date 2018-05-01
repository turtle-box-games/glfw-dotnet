using System;
using System.Runtime.InteropServices;
using System.Security;

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
        private static GLFWException TranslateError(ErrorCode code, string description)
        {
            switch (code)
            {
            case ErrorCode.NotInitialized:
                return new NotInitializedGLFWException(description);
            case ErrorCode.NoCurrentContext:
                return new NoCurrentContextGLFWException(description);
            case ErrorCode.InvalidEnum:
                return new InvalidEnumGLFWException(description);
            case ErrorCode.InvalidValue:
                return new InvalidValueGLFWException(description);
            case ErrorCode.OutOfMemory:
                return new OutOfMemoryGLFWException(description);
            case ErrorCode.ApiUnavailable:
                return new ApiUnavailableGLFWException(description);
            case ErrorCode.VersionUnavailable:
                return new VersionUnavailableGLFWException(description);
            case ErrorCode.PlatformError:
                return new PlatformErrorGLFWException(description);
            case ErrorCode.FormatUnavailable:
                return new FormatUnavailableGLFWException(description);
            case ErrorCode.NoWindowContext:
                return new NoWindowContextGLFWException(description);
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
        /// The function signature for error callbacks.
        /// </summary>
        /// <param name="errorCode">An error code.</param>
        /// <param name="description">A UTF-8 encoded string describing the error.</param>
        /// <seealso cref="SetErrorCallback"/>
        internal delegate void ErrorCallback(ErrorCode errorCode,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string description);

        /// <summary>
        /// Sets the error callback.
        /// <para>This function sets the error callback,
        /// which is called with an error code and a human-readable description each time a GLFW error occurs.</para>
        /// <para>The error callback is called on the thread where the error occurred.
        /// If you are using GLFW from multiple threads, your error callback needs to be written accordingly.</para>
        /// <para>Once set, the error callback remains set even after the library has been terminated.</para>
        /// </summary>
        /// <param name="callback">The new callback, or <c>null</c> to remove the currently set callback.</param>
        /// <returns>The previously set callback, or <c>null</c> if no callback was set.</returns>
        /// <remarks>This function may be called before <see cref="Initialize"/>.</remarks>
        internal static ErrorCallback SetErrorCallback(ErrorCallback callback)
        {
            var pointerForDelegate  = callback == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(callback);
            var prevCallbackPointer = Internal.SetErrorCallback(pointerForDelegate);
            return prevCallbackPointer == IntPtr.Zero
                ? null
                : Marshal.GetDelegateForFunctionPointer<ErrorCallback>(prevCallbackPointer);
        }
        
        private static partial class Internal
        {
            /// <summary>
            /// Sets the error callback.
            /// <para>This function sets the error callback,
            /// which is called with an error code and a human-readable description each time a GLFW error occurs.</para>
            /// <para>The error callback is called on the thread where the error occurred.
            /// If you are using GLFW from multiple threads, your error callback needs to be written accordingly.</para>
            /// <para>Because the description string may have been generated specifically for that error,
            /// it is not guaranteed to be valid after the callback has returned.
            /// If you wish to use it after the callback returns, you need to make a copy.</para>
            /// <para>Once set, the error callback remains set even after the library has been terminated.</para>
            /// </summary>
            /// <param name="callback">The new callback, or <c>null</c> to remove the currently set callback.</param>
            /// <returns>The previously set callback, or <c>null</c> if no callback was set.</returns>
            /// <remarks>This function may be called before <see cref="Init"/>.</remarks>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwSetErrorCallback", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr SetErrorCallback(IntPtr callback);
        }
    }
}