using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Glfw3
{
    public static partial class Glfw
    {
        /// <summary>
        /// Initializes GLFW.
        /// <para>This function initializes the GLFW library.
        /// Before most GLFW functions can be used, GLFW must be initialized,
        /// and before an application terminates GLFW should be terminated
        /// in order to free any resources allocated during or after initialization.</para>
        /// <para>If this function fails, it calls <see cref="Terminate"/> before returning.
        /// If it succeeds, you should call <see cref="Terminate"/> before the application exits.</para>
        /// <para>Additional calls to this function after successful initialization
        /// but before termination will return <c>true</c> immediately.</para>
        /// </summary>
        /// <exception cref="PlatformErrorGlfwException">GLFW encounted a problem
        /// initializing on this platform.</exception>
        /// <remarks>If initialization fails, there's no need to call <see cref="Terminate"/>.</remarks>
        /// <seealso cref="Terminate"/>
        public static void Initialize()
        {
            InitializeErrorHandler();
            if (Internal.Init() == Internal.False)
                HandleError();
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
        /// <exception cref="PlatformErrorGlfwException">GLFW encounted a problem
        /// terminating on this platform.</exception>
        /// <remarks>This function may be called before <see cref="Initialize"/>.
        /// <para>Warning: The contexts of any remaining windows
        /// must not be current on any other thread when this function is called.</para>
        /// <para>This function must not be called from a callback.</para></remarks>
        /// <seealso cref="Initialize"/>
        public static void Terminate()
        {
            Internal.Terminate();
            HandleError();
            RemoveErrorHandler();
        }

        /// <summary>
        /// Current running version of GLFW.
        /// </summary>
        public static Version Version
        {
            get
            {
                Internal.GetVersion(out var major, out var minor, out var rev);
                return new Version(major, minor, rev);
            }
        }

        /// <summary>
        /// Current running version of GLFW formatted as a string.
        /// </summary>
        public static string VersionString => Internal.GetVersionString().FromNativeUtf8();
        
        // ReSharper disable MemberHidesStaticFromOuterClass
        private static partial class Internal
        {
            /// <summary>
            /// Initializes the GLFW library.
            /// <para>This function initializes the GLFW library.
            /// Before most GLFW functions can be used, GLFW must be initialized,
            /// and before an application terminates GLFW should be terminated
            /// in order to free any resources allocated during or after initialization.</para>
            /// <para>If this function fails, it calls <see cref="Terminate"/> before returning.
            /// If it succeeds, you should call <see cref="Terminate"/> before the application exits.</para>
            /// <para>Additional calls to this function after successful initialization
            /// but before termination will return <see cref="True"/> immediately.</para>
            /// <para>Possible errors include <see cref="ErrorCode.PlatformError"/>.</para>
            /// </summary>
            /// <returns><see cref="True"/> if successful, or <see cref="False"/> if an error occurred.</returns>
            /// <remarks>OS X: This function will change the current directory of the application
            /// to the <c>Contents/Resources</c> subdirectory of the application's bundle, if present.
            /// This can be disabled with a compile-time option.</remarks>
            /// <see cref="Terminate"/>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwInit", CallingConvention = CallingConvention.Cdecl)]
            public static extern int Init();

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
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwTerminate", CallingConvention = CallingConvention.Cdecl)]
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
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwGetVersion", CallingConvention = CallingConvention.Cdecl)]
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
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwGetVersionString", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr GetVersionString();
        }
    }
}