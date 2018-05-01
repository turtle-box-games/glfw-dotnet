using System;
using System.Runtime.InteropServices;
using System.Security;

namespace GLFW.Net
{
    public static partial class GLFW
    {
        private static partial class Internal
        {
            /// <summary>
            /// Returns the value of an input option for the specified window.
            /// </summary>
            /// <param name="window">The window to query.</param>
            /// <param name="mode">One of <see cref="InputMode.Cursor"/>, <see cref="InputMode.StickyKeys"/>,
            /// or <see cref="InputMode.StickyMouseButtons"/>.</param>
            /// <returns>Value of the input option
            /// for the specified <paramref name="window"/> and <paramref name="mode"/>.</returns>
            /// <remarks>Possible errors include
            /// <see cref="ErrorCode.NotInitialized"/> and <see cref="ErrorCode.InvalidEnum"/>.</remarks>
            /// <seealso cref="SetInputMode"/>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwGetInputMode", CallingConvention = CallingConvention.Cdecl)]
            public static extern int GetInputMode(IntPtr window, InputMode mode);

            /// <summary>
            /// Sets an input option for the specified window.
            /// <para>This function sets an input mode option for the specified window.
            /// The mode must be one of <see cref="InputMode.Cursor"/>, <see cref="InputMode.StickyKeys"/>
            /// or <see cref="InputMode.StickyMouseButtons"/>.</para>
            /// <para>If the mode is <see cref="InputMode.Cursor"/>,
            /// the value must be one of <see cref="CursorMode"/>.</para>
            /// <para>If the mode is <see cref="InputMode.StickyKeys"/>,
            /// the value must be either <see cref="True"/> to enable sticky keys, or <see cref="False"/> to disable it.
            /// If sticky keys are enabled,
            /// a key press will ensure that <see cref="GetKey"/> returns <see cref="KeyAction.Press"/>
            /// the next time it is called even if the key had been released before the call.
            /// This is useful when you are only interested in whether keys have been pressed
            /// but not when or in which order.</para>
            /// <para>If the mode is <see cref="InputMode.StickyMouseButtons"/>,
            /// the value must be either <see cref="True"/> to enable sticky mouse buttons,
            /// or <see cref="False"/> to disable it.
            /// If sticky mouse buttons are enabled,
            /// a mouse button press will ensure that <see cref="GetMouseButton"/> returns <see cref="ButtonAction.Press"/>
            /// the next time it is called even if the mouse button had been released before the call.
            /// This is useful when you are only interested in whether mouse buttons have been pressed
            /// but not when or in which order.</para>
            /// </summary>
            /// <param name="window">The window whose input mode to set.</param>
            /// <param name="mode">One of <see cref="InputMode.Cursor"/>, <see cref="InputMode.StickyKeys"/>,
            /// or <see cref="InputMode.StickyMouseButtons"/>.</param>
            /// <param name="value">The new value of the specified input mode.</param>
            /// <remarks>Possible errors include
            /// <see cref="ErrorCode.NotInitialized"/>, <see cref="ErrorCode.InvalidEnum"/>,
            /// and <see cref="ErrorCode.PlatformError"/>.</remarks>
            /// <seealso cref="GetInputMode"/>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwSetInputMode", CallingConvention = CallingConvention.Cdecl)]
            public static extern void SetInputMode(IntPtr window, InputMode mode, int value);

            /// <summary>
            /// Sets the clipboard to the specified string.
            /// </summary>
            /// <param name="window">The window that will own the clipboard contents.</param>
            /// <param name="string">A UTF-8 encoded string.</param>
            /// <remarks>Possible errors include
            /// <see cref="ErrorCode.NotInitialized"/> and <see cref="ErrorCode.PlatformError"/>.</remarks>
            /// <seealso cref="GetClipboardString"/>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwSetClipboardString", CallingConvention = CallingConvention.Cdecl)]
            public static extern void
                SetClipboardString(IntPtr window, [MarshalAs(UnmanagedType.LPUTF8Str)] string @string);

            /// <summary>
            /// Returns the contents of the clipboard as a string.
            /// <para>This function returns the contents of the system clipboard,
            /// if it contains or is convertible to a UTF-8 encoded string.
            /// If the clipboard is empty or if its contents cannot be converted,
            /// <c>null</c> is returned and a <see cref="ErrorCode.FormatUnavailable"/> error is generated.</para>
            /// </summary>
            /// <param name="window">The window that will request the clipboard contents.</param>
            /// <returns>The contents of the clipboard as a UTF-8 encoded string,
            /// or <c>null</c> if an error occurred.</returns>
            /// <remarks>Possible errors include
            /// <see cref="ErrorCode.NotInitialized"/> and <see cref="ErrorCode.PlatformError"/>.</remarks>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwGetClipboardString", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr GetClipboardString(IntPtr window);

            /// <summary>
            /// Returns the value of the GLFW timer.
            /// <para>This function returns the value of the GLFW timer.
            /// Unless the timer has been set using <see cref="SetTime"/>,
            /// the timer measures time elapsed since GLFW was initialized.</para>
            /// <para>The resolution of the timer is system dependent,
            /// but is usually on the order of a few micro- or nanoseconds.
            /// It uses the highest-resolution monotonic time source on each supported platform.</para>
            /// </summary>
            /// <returns>The current value, in seconds, or zero if an error occurred.</returns>
            /// <remarks>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</remarks>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwGetTime", CallingConvention = CallingConvention.Cdecl)]
            public static extern double GetTime();

            /// <summary>
            /// Sets the GLFW timer.
            /// <para>This function sets the value of the GLFW timer.
            /// It then continues to count up from that value.
            /// The value must be a positive finite number less than or equal to 18446744073.0,
            /// which is approximately 584.5 years.</para>
            /// </summary>
            /// <param name="time">The new value, in seconds.</param>
            /// <remarks><para>Possible errors include
            /// <see cref="ErrorCode.NotInitialized"/> and <see cref="ErrorCode.InvalidValue"/>.</para>
            /// <para>The upper limit of the timer is calculated as <c>floor((2^64 - 1) / 10^9)</c>
            /// and is due to implementations storing nanoseconds in 64 bits.
            /// The limit may be increased in the future.</para></remarks>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwSetTime", CallingConvention = CallingConvention.Cdecl)]
            public static extern void SetTime(double time);

            /// <summary>
            /// Returns the current value of the raw timer.
            /// <para>This function returns the current value of the raw timer,
            /// measured in 1 / frequency seconds.
            /// To get the frequency, call <see cref="GetTimerFrequency"/>.</para>
            /// </summary>
            /// <returns>The value of the timer, or zero if an error occurred.</returns>
            /// <remarks>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</remarks>
            /// <seealso cref="GetTimerFrequency"/>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwGetTimerValue", CallingConvention = CallingConvention.Cdecl)]
            public static extern ulong GetTimerValue();

            /// <summary>
            /// Returns the frequency, in Hz, of the raw timer.
            /// </summary>
            /// <returns>The frequency of the timer, in Hz, or zero if an error occurred.</returns>
            /// <remarks>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</remarks>
            /// <seealso cref="GetTimerValue"/>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwGetTimerFrequency", CallingConvention = CallingConvention.Cdecl)]
            public static extern ulong GetTimerFrequency();
        }
    }
}