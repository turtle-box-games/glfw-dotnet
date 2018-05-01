﻿using System;

namespace GLFW.Net
{
    public static partial class GLFW
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
        /// but before termination will return <see cref="True"/> immediately.</para>
        /// </summary>
        /// <returns><c>true</c> if the initialization finished successfully, <c>false</c> otherwise.</returns>
        /// <exception cref="PlatformErrorGLFWException">GLFW encounted a problem
        /// initializing on this platform.</exception>
        /// <remarks>If initialization fails, there's no need to call <see cref="Terminate"/>.</remarks>
        /// <seealso cref="Terminate"/>
        public static bool Initialize()
        {
            return CheckedCall(Internal.Init);
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
            CheckedCall(Internal.Terminate);
        }

        /// <summary>
        /// Current running version of GLFW.
        /// </summary>
        public static Version Version
        {
            get
            {
                int major, minor, rev;
                Internal.GetVersion(out major, out minor, out rev);
                return new Version(major, minor, rev);
            }
        }

        /// <summary>
        /// Current running version of GLFW formatted as a string.
        /// </summary>
        public static string VersionString => Internal.GetVersionString().FromNativeUtf8();
    }
}