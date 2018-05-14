using System.Runtime.InteropServices;

namespace Glfw3
{
    /// <summary>
    /// Describes a single video mode.
    /// </summary>
    /// <seealso cref="Glfw.GetVideoMode"/>
    /// <seealso cref="Glfw.GetVideoModes"/>
    [StructLayout(LayoutKind.Sequential)]
    public struct VideoMode
    {
        /// <summary>
        /// Size of the structure in bytes.
        /// Used in marshalling data from unmanaged context.
        /// </summary>
        internal const int StructSize = sizeof(int) * 6;
        
        /// <summary>
        /// The width, in screen coordinates.
        /// </summary>
        public readonly int Width;

        /// <summary>
        /// The height, in screen coordinates.
        /// </summary>
        public readonly int Height;

        /// <summary>
        /// The bit depth of the red channel.
        /// </summary>
        public readonly int RedBits;

        /// <summary>
        /// The bit depth of the green channel.
        /// </summary>
        public readonly int GreenBits;

        /// <summary>
        /// The bit depth of the blue channel.
        /// </summary>
        public readonly int BlueBits;

        /// <summary>
        /// The refresh rate, in Hz.
        /// </summary>
        public readonly int RefreshRate;

        /// <summary>
        /// Creates a string representation of the video mode.
        /// </summary>
        /// <returns>Video mode information in the format:
        /// <c>W x H @ R Hz (R#G#B#)</c>.</returns>
        public override string ToString()
        {
            return string.Format("{0} x {1} @ {5} Hz (R{2}G{3}B{4})", Width, Height, RedBits, GreenBits, BlueBits,
                RefreshRate);
        }
    }
}