using System;
using System.Runtime.InteropServices;

namespace GLFW.Net
{
    public static partial class GLFW
    {
        private static partial class Internal
        {
            /// <summary>
            /// Initializes the GLFW library.
            /// <para>This function initializes the GLFW library.
            /// Before most GLFW functions can be used, GLFW must be initialized,
            /// and before an application terminates GLFW should be terminated
            /// in order to free any resources allocated during or after initialization.</para>
            /// <para>If this function fails, it calls <see cref="NativeTerminate"/> before returning.
            /// If it succeeds, you should call <see cref="NativeTerminate"/> before the application exits.</para>
            /// <para>Additional calls to this function after successful initialization
            /// but before termination will return <see cref="True"/> immediately.</para>
            /// <para>Possible errors include <see cref="ErrorCode.PlatformError"/>.</para>
            /// </summary>
            /// <returns><c>true</c> if successful, or <c>false</c> if an error occurred.</returns>
            /// <remarks>OS X: This function will change the current directory of the application
            /// to the <c>Contents/Resources</c> subdirectory of the application's bundle, if present.
            /// This can be disabled with a compile-time option.</remarks>
            /// <see cref="NativeTerminate"/>
            [DllImport(DllName, EntryPoint = "glfwInit")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool Init();

            /// <summary>
            /// Terminates the GLFW library.
            /// <para>This function destroys all remaining windows and cursors,
            /// restores any modified gamma ramps and frees any other allocated resources.
            /// Once this function is called, you must again call <see cref="Init"/> successfully
            /// before you will be able to use most GLFW functions.</para>
            /// <para>If GLFW has been successfully initialized,
            /// this function should be called before the application exits.
            /// If initialization fails, there is no need to call this function,
            /// as it is called by <see cref="Init"/> before it returns failure.</para>
            /// <para>Possible errors include <see cref="ErrorCode.PlatformError"/>.</para>
            /// </summary>
            /// <remarks>This function may be called before <see cref="Init"/>.
            /// <para>Warning: The contexts of any remaining windows
            /// must not be current on any other thread when this function is called.</para>
            /// <para>This function must not be called from a callback.</para></remarks>
            /// <seealso cref="Init"/>
            [DllImport(DllName, EntryPoint = "glfwTerminate")]
            public static extern void Terminate();

            /// <summary>
            /// Retrieves the version of the GLFW library.
            /// <para>This function retrieves the major, minor and revision numbers of the GLFW library.
            /// It is intended for when you are using GLFW as a shared library
            /// and want to ensure that you are using the minimum required version.</para>
            /// </summary>
            /// <param name="major">Where to store the major version number.</param>
            /// <param name="minor">Where to store the minor version number.</param>
            /// <param name="rev">Where to store the revision number.</param>
            /// <remarks>This function may be called before <see cref="Init"/>.</remarks>
            /// <seealso cref="GetVersionString"/>
            [DllImport(DllName, EntryPoint = "glfwGetVersion")]
            public static extern void GetVersion(out int major, out int minor, out int rev);

            /// <summary>
            /// Returns a string describing the compile-time configuration.
            /// <para>This function returns the compile-time generated version string of the GLFW library binary.
            /// It describes the version, platform, compiler and any platform-specific compile-time options.
            /// It should not be confused with the OpenGL or OpenGL ES version string,
            /// queried with <c>glGetString</c>.</para>
            /// </summary>
            /// <returns>The ASCII encoded GLFW version string.</returns>
            /// <remarks>This function may be called before <see cref="Init"/>.</remarks>
            /// <seealso cref="GetVersion"/>
            [DllImport(DllName, EntryPoint = "glfwGetVersionString")]
            public static extern IntPtr GetVersionString();
        }
    }
}