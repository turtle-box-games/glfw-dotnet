using System;
using System.Runtime.InteropServices;

namespace GLFW.Net.Native
{
    internal static partial class GLFW
    {
        #region Joystick
        
        /// <summary>
        /// The function signature for joystick configuration callbacks.
        /// </summary>
        /// <param name="joy">The joystick that was connected or disconnected.</param>
        /// <param name="event">One of <see cref="Connected"/> or <see cref="Disconnected"/>.</param>
        /// <seealso cref="SetJoystickCallback"/>
        public delegate void JoystickCallback(int joy, int @event);

        [DllImport(DllName, EntryPoint = "glfwJoystickPresent")]
        public static extern int JoystickPresent(int joy);

        [DllImport(DllName, EntryPoint = "glfwGetJoystickAxes")]
        public static extern float[] GetJoystickAxes(int joy, out int count);

        [DllImport(DllName, EntryPoint = "glfwGetJoystickButtons")]
        public static extern byte[] GetJoystickButtons(int joy, out int count);

        [DllImport(DllName, EntryPoint = "glfwGetJoystickName")]
        [return: MarshalAs(UnmanagedType.LPStr)]
        public static extern string GetJoystickName(int joy);

        [DllImport(DllName, EntryPoint = "glfwSetJoystickCallback")]
        [return: MarshalAs(UnmanagedType.FunctionPtr)]
        public static extern JoystickCallback SetJoystickCallback(
            [MarshalAs(UnmanagedType.FunctionPtr)] JoystickCallback cbfun);
        
        #endregion
        
        #region Keyboard

        /// <summary>
        /// The function signature for keyboard key callbacks.
        /// </summary>
        /// <param name="window">The window that received the event.</param>
        /// <param name="key">The keyboard key that was pressed or released.</param>
        /// <param name="scancode">The system-specific scancode of the key.</param>
        /// <param name="action"><see cref="Press"/>, <see cref="Release"/>, or <see cref="Repeat"/>.</param>
        /// <param name="mods">Bit field describing which modifier keys were held down.</param>
        /// <seealso cref="SetKeyCallback"/>
        public delegate void KeyCallback(IntPtr window, int key, int scancode, int action, int mods);

        /// <summary>
        /// The function signature for Unicode character callbacks.
        /// </summary>
        /// <param name="window">The window that received the event.</param>
        /// <param name="codepoint">The Unicode code point of the character.</param>
        /// <seealso cref="SetCharCallback"/>
        public delegate void CharacterCallback(IntPtr window, uint codepoint);

        /// <summary>
        /// The function signature for Unicode character with modifiers callbacks.
        /// <para>This is the function signature for Unicode character with modifiers callback functions.
        /// It is called for each input character, regardless of what modifier keys are held down.</para>
        /// </summary>
        /// <param name="window">The window that received the event.</param>
        /// <param name="codepoint">The Unicode code point of the character. </param>
        /// <param name="mods">Bit field describing which modifier keys were held down.</param>
        /// <seealso cref="SetCharModsCallback"/>
        public delegate void CharacterModifierCallback(IntPtr window, uint codepoint, int mods);

        [DllImport(DllName, EntryPoint = "glfwGetKeyName")]
        [return: MarshalAs(UnmanagedType.LPStr)]
        public static extern string GetKeyName(int key, int scancode);

        [DllImport(DllName, EntryPoint = "glfwGetKey")]
        public static extern int GetKey(IntPtr window, int key);

        [DllImport(DllName, EntryPoint = "glfwSetKeyCallback")]
        [return: MarshalAs(UnmanagedType.FunctionPtr)]
        public static extern KeyCallback SetKeyCallback(IntPtr window,
            [MarshalAs(UnmanagedType.FunctionPtr)] KeyCallback cbfun);

        [DllImport(DllName, EntryPoint = "glfwSetCharCallback")]
        [return: MarshalAs(UnmanagedType.FunctionPtr)]
        public static extern CharacterCallback SetCharCallback(IntPtr window,
            [MarshalAs(UnmanagedType.FunctionPtr)] CharacterCallback cbfun);

        [DllImport(DllName, EntryPoint = "glfwSetCharModsCallback")]
        [return: MarshalAs(UnmanagedType.FunctionPtr)]
        public static extern CharacterModifierCallback SetCharModsCallback(IntPtr window,
            [MarshalAs(UnmanagedType.FunctionPtr)] CharacterModifierCallback cbfun);
        
        #endregion

        #region Mouse

        /// <summary>
        /// The function signature for mouse button callbacks.
        /// </summary>
        /// <param name="window">The window that received the event.</param>
        /// <param name="button">The mouse button that was pressed or released.</param>
        /// <param name="action">One of <see cref="Press"/> or <see cref="Release"/>.</param>
        /// <param name="mods">Bit field describing which modifier keys were held down.</param>
        /// <seealso cref="SetMouseButtonCallback"/>
        public delegate void MouseButtonCallback(IntPtr window, int button, int action, int mods);

        /// <summary>
        /// The function signature for cursor position callbacks.
        /// </summary>
        /// <param name="window">The window that received the event.</param>
        /// <param name="xpos">The new cursor x-coordinate, relative to the left edge of the client area.</param>
        /// <param name="ypos">The new cursor y-coordinate, relative to the top edge of the client area.</param>
        /// <seealso cref="SetCursorPosCallback"/>
        public delegate void CursorPositionCallback(IntPtr window, double xpos, double ypos);

