using System;
using System.Runtime.InteropServices;
using System.Security;

namespace GLFW.Net
{
    public static partial class GLFW
    {
        /// <summary>
        /// The function signature for keyboard key callbacks.
        /// </summary>
        /// <param name="window">The window that received the event.</param>
        /// <param name="key">The keyboard key that was pressed or released.</param>
        /// <param name="scancode">The system-specific scancode of the key.</param>
        /// <param name="action">One of <see cref="KeyAction"/>.</param>
        /// <param name="mods">Bit field describing which modifier keys were held down.</param>
        /// <seealso cref="SetKeyCallback"/>
        internal delegate void KeyCallback(IntPtr window, Key key, int scancode, KeyAction action, ModifierKey mods);

        /// <summary>
        /// The function signature for Unicode character callbacks.
        /// </summary>
        /// <param name="window">The window that received the event.</param>
        /// <param name="codepoint">The Unicode code point of the character.</param>
        /// <seealso cref="SetCharacterCallback"/>
        internal delegate void CharacterCallback(IntPtr window, uint codepoint);

        /// <summary>
        /// The function signature for Unicode character with modifiers callbacks.
        /// <para>This is the function signature for Unicode character with modifiers callback functions.
        /// It is called for each input character, regardless of what modifier keys are held down.</para>
        /// </summary>
        /// <param name="window">The window that received the event.</param>
        /// <param name="codepoint">The Unicode code point of the character. </param>
        /// <param name="mods">Bit field describing which modifier keys were held down.</param>
        /// <seealso cref="SetCharacterModifierCallback"/>
        internal delegate void CharacterModifierCallback(IntPtr window, uint codepoint, ModifierKey mods);

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
        /// <exception cref="NotInitializedGLFWException">GLFW is not initialized.</exception>
        /// <exception cref="PlatformErrorGLFWException">This operation is not supported on this platform.</exception>
        internal static string GetKeyName(Key key, int scancode)
        {
            var result = Internal.GetKeyName((int) key, scancode);
            HandleError();
            return result.FromNativeUtf8();
        }

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
        /// <exception cref="NotInitializedGLFWException">GLFW is not initialized.</exception>
        /// <exception cref="InvalidEnumGLFWException">The <paramref name="key"/> provided is invalid.</exception>
        /// <exception cref="PlatformErrorGLFWException">This operation is not supported on this platform.</exception>
        internal static KeyAction GetKey(IntPtr window, Key key)
        {
            var result = Internal.GetKey(window, (int) key);
            HandleError();
            return (KeyAction) result;
        }

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
        /// <param name="callback">The new key callback, or <c>null</c> to remove the currently set callback.</param>
        /// <returns>The previously set callback,
        /// or <c>null</c> if no callback was set or the library had not been initialized.</returns>
        /// <exception cref="NotInitializedGLFWException">GLFW is not initialized.</exception>
        internal static KeyCallback SetKeyCallback(IntPtr window, KeyCallback callback)
        {
            return SetInternalCallback(Internal.SetKeyCallback, callback, window);
        }

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
        /// <param name="callback">The new callback, or <c>null</c> to remove the currently set callback.</param>
        /// <returns>The previously set callback,
        /// or <c>null</c> if no callback was set or the library had not been initialized.</returns>
        /// <remarks>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</remarks>
        internal static CharacterCallback SetCharacterCallback(IntPtr window, CharacterCallback callback)
        {
            return SetInternalCallback(Internal.SetCharCallback, callback, window);
        }

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
        /// <param name="callback">The new callback, or <c>null</c> to remove the currently set callback.</param>
        /// <returns>The previously set callback,
        /// or <c>null</c> if no callback was set or the library had not been initialized.</returns>
        /// <remarks>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</remarks>
        internal static CharacterModifierCallback SetCharacterModifierCallback(IntPtr window,
            CharacterModifierCallback callback)
        {
            return SetInternalCallback(Internal.SetCharModsCallback, callback, window);
        }

        private static partial class Internal
        {
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
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwGetKeyName", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr GetKeyName(int key, int scancode);

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
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwGetKey", CallingConvention = CallingConvention.Cdecl)]
            public static extern int GetKey(IntPtr window, int key);

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
            /// <param name="cbfun">The new key callback,
            /// or <see cref="IntPtr.Zero"/> to remove the currently set callback.</param>
            /// <returns>The previously set callback,
            /// or <see cref="IntPtr.Zero"/> if no callback was set or the library had not been initialized.</returns>
            /// <remarks>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</remarks>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwSetKeyCallback", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr SetKeyCallback(IntPtr window, IntPtr cbfun);

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
            /// <param name="cbfun">The new callback,
            /// or <see cref="IntPtr.Zero"/> to remove the currently set callback.</param>
            /// <returns>The previously set callback,
            /// or <see cref="IntPtr.Zero"/> if no callback was set or the library had not been initialized.</returns>
            /// <remarks>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</remarks>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwSetCharCallback", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr SetCharCallback(IntPtr window, IntPtr cbfun);

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
            /// <param name="cbfun">The new callback,
            /// or <see cref="IntPtr.Zero"/> to remove the currently set callback.</param>
            /// <returns>The previously set callback,
            /// or <see cref="IntPtr.Zero"/> if no callback was set or an error occurred.</returns>
            /// <remarks>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</remarks>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwSetCharModsCallback", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr SetCharModsCallback(IntPtr window, IntPtr cbfun);
        }
    }
}