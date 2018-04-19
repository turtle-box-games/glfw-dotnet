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
        public delegate void JoystickHandler(int joy, int @event);
        
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
        public delegate void KeyHandler(IntPtr window, int key, int scancode, int action, int mods);

        /// <summary>
        /// The function signature for Unicode character callbacks.
        /// </summary>
        /// <param name="window">The window that received the event.</param>
        /// <param name="codepoint">The Unicode code point of the character.</param>
        /// <seealso cref="SetCharCallback"/>
        public delegate void CharacterHandler(IntPtr window, uint codepoint);

        /// <summary>
        /// The function signature for Unicode character with modifiers callbacks.
        /// <para>This is the function signature for Unicode character with modifiers callback functions.
        /// It is called for each input character, regardless of what modifier keys are held down.</para>
        /// </summary>
        /// <param name="window">The window that received the event.</param>
        /// <param name="codepoint">The Unicode code point of the character. </param>
        /// <param name="mods">Bit field describing which modifier keys were held down.</param>
        /// <seealso cref="SetCharModsCallback"/>
        public delegate void CharacterModifierHandler(IntPtr window, uint codepoint, int mods);
        
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
        public delegate void MouseButtonHandler(IntPtr window, int button, int action, int mods);

        /// <summary>
        /// The function signature for cursor position callbacks.
        /// </summary>
        /// <param name="window">The window that received the event.</param>
        /// <param name="xpos">The new cursor x-coordinate, relative to the left edge of the client area.</param>
        /// <param name="ypos">The new cursor y-coordinate, relative to the top edge of the client area.</param>
        /// <seealso cref="SetCursorPosCallback"/>
        public delegate void CursorPositionHandler(IntPtr window, double xpos, double ypos);

        /// <summary>
        /// The function signature for cursor enter/leave callbacks.
        /// </summary>
        /// <param name="window">The window that received the event.</param>
        /// <param name="entered"><see cref="True"/> if the cursor entered the window's client area,
        /// or <see cref="False"/> if it left it.</param>
        /// <seealso cref="SetCursorEnterCallback"/>
        public delegate void CursorEnterHandler(IntPtr window, int entered);

        /// <summary>
        /// The function signature for scroll callbacks.
        /// </summary>
        /// <param name="window">The window that received the event.</param>
        /// <param name="xoffset">The scroll offset along the x-axis.</param>
        /// <param name="yoffset">The scroll offset along the y-axis.</param>
        /// <seealso cref="SetScrollCallback"/>
        public delegate void ScrollHandler(IntPtr window, double xoffset, double yoffset);

        /// <summary>
        /// The function signature for file drop callbacks.
        /// </summary>
        /// <param name="window">The window that received the event.</param>
        /// <param name="count">The number of dropped files.</param>
        /// <param name="paths">The UTF-8 encoded file and/or directory path names.</param>
        /// <seealso cref="SetDropCallback"/>
        public delegate void DropHandler(IntPtr window, int count,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr, SizeParamIndex = 1)] string[] paths);

        #endregion
    }
}