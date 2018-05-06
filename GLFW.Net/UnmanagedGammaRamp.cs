using System;
using System.Runtime.InteropServices;

namespace GLFW.Net
{
    /// <summary>
    /// Describes the gamma ramp of a monitor.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct UnmanagedGammaRamp
    {
        /// <summary>
        /// Pointer to an array describing the response of the red channel.
        /// </summary>
        public IntPtr Red;

        /// <summary>
        /// Pointer to an array describing the response of the green channel.
        /// </summary>
        public IntPtr Green;

        /// <summary>
        /// Pointer to an array describing the response of the blue channel.
        /// </summary>
        public IntPtr Blue;

        /// <summary>
        /// Number of items in each array.
        /// </summary>
        public uint Size;
    }
}
