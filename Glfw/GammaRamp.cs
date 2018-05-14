using System;

namespace Glfw3
{
    /// <summary>
    /// Describes the responsiveness of color channels on a monitor.
    /// </summary>
    public class GammaRamp
    {
        /// <summary>
        /// Creates a new gamma ramp.
        /// </summary>
        /// <param name="red">Responsiveness of the red channel.</param>
        /// <param name="green">Responsiveness of the green channel.</param>
        /// <param name="blue">Responsiveness of the blue channel.</param>
        /// <exception cref="ArgumentNullException">Array of channel responses can't be null.</exception>
        /// <exception cref="ArgumentException">The channel response arrays must have matching lengths.</exception>
        public GammaRamp(ushort[] red, ushort[] green, ushort[] blue)
        {
            if(red == null)
                throw new ArgumentNullException(nameof(red), "Array of channel responses can't be null.");
            if(green == null)
                throw new ArgumentNullException(nameof(green), "Array of channel responses can't be null.");
            if(blue == null)
                throw new ArgumentNullException(nameof(blue), "Array of channel responses can't be null.");
            if(red.Length != green.Length || green.Length != blue.Length)
                throw new ArgumentException("The channel response arrays must have matching lengths.");
            
            Red   = red;
            Green = green;
            Blue  = blue;
        }

        /// <summary>
        /// Responsiveness of the red channel.
        /// </summary>
        public ushort[] Red { get; }

        /// <summary>
        /// Responsiveness of the green channel.
        /// </summary>
        public ushort[] Green { get; }

        /// <summary>
        /// Responsiveness of the blue channel.
        /// </summary>
        public ushort[] Blue { get; }

        /// <summary>
        /// Number of elements in each channel array.
        /// </summary>
        public int Size => Red.Length;
    }
}
