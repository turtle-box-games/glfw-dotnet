﻿using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Glfw3
{
    public static partial class Glfw
    {
        /// <summary>
        /// The function signature for joystick configuration callbacks.
        /// </summary>
        /// <param name="joy">The joystick that was connected or disconnected.</param>
        /// <param name="event">One of <see cref="DeviceEvent.Connected"/>
        /// or <see cref="DeviceEvent.Disconnected"/>.</param>
        /// <seealso cref="SetJoystickCallback"/>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void JoystickCallback(int joy, DeviceEvent @event);

        /// <summary>
        /// Returns whether the specified joystick is present.
        /// </summary>
        /// <param name="joy">The joystick to query.</param>
        /// <returns><c>true</c> if the joystick is present, or <c>false</c> otherwise.</returns>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        /// <exception cref="InvalidEnumGlfwException">The <paramref name="joy"/> index
        /// is outside the allowed range.</exception>
        /// <exception cref="PlatformErrorGlfwException">This operation is not supported on this platform.</exception>
        public static bool JoystickPresent(int joy)
        {
            var result = Internal.JoystickPresent(joy);
            HandleError();
            return result != Internal.False;
        }

        /// <summary>
        /// Returns the values of all axes of the specified joystick.
        /// <para>This function returns the values of all axes of the specified joystick.
        /// Each element in the array is a value between -1.0 and 1.0.</para>
        /// <para>Querying a joystick slot with no device present is not an error,
        /// but will cause this function to return <c>null</c>.
        /// Call <see cref="JoystickPresent"/> to check device presence.</para>
        /// </summary>
        /// <param name="joy">The joystick to query.</param>
        /// <returns>An array of axis values, or <c>null</c> if the joystick is not present.</returns>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        /// <exception cref="InvalidEnumGlfwException">The <paramref name="joy"/> index
        /// is outside the allowed range.</exception>
        /// <exception cref="PlatformErrorGlfwException">This operation is not supported on this platform.</exception>
        public static float[] GetJoystickAxes(int joy)
        {
            var axesPointer = Internal.GetJoystickAxes(joy, out var count);
            if (axesPointer == IntPtr.Zero)
            {
                HandleError();
                return null;
            }
            var axes = new float[count];
            Marshal.Copy(axesPointer, axes, 0, count);
            return axes;
        }

        /// <summary>
        /// Retrieves the values of axes of the specified joystick.
        /// <para>This function gets the values of all axes of the specified joystick.
        /// Each element in the array is a value between -1.0 and 1.0.</para>
        /// <para>Querying a joystick slot with no device present is not an error,
        /// but will cause this function to return <c>false</c> and leave <paramref name="axes"/> untouched.
        /// Call <see cref="JoystickPresent"/> to check device presence.</para>
        /// </summary>
        /// <param name="joy">The joystick to query.</param>
        /// <param name="axes">Array to store joystick axes values in.</param>
        /// <returns><c>true</c> if the joystick is present, or <c>false</c> if it isn't.</returns>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        /// <exception cref="InvalidEnumGlfwException">The <paramref name="joy"/> index
        /// is outside the allowed range.</exception>
        /// <exception cref="PlatformErrorGlfwException">This operation is not supported on this platform.</exception>
        public static bool GetJoystickAxes(int joy, ref float[] axes)
        {
            var axesPointer = Internal.GetJoystickAxes(joy, out var count);
            if (axesPointer == IntPtr.Zero)
            {
                HandleError();
                return false;
            }
            Marshal.Copy(axesPointer, axes, 0, Math.Min(count, axes.Length));
            return true;
        }

        /// <summary>
        /// Returns the state of all buttons of the specified joystick.
        /// <para>This function returns the state of all buttons of the specified joystick.
        /// Each element in the array is either
        /// <see cref="JoystickButtonState.Press"/> or <see cref="JoystickButtonState.Release"/>.</para>
        /// <para>Querying a joystick slot with no device present is not an error,
        /// but will cause this function to return <c>null</c>.
        /// Call <see cref="JoystickPresent"/> to check device presence.</para>
        /// </summary>
        /// <param name="joy">The joystick to query.</param>
        /// <returns>An array of button states, or <c>null</c> if the joystick is not present.</returns>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        /// <exception cref="InvalidEnumGlfwException">The <paramref name="joy"/> index
        /// is outside the allowed range.</exception>
        /// <exception cref="PlatformErrorGlfwException">This operation is not supported on this platform.</exception>
        public static JoystickButtonState[] GetJoystickButtons(int joy)
        {
            var statesPointer = Internal.GetJoystickButtons(joy, out var count);
            if (statesPointer == IntPtr.Zero)
            {
                HandleError();
                return null;
            }
            var buttonStates = new JoystickButtonState[count];
            // ReSharper disable once PossibleInvalidCastException
            Marshal.Copy(statesPointer, (byte[]) (object) buttonStates, 0, count);
            return buttonStates;
        }

        /// <summary>
        /// Retrieves the state of all buttons of the specified joystick.
        /// <para>This function gets the state of all buttons of the specified joystick.
        /// Each element in the array is either
        /// <see cref="JoystickButtonState.Press"/> or <see cref="JoystickButtonState.Release"/>.</para>
        /// <para>Querying a joystick slot with no device present is not an error,
        /// but will cause this function to return <c>false</c>.
        /// Call <see cref="JoystickPresent"/> to check device presence.</para>
        /// </summary>
        /// <param name="joy">The joystick to query.</param>
        /// <param name="buttonStates">Array to store joystick button states in.</param>
        /// <returns><c>true</c> if the joystick is present, or <c>false</c> if it isn't.</returns>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        /// <exception cref="InvalidEnumGlfwException">The <paramref name="joy"/> index
        /// is outside the allowed range.</exception>
        /// <exception cref="PlatformErrorGlfwException">This operation is not supported on this platform.</exception>
        public static bool GetJoystickButtons(int joy, ref JoystickButtonState[] buttonStates)
        {
            var statesPointer = Internal.GetJoystickButtons(joy, out var count);
            if (statesPointer == IntPtr.Zero)
            {
                HandleError();
                return false;
            }
            // ReSharper disable once PossibleInvalidCastException
            Marshal.Copy(statesPointer, (byte[]) (object) buttonStates, 0, Math.Min(count, buttonStates.Length));
            return true;
        }

        /// <summary>
        /// Returns the name of the specified joystick.
        /// <para>Querying a joystick slot with no device present is not an error,
        /// but will cause this function to return <c>null</c>.
        /// Call <see cref="JoystickPresent"/> to check device presence.</para>
        /// </summary>
        /// <param name="joy">The joystick to query.</param>
        /// <returns>The UTF-8 encoded name of the joystick, or <c>null</c> if the joystick is not present.</returns>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        /// <exception cref="InvalidEnumGlfwException">The <paramref name="joy"/> index
        /// is outside the allowed range.</exception>
        /// <exception cref="PlatformErrorGlfwException">This operation is not supported on this platform.</exception>
        public static string GetJoystickName(int joy)
        {
            var result = Internal.GetJoystickName(joy);
            if (result == IntPtr.Zero)
                HandleError();
            return result.FromNativeUtf8();
        }

        /// <summary>
        /// Sets the joystick configuration callback.
        /// <para>This function sets the joystick configuration callback, or removes the currently set callback.
        /// This is called when a joystick is connected to or disconnected from the system.</para>
        /// </summary>
        /// <param name="callback">The new callback, or <c>null</c> to remove the currently set callback.</param>
        /// <returns>The previously set callback,
        /// or <c>null</c> if no callback was set or the library had not been initialized.</returns>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        public static JoystickCallback SetJoystickCallback(JoystickCallback callback)
        {
            return SetInternalCallback(Internal.SetJoystickCallback, callback);
        }
        
        // ReSharper disable MemberHidesStaticFromOuterClass
        private static partial class Internal
        {
            /// <summary>
            /// Returns whether the specified joystick is present.
            /// </summary>
            /// <param name="joy">The joystick to query.</param>
            /// <returns><see cref="True"/> if the joystick is present, or <see cref="False"/> otherwise.</returns>
            /// <remarks>Possible errors include
            /// <see cref="ErrorCode.NotInitialized"/>, <see cref="ErrorCode.InvalidEnum"/>,
            /// and <see cref="ErrorCode.PlatformError"/>.</remarks>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwJoystickPresent", CallingConvention = CallingConvention.Cdecl)]
            public static extern int JoystickPresent(int joy);

            /// <summary>
            /// Returns the values of all axes of the specified joystick.
            /// <para>This function returns the values of all axes of the specified joystick.
            /// Each element in the array is a value between -1.0 and 1.0.</para>
            /// <para>Querying a joystick slot with no device present is not an error,
            /// but will cause this function to return <c>null</c>.
            /// Call <see cref="JoystickPresent"/> to check device presence.</para>
            /// </summary>
            /// <param name="joy">The joystick to query.</param>
            /// <param name="count">Where to store the number of axis values in the returned array.
            /// This is set to zero if the joystick is not present or an error occurred.</param>
            /// <returns>An array of axis values,
            /// or <c>null</c> if the joystick is not present or an error occurred.</returns>
            /// <remarks>Possible errors include
            /// <see cref="ErrorCode.NotInitialized"/>, <see cref="ErrorCode.InvalidEnum"/>,
            /// and <see cref="ErrorCode.PlatformError"/>.</remarks>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwGetJoystickAxes", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr GetJoystickAxes(int joy, out int count);

            /// <summary>
            /// Returns the state of all buttons of the specified joystick.
            /// <para>This function returns the state of all buttons of the specified joystick.
            /// Each element in the array is either
            /// <see cref="JoystickButtonState.Press"/> or <see cref="JoystickButtonState.Release"/>.</para>
            /// <para>Querying a joystick slot with no device present is not an error,
            /// but will cause this function to return <c>null</c>.
            /// Call <see cref="JoystickPresent"/> to check device presence.</para>
            /// </summary>
            /// <param name="joy">The joystick to query.</param>
            /// <param name="count">Where to store the number of button states in the returned array.
            /// This is set to zero if the joystick is not present or an error occurred.</param>
            /// <returns>An array of button states,
            /// or <c>null</c> if the joystick is not present or an error occurred.</returns>
            /// <remarks>Possible errors include
            /// <see cref="ErrorCode.NotInitialized"/>, <see cref="ErrorCode.InvalidEnum"/>,
            /// and <see cref="ErrorCode.PlatformError"/>.</remarks>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwGetJoystickButtons", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr GetJoystickButtons(int joy, out int count);

            /// <summary>
            /// Returns the name of the specified joystick.
            /// <para>Querying a joystick slot with no device present is not an error,
            /// but will cause this function to return <c>null</c>.
            /// Call <see cref="JoystickPresent"/> to check device presence.</para>
            /// </summary>
            /// <param name="joy">The joystick to query.</param>
            /// <returns>The UTF-8 encoded name of the joystick,
            /// or <c>null</c> if the joystick is not present or an error occurred.</returns>
            /// <remarks>Possible errors include
            /// <see cref="ErrorCode.NotInitialized"/>, <see cref="ErrorCode.InvalidEnum"/>,
            /// and <see cref="ErrorCode.PlatformError"/>.</remarks>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwGetJoystickName", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr GetJoystickName(int joy);

            /// <summary>
            /// Sets the joystick configuration callback.
            /// <para>This function sets the joystick configuration callback,
            /// or removes the currently set callback.
            /// This is called when a joystick is connected to or disconnected from the system.</para>
            /// </summary>
            /// <param name="cbfun">The new callback, or <c>null</c> to remove the currently set callback.</param>
            /// <returns>The previously set callback,
            /// or <c>null</c> if no callback was set or the library had not been initialized.</returns>
            /// <remarks>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</remarks>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwSetJoystickCallback", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr SetJoystickCallback(IntPtr cbfun);
        }
    }
}