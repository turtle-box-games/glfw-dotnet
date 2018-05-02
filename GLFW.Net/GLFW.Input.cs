using System;
using System.Runtime.InteropServices;
using System.Security;

namespace GLFW.Net
{
    public static partial class GLFW
    {
        /// <summary>
        /// Retrieves the current mode for the cursor.
        /// </summary>
        /// <param name="window">Window the cursor mode applies to.</param>
        /// <returns>Active mode for the cursor in <paramref name="window"/>.</returns>
        /// <exception cref="NotInitializedGLFWException">GLFW is not initialized.</exception>
        internal static CursorMode GetCursorMode(IntPtr window)
        {
            var result = Internal.GetInputMode(window, (int) InputMode.Cursor);
            HandleError();
            return (CursorMode) result;
        }

        /// <summary>
        /// Updates the current mode for the cursor.
        /// </summary>
        /// <param name="window">Window the cursor mode applies to.</param>
        /// <param name="mode">Cursor mode to make active.</param>
        /// <exception cref="NotInitializedGLFWException">GLFW is not initialized.</exception>
        /// <exception cref="InvalidEnumGLFWException">The value of <paramref name="mode"/> is not allowed.</exception>
        internal static void SetCursorMode(IntPtr window, CursorMode mode)
        {
            Internal.SetInputMode(window, (int) InputMode.Cursor, (int) mode);
            HandleError();
        }

        /// <summary>
        /// Checks whether sticky keys is enabled.
        /// </summary>
        /// <param name="window">Window that sticky keys applies to.</param>
        /// <returns><c>true</c> if sticky keys is enabled, or <c>false</c> if it isn't.</returns>
        /// <exception cref="NotInitializedGLFWException">GLFW is not initialized.</exception>
        internal static bool GetStickyKeysEnabled(IntPtr window)
        {
            var result = Internal.GetInputMode(window, (int) InputMode.StickyKeys);
            HandleError();
            return result != Internal.False;
        }

        /// <summary>
        /// Updatest whether sticky keys is enabled.
        /// </summary>
        /// <param name="window">Window that sticky keys applies to.</param>
        /// <param name="enabled"><c>true</c> to enable sticky keys, or <c>false</c> to disable it.</param>
        /// <exception cref="NotInitializedGLFWException">GLFW is not initialized.</exception>
        internal static void SetStickyKeysEnabled(IntPtr window, bool enabled = true)
        {
            var value = enabled ? Internal.True : Internal.False;
            Internal.SetInputMode(window, (int) InputMode.StickyKeys, value);
            HandleError();
        }

        /// <summary>
        /// Checks whether sticky mouse buttons is enabled.
        /// </summary>
        /// <param name="window">Window that sticky mouse buttons applies to.</param>
        /// <returns><c>true</c> if sticky mouse buttons is enabled, or <c>false</c> if it isn't.</returns>
        /// <exception cref="NotInitializedGLFWException">GLFW is not initialized.</exception>
        internal static bool GetStickyMouseButtonsEnabled(IntPtr window)
        {
            var result = Internal.GetInputMode(window, (int) InputMode.StickyMouseButtons);
            HandleError();
            return result != Internal.False;
        }

        /// <summary>
        /// Updatest whether sticky mouse buttons is enabled.
        /// </summary>
        /// <param name="window">Window that sticky mouse buttons applies to.</param>
        /// <param name="enabled"><c>true</c> to enable sticky mouse buttons, or <c>false</c> to disable it.</param>
        /// <exception cref="NotInitializedGLFWException">GLFW is not initialized.</exception>
        internal static void SetStickyMouseButtonsEnabled(IntPtr window, bool enabled = true)
        {
            var value = enabled ? Internal.True : Internal.False;
            Internal.SetInputMode(window, (int) InputMode.StickyMouseButtons, value);
            HandleError();
        }

