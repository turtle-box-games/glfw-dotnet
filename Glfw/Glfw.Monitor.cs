using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Glfw3
{
    // ReSharper disable MemberHidesStaticFromOuterClass
    public static partial class Glfw
    {
        /// <summary>
        /// The function signature for monitor configuration callbacks.
        /// </summary>
        /// <param name="monitor">The monitor that was connected or disconnected.</param>
        /// <param name="event">One of <see cref="DeviceEvent.Connected"/>
        /// or <see cref="DeviceEvent.Disconnected"/></param>
        /// <seealso cref="SetMonitorCallback"/>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void MonitorCallback(IntPtr monitor, DeviceEvent @event);

        /// <summary>
        /// Returns the currently connected monitors.
        /// <para>This function returns an array of handles for all currently connected monitors.
        /// The primary monitor is always first in the returned array.
        /// If no monitors were found, this function returns <c>null</c>.</para>
        /// </summary>
        /// <returns>An array of monitor handles, or an empty array if no monitors were found.</returns>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        /// <seealso cref="GetPrimaryMonitor"/>
        public static IntPtr[] GetMonitors()
        {
            var arrayPointer = Internal.GetMonitors(out var count);
            HandleError();
            if (arrayPointer == IntPtr.Zero)
                return new IntPtr[0];
            var monitors = new IntPtr[count];
            Marshal.Copy(arrayPointer, monitors, 0, count);
            return monitors;
        }

        /// <summary>
        /// Returns the primary monitor.
        /// <para>This function returns the primary monitor.
        /// This is usually the monitor where elements like the task bar or global menu bar are located.</para>
        /// </summary>
        /// <returns>The primary monitor, or <c>null</c> if no monitors were found.</returns>
        /// <remarks>The primary monitor is always first in the array returned by <see cref="GetMonitors"/>.</remarks>
        /// <seealso cref="GetMonitors"/>
        public static IntPtr GetPrimaryMonitor()
        {
            var monitorPointer = Internal.GetPrimaryMonitor();
            HandleError();
            return monitorPointer;
        }

        /// <summary>
        /// Returns the position of the monitor's viewport on the virtual screen.
        /// <para>This function returns the position, in screen coordinates,
        /// of the upper-left corner of the specified monitor.</para>
        /// </summary>
        /// <param name="monitor">The monitor to query.</param>
        /// <param name="xpos">Where to store the monitor x-coordinate.</param>
        /// <param name="ypos">Where to store the monitor y-coordinate.</param>
        /// <exception cref="PlatformErrorGlfwException">This operation is not supported on this platform.</exception>
        public static void GetMonitorPos(IntPtr monitor, out int xpos, out int ypos)
        {
            Internal.GetMonitorPos(monitor, out xpos, out ypos);
            HandleError();
        }

        /// <summary>
        /// Returns the physical size of the monitor.
        /// <para>This function returns the size, in millimetres, of the display area of the specified monitor.</para>
        /// <para>Some systems do not provide accurate monitor size information,
        /// either because the monitor EDID data is incorrect
        /// or because the driver does not report it accurately.</para>
        /// </summary>
        /// <param name="monitor">The monitor to query.</param>
        /// <param name="widthMm">Where to store the width, in millimetres, of the monitor's display area.</param>
        /// <param name="heightMm">	Where to store the height, in millimetres, of the monitor's display area.</param>
        /// <remarks><para>Windows: calculates the returned physical size from the current resolution and system DPI
        /// instead of querying the monitor EDID data.</para></remarks>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        public static void GetMonitorPhysicalSize(IntPtr monitor, out int widthMm, out int heightMm)
        {
            Internal.GetMonitorPhysicalSize(monitor, out widthMm, out heightMm);
            HandleError();
        }

        /// <summary>
        /// Returns the name of the specified monitor.
        /// <para>This function returns a human-readable name, encoded as UTF-8, of the specified monitor.
        /// The name typically reflects the make and model of the monitor
        /// and is not guaranteed to be unique among the connected monitors.</para>
        /// </summary>
        /// <param name="monitor">The monitor to query.</param>
        /// <returns>The UTF-8 encoded name of the monitor.</returns>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        public static string GetMonitorName(IntPtr monitor)
        {
            var namePointer = Internal.GetMonitorName(monitor);
            HandleError();
            return namePointer.FromNativeUtf8();
        }

        /// <summary>
        /// Sets the monitor configuration callback.
        /// <para>This function sets the monitor configuration callback, or removes the currently set callback.
        /// This is called when a monitor is connected to or disconnected from the system.</para>
        /// </summary>
        /// <param name="callback">The new callback, or <c>null</c> to remove the currently set callback.</param>
        /// <returns>The previously set callback,
        /// or <c>null</c> if no callback was set or the library had not been initialized.</returns>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        public static MonitorCallback SetMonitorCallback(MonitorCallback callback)
        {
            return SetInternalCallback(Internal.SetMonitorCallback, callback);
        }

        /// <summary>
        /// Returns the available video modes for the specified monitor.
        /// <para>This function returns an array of all video modes supported by the specified monitor.
        /// The returned array is sorted in ascending order,
        /// first by color bit depth (the sum of all channel depths)
        /// and then by resolution area (the product of width and height).</para>
        /// </summary>
        /// <param name="monitor">The monitor to query.</param>
        /// <returns>An array of video modes.</returns>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        /// <exception cref="PlatformErrorGlfwException">This operation is not supported on this platform.</exception>
        /// <seealso cref="GetVideoMode"/>
        public static VideoMode[] GetVideoModes(IntPtr monitor)
        {
            var modesPointer = Internal.GetVideoModes(monitor, out var count);
            HandleError();
            return modesPointer.PtrToStructureArray<VideoMode>(count, VideoMode.StructSize);
        }

        /// <summary>
        /// Returns the current mode of the specified monitor.
        /// <para>This function returns the current video mode of the specified monitor.
        /// If you have created a full screen window for that monitor,
        /// the return value will depend on whether that window is iconified.</para>
        /// </summary>
        /// <param name="monitor">The monitor to query.</param>
        /// <returns>The current mode of the monitor.</returns>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        /// <exception cref="PlatformErrorGlfwException">This operation is not supported on this platform.</exception>
        /// <seealso cref="GetVideoModes"/>
        public static VideoMode GetVideoMode(IntPtr monitor)
        {
            var modePointer = Internal.GetVideoMode(monitor);
            HandleError();
            return Marshal.PtrToStructure<VideoMode>(modePointer);
        }

        /// <summary>
        /// Generates a gamma ramp and sets it for the specified monitor.
        /// <para>This function generates a 256-element gamma ramp
        /// from the specified exponent and then calls <see cref="SetGammaRamp"/> with it.
        /// The value must be a finite number greater than zero.</para>
        /// </summary>
        /// <param name="monitor">The monitor whose gamma ramp to set.</param>
        /// <param name="gamma">The desired exponent.</param>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        /// <exception cref="PlatformErrorGlfwException">This operation is not supported on this platform.</exception>
        /// <exception cref="InvalidValueGlfwException">The <paramref name="gamma"/> value is invalid.</exception>
        public static void SetGamma(IntPtr monitor, float gamma)
        {
            Internal.SetGamma(monitor, gamma);
            HandleError();
        }

        /// <summary>
        /// Returns the current gamma ramp for the specified monitor.
        /// </summary>
        /// <param name="monitor">The monitor to query.</param>
        /// <returns>The current gamma ramp.</returns>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        /// <exception cref="PlatformErrorGlfwException">This operation is not supported on this platform.</exception>
        public static GammaRamp GetGammaRamp(IntPtr monitor)
        {
            var rampPointer = Internal.GetGammaRamp(monitor);
            HandleError();
            if (rampPointer == IntPtr.Zero)
                return null;
            var ramp = Marshal.PtrToStructure<UnmanagedGammaRamp>(rampPointer);
            return ramp.ToManaged();
        }

        /// <summary>
        /// Sets the current gamma ramp for the specified monitor.
        /// <para>This function sets the current gamma ramp for the specified monitor.
        /// The original gamma ramp for that monitor is saved by GLFW the first time this function is called
        /// and is restored by <see cref="Terminate"/>.</para>
        /// </summary>
        /// <param name="monitor">The monitor whose gamma ramp to set.</param>
        /// <param name="ramp">The gamma ramp to use.</param>
        /// <remarks><para>Gamma ramp sizes other than 256
        /// are not supported by all platforms or graphics hardware.</para>
        /// <para>Windows: The gamma ramp size must be 256.</para></remarks>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        /// <exception cref="PlatformErrorGlfwException">This operation is not supported on this platform.</exception>
        public static void SetGammaRamp(IntPtr monitor, GammaRamp ramp)
        {
            // Check if there was a previous ramp and free it.
            var prevRampPointer = Internal.GetGammaRamp(monitor);
            HandleError();
            if (prevRampPointer != IntPtr.Zero)
            {
                var prevRamp = Marshal.PtrToStructure<UnmanagedGammaRamp>(prevRampPointer);
                prevRamp.Free();
                Marshal.FreeHGlobal(prevRampPointer);
            }

            var rampPointer = IntPtr.Zero;
            try
            {
                var unmanagedRamp = UnmanagedGammaRamp.FromManaged(ramp);
                rampPointer       = Marshal.AllocHGlobal(UnmanagedGammaRamp.MarshalSize);
                Marshal.StructureToPtr(unmanagedRamp, rampPointer, false);
                Internal.SetGammaRamp(monitor, rampPointer);
                HandleError();
            }
            catch (Exception)
            {
                Marshal.FreeHGlobal(rampPointer);
                throw;
            }
        }
        
        private static partial class Internal
        {
            /// <summary>
            /// Returns the currently connected monitors.
            /// <para>This function returns an array of handles for all currently connected monitors.
            /// The primary monitor is always first in the returned array.
            /// If no monitors were found, this function returns <see cref="IntPtr.Zero"/>.</para>
            /// </summary>
            /// <param name="count">Where to store the number of monitors in the returned array.
            /// This is set to zero if an error occurred.</param>
            /// <returns>An array of monitor handles, 
            /// or <see cref="IntPtr.Zero"/> if no monitors were found or if an error occurred.</returns>
            /// <seealso cref="GetPrimaryMonitor"/>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwGetMonitors", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr GetMonitors(out int count);

            /// <summary>
            /// Returns the primary monitor.
            /// <para>This function returns the primary monitor.
            /// This is usually the monitor where elements like the task bar or global menu bar are located.</para>
            /// </summary>
            /// <returns>The primary monitor,
            /// or <see cref="IntPtr.Zero"/> if no monitors were found or if an error occurred.</returns>
            /// <remarks><para>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</para>
            /// <para>The primary monitor is always first in the array
            /// returned by <see cref="GetMonitors"/>.</para></remarks>
            /// <seealso cref="GetMonitors"/>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwGetPrimaryMonitor", CallingConvention = CallingConvention.Cdecl)]
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
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwGetMonitorPos", CallingConvention = CallingConvention.Cdecl)]
            public static extern void GetMonitorPos(IntPtr monitor, out int xpos, out int ypos);

            /// <summary>
            /// Returns the physical size of the monitor.
            /// <para>This function returns the size, in millimetres, of the display area of the specified monitor.</para>
            /// <para>Some systems do not provide accurate monitor size information,
            /// either because the monitor EDID data is incorrect
            /// or because the driver does not report it accurately.</para>
            /// </summary>
            /// <param name="monitor">The monitor to query.</param>
            /// <param name="widthMm">Where to store the width, in millimetres, of the monitor's display area.</param>
            /// <param name="heightMm">	Where to store the height, in millimetres, of the monitor's display area.</param>
            /// <remarks><para>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</para>
            /// <para>Windows: calculates the returned physical size from the current resolution and system DPI
            /// instead of querying the monitor EDID data.</para></remarks>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwGetMonitorPhysicalSize", CallingConvention = CallingConvention.Cdecl)]
            public static extern void GetMonitorPhysicalSize(IntPtr monitor, out int widthMm, out int heightMm);

            /// <summary>
            /// Returns the name of the specified monitor.
            /// <para>This function returns a human-readable name, encoded as UTF-8, of the specified monitor.
            /// The name typically reflects the make and model of the monitor
            /// and is not guaranteed to be unique among the connected monitors.</para>
            /// </summary>
            /// <param name="monitor">The monitor to query.</param>
            /// <returns>The UTF-8 encoded name of the monitor, or <c>null</c> if an error occurred.</returns>
            /// <remarks>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</remarks>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwGetMonitorName", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr GetMonitorName(IntPtr monitor);

            /// <summary>
            /// Sets the monitor configuration callback.
            /// <para>This function sets the monitor configuration callback, or removes the currently set callback.
            /// This is called when a monitor is connected to or disconnected from the system.</para>
            /// </summary>
            /// <param name="cbfun">The new callback,
            /// or <see cref="IntPtr.Zero"/> to remove the currently set callback.</param>
            /// <returns>The previously set callback,
            /// or <see cref="IntPtr.Zero"/> if no callback was set or the library had not been initialized.</returns>
            /// <remarks>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</remarks>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwSetMonitorCallback", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr SetMonitorCallback(IntPtr cbfun);

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
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwGetVideoModes", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr GetVideoModes(IntPtr monitor, out int count);

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
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwGetVideoMode", CallingConvention = CallingConvention.Cdecl)]
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
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwSetGamma", CallingConvention = CallingConvention.Cdecl)]
            public static extern void SetGamma(IntPtr monitor, float gamma);

            /// <summary>
            /// Returns the current gamma ramp for the specified monitor.
            /// </summary>
            /// <param name="monitor">The monitor to query.</param>
            /// <returns>The current gamma ramp, or <c>null</c> if an error occurred.</returns>
            /// <remarks>Possible errors include
            /// <see cref="ErrorCode.NotInitialized"/> and <see cref="ErrorCode.PlatformError"/>.</remarks>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwGetGammaRamp", CallingConvention = CallingConvention.Cdecl)]
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
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwSetGammaRamp", CallingConvention = CallingConvention.Cdecl)]
            public static extern void SetGammaRamp(IntPtr monitor, IntPtr ramp);
        }
    }
}