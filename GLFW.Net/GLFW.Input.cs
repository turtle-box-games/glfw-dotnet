using System;
using System.Runtime.InteropServices;

namespace GLFW.Net
{
    internal static partial class GLFW
    {
        #region Joystick
        
        /// <summary>
        /// The function signature for joystick configuration callbacks.
        /// </summary>
        /// <param name="joy">The joystick that was connected or disconnected.</param>
        /// <param name="event">One of <see cref="DeviceEvent.Connected"/>
        /// or <see cref="DeviceEvent.Disconnected"/>.</param>
        /// <seealso cref="SetJoystickCallback"/>
        public delegate void JoystickCallback(int joy, DeviceEvent @event);

        /// <summary>
        /// Returns whether the specified joystick is present.
        /// </summary>
        /// <param name="joy">The joystick to query.</param>
        /// <returns><see cref="True"/> if the joystick is present, or <see cref="False"/> otherwise.</returns>
        /// <remarks>Possible errors include
        /// <see cref="ErrorCode.NotInitialized"/>, <see cref="ErrorCode.InvalidEnum"/>,
        /// and <see cref="ErrorCode.PlatformError"/>.</remarks>
        [DllImport(DllName, EntryPoint = "glfwJoystickPresent")]
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
        [DllImport(DllName, EntryPoint = "glfwGetJoystickAxes")]
        [return: MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.R4, SizeParamIndex = 1)]
        public static extern float[] GetJoystickAxes(int joy, out int count);

