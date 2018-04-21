using System;
using System.Runtime.InteropServices;

namespace GLFW.Net
{
    internal static partial class GLFW
    {
        /// <summary>
        /// The function signature for monitor configuration callbacks.
        /// </summary>
        /// <param name="monitor">The monitor that was connected or disconnected.</param>
        /// <param name="event">One of <see cref="DeviceEvent.Connected"/>
        /// or <see cref="DeviceEvent.Disconnected"/></param>
        /// <seealso cref="SetMonitorCallback"/>
        public delegate void MonitorCallback(IntPtr monitor, int @event);

        /// <summary>
        /// Returns the currently connected monitors.
        /// <para>This function returns an array of handles for all currently connected monitors.
        /// The primary monitor is always first in the returned array.
        /// If no monitors were found, this function returns <c>null</c>.</para>
        /// </summary>
        /// <param name="count">Where to store the number of monitors in the returned array.
        /// This is set to zero if an error occurred.</param>
        /// <returns>An array of monitor handles,
        /// or <c>null</c> if no monitors were found or if an error occurred.</returns>
        /// <remarks>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</remarks>
        /// <seealso cref="GetPrimaryMonitor"/>
        [DllImport(DllName, EntryPoint = "glfwGetMonitors")]
        [return: MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStruct, SizeParamIndex = 0)]
        public static extern IntPtr[] GetMonitors(out int count);

        /// <summary>
        /// Returns the primary monitor.
        /// <para>This function returns the primary monitor.
        /// This is usually the monitor where elements like the task bar or global menu bar are located.</para>
        /// </summary>
        /// <returns>The primary monitor, or <c>null</c> if no monitors were found or if an error occurred.</returns>
        /// <remarks><para>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</para>
        /// <para>The primary monitor is always first in the array
        /// returned by <see cref="GetMonitors"/>.</para></remarks>
        /// <seealso cref="GetMonitors"/>
        [DllImport(DllName, EntryPoint = "glfwGetPrimaryMonitor")]
        public static extern IntPtr GetPrimaryMonitor();

        /// <summary>
        /// Returns the position of the monitor's viewport on the virtual screen.
        /// <para>This function returns the position, in screen coordinates,
        /// of the upper-left corner of the specified monitor.</para>
        /// </summary>
        /// <param name="monitor">The monitor to query.</param>
        /// <param name="xpos">Where to store the monitor x-coordinate.</param>
        /// <param name="ypos">Where to store the monitor y-coordinate.</param>
        /// <remarks>Possible errors include
        /// <see cref="ErrorCode.NotInitialized"/> and <see cref="ErrorCode.PlatformError"/>.</remarks>
        [DllImport(DllName, EntryPoint = "glfwGetMonitorPos")]
        public static extern void GetMonitorPos(IntPtr monitor, out int xpos, out int ypos);

        /// <summary>
        /// Returns the physical size of the monitor.
        /// <para>This function returns the size, in millimetres, of the display area of the specified monitor.</para>
        /// <para>Some systems do not provide accurate monitor size information,
        /// either because the monitor EDID data is incorrect
        /// or because the driver does not report it accurately.</para>
        /// </summary>
        /// <param name="monitor">The monitor to query.</param>
        /// <param name="widthMM">Where to store the width, in millimetres, of the monitor's display area.</param>
        /// <param name="heightMM">	Where to store the height, in millimetres, of the monitor's display area.</param>
        /// <remarks><para>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</para>
        /// <para>Windows: calculates the returned physical size from the current resolution and system DPI
        /// instead of querying the monitor EDID data.</para></remarks>
        [DllImport(DllName, EntryPoint = "glfwGetMonitorPhysicalSize")]
        public static extern void GetMonitorPhysicalSize(IntPtr monitor, out int widthMM, out int heightMM);

        /// <summary>
        /// Returns the name of the specified monitor.
        /// <para>This function returns a human-readable name, encoded as UTF-8, of the specified monitor.
        /// The name typically reflects the make and model of the monitor
        /// and is not guaranteed to be unique among the connected monitors.</para>
        /// </summary>
        /// <param name="monitor">The monitor to query.</param>
        /// <returns>The UTF-8 encoded name of the monitor, or <c>null</c> if an error occurred.</returns>
        /// <remarks>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</remarks>
        [DllImport(DllName, EntryPoint = "glfwGetMonitorName")]
        [return: MarshalAs(UnmanagedType.LPStr)]
        public static extern string GetMonitorName(IntPtr monitor);

