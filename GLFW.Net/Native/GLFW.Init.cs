using System.Runtime.InteropServices;

namespace GLFW.Net.Native
{
    internal static partial class GLFW
    {
        /// <summary>
        /// The function signature for error callbacks.
        /// </summary>
        /// <param name="errorCode">An error code.</param>
        /// <param name="description">A UTF-8 encoded string describing the error.</param>
        /// <seealso cref="GLFW.glfwSetErrorCallback"/>
        public delegate void ErrorHandler(int errorCode, [MarshalAs(UnmanagedType.LPStr)] string description);

        /// <summary>
        /// Initializes the GLFW library.
        /// <para>This function initializes the GLFW library.
        /// Before most GLFW functions can be used, GLFW must be initialized,
        /// and before an application terminates GLFW should be terminated
        /// in order to free any resources allocated during or after initialization.</para>
        /// <para>If this function fails, it calls <see cref="glfwTerminate"/> before returning.
        /// If it succeeds, you should call <see cref="glfwTerminate"/> before the application exits.</para>
        /// <para>Additional calls to this function after successful initialization
        /// but before termination will return <see cref="True"/> immediately.</para>
        /// <para>Possible errors include <see cref="PlatformError"/>.</para>
        /// </summary>
        /// <returns><see cref="True"/> if successful, or <see cref="False"/> if an error occurred.</returns>
        /// <remarks>OS X: This function will change the current directory of the application
        /// to the <c>Contents/Resources</c> subdirectory of the application's bundle, if present.
        /// This can be disabled with a compile-time option.</remarks>
        /// <see cref="glfwTerminate"/>
        [DllImport(DllName)]
        public static extern int glfwInit();

        /// <summary>
        /// Terminates the GLFW library.
        /// <para>This function destroys all remaining windows and cursors,
        /// restores any modified gamma ramps and frees any other allocated resources.
        /// Once this function is called, you must again call <see cref="glfwInit"/> successfully
        /// before you will be able to use most GLFW functions.</para>
        /// <para>If GLFW has been successfully initialized,
        /// this function should be called before the application exits.
        /// If initialization fails, there is no need to call this function,
        /// as it is called by <see cref="glfwInit"/> before it returns failure.</para>
        /// <para>Possible errors include <see cref="PlatformError"/>.</para>
        /// </summary>
        /// <remarks>This function may be called before <see cref="glfwInit"/>.
        /// <para>Warning: The contexts of any remaining windows
        /// must not be current on any other thread when this function is called.</para>
        /// <para>This function must not be called from a callback.</para></remarks>
        /// <seealso cref="glfwInit"/>
        [DllImport(DllName)]
        public static extern void glfwTerminate();

        /// <summary>
        /// Retrieves the version of the GLFW library.
        /// <para>This function retrieves the major, minor and revision numbers of the GLFW library.
        /// It is intended for when you are using GLFW as a shared library
        /// and want to ensure that you are using the minimum required version.</para>
        /// </summary>
        /// <param name="major">Where to store the major version number.</param>
        /// <param name="minor">Where to store the minor version number.</param>
        /// <param name="rev">Where to store the revision number.</param>
        /// <remarks>This function may be called before <see cref="glfwInit"/>.</remarks>
        /// <seealso cref="glfwGetVersionString"/>
        [DllImport(DllName)]
        public static extern void glfwGetVersion(out int major, out int minor, out int rev);

        /// <summary>
        /// Returns a string describing the compile-time configuration.
        /// <para>This function returns the compile-time generated version string of the GLFW library binary.
        /// It describes the version, platform, compiler and any platform-specific compile-time options.
        /// It should not be confused with the OpenGL or OpenGL ES version string,
        /// queried with <c>glGetString</c>.</para>
        /// </summary>
        /// <returns>The ASCII encoded GLFW version string.</returns>
        /// <remarks>This function may be called before <see cref="glfwInit"/>.</remarks>
        /// <seealso cref="glfwGetVersion"/>
        [DllImport(DllName)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        public static extern string glfwGetVersionString();

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
        /// <remarks>This function may be called before <see cref="glfwInit"/>.</remarks>
        [DllImport(DllName)]
        [return: MarshalAs(UnmanagedType.FunctionPtr)]
        public static extern ErrorHandler glfwSetErrorCallback([MarshalAs(UnmanagedType.FunctionPtr)] ErrorHandler callback);
    }
}