        /// <summary>
        /// Returns the state of all buttons of the specified joystick.
        /// <para>This function returns the state of all buttons of the specified joystick.
        /// Each element in the array is either
        /// <see cref="ButtonAction.Press"/> or <see cref="ButtonAction.Release"/>.</para>
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
        [DllImport(DllName, EntryPoint = "glfwGetJoystickButtons")]
        [return: MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)]
        public static extern ButtonAction[] GetJoystickButtons(int joy, out int count);

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
        [DllImport(DllName, EntryPoint = "glfwGetJoystickName")]
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
        /// <param name="action">One of <see cref="KeyAction"/>.</param>
        /// <param name="mods">Bit field describing which modifier keys were held down.</param>
        /// <seealso cref="SetKeyCallback"/>
        public delegate void KeyCallback(IntPtr window, Key key, int scancode, KeyAction action, ModifierKey mods);

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
        public delegate void CharacterModifierCallback(IntPtr window, uint codepoint, ModifierKey mods);

        /// <summary>
        /// Returns the localized name of the specified printable key.
        /// <para>This function returns the localized name of the specified printable key.
        /// This is intended for displaying key bindings to the user.</para>
        /// <para>If the key is <see cref="Key.Unknown"/>, the scancode is used instead,
        /// otherwise the scancode is ignored.
        /// If a non-printable key or (if the key is <see cref="Key.Unknown"/>)
        /// a scancode that maps to a non-printable key is specified, this function returns <c>null</c>.</para>
        /// <para>This behavior allows you to pass in the arguments
        /// passed to the <see cref="KeyCallback"/> without modification.</para>
        /// </summary>
        /// <param name="key">The key to query, or <see cref="Key.Unknown"/>.</param>
        /// <param name="scancode">The scancode of the key to query.</param>
        /// <returns>The localized name of the key, or <c>null</c>.</returns>
        /// <remarks>Possible errors include
        /// <see cref="ErrorCode.NotInitialized"/> and <see cref="ErrorCode.PlatformError"/>.</remarks>
        [DllImport(DllName, EntryPoint = "glfwGetKeyName")]
        public static extern IntPtr GetKeyName(Key key, int scancode);

        /// <summary>
        /// Returns the last reported state of a keyboard key for the specified window.
        /// <para>This function returns the last state reported for the specified key to the specified window.
        /// The returned state is one of <see cref="KeyAction.Press"/> or <see cref="KeyAction.Release"/>.
        /// The higher-level action <see cref="KeyAction.Repeat"/> is only reported to the key callback.</para>
        /// <para>If the <see cref="InputMode.StickyKeys"/> input mode is enabled,
        /// this function returns <see cref="KeyAction.Press"/> the first time you call it for a key that was pressed,
        /// even if that key has already been released.</para>
        /// <para>The key functions deal with physical keys,
        /// with key tokens named after their use on the standard US keyboard layout.
        /// If you want to input text, use the Unicode character callback instead.</para>
        /// <para>The modifier key bit masks are not key tokens and cannot be used with this function.</para>
        /// <para>Do not use this function to implement text input.</para>
        /// </summary>
        /// <param name="window">The desired window.</param>
        /// <param name="key">The desired keyboard key.
        /// <see cref="Key.Unknown"/> is not a valid key for this function.</param>
        /// <returns>One of <see cref="KeyAction.Press"/> or <see cref="KeyAction.Release"/>.</returns>
        /// <remarks>Possible errors include
        /// <see cref="ErrorCode.NotInitialized"/> and <see cref="ErrorCode.InvalidEnum"/>.</remarks>
        [DllImport(DllName, EntryPoint = "glfwGetKey")]
        public static extern KeyAction GetKey(IntPtr window, Key key);

        /// <summary>
        /// Sets the key callback.
        /// <para>This function sets the key callback of the specified window,
        /// which is called when a key is pressed, repeated or released.</para>
        /// <para>The key functions deal with physical keys,
        /// with layout independent key tokens named after their values in the standard US keyboard layout.
        /// If you want to input text, use <see cref="CharacterCallback"/> instead.</para>
        /// <para>When a window loses input focus,
        /// it will generate synthetic key release events for all pressed keys.
        /// You can tell these events from user-generated events
        /// by the fact that the synthetic ones are generated after the focus loss event has been processed,
        /// i.e. after the window focus callback has been called.</para>
        /// <para>The scancode of a key is specific to that platform or sometimes even to that machine.
        /// Scancodes are intended to allow users to bind keys that don't have a GLFW key token.
        /// Such keys have key set to <see cref="Key.Unknown"/>,
        /// their state is not saved and so it cannot be queried with <see cref="GetKey"/>.</para>
        /// <para>Sometimes GLFW needs to generate synthetic key events, in which case the scancode may be zero.</para>
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="cbfun">The new key callback, or <c>null</c> to remove the currently set callback.</param>
        /// <returns>The previously set callback,
        /// or <c>null</c> if no callback was set or the library had not been initialized.</returns>
        /// <remarks>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</remarks>
        [DllImport(DllName, EntryPoint = "glfwSetKeyCallback")]
        [return: MarshalAs(UnmanagedType.FunctionPtr)]
        public static extern KeyCallback SetKeyCallback(IntPtr window,
            [MarshalAs(UnmanagedType.FunctionPtr)] KeyCallback cbfun);

        /// <summary>
        /// Sets the Unicode character callback.
        /// <para>This function sets the character callback of the specified window,
        /// which is called when a Unicode character is input.</para>
        /// <para>The character callback is intended for Unicode text input.
        /// As it deals with characters, it is keyboard layout dependent, whereas the key callback is not.
        /// Characters do not map 1:1 to physical keys, as a key may produce zero, one or more characters.
        /// If you want to know whether a specific physical key was pressed or released,
        /// see <see cref="KeyCallback"/> instead.</para>
        /// <para>The character callback behaves as system text input normally does
        /// and will not be called if modifier keys are held down that would prevent normal text input on that platform,
        /// for example a Super (Command) key on OS X or Alt key on Windows.
        /// There is a character with modifiers callback that receives these events.</para>
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="cbfun">The new callback, or <c>null</c> to remove the currently set callback.</param>
        /// <returns>The previously set callback,
        /// or <c>null</c> if no callback was set or the library had not been initialized.</returns>
        /// <remarks>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</remarks>
        [DllImport(DllName, EntryPoint = "glfwSetCharCallback")]
        [return: MarshalAs(UnmanagedType.FunctionPtr)]
        public static extern CharacterCallback SetCharCallback(IntPtr window,
            [MarshalAs(UnmanagedType.FunctionPtr)] CharacterCallback cbfun);

        /// <summary>
        /// Sets the Unicode character with modifiers callback.
        /// <para>This function sets the character with modifiers callback of the specified window,
        /// which is called when a Unicode character is input regardless of what modifier keys are used.</para>
        /// <para>The character with modifiers callback is intended for implementing custom Unicode character input.
        /// For regular Unicode text input, see <see cref="CharacterCallback"/>.
        /// Like the character callback, the character with modifiers callback deals with characters
        /// and is keyboard layout dependent.
        /// Characters do not map 1:1 to physical keys, as a key may produce zero, one or more characters.
        /// If you want to know whether a specific physical key was pressed or released,
        /// see the <see cref="KeyCallback"/> instead.</para>
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="cbfun">The new callback, or <c>null</c> to remove the currently set callback.</param>
        /// <returns>The previously set callback, or <c>null</c> if no callback was set or an error occurred.</returns>
        /// <remarks>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</remarks>
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
        /// <param name="action">One of <see cref="ButtonAction.Press"/> or <see cref="ButtonAction.Release"/>.</param>
        /// <param name="mods">Bit field describing which modifier keys were held down.</param>
        /// <seealso cref="SetMouseButtonCallback"/>
        public delegate void MouseButtonCallback(IntPtr window, MouseButton button, ButtonAction action,
            ModifierKey mods);

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
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPUTF8Str, SizeParamIndex = 1)]
            string[] paths);

        /// <summary>
        /// Returns the last reported state of a mouse button for the specified window.
        /// <para>This function returns the last state reported for the specified mouse button to the specified window.
        /// The returned state is one of <see cref="ButtonAction.Press"/> or <see cref="ButtonAction.Release"/>.</para>
        /// <para>If the <see cref="InputMode.StickyMouseButtons"/> input mode is enabled,
        /// this function returns <see cref="ButtonAction.Press"/> the first time you call it
        /// for a mouse button that was pressed, even if that mouse button has already been released.</para>
        /// </summary>
        /// <param name="window">The desired window.</param>
        /// <param name="button">The desired mouse button.</param>
        /// <returns>One of <see cref="ButtonAction.Press"/> or <see cref="ButtonAction.Release"/>.</returns>
        /// <remarks>Possible errors include
        /// <see cref="ErrorCode.NotInitialized"/> and <see cref="ErrorCode.InvalidEnum"/>.</remarks>
        [DllImport(DllName, EntryPoint = "glfwGetMouseButton")]
        public static extern ButtonAction GetMouseButton(IntPtr window, MouseButton button);

        /// <summary>
        /// Retrieves the position of the cursor relative to the client area of the window.
        /// <para>This function returns the position of the cursor, in screen coordinates,
        /// relative to the upper-left corner of the client area of the specified window.</para>
        /// <para>If the cursor is disabled (with <see cref="CursorMode.Disabled"/>)then the cursor position
        /// is unbounded and limited only by the minimum and maximum values of a double.</para>
        /// <para>The coordinate can be converted to their integer equivalents with the <c>floor</c> function.
        /// Casting directly to an integer type works for positive coordinates, but fails for negative ones.</para>
        /// <para>Any or all of the position arguments may be <c>null</c>.
        /// If an error occurs, all non-<c>null</c> position arguments will be set to zero.</para>
        /// </summary>
        /// <param name="window">The desired window.</param>
        /// <param name="xpos">Where to store the cursor x-coordinate,
        /// relative to the left edge of the client area.</param>
        /// <param name="ypos">Where to store the cursor y-coordinate,
        /// relative to the top edge of the client area.</param>
        /// <remarks>Possible errors include
        /// <see cref="ErrorCode.NotInitialized"/> and <see cref="ErrorCode.PlatformError"/>.</remarks>
        /// <seealso cref="SetCursorPos"/>
        [DllImport(DllName, EntryPoint = "glfwGetCursorPos")]
        public static extern void GetCursorPos(IntPtr window, out double xpos, out double ypos);

        /// <summary>
        /// Sets the position of the cursor, relative to the client area of the window.
        /// <para>This function sets the position, in screen coordinates,
        /// of the cursor relative to the upper-left corner of the client area of the specified window.
        /// The window must have input focus.
        /// If the window does not have input focus when this function is called, it fails silently.</para>
        /// <para>Do not use this function to implement things like camera controls.
        /// GLFW already provides the <see cref="CursorMode.Disabled"/> cursor mode that hides the cursor,
        /// transparently re-centers it and provides unconstrained cursor motion.
        /// See <see cref="SetInputMode"/> for more information.</para>
        /// <para>If the cursor mode is <see cref="CursorMode.Disabled"/> then the cursor position is unconstrained
        /// and limited only by the minimum and maximum values of a double.</para>
        /// </summary>
        /// <param name="window">The desired window.</param>
        /// <param name="xpos">The desired x-coordinate, relative to the left edge of the client area.</param>
        /// <param name="ypos">The desired y-coordinate, relative to the top edge of the client area.</param>
        /// <remarks>Possible errors include
        /// <see cref="ErrorCode.NotInitialized"/> and <see cref="ErrorCode.PlatformError"/>.</remarks>
        /// <seealso cref="GetCursorPos"/>
        [DllImport(DllName, EntryPoint = "glfwSetCursorPos")]
        public static extern void SetCursorPos(IntPtr window, double xpos, double ypos);

        /// <summary>
        /// Creates a custom cursor.
        /// <para>Creates a new custom cursor image that can be set for a window with glfwSetCursor.
        /// The cursor can be destroyed with glfwDestroyCursor.
        /// Any remaining cursors are destroyed by glfwTerminate.</para>
        /// <para>The pixels are 32-bit, little-endian, non-premultiplied RGBA, i.e. eight bits per channel.
        /// They are arranged canonically as packed sequential rows, starting from the top-left corner.</para>
        /// <para>The cursor hotspot is specified in pixels, relative to the upper-left corner of the cursor image.
        /// Like all other coordinate systems in GLFW, the X-axis points to the right and the Y-axis points down.</para>
        /// </summary>
        /// <param name="image">The desired cursor image.</param>
        /// <param name="xhot">The desired x-coordinate, in pixels, of the cursor hotspot.</param>
        /// <param name="yhot">The desired y-coordinate, in pixels, of the cursor hotspot. </param>
        /// <returns>The handle of the created cursor, or <c>null</c> if an error occurred.</returns>
        /// <remarks><para>Possible errors include
        /// <see cref="ErrorCode.NotInitialized"/> and <see cref="ErrorCode.PlatformError"/>.</para>
        /// <para>This function must not be called from a callback.</para></remarks>
        /// <seealso cref="DestroyCursor"/>
        /// <seealso cref="CreateStandardCursor"/>
        [DllImport(DllName, EntryPoint = "glfwCreateCursor")]
        public static extern IntPtr CreateCursor(IntPtr image, int xhot, int yhot);

        /// <summary>
        /// Creates a cursor with a standard shape.
        /// <para>Returns a cursor with a standard shape,
        /// that can be set for a window with <see cref="SetCursor"/>.</para>
        /// </summary>
        /// <param name="shape">One of the standard shapes.</param>
        /// <returns>A new cursor ready to use or <c>null</c> if an error occurred.</returns>
        /// <remarks><para>Possible errors include
        /// <see cref="ErrorCode.NotInitialized"/>, <see cref="ErrorCode.InvalidEnum"/>,
        /// and <see cref="ErrorCode.PlatformError"/>.</para>
        /// <para>This function must not be called from a callback.</para></remarks>
        /// <seealso cref="CreateCursor"/>
        [DllImport(DllName, EntryPoint = "glfwCreateStandardCursor")]
        public static extern IntPtr CreateStandardCursor(CursorShape shape);

        /// <summary>
        /// Destroys a cursor.
        /// <para>This function destroys a cursor previously created with <see cref="CreateCursor"/>.
        /// Any remaining cursors will be destroyed by <see cref="Terminate"/>.</para>
        /// </summary>
        /// <param name="cursor">The cursor object to destroy.</param>
        /// <remarks><para>Possible errors include
        /// <see cref="ErrorCode.NotInitialized"/> and <see cref="ErrorCode.PlatformError"/>.</para>
        /// <para>This function must not be called from a callback.</para></remarks>
        /// <seealso cref="CreateCursor"/>
        [DllImport(DllName, EntryPoint = "glfwDestroyCursor")]
        public static extern void DestroyCursor(IntPtr cursor);

        /// <summary>
        /// Sets the cursor for the window.
        /// <para>This function sets the cursor image to be used
        /// when the cursor is over the client area of the specified window.
        /// The set cursor will only be visible
        /// when the cursor mode of the window is <see cref="CursorMode.Normal"/>.</para>
        /// <para>On some platforms, the set cursor may not be visible unless the window also has input focus.</para>
        /// </summary>
        /// <param name="window">The window to set the cursor for.</param>
        /// <param name="cursor">The cursor to set, or <c>null</c> to switch back to the default arrow cursor.</param>
        /// <remarks>Possible errors include
        /// <see cref="ErrorCode.NotInitialized"/> and <see cref="ErrorCode.PlatformError"/>.</remarks>
        [DllImport(DllName, EntryPoint = "glfwSetCursor")]
        public static extern void SetCursor(IntPtr window, IntPtr cursor);

        /// <summary>
        /// Sets the mouse button callback.
        /// <para>This function sets the mouse button callback of the specified window,
        /// which is called when a mouse button is pressed or released.</para>
        /// <para>When a window loses input focus,
        /// it will generate synthetic mouse button release events for all pressed mouse buttons.
        /// You can tell these events from user-generated events
        /// by the fact that the synthetic ones are generated after the focus loss event has been processed,
        /// i.e. after the window focus callback has been called.</para>
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="cbfun">The new callback, or <c>null</c> to remove the currently set callback.</param>
        /// <returns>The previously set callback,
        /// or <c>null</c> if no callback was set or the library had not been initialized.</returns>
        /// <remarks>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</remarks>
        [DllImport(DllName, EntryPoint = "glfwSetMouseButtonCallback")]
        [return: MarshalAs(UnmanagedType.FunctionPtr)]
        public static extern MouseButtonCallback SetMouseButtonCallback(IntPtr window,
            [MarshalAs(UnmanagedType.FunctionPtr)] MouseButtonCallback cbfun);

        /// <summary>
        /// Sets the cursor position callback.
        /// <para>This function sets the cursor position callback of the specified window,
        /// which is called when the cursor is moved.
        /// The callback is provided with the position, in screen coordinates,
        /// relative to the upper-left corner of the client area of the window.</para>
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="cbfun">The new callback, or <c>null</c> to remove the currently set callback.</param>
        /// <returns>The previously set callback,
        /// or <c>null</c> if no callback was set or the library had not been initialized.</returns>
        /// <remarks>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</remarks>
        [DllImport(DllName, EntryPoint = "glfwSetCursorPosCallback")]
        [return: MarshalAs(UnmanagedType.FunctionPtr)]
        public static extern CursorPositionCallback SetCursorPosCallback(IntPtr window,
            [MarshalAs(UnmanagedType.FunctionPtr)] CursorPositionCallback cbfun);

        /// <summary>
        /// Sets the cursor enter/exit callback.
        /// <para>This function sets the cursor boundary crossing callback of the specified window,
        /// which is called when the cursor enters or leaves the client area of the window.</para>
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="cbfun">The new callback, or <c>null</c> to remove the currently set callback.</param>
        /// <returns>The previously set callback,
        /// or <c>null</c> if no callback was set or the library had not been initialized.</returns>
        /// <remarks>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</remarks>
        [DllImport(DllName, EntryPoint = "glfwSetCursorEnterCallback")]
        [return: MarshalAs(UnmanagedType.FunctionPtr)]
        public static extern CursorEnterCallback SetCursorEnterCallback(IntPtr window,
            [MarshalAs(UnmanagedType.FunctionPtr)] CursorEnterCallback cbfun);

        /// <summary>
        /// Sets the scroll callback.
        /// <para>This function sets the scroll callback of the specified window,
        /// which is called when a scrolling device is used,
        /// such as a mouse wheel or scrolling area of a touchpad.</para>
        /// <para>The scroll callback receives all scrolling input,
        /// like that from a mouse wheel or a touchpad scrolling area.</para>
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="cbfun">The new scroll callback, or <c>null</c> to remove the currently set callback.</param>
        /// <returns>The previously set callback,
        /// or <c>null</c> if no callback was set or the library had not been initialized.</returns>
        /// <remarks>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</remarks>
        [DllImport(DllName, EntryPoint = "glfwSetScrollCallback")]
        [return: MarshalAs(UnmanagedType.FunctionPtr)]
        public static extern ScrollCallback SetScrollCallback(IntPtr window,
            [MarshalAs(UnmanagedType.FunctionPtr)] ScrollCallback cbfun);

        /// <summary>
        /// Sets the file drop callback.
        /// <para>This function sets the file drop callback of the specified window,
        /// which is called when one or more dragged files are dropped on the window.</para>
        /// <para>Because the path array and its strings may have been generated specifically for that event,
        /// they are not guaranteed to be valid after the callback has returned.
        /// If you wish to use them after the callback returns, you need to make a deep copy.</para>
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="cbfun">The new file drop callback, or <c>null</c> to remove the currently set callback.</param>
        /// <returns>The previously set callback,
        /// or <c>null</c> if no callback was set or the library had not been initialized.</returns>
        /// <remarks>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</remarks>
        [DllImport(DllName, EntryPoint = "glfwSetDropCallback")]
        [return: MarshalAs(UnmanagedType.FunctionPtr)]
        public static extern DropCallback SetDropCallback(IntPtr window,
            [MarshalAs(UnmanagedType.FunctionPtr)] DropCallback cbfun);

        #endregion

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
        [DllImport(DllName, EntryPoint = "glfwGetInputMode")]
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
        [DllImport(DllName, EntryPoint = "glfwSetInputMode")]
        public static extern void SetInputMode(IntPtr window, InputMode mode, int value);

        /// <summary>
        /// Sets the clipboard to the specified string.
        /// </summary>
        /// <param name="window">The window that will own the clipboard contents.</param>
        /// <param name="string">A UTF-8 encoded string.</param>
        /// <remarks>Possible errors include
        /// <see cref="ErrorCode.NotInitialized"/> and <see cref="ErrorCode.PlatformError"/>.</remarks>
        /// <seealso cref="GetClipboardString"/>
        [DllImport(DllName, EntryPoint = "glfwSetClipboardString")]
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
        [DllImport(DllName, EntryPoint = "glfwGetClipboardString")]
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
        [DllImport(DllName, EntryPoint = "glfwGetTime")]
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
        [DllImport(DllName, EntryPoint = "glfwSetTime")]
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
        [DllImport(DllName, EntryPoint = "glfwGetTimerValue")]
        public static extern ulong GetTimerValue();

        /// <summary>
        /// Returns the frequency, in Hz, of the raw timer.
        /// </summary>
        /// <returns>The frequency of the timer, in Hz, or zero if an error occurred.</returns>
        /// <remarks>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</remarks>
        /// <seealso cref="GetTimerValue"/>
        [DllImport(DllName, EntryPoint = "glfwGetTimerFrequency")]
        public static extern ulong GetTimerFrequency();
    }
}