        /// <summary>
        /// Sets the monitor configuration callback.
        /// <para>This function sets the monitor configuration callback, or removes the currently set callback.
        /// This is called when a monitor is connected to or disconnected from the system.</para>
        /// </summary>
        /// <param name="cbfun">The new callback, or <c>null</c> to remove the currently set callback.</param>
        /// <returns>The previously set callback,
        /// or <c>null</c> if no callback was set or the library had not been initialized.</returns>
        /// <remarks>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</remarks>
        [DllImport(DllName, EntryPoint = "glfwSetMonitorCallback")]
        [return: MarshalAs(UnmanagedType.FunctionPtr)]
        public static extern MonitorCallback SetMonitorCallback(
            [MarshalAs(UnmanagedType.FunctionPtr)] MonitorCallback cbfun);

        /// <summary>
        /// Returns the available video modes for the specified monitor.
        /// <para>This function returns an array of all video modes supported by the specified monitor.
        /// The returned array is sorted in ascending order,
        /// first by color bit depth (the sum of all channel depths)
        /// and then by resolution area (the product of width and height).</para>
        /// </summary>
        /// <param name="monitor">The monitor to query.</param>
        /// <param name="count">Where to store the number of video modes in the returned array.
        /// This is set to zero if an error occurred.</param>
        /// <returns>An array of video modes, or <c>null</c> if an error occurred.</returns>
        /// <remarks>Possible errors include
        /// <see cref="ErrorCode.NotInitialized"/> and <see cref="ErrorCode.PlatformError"/>.</remarks>
        /// <seealso cref="GetVideoMode"/>
        [DllImport(DllName, EntryPoint = "glfwGetVideoModes")]
        [return: MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStruct, SizeParamIndex = 1)]
        public static extern IntPtr[] GetVideoModes(IntPtr monitor, out int count);

        /// <summary>
        /// Returns the current mode of the specified monitor.
        /// <para>This function returns the current video mode of the specified monitor.
        /// If you have created a full screen window for that monitor,
        /// the return value will depend on whether that window is iconified.</para>
        /// </summary>
        /// <param name="monitor">The monitor to query.</param>
        /// <returns>The current mode of the monitor, or <c>null</c> if an error occurred.</returns>
        /// <remarks>Possible errors include
        /// <see cref="ErrorCode.NotInitialized"/> and <see cref="ErrorCode.PlatformError"/>.</remarks>
        /// <seealso cref="GetVideoModes"/>
        [DllImport(DllName, EntryPoint = "glfwGetVideoMode")]
        public static extern IntPtr GetVideoMode(IntPtr monitor);

        /// <summary>
        /// Generates a gamma ramp and sets it for the specified monitor.
        /// <para>This function generates a 256-element gamma ramp
        /// from the specified exponent and then calls <see cref="SetGammaRamp"/> with it.
        /// The value must be a finite number greater than zero.</para>
        /// </summary>
        /// <param name="monitor">The monitor whose gamma ramp to set.</param>
        /// <param name="gamma">The desired exponent.</param>
        /// <remarks>Possible errors include
        /// <see cref="ErrorCode.NotInitialized"/>, <see cref="ErrorCode.InvalidValue"/>,
        /// and <see cref="ErrorCode.PlatformError"/>.</remarks>
        [DllImport(DllName, EntryPoint = "glfwSetGamma")]
        public static extern void SetGamma(IntPtr monitor, float gamma);

        /// <summary>
        /// Returns the current gamma ramp for the specified monitor.
        /// </summary>
        /// <param name="monitor">The monitor to query.</param>
        /// <returns>The current gamma ramp, or <c>null</c> if an error occurred.</returns>
        /// <remarks>Possible errors include
        /// <see cref="ErrorCode.NotInitialized"/> and <see cref="ErrorCode.PlatformError"/>.</remarks>
        [DllImport(DllName, EntryPoint = "glfwGetGammaRamp")]
        public static extern IntPtr GetGammaRamp(IntPtr monitor);

        /// <summary>
        /// Sets the current gamma ramp for the specified monitor.
        /// <para>This function sets the current gamma ramp for the specified monitor.
        /// The original gamma ramp for that monitor is saved by GLFW the first time this function is called
        /// and is restored by <see cref="Terminate"/>.</para>
        /// </summary>
        /// <param name="monitor">The monitor whose gamma ramp to set.</param>
        /// <param name="ramp">The gamma ramp to use.</param>
        /// <remarks><para>Possible errors include
        /// <see cref="ErrorCode.NotInitialized"/> and <see cref="ErrorCode.PlatformError"/>.</para>
        /// <para>Gamma ramp sizes other than 256 are not supported by all platforms or graphics hardware.</para>
        /// <para>Windows: The gamma ramp size must be 256.</para></remarks>
        [DllImport(DllName, EntryPoint = "glfwSetGammaRamp")]
        public static extern void SetGammaRamp(IntPtr monitor, IntPtr ramp);
    }
}