        /// <summary>
        /// Sets the clipboard to the specified string.
        /// </summary>
        /// <param name="window">The window that will own the clipboard contents.</param>
        /// <param name="clip">String to place into the clipboard.</param>
        /// <exception cref="NotInitializedGLFWException">GLFW is not initialized.</exception>
        /// <exception cref="PlatformErrorGLFWException">This operation is not supported on this platform.</exception>
        /// <seealso cref="GetClipboardString"/>
        internal static void SetClipboardString(IntPtr window, string clip)
        {
            var clipPointer = clip.ToNativeUtf8();
            Internal.SetClipboardString(window, clipPointer);
            HandleError();
        }

        /// <summary>
        /// Retrieves the contents of the clipboard.
        /// </summary>
        /// <param name="window">The window that will own the clipboard contents.</param>
        /// <returns>Contents of the clipboard as a string.</returns>
        /// <exception cref="NotInitializedGLFWException">GLFW is not initialized.</exception>
        /// <exception cref="PlatformErrorGLFWException">This operation is not supported on this platform.</exception>
        /// <exception cref="FormatUnavailableGLFWException">The clipboard is empty
        /// or the contents are in an unrecognized format.</exception>
        /// <seealso cref="SetClipboardString"/>
        internal static string GetClipboardString(IntPtr window)
        {
            var result = Internal.GetClipboardString(window);
            HandleError();
            return result.FromNativeUtf8();
        }

        /// <summary>
        /// Returns the number of seconds that have elapsed.
        /// <para>This method returns the number of seconds that have passed since GLFW was initialized.
        /// However, the value can be changed by calling <see cref="SetTimeInSeconds"/>.</para>
        /// </summary>
        /// <returns>Time span in seconds.</returns>
        /// <remarks><para>The upper limit of the timer is calculated as <c>floor((2^64 - 1) / 10^9)</c>
        /// and is due to implementations storing nanoseconds in 64 bits.</para></remarks>
        /// <exception cref="NotInitializedGLFWException">GLFW is not initialized.</exception>
        /// <seealso cref="SetTimeInSeconds"/>
        internal static double GetTimeInSeconds()
        {
            var result = Internal.GetTime();
            HandleError();
            return result;
        }

        /// <summary>
        /// Updates the timer to a known point in time.
        /// The timer will count up for the set value.
        /// </summary>
        /// <param name="value">New value to set the timer to.
        /// <para>The value must be a positive finite number less than or equal to 18446744073.0,
        /// which is approximately 584.5 years.</para></param>
        /// <exception cref="NotInitializedGLFWException">GLFW is not initialized.</exception>
        /// <exception cref="InvalidValueGLFWException">The provided <paramref name="value"/> is invalid.
        /// It must be a positive finite number less than or equal to 18446744073.0.</exception>
        /// <seealso cref="GetTimeInSeconds"/>
        internal static void SetTimeInSeconds(double value = 0d)
        {
            Internal.SetTime(value);
            HandleError();
        }

        /// <summary>
        /// Returns the current value of the raw timer.
        /// <para>This function returns the current value of the raw timer,
        /// measured in <c>1 / frequency</c> seconds.
        /// To get the frequency, call <see cref="GetTimerFrequency"/>.</para>
        /// </summary>
        /// <returns>The value of the timer.</returns>
        /// <exception cref="NotInitializedGLFWException">GLFW is not initialized.</exception>
        /// <seealso cref="GetTimerFrequency"/>
        internal static ulong GetTime()
        {
            var result = Internal.GetTimerValue();
            HandleError();
            return result;
        }

        /// <summary>
        /// Returns the frequency, in Hz, of the raw timer.
        /// </summary>
        /// <returns>The frequency of the timer, in Hz.</returns>
        /// <exception cref="NotInitializedGLFWException">GLFW is not initialized.</exception>
        /// <seealso cref="GetTime"/>
        internal static ulong GetTimerFrequency()
        {
            var result = Internal.GetTimerFrequency();
            HandleError();
            return result;
        }

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
            public static extern int GetInputMode(IntPtr window, int mode);

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
            /// If sticky mouse buttons are enabled, a mouse button press will ensure that <see cref="GetMouseButton"/>
            /// returns <see cref="MouseButtonState.Press"/>
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
            public static extern void SetInputMode(IntPtr window, int mode, int value);

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
            public static extern void SetClipboardString(IntPtr window, IntPtr @string);

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
            /// measured in <c>1 / frequency</c> seconds.
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