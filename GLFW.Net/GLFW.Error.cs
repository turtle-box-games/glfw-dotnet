using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;

namespace GLFW.Net
{
    public static partial class GLFW
    {
        /// <summary>
        /// Errors that occurred on each thread while using GLFW methods.
        /// </summary>
        private static readonly ThreadLocal<Error> PendingError = new ThreadLocal<Error>();
        
        /// <summary>
        /// Information about an error that occurred in GLFW.
        /// </summary>
        private class Error
        {
            private readonly int _code;
            private readonly IntPtr _description;

            /// <summary>
            /// Creates a reference to an error that occurred in GLFW.
            /// </summary>
            /// <param name="code">Error code from GLFW.</param>
            /// <param name="description">UTF-8 encoded string containing the error message.</param>
            public Error(int code, IntPtr description)
            {
                _code = code;
                _description = description;
            }
        
            /// <summary>
            /// Converts the GLFW error into an exception that can be handled by C#.
            /// </summary>
            /// <returns>Corresponding exception representing the GLFW error.</returns>
            /// <exception cref="ArgumentOutOfRangeException">An unrecognized GLFW code was given.</exception>
            public GLFWException Translate()
            {
                var code = (ErrorCode) _code;
                var description = _description.FromNativeUtf8();
                
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
        }

        /// <summary>
        /// Stores an error reported by GLFW into local thread storage.
        /// The error should be picked up and translated soon after this method is called.
        /// </summary>
        /// <param name="code">Error code from GLFW.</param>
        /// <param name="description">UTF-8 encoded string containing the error message.</param>
        private static void StoreError(int code, IntPtr description)
        {
            PendingError.Value = new Error(code, description);
        }

        /// <summary>
        /// Checks if a GLFW error occurred and raises it as an exception if there was one.
        /// This method should be called immediately after every GLFW call.
        /// </summary>
        /// <exception cref="GLFWException">An error occurred while using GLFW.</exception>
        /// <exception cref="ArgumentOutOfRangeException">An unrecognized GLFW error ocurred.</exception>
        private static void HandleError()
        {
            var error = PendingError.Value;
            if (error == null)
                return;
            PendingError.Value = null;
            throw error.Translate();
        }

        /// <summary>
        /// Sets up the error handler.
        /// This method must be called during initialization.
        /// </summary>
        private static void InitializeErrorHandler()
        {
            var pointerForDelegate = Marshal.GetFunctionPointerForDelegate<ErrorCallback>(StoreError);
            Internal.SetErrorCallback(pointerForDelegate);
        }

        /// <summary>
        /// Disables the error handler.
        /// </summary>
        private static void RemoveErrorHandler()
        {
            Internal.SetErrorCallback(IntPtr.Zero);
        }

        /// <summary>
        /// The function signature for error callbacks.
        /// </summary>
        /// <param name="code">An error code.</param>
        /// <param name="description">A UTF-8 encoded string describing the error.</param>
        private delegate void ErrorCallback(int code, IntPtr description);
        
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
            /// <param name="cbfun">The new callback, or <c>null</c> to remove the currently set callback.</param>
            /// <returns>The previously set callback, or <c>null</c> if no callback was set.</returns>
            /// <remarks>This function may be called before <see cref="Init"/>.</remarks>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwSetErrorCallback", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr SetErrorCallback(IntPtr cbfun);
        }
    }
}