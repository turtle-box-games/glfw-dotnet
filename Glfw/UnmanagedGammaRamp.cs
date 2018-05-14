using System;
using System.Runtime.InteropServices;

namespace Glfw3
{
    /// <summary>
    /// Describes the gamma ramp of a monitor.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct UnmanagedGammaRamp
    {
        /// <summary>
        /// Number of bytes this structure takes up in memory.
        /// </summary>
        internal static readonly int MarshalSize = IntPtr.Size * 3 + sizeof(uint);
        
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

        /// <summary>
        /// Creates a managed gamma ramp instance.
        /// </summary>
        /// <returns>Gamma ramp.</returns>
        public GammaRamp ToManaged()
        {
            var red   = new ushort[Size];
            var green = new ushort[Size];
            var blue  = new ushort[Size];
            
            // ReSharper disable PossibleInvalidCastException
            Marshal.Copy(Red,   (short[]) (object) red,   0, red.Length);
            Marshal.Copy(Green, (short[]) (object) green, 0, green.Length);
            Marshal.Copy(Blue,  (short[]) (object) blue,  0, blue.Length);
            
            return new GammaRamp(red, green, blue);
        }

        /// <summary>
        /// Copied managed gamma ramp data into the structure.
        /// </summary>
        /// <param name="gammaRamp">Managed gamma ramp to pull data from.</param>
        /// <returns>Instance containing unmanaged gamma ramp data.</returns>
        public static UnmanagedGammaRamp FromManaged(GammaRamp gammaRamp)
        {
            var unmanagedGammaRamp = new UnmanagedGammaRamp();
            try
            {
                // TODO: Make one allocation.
                unmanagedGammaRamp.Red   = Marshal.AllocHGlobal(gammaRamp.Size * sizeof(ushort));
                unmanagedGammaRamp.Green = Marshal.AllocHGlobal(gammaRamp.Size * sizeof(ushort));
                unmanagedGammaRamp.Blue  = Marshal.AllocHGlobal(gammaRamp.Size * sizeof(ushort));
                unmanagedGammaRamp.Size  = (uint) gammaRamp.Size;
                Marshal.Copy((short[]) (object) gammaRamp.Red,   0, unmanagedGammaRamp.Red,   gammaRamp.Size);
                Marshal.Copy((short[]) (object) gammaRamp.Green, 0, unmanagedGammaRamp.Green, gammaRamp.Size);
                Marshal.Copy((short[]) (object) gammaRamp.Blue,  0, unmanagedGammaRamp.Blue,  gammaRamp.Size);
            }
            catch (Exception)
            {
                unmanagedGammaRamp.Free();
                throw;
            }

            return unmanagedGammaRamp;
        }

        /// <summary>
        /// Releases unmanaged memory held by the instance.
        /// </summary>
        public void Free()
        {
            if (Red != IntPtr.Zero)
                Marshal.FreeHGlobal(Red);
            if (Green != IntPtr.Zero)
                Marshal.FreeHGlobal(Green);
            if (Blue != IntPtr.Zero)
                Marshal.FreeHGlobal(Blue);
        }
    }
}
