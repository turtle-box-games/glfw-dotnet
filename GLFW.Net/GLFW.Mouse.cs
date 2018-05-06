using System;
using System.Runtime.InteropServices;
using System.Security;

namespace GLFW.Net
{
    public static partial class GLFW
    {
        /// <summary>
        /// The function signature for mouse button callbacks.
        /// </summary>
        /// <param name="window">The window that received the event.</param>
        /// <param name="button">The mouse button that was pressed or released.</param>
        /// <param name="state">One of <see cref="MouseButtonState.Press"/>
        /// or <see cref="MouseButtonState.Release"/>.</param>
        /// <param name="mods">Bit field describing which modifier keys were held down.</param>
        /// <seealso cref="SetMouseButtonCallback"/>
        public delegate void MouseButtonCallback(IntPtr window, MouseButton button, MouseButtonState state,
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
        /// <param name="entered"><c>true</c> if the cursor entered the window's client area,
        /// or <c>false</c> if it left it.</param>
        /// <seealso cref="SetCursorEnterCallback"/>
        public delegate void CursorEnterCallback(IntPtr window, [MarshalAs(UnmanagedType.Bool)] bool entered);

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
        /// <para>This function returns the last state reported
        /// for the specified mouse button to the specified window.
        /// The returned state is one of <see cref="MouseButtonState.Press"/>
        /// or <see cref="MouseButtonState.Release"/>.</para>
        /// <para>If the <see cref="InputMode.StickyMouseButtons"/> input mode is enabled,
        /// this function returns <see cref="MouseButtonState.Press"/> the first time you call it
        /// for a mouse button that was pressed, even if that mouse button has already been released.</para>
        /// </summary>
        /// <param name="window">The desired window.</param>
        /// <param name="button">The desired mouse button.</param>
        /// <returns>One of <see cref="MouseButtonState.Press"/> or <see cref="MouseButtonState.Release"/>.</returns>
        /// <exception cref="NotInitializedGLFWException">GLFW is not initialized.</exception>
        /// <exception cref="InvalidEnumGLFWException">The <paramref name="button"/> is invalid.</exception>
        public static MouseButtonState GetMouseButton(IntPtr window, MouseButton button)
        {
            var buttonState = Internal.GetMouseButton(window, (int) button);
            HandleError();
            return (MouseButtonState) buttonState;
        }

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
        /// <exception cref="NotInitializedGLFWException">GLFW is not initialized.</exception>
        /// <exception cref="PlatformErrorGLFWException">This operation is not supported on this platform.</exception>
        /// <seealso cref="SetCursorPos"/>
        public static void GetCursorPos(IntPtr window, out double xpos, out double ypos)
        {
            Internal.GetCursorPos(window, out xpos, out ypos);
            HandleError();
        }

        /// <summary>
        /// Sets the position of the cursor, relative to the client area of the window.
        /// <para>This function sets the position, in screen coordinates,
        /// of the cursor relative to the upper-left corner of the client area of the specified window.
        /// The window must have input focus.
        /// If the window does not have input focus when this function is called, it fails silently.</para>
        /// <para>Do not use this function to implement things like camera controls.
        /// GLFW already provides the <see cref="CursorMode.Disabled"/> cursor mode that hides the cursor,
        /// transparently re-centers it and provides unconstrained cursor motion.
        /// See <see cref="SetCursorMode"/> for more information.</para>
        /// <para>If the cursor mode is <see cref="CursorMode.Disabled"/> then the cursor position is unconstrained
        /// and limited only by the minimum and maximum values of a double.</para>
        /// </summary>
        /// <param name="window">The desired window.</param>
        /// <param name="xpos">The desired x-coordinate, relative to the left edge of the client area.</param>
        /// <param name="ypos">The desired y-coordinate, relative to the top edge of the client area.</param>
        /// <exception cref="NotInitializedGLFWException">GLFW is not initialized.</exception>
        /// <exception cref="PlatformErrorGLFWException">This operation is not supported on this platform.</exception>
        /// <seealso cref="GetCursorPos"/>
        public static void SetCursorPos(IntPtr window, double xpos, double ypos)
        {
            Internal.SetCursorPos(window, xpos, ypos);
            HandleError();
        }

        /// <summary>
        /// Creates a custom cursor.
        /// <para>Creates a new custom cursor image that can be set for a window with <see cref="SetCursor"/>.
        /// The cursor can be destroyed with <see cref="DestroyCursor"/>.
        /// Any remaining cursors are destroyed by <see cref="Terminate"/>.</para>
        /// <para>The pixels are 32-bit, little-endian, non-premultiplied RGBA, i.e. eight bits per channel.
        /// They are arranged canonically as packed sequential rows, starting from the top-left corner.</para>
        /// <para>The cursor hotspot is specified in pixels, relative to the upper-left corner of the cursor image.
        /// Like all other coordinate systems in GLFW,
        /// the X-axis points to the right and the Y-axis points down.</para>
        /// </summary>
        /// <param name="image">The desired cursor image.</param>
        /// <param name="xhot">The desired x-coordinate, in pixels, of the cursor hotspot.</param>
        /// <param name="yhot">The desired y-coordinate, in pixels, of the cursor hotspot. </param>
        /// <returns>The handle of the created cursor, or <c>null</c> if an error occurred.</returns>
        /// <remarks>This function must not be called from a callback.</remarks>
        /// <exception cref="NotInitializedGLFWException">GLFW is not initialized.</exception>
        /// <exception cref="PlatformErrorGLFWException">This operation is not supported on this platform.</exception>
        /// <seealso cref="DestroyCursor"/>
        /// <seealso cref="CreateStandardCursor"/>
        public static IntPtr CreateCursor(IntPtr image, int xhot, int yhot)
        {
            var cursorPointer = Internal.CreateCursor(image, xhot, yhot);
            HandleError();
            return cursorPointer;
        }

        /// <summary>
        /// Creates a cursor with a standard shape.
        /// <para>Returns a cursor with a standard shape,
        /// that can be set for a window with <see cref="SetCursor"/>.</para>
        /// </summary>
        /// <param name="shape">One of the standard shapes.</param>
        /// <returns>A new cursor ready to use or <c>null</c> if an error occurred.</returns>
        /// <remarks>This function must not be called from a callback.</remarks>
        /// <exception cref="NotInitializedGLFWException">GLFW is not initialized.</exception>
        /// <exception cref="PlatformErrorGLFWException">This operation is not supported on this platform.</exception>
        /// <exception cref="InvalidEnumGLFWException">The <paramref name="shape"/> is not supported.</exception>
        /// <seealso cref="CreateCursor"/>
        public static IntPtr CreateStandardCursor(CursorShape shape)
        {
            var cursorPointer = Internal.CreateStandardCursor((int) shape);
            HandleError();
            return cursorPointer;
        }

        /// <summary>
        /// Destroys a cursor.
        /// <para>This function destroys a cursor previously created with <see cref="CreateCursor"/>.
        /// Any remaining cursors will be destroyed by <see cref="Terminate"/>.</para>
        /// </summary>
        /// <param name="cursor">The cursor object to destroy.</param>
        /// <remarks>This function must not be called from a callback.</remarks>
        /// <exception cref="NotInitializedGLFWException">GLFW is not initialized.</exception>
        /// <exception cref="PlatformErrorGLFWException">This operation is not supported on this platform.</exception>
        /// <seealso cref="CreateCursor"/>
        public static void DestroyCursor(IntPtr cursor)
        {
            Internal.DestroyCursor(cursor);
            HandleError();
        }

        /// <summary>
        /// Sets the cursor for the window.
        /// <para>This function sets the cursor image to be used
        /// when the cursor is over the client area of the specified window.
        /// The set cursor will only be visible
        /// when the cursor mode of the window is <see cref="CursorMode.Normal"/>.</para>
        /// <para>On some platforms,
        /// the set cursor may not be visible unless the window also has input focus.</para>
        /// </summary>
        /// <param name="window">The window to set the cursor for.</param>
        /// <param name="cursor">The cursor to set,
        /// or <c>null</c> to switch back to the default arrow cursor.</param>
        /// <exception cref="NotInitializedGLFWException">GLFW is not initialized.</exception>
        /// <exception cref="PlatformErrorGLFWException">This operation is not supported on this platform.</exception>
        public static void SetCursor(IntPtr window, IntPtr cursor)
        {
            Internal.SetCursor(window, cursor);
            HandleError();
        }

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
        /// <param name="callback">The new callback, or <c>null</c> to remove the currently set callback.</param>
        /// <returns>The previously set callback,
        /// or <c>null</c> if no callback was set or the library had not been initialized.</returns>
        /// <exception cref="NotInitializedGLFWException">GLFW is not initialized.</exception>
        public static MouseButtonCallback SetMouseButtonCallback(IntPtr window, MouseButtonCallback callback)
        {
            return SetInternalCallback(Internal.SetMouseButtonCallback, callback, window);
        }

        /// <summary>
        /// Sets the cursor position callback.
        /// <para>This function sets the cursor position callback of the specified window,
        /// which is called when the cursor is moved.
        /// The callback is provided with the position, in screen coordinates,
        /// relative to the upper-left corner of the client area of the window.</para>
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="callback">The new callback, or <c>null</c> to remove the currently set callback.</param>
        /// <returns>The previously set callback,
        /// or <c>null</c> if no callback was set or the library had not been initialized.</returns>
        /// <exception cref="NotInitializedGLFWException">GLFW is not initialized.</exception>
        public static CursorPositionCallback SetCursorPosCallback(IntPtr window, CursorPositionCallback callback)
        {
            return SetInternalCallback(Internal.SetCursorPosCallback, callback, window);
        }

        /// <summary>
        /// Sets the cursor enter/exit callback.
        /// <para>This function sets the cursor boundary crossing callback of the specified window,
        /// which is called when the cursor enters or leaves the client area of the window.</para>
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="callback">The new callback, or <c>null</c> to remove the currently set callback.</param>
        /// <returns>The previously set callback,
        /// or <c>null</c> if no callback was set or the library had not been initialized.</returns>
        /// <exception cref="NotInitializedGLFWException">GLFW is not initialized.</exception>
        public static CursorEnterCallback SetCursorEnterCallback(IntPtr window, CursorEnterCallback callback)
        {
            return SetInternalCallback(Internal.SetCursorEnterCallback, callback, window);
        }

        /// <summary>
        /// Sets the scroll callback.
        /// <para>This function sets the scroll callback of the specified window,
        /// which is called when a scrolling device is used,
        /// such as a mouse wheel or scrolling area of a touchpad.</para>
        /// <para>The scroll callback receives all scrolling input,
        /// like that from a mouse wheel or a touchpad scrolling area.</para>
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="callback">The new scroll callback,
        /// or <c>null</c> to remove the currently set callback.</param>
        /// <returns>The previously set callback,
        /// or <c>null</c> if no callback was set or the library had not been initialized.</returns>
        /// <exception cref="NotInitializedGLFWException">GLFW is not initialized.</exception>
        public static ScrollCallback SetScrollCallback(IntPtr window, ScrollCallback callback)
        {
            return SetInternalCallback(Internal.SetScrollCallback, callback, window);
        }

        /// <summary>
        /// Sets the file drop callback.
        /// <para>This function sets the file drop callback of the specified window,
        /// which is called when one or more dragged files are dropped on the window.</para>
        /// <para>Because the path array and its strings may have been generated specifically for that event,
        /// they are not guaranteed to be valid after the callback has returned.
        /// If you wish to use them after the callback returns, you need to make a deep copy.</para>
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="callback">The new file drop callback,
        /// or <c>null</c> to remove the currently set callback.</param>
        /// <returns>The previously set callback,
        /// or <c>null</c> if no callback was set or the library had not been initialized.</returns>
        /// <exception cref="NotInitializedGLFWException">GLFW is not initialized.</exception>
        public static DropCallback SetDropCallback(IntPtr window, DropCallback callback)
        {
            return SetInternalCallback(Internal.SetDropCallback, callback, window);
        }
        
        private static partial class Internal
        {
            /// <summary>
            /// Returns the last reported state of a mouse button for the specified window.
            /// <para>This function returns the last state reported
            /// for the specified mouse button to the specified window.
            /// The returned state is one of <see cref="MouseButtonState.Press"/>
            /// or <see cref="MouseButtonState.Release"/>.</para>
            /// <para>If the <see cref="InputMode.StickyMouseButtons"/> input mode is enabled,
            /// this function returns <see cref="MouseButtonState.Press"/> the first time you call it
            /// for a mouse button that was pressed, even if that mouse button has already been released.</para>
            /// </summary>
            /// <param name="window">The desired window.</param>
            /// <param name="button">The desired mouse button.</param>
            /// <returns>One of <see cref="MouseButtonState.Press"/>
            /// or <see cref="MouseButtonState.Release"/>.</returns>
            /// <remarks>Possible errors include
            /// <see cref="ErrorCode.NotInitialized"/> and <see cref="ErrorCode.InvalidEnum"/>.</remarks>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwGetMouseButton", CallingConvention = CallingConvention.Cdecl)]
            public static extern int GetMouseButton(IntPtr window, int button);

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
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwGetCursorPos", CallingConvention = CallingConvention.Cdecl)]
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
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwSetCursorPos", CallingConvention = CallingConvention.Cdecl)]
            public static extern void SetCursorPos(IntPtr window, double xpos, double ypos);

            /// <summary>
            /// Creates a custom cursor.
            /// <para>Creates a new custom cursor image that can be set for a window with <see cref="SetCursor"/>.
            /// The cursor can be destroyed with <see cref="DestroyCursor"/>.
            /// Any remaining cursors are destroyed by <see cref="Terminate"/>.</para>
            /// <para>The pixels are 32-bit, little-endian, non-premultiplied RGBA, i.e. eight bits per channel.
            /// They are arranged canonically as packed sequential rows, starting from the top-left corner.</para>
            /// <para>The cursor hotspot is specified in pixels, relative to the upper-left corner of the cursor image.
            /// Like all other coordinate systems in GLFW,
            /// the X-axis points to the right and the Y-axis points down.</para>
            /// </summary>
            /// <param name="image">The desired cursor image.</param>
            /// <param name="xhot">The desired x-coordinate, in pixels, of the cursor hotspot.</param>
            /// <param name="yhot">The desired y-coordinate, in pixels, of the cursor hotspot. </param>
            /// <returns>The handle of the created cursor, or <see cref="IntPtr.Zero"/> if an error occurred.</returns>
            /// <remarks><para>Possible errors include
            /// <see cref="ErrorCode.NotInitialized"/> and <see cref="ErrorCode.PlatformError"/>.</para>
            /// <para>This function must not be called from a callback.</para></remarks>
            /// <seealso cref="DestroyCursor"/>
            /// <seealso cref="CreateStandardCursor"/>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwCreateCursor", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr CreateCursor(IntPtr image, int xhot, int yhot);

            /// <summary>
            /// Creates a cursor with a standard shape.
            /// <para>Returns a cursor with a standard shape,
            /// that can be set for a window with <see cref="SetCursor"/>.</para>
            /// </summary>
            /// <param name="shape">One of the standard shapes.</param>
            /// <returns>A new cursor ready to use or <see cref="IntPtr.Zero"/> if an error occurred.</returns>
            /// <remarks><para>Possible errors include
            /// <see cref="ErrorCode.NotInitialized"/>, <see cref="ErrorCode.InvalidEnum"/>,
            /// and <see cref="ErrorCode.PlatformError"/>.</para>
            /// <para>This function must not be called from a callback.</para></remarks>
            /// <seealso cref="CreateCursor"/>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwCreateStandardCursor", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr CreateStandardCursor(int shape);

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
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwDestroyCursor", CallingConvention = CallingConvention.Cdecl)]
            public static extern void DestroyCursor(IntPtr cursor);

            /// <summary>
            /// Sets the cursor for the window.
            /// <para>This function sets the cursor image to be used
            /// when the cursor is over the client area of the specified window.
            /// The set cursor will only be visible
            /// when the cursor mode of the window is <see cref="CursorMode.Normal"/>.</para>
            /// <para>On some platforms,
            /// the set cursor may not be visible unless the window also has input focus.</para>
            /// </summary>
            /// <param name="window">The window to set the cursor for.</param>
            /// <param name="cursor">The cursor to set,
            /// or <see cref="IntPtr.Zero"/> to switch back to the default arrow cursor.</param>
            /// <remarks>Possible errors include
            /// <see cref="ErrorCode.NotInitialized"/> and <see cref="ErrorCode.PlatformError"/>.</remarks>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwSetCursor", CallingConvention = CallingConvention.Cdecl)]
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
            /// <param name="cbfun">The new callback,
            /// or <see cref="IntPtr.Zero"/> to remove the currently set callback.</param>
            /// <returns>The previously set callback,
            /// or <see cref="IntPtr.Zero"/> if no callback was set or the library had not been initialized.</returns>
            /// <remarks>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</remarks>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwSetMouseButtonCallback", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr SetMouseButtonCallback(IntPtr window, IntPtr cbfun);

            /// <summary>
            /// Sets the cursor position callback.
            /// <para>This function sets the cursor position callback of the specified window,
            /// which is called when the cursor is moved.
            /// The callback is provided with the position, in screen coordinates,
            /// relative to the upper-left corner of the client area of the window.</para>
            /// </summary>
            /// <param name="window">The window whose callback to set.</param>
            /// <param name="cbfun">The new callback,
            /// or <see cref="IntPtr.Zero"/> to remove the currently set callback.</param>
            /// <returns>The previously set callback,
            /// or <see cref="IntPtr.Zero"/> if no callback was set or the library had not been initialized.</returns>
            /// <remarks>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</remarks>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwSetCursorPosCallback", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr SetCursorPosCallback(IntPtr window, IntPtr cbfun);

            /// <summary>
            /// Sets the cursor enter/exit callback.
            /// <para>This function sets the cursor boundary crossing callback of the specified window,
            /// which is called when the cursor enters or leaves the client area of the window.</para>
            /// </summary>
            /// <param name="window">The window whose callback to set.</param>
            /// <param name="cbfun">The new callback,
            /// or <see cref="IntPtr.Zero"/> to remove the currently set callback.</param>
            /// <returns>The previously set callback,
            /// or <see cref="IntPtr.Zero"/> if no callback was set or the library had not been initialized.</returns>
            /// <remarks>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</remarks>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwSetCursorEnterCallback", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr SetCursorEnterCallback(IntPtr window, IntPtr cbfun);

            /// <summary>
            /// Sets the scroll callback.
            /// <para>This function sets the scroll callback of the specified window,
            /// which is called when a scrolling device is used,
            /// such as a mouse wheel or scrolling area of a touchpad.</para>
            /// <para>The scroll callback receives all scrolling input,
            /// like that from a mouse wheel or a touchpad scrolling area.</para>
            /// </summary>
            /// <param name="window">The window whose callback to set.</param>
            /// <param name="cbfun">The new scroll callback,
            /// or <see cref="IntPtr.Zero"/> to remove the currently set callback.</param>
            /// <returns>The previously set callback,
            /// or <see cref="IntPtr.Zero"/> if no callback was set or the library had not been initialized.</returns>
            /// <remarks>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</remarks>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwSetScrollCallback", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr SetScrollCallback(IntPtr window, IntPtr cbfun);

            /// <summary>
            /// Sets the file drop callback.
            /// <para>This function sets the file drop callback of the specified window,
            /// which is called when one or more dragged files are dropped on the window.</para>
            /// <para>Because the path array and its strings may have been generated specifically for that event,
            /// they are not guaranteed to be valid after the callback has returned.
            /// If you wish to use them after the callback returns, you need to make a deep copy.</para>
            /// </summary>
            /// <param name="window">The window whose callback to set.</param>
            /// <param name="cbfun">The new file drop callback,
            /// or <see cref="IntPtr.Zero"/> to remove the currently set callback.</param>
            /// <returns>The previously set callback,
            /// or <see cref="IntPtr.Zero"/> if no callback was set or the library had not been initialized.</returns>
            /// <remarks>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</remarks>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwSetDropCallback", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr SetDropCallback(IntPtr window, IntPtr cbfun);
        }
    }
}