        /// <summary>
        /// The function signature for cursor enter/leave callbacks.
        /// </summary>
        /// <param name="window">The window that received the event.</param>
        /// <param name="entered"><see cref="True"/> if the cursor entered the window's client area,
        /// or <see cref="False"/> if it left it.</param>
        /// <seealso cref="SetCursorEnterCallback"/>
        public delegate void CursorEnterCallback(IntPtr window, int entered);

        /// <summary>
        /// The function signature for scroll callbacks.
        /// </summary>
        /// <param name="window">The window that received the event.</param>
        /// <param name="xoffset">The scroll offset along the x-axis.</param>
        /// <param name="yoffset">The scroll offset along the y-axis.</param>
        /// <seealso cref="SetScrollCallback"/>
        public delegate void ScrollCallback(IntPtr window, double xoffset, double yoffset);

        /// <summary>
        /// The function signature for file drop callbacks.
        /// </summary>
        /// <param name="window">The window that received the event.</param>
        /// <param name="count">The number of dropped files.</param>
        /// <param name="paths">The UTF-8 encoded file and/or directory path names.</param>
        /// <seealso cref="SetDropCallback"/>
        public delegate void DropCallback(IntPtr window, int count,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr, SizeParamIndex = 1)]
            string[] paths);

        [DllImport(DllName, EntryPoint = "glfwGetMouseButton")]
        public static extern int GetMouseButton(IntPtr window, int button);

        [DllImport(DllName, EntryPoint = "glfwGetCursorPos")]
        public static extern void GetCursorPos(IntPtr window, out double xpos, out double ypos);

        [DllImport(DllName, EntryPoint = "glfwSetCursorPos")]
        public static extern void SetCursorPos(IntPtr window, double xpos, double ypos);

        [DllImport(DllName, EntryPoint = "glfwCreateCursor")]
        public static extern IntPtr CreateCursor(IntPtr image, int xhot, int yhot);

        [DllImport(DllName, EntryPoint = "glfwCreateStandardCursor")]
        public static extern IntPtr CreateStandardCursor(int shape);

        [DllImport(DllName, EntryPoint = "glfwDestroyCursor")]
        public static extern void DestroyCursor(IntPtr cursor);

        [DllImport(DllName, EntryPoint = "glfwSetCursor")]
        public static extern void SetCursor(IntPtr window, IntPtr cursor);

        [DllImport(DllName, EntryPoint = "glfwSetMouseButtonCallback")]
        [return: MarshalAs(UnmanagedType.FunctionPtr)]
        public static extern MouseButtonCallback SetMouseButtonCallback(IntPtr window,
            [MarshalAs(UnmanagedType.FunctionPtr)] MouseButtonCallback cbfun);

        [DllImport(DllName, EntryPoint = "glfwSetCursorPosCallback")]
        [return: MarshalAs(UnmanagedType.FunctionPtr)]
        public static extern CursorPositionCallback SetCursorPosCallback(IntPtr window,
            [MarshalAs(UnmanagedType.FunctionPtr)] CursorPositionCallback cbfun);

        [DllImport(DllName, EntryPoint = "glfwSetCursorEnterCallback")]
        [return: MarshalAs(UnmanagedType.FunctionPtr)]
        public static extern CursorEnterCallback SetCursorEnterCallback(IntPtr window,
            [MarshalAs(UnmanagedType.FunctionPtr)] CursorEnterCallback cbfun);

        [DllImport(DllName, EntryPoint = "glfwSetScrollCallback")]
        [return: MarshalAs(UnmanagedType.FunctionPtr)]
        public static extern ScrollCallback SetScrollCallback(IntPtr window,
            [MarshalAs(UnmanagedType.FunctionPtr)] ScrollCallback cbfun);

        [DllImport(DllName, EntryPoint = "glfwSetDropCallback")]
        [return: MarshalAs(UnmanagedType.FunctionPtr)]
        public static extern DropCallback SetDropCallback(IntPtr window,
            [MarshalAs(UnmanagedType.FunctionPtr)] DropCallback cbfun);

        #endregion

        [DllImport(DllName, EntryPoint = "glfwGetInputMode")]
        public static extern int GetInputMode(IntPtr window, int mode);

        [DllImport(DllName, EntryPoint = "glfwSetInputMode")]
        public static extern void SetInputMode(IntPtr window, int mode, int value);

        [DllImport(DllName, EntryPoint = "glfwSetClipboardString")]
        public static extern void SetClipboardString(IntPtr window, [MarshalAs(UnmanagedType.LPStr)] string @string);

        [DllImport(DllName, EntryPoint = "glfwGetClipboardString")]
        [return: MarshalAs(UnmanagedType.LPStr)]
        public static extern string GetClipboardString(IntPtr window);

        [DllImport(DllName, EntryPoint = "glfwGetTime")]
        public static extern double GetTime();

        [DllImport(DllName, EntryPoint = "glfwSetTime")]
        public static extern void SetTime(double time);

        [DllImport(DllName, EntryPoint = "glfwGetTimerValue")]
        public static extern ulong GetTimerValue();

        [DllImport(DllName, EntryPoint = "glfwGetTimerFrequency")]
        public static extern ulong GetTimerFrequency();
    }
}