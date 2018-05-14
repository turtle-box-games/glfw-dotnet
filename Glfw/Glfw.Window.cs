using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Glfw3
{
    public static partial class Glfw
    {
        /// <summary>
        /// The function signature for window position callbacks.
        /// </summary>
        /// <param name="window">The window that was moved.</param>
        /// <param name="x">The new x-coordinate, in screen coordinates,
        /// of the upper-left corner of the client area of the window.</param>
        /// <param name="y">The new y-coordinate, in screen coordinates,
        /// of the upper-left corner of the client area of the window.</param>
        /// <seealso cref="SetWindowPosCallback"/>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void WindowPosCallback(IntPtr window, int x, int y);

        /// <summary>
        /// The function signature for window resize callbacks.
        /// </summary>
        /// <param name="window">The window that was resized.</param>
        /// <param name="width">The new width, in screen coordinates, of the window.</param>
        /// <param name="height">The new height, in screen coordinates, of the window.</param>
        /// <seealso cref="SetWindowSizeCallback"/>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void WindowSizeCallback(IntPtr window, int width, int height);

        /// <summary>
        /// The function signature for window close callbacks.
        /// </summary>
        /// <param name="window">The window that the user attempted to close.</param>
        /// <seealso cref="SetWindowCloseCallback"/>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void WindowCloseCallback(IntPtr window);

        /// <summary>
        /// The function signature for window content refresh callbacks.
        /// </summary>
        /// <param name="window">The window whose content needs to be refreshed.</param>
        /// <seealso cref="SetWindowRefreshCallback"/>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void WindowRefreshCallback(IntPtr window);

        /// <summary>
        /// The function signature for window focus/defocus callbacks.
        /// </summary>
        /// <param name="window">The window that gained or lost input focus.</param>
        /// <param name="focused"><c>true</c> if the window was given input focus,
        /// or <c>false</c> if it lost it.</param>
        /// <seealso cref="SetWindowFocusCallback"/>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void WindowFocusCallback(IntPtr window, [MarshalAs(UnmanagedType.Bool)] bool focused);

        /// <summary>
        /// The function signature for window iconify/restore callbacks.
        /// </summary>
        /// <param name="window">The window that was iconified or restored.</param>
        /// <param name="iconified"><c>true</c> if the window was iconified,
        /// or <c>false</c> if it was restored.</param>
        /// <seealso cref="SetWindowIconifyCallback"/>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void WindowIconifyCallback(IntPtr window, [MarshalAs(UnmanagedType.Bool)] bool iconified);

        /// <summary>
        /// The function signature for framebuffer resize callbacks.
        /// </summary>
        /// <param name="window">The window whose framebuffer was resized.</param>
        /// <param name="width">The new width, in pixels, of the framebuffer.</param>
        /// <param name="height">The new height, in pixels, of the framebuffer.</param>
        /// <seealso cref="SetFrameBufferSizeCallback"/>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void FrameBufferSizeCallback(IntPtr window, int width, int height);

        /// <summary>
        /// Resets all window hints to their default values.
        /// </summary>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        /// <seealso cref="WindowHint"/>
        public static void DefaultWindowHints()
        {
            Internal.DefaultWindowHints();
            HandleError();
        }

        /// <summary>
        /// Sets the specified window hint to the desired value.
        /// <para>This function sets hints for the next call to <see cref="CreateWindow"/>.
        /// The hints, once set, retain their values
        /// until changed by a call to <see cref="WindowHint"/> or <see cref="DefaultWindowHints"/>,
        /// or until the library is terminated.</para>
        /// <para>This function does not check whether the specified hint values are valid.
        /// If you set hints to invalid values
        /// this will instead be reported by the next call to <see cref="CreateWindow"/>.</para>
        /// </summary>
        /// <param name="hint">The window hint to set.</param>
        /// <param name="value">The new value of the window hint.</param>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        /// <exception cref="InvalidEnumGlfwException">The value provided for <paramref name="hint"/>
        /// or <paramref name="value"/> is invalid.</exception>
        /// <seealso cref="DefaultWindowHints"/>
        public static void WindowHint(WindowHint hint, int value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a window and its associated context.
        /// <para>This function creates a window and its associated OpenGL or OpenGL ES context.
        /// Most of the options controlling how the window and its context should be created
        /// are specified with window hints.</para>
        /// <para>Successful creation does not change which context is current.
        /// Before you can use the newly created context, you need to make it current.
        /// For information about the <paramref name="share"/> parameter, see Context object sharing.</para>
        /// <para>The created window, framebuffer and context may differ from what you requested,
        /// as not all parameters and hints are hard constraints.
        /// This includes the size of the window, especially for full screen windows.
        /// To query the actual attributes of the created window, framebuffer and context,
        /// see <see cref="GetWindowAttrib"/>, <see cref="GetWindowSize"/> and <see cref="GetFramebufferSize"/>.</para>
        /// <para>To create a full screen window, you need to specify the monitor the window will cover.
        /// If no monitor is specified, the window will be windowed mode.
        /// Unless you have a way for the user to choose a specific monitor,
        /// it is recommended that you pick the primary monitor.
        /// For more information on how to query connected monitors, see Retrieving monitors.</para>
        /// <para>For full screen windows,the specified size becomes the resolution of the window's desired video mode.
        /// As long as a full screen window is not iconified,
        /// the supported video mode most closely matching the desired video mode is set for the specified monitor.
        /// For more information about full screen windows,
        /// including the creation of so called windowed full screen or borderless full screen windows,
        /// see "Windowed full screen" windows.</para>
        /// <para>Once you have created the window,
        /// you can switch it between windowed and full screen mode with <see cref="SetWindowMonitor"/>.
        /// If the window has an OpenGL or OpenGL ES context, it will be unaffected.</para>
        /// <para>By default, newly created windows use the placement recommended by the window system.
        /// To create the window at a specific position,
        /// make it initially invisible using the <see cref="Glfw3.WindowHint.Visible"/> window hint,
        /// set its position and then show it.</para>
        /// <para>As long as at least one full screen window is not iconified,
        /// the screensaver is prohibited from starting.</para>
        /// <para>Window systems put limits on window sizes.
        /// Very large or very small window dimensions may be overridden by the window system on creation.
        /// Check the actual size after creation.</para>
        /// <para>The swap interval is not set during window creation
        /// and the initial value may vary depending on driver settings and defaults.</para>
        /// </summary>
        /// <param name="width">The desired width, in screen coordinates, of the window.
        /// This must be greater than zero.</param>
        /// <param name="height">The desired height, in screen coordinates, of the window.
        /// This must be greater than zero.</param>
        /// <param name="title">The initial window title.</param>
        /// <param name="monitor">The monitor to use for full screen mode, or <c>null</c> for windowed mode.</param>
        /// <param name="share">The window whose context to share resources with,
        /// or <c>null</c> to not share resources.</param>
        /// <returns>The handle of the created window, or <c>null</c> if an error occurred.</returns>
        /// <remarks><para>This function must not be called from a callback.</para>
        /// <para>Windows: Window creation will fail
        /// if the Microsoft GDI software OpenGL implementation is the only one available.</para>
        /// <para>Windows: If the executable has an icon resource named <c>Icon</c>,
        /// it will be set as the initial icon for the window.
        /// If no such icon is present, the <c>IDI_WINLOGO</c> icon will be used instead.
        /// To set a different icon, see <see cref="SetWindowIcon"/>.</para>
        /// <para>Windows: The context to share resources with must not be current on any other thread.</para>
        /// <para>OS X: The GLFW window has no icon, as it is not a document window,
        /// but the dock icon will be the same as the application bundle's icon.
        /// For more information on bundles, see the Bundle Programming Guide in the Mac Developer Library.</para>
        /// <para>OS X: The first time a window is created the menu bar is populated with common commands
        /// like Hide, Quit and About.
        /// The About entry opens a minimal about dialog with information from the application's bundle.
        /// The menu bar can be disabled with a compile-time option.</para>
        /// <para>OS X: On OS X 10.10 and later the window frame will not be rendered at full resolution
        /// on Retina displays unless the <c>NSHighResolutionCapable</c> key is enabled
        /// in the application bundle's <c>Info.plist</c>.
        /// For more information, see High Resolution Guidelines for OS X in the Mac Developer Library.
        /// The GLFW test and example programs use a custom <c>Info.plist</c> template for this,
        /// which can be found as <c>CMake/MacOSXBundleInfo.plist.in</c> in the source tree.</para>
        /// <para>X11: Some window managers will not respect the placement of initially hidden windows.</para>
        /// <para>X11: Due to the asynchronous nature of X11,
        /// it may take a moment for a window to reach its requested state.
        /// This means you may not be able to query the final size,
        /// position or other attributes directly after window creation.</para></remarks>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        /// <exception cref="PlatformErrorGlfwException">This operation is not supported on this platform.</exception>
        /// <exception cref="InvalidEnumGlfwException">One of the window hints is invalid.</exception>
        /// <exception cref="InvalidValueGlfwException">The <paramref name="width"/> or <paramref name="height"/>
        /// must be larger than zero.</exception>
        /// <exception cref="ApiUnavailableGlfwException">The specified API is unavailable on this system.</exception>
        /// <exception cref="VersionUnavailableGlfwException">The specified OpenGL version is unavailable.</exception>
        /// <exception cref="FormatUnavailableGlfwException">The specified video mode is unavailable.</exception>
        /// <seealso cref="DestroyWindow"/>
        public static IntPtr CreateWindow(int width, int height, string title, IntPtr monitor, IntPtr share)
        {
            var titlePointer  = title.ToNativeUtf8();
            var windowPointer = Internal.CreateWindow(width, height, titlePointer, monitor, share);
            HandleError();
            return windowPointer;
        }

        /// <summary>
        /// Destroys the specified window and its context.
        /// <para>This function destroys the specified window and its context.
        /// On calling this function, no further callbacks will be called for that window.</para>
        /// <para>If the context of the specified window is current on the main thread,
        /// it is detached before being destroyed.</para>
        /// </summary>
        /// <param name="window">The window to destroy.</param>
        /// <remarks><para>The context of the specified window must not be current on any other thread
        /// when this function is called.</para>
        /// <para>This function must not be called from a callback.</para></remarks>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        /// <exception cref="PlatformErrorGlfwException">This operation is not supported on this platform.</exception>
        /// <seealso cref="CreateWindow"/>
        public static void DestroyWindow(IntPtr window)
        {
            Internal.DestroyWindow(window);
            HandleError();
        }

        /// <summary>
        /// Checks the close flag of the specified window.
        /// </summary>
        /// <param name="window">The window to query.</param>
        /// <returns>The value of the close flag.</returns>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        public static bool WindowShouldClose(IntPtr window)
        {
            var result = Internal.WindowShouldClose(window);
            HandleError();
            return result != Internal.False;
        }

        /// <summary>
        /// Sets the close flag of the specified window.
        /// <para>This function sets the value of the close flag of the specified window.
        /// This can be used to override the user's attempt to close the window,
        /// or to signal that it should be closed.</para>
        /// </summary>
        /// <param name="window">The window whose flag to change.</param>
        /// <param name="value">The new value.</param>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        public static void SetWindowShouldClose(IntPtr window, bool value = true)
        {
            var intValue = value ? Internal.True : Internal.False;
            Internal.SetWindowShouldClose(window, intValue);
            HandleError();
        }

        /// <summary>
        /// Sets the title of the specified window.
        /// <para>This function sets the window title of the specified window.</para>
        /// </summary>
        /// <param name="window">The window whose title to change.</param>
        /// <param name="title">The window title.</param>
        /// <remarks><para>OS X: The window title will not be updated
        /// until the next time you process events.</para></remarks>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        /// <exception cref="PlatformErrorGlfwException">This operation is not supported on this platform.</exception>
        public static void SetWindowTitle(IntPtr window, string title)
        {
            var titlePointer = title.ToNativeUtf8();
            Internal.SetWindowTitle(window, titlePointer);
            HandleError();
        }

        /// <summary>
        /// Sets the icon for the specified window.
        /// <para>This function sets the icon of the specified window.
        /// If passed an array of candidate images,
        /// those of or closest to the sizes desired by the system are selected.
        /// If no images are specified, the window reverts to its default icon.</para>
        /// <para>The desired image sizes varies depending on platform and system settings.
        /// The selected images will be rescaled as needed.
        /// Good sizes include 16x16, 32x32 and 48x48.</para>
        /// </summary>
        /// <param name="window">The window whose icon to set.</param>
        /// <param name="count">The number of images in the specified array,
        /// or zero to revert to the default window icon.</param>
        /// <param name="images">The images to create the icon from.
        /// This is ignored if count is zero.</param>
        /// <remarks><para>OS X: The GLFW window has no icon, as it is not a document window,
        /// so this function does nothing.
        /// The dock icon will be the same as the application bundle's icon.
        /// For more information on bundles,
        /// see the Bundle Programming Guide in the Mac Developer Library.</para></remarks>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        /// <exception cref="PlatformErrorGlfwException">This operation is not supported on this platform.</exception>
        public static void SetWindowIcon(IntPtr window, int count, IntPtr[] images)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves the position of the client area of the specified window.
        /// <para>This function retrieves the position, in screen coordinates,
        /// of the upper-left corner of the client area of the specified window.</para>
        /// </summary>
        /// <param name="window">The window to query.</param>
        /// <param name="xpos">Where to store the x-coordinate of the upper-left corner of the client area.</param>
        /// <param name="ypos">Where to store the y-coordinate of the upper-left corner of the client area.</param>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        /// <exception cref="PlatformErrorGlfwException">This operation is not supported on this platform.</exception>
        /// <seealso cref="SetWindowPos"/>
        public static void GetWindowPos(IntPtr window, out int xpos, out int ypos)
        {
            Internal.GetWindowPos(window, out xpos, out ypos);
            HandleError();
        }

        /// <summary>
        /// Sets the position of the client area of the specified window.
        /// <para>This function sets the position, in screen coordinates, of the upper-left corner
        /// of the client area of the specified windowed mode window.
        /// If the window is a full screen window, this function does nothing.</para>
        /// <para>Do not use this function to move an already visible window
        /// unless you have very good reasons for doing so, as it will confuse and annoy the user.</para>
        /// <para>The window manager may put limits on what positions are allowed.
        /// GLFW cannot and should not override these limits.</para>
        /// </summary>
        /// <param name="window">The window to query.</param>
        /// <param name="xpos">The x-coordinate of the upper-left corner of the client area.</param>
        /// <param name="ypos">The y-coordinate of the upper-left corner of the client area.</param>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        /// <exception cref="PlatformErrorGlfwException">This operation is not supported on this platform.</exception>
        /// <seealso cref="GetWindowPos"/>
        public static void SetWindowPos(IntPtr window, int xpos, int ypos)
        {
            Internal.SetWindowPos(window, xpos, ypos);
            HandleError();
        }

        /// <summary>
        /// Retrieves the size of the client area of the specified window.
        /// <para>This function retrieves the size, in screen coordinates,
        /// of the client area of the specified window.
        /// If you wish to retrieve the size of the framebuffer of the window in pixels,
        /// see <see cref="GetFramebufferSize"/>.</para>
        /// </summary>
        /// <param name="window">The window whose size to retrieve.</param>
        /// <param name="width">Where to store the width, in screen coordinates, of the client area.</param>
        /// <param name="height">Where to store the height, in screen coordinates, of the client area.</param>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        /// <exception cref="PlatformErrorGlfwException">This operation is not supported on this platform.</exception>
        /// <seealso cref="SetWindowSize"/>
        public static void GetWindowSize(IntPtr window, out int width, out int height)
        {
            Internal.GetWindowSize(window, out width, out height);
            HandleError();
        }

        /// <summary>
        /// Sets the size limits of the specified window.
        /// </summary>
        /// <param name="window">The window to set limits for.</param>
        /// <param name="minWidth">The minimum width, in screen coordinates, of the client area,
        /// or <see cref="Glfw3.Glfw.Internal.DontCare"/>.</param>
        /// <param name="minHeight">The minimum height, in screen coordinates, of the client area,
        /// or <see cref="Glfw3.Glfw.Internal.DontCare"/>.</param>
        /// <param name="maxWidth">The maximum width, in screen coordinates, of the client area,
        /// or <see cref="Glfw3.Glfw.Internal.DontCare"/>.</param>
        /// <param name="maxHeight">The maximum height, in screen coordinates, of the client area,
        /// or <see cref="Glfw3.Glfw.Internal.DontCare"/>.</param>
        /// <remarks>If you set size limits and an aspect ratio that conflict, the results are undefined.</remarks>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        /// <exception cref="PlatformErrorGlfwException">This operation is not supported on this platform.</exception>
        /// <exception cref="InvalidValueGlfwException">The combination of size parameters is invalid.</exception>
        /// <seealso cref="SetWindowAspectRatio"/>
        public static void SetWindowSizeLimits(IntPtr window, int minWidth, int minHeight, int maxWidth,
            int maxHeight)
        {
            Internal.SetWindowSizeLimits(window, minWidth, minHeight, maxWidth, maxHeight);
            HandleError();
        }

        /// <summary>
        /// Sets the aspect ratio of the specified window.
        /// <para>This function sets the required aspect ratio of the client area of the specified window.
        /// If the window is full screen, the aspect ratio only takes effect once it is made windowed.
        /// If the window is not resizable, this function does nothing.</para>
        /// <para>The aspect ratio is specified as a numerator and a denominator
        /// and both values must be greater than zero.
        /// For example, the common 16:9 aspect ratio is specified as 16 and 9, respectively.</para>
        /// <para>If the numerator and denominator is set to <see cref="Glfw3.Glfw.Internal.DontCare"/>
        /// then the aspect ratio limit is disabled.</para>
        /// <para>The aspect ratio is applied immediately to a windowed mode window
        /// and may cause it to be resized.</para>
        /// </summary>
        /// <param name="window">The window to set limits for.</param>
        /// <param name="numer">The numerator of the desired aspect ratio, or <see cref="Glfw3.Glfw.Internal.DontCare"/>.</param>
        /// <param name="denom">The denominator of the desired aspect ratio, or <see cref="Glfw3.Glfw.Internal.DontCare"/>.</param>
        /// <remarks>If you set size limits and an aspect ratio that conflict, the results are undefined.</remarks>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        /// <exception cref="PlatformErrorGlfwException">This operation is not supported on this platform.</exception>
        /// <exception cref="InvalidValueGlfwException">The <paramref name="numer"/> and <paramref name="denom"/>
        /// must be greater than zero.</exception>
        /// <seealso cref="SetWindowSizeLimits"/>
        public static void SetWindowAspectRatio(IntPtr window, int numer, int denom)
        {
            Internal.SetWindowAspectRatio(window, numer, denom);
            HandleError();
        }

        /// <summary>
        /// Sets the size of the client area of the specified window.
        /// <para>For full screen windows, this function updates the resolution of its desired video mode
        /// and switches to the video mode closest to it, without affecting the window's context.
        /// As the context is unaffected, the bit depths of the framebuffer remain unchanged.</para>
        /// <para>If you wish to update the refresh rate of the desired video mode in addition to its resolution,
        /// see <see cref="SetWindowMonitor"/>.</para>
        /// <para>The window manager may put limits on what sizes are allowed.
        /// GLFW cannot and should not override these limits.</para>
        /// </summary>
        /// <param name="window">The window to resize.</param>
        /// <param name="width">The desired width, in screen coordinates, of the window client area.</param>
        /// <param name="height">The desired height, in screen coordinates, of the window client area.</param>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        /// <exception cref="PlatformErrorGlfwException">This operation is not supported on this platform.</exception>
        /// <seealso cref="GetWindowSize"/>
        /// <seealso cref="SetWindowMonitor"/>
        public static void SetWindowSize(IntPtr window, int width, int height)
        {
            Internal.SetWindowSize(window, width, height);
            HandleError();
        }

        /// <summary>
        /// Retrieves the size of the framebuffer of the specified window.
        /// <para>This function retrieves the size, in pixels, of the framebuffer of the specified window.
        /// If you wish to retrieve the size of the window in screen coordinates,
        /// see <see cref="GetWindowSize"/>.</para>
        /// </summary>
        /// <param name="window">The window whose framebuffer to query.</param>
        /// <param name="width">Where to store the width, in pixels, of the framebuffer.</param>
        /// <param name="height">Where to store the height, in pixels, of the framebuffer.</param>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        /// <exception cref="PlatformErrorGlfwException">This operation is not supported on this platform.</exception>
        /// <seealso cref="SetFrameBufferSizeCallback"/>
        public static void GetFramebufferSize(IntPtr window, out int width, out int height)
        {
            Internal.GetFramebufferSize(window, out width, out height);
            HandleError();
        }

        /// <summary>
        /// Retrieves the size of the frame of the window.
        /// <para>This function retrieves the size, in screen coordinates,
        /// of each edge of the frame of the specified window.
        /// This size includes the title bar, if the window has one.
        /// The size of the frame may vary depending on the window-related hints used to create it.</para>
        /// <para>Because this function retrieves the size of each window frame edge
        /// and not the offset along a particular coordinate axis,
        /// the retrieved values will always be zero or positive.</para>
        /// </summary>
        /// <param name="window">The window whose frame size to query.</param>
        /// <param name="left">Where to store the size, in screen coordinates,
        /// of the left edge of the window frame.</param>
        /// <param name="top">Where to store the size, in screen coordinates,
        /// of the top edge of the window frame</param>
        /// <param name="right">Where to store the size, in screen coordinates,
        /// of the right edge of the window frame</param>
        /// <param name="bottom">Where to store the size, in screen coordinates,
        /// of the bottom edge of the window frame</param>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        /// <exception cref="PlatformErrorGlfwException">This operation is not supported on this platform.</exception>
        public static void GetWindowFrameSize(IntPtr window, out int left, out int top, out int right,
            out int bottom)
        {
            Internal.GetWindowFrameSize(window, out left, out top, out right, out bottom);
            HandleError();
        }

        /// <summary>
        /// Iconifies the specified window.
        /// <para>This function iconifies (minimizes) the specified window if it was previously restored.
        /// If the window is already iconified, this function does nothing.</para>
        /// <para>If the specified window is a full screen window,
        /// the original monitor resolution is restored until the window is restored.</para>
        /// </summary>
        /// <param name="window">The window to iconify.</param>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        /// <exception cref="PlatformErrorGlfwException">This operation is not supported on this platform.</exception>
        /// <seealso cref="RestoreWindow"/>
        /// <seealso cref="MaximizeWindow"/>
        public static void IconifyWindow(IntPtr window)
        {
            Internal.IconifyWindow(window);
            HandleError();
        }

        /// <summary>
        /// Restores the specified window.
        /// <para>This function restores the specified window if it was previously iconified (minimized) or maximized.
        /// If the window is already restored, this function does nothing.</para>
        /// <para>If the specified window is a full screen window,
        /// the resolution chosen for the window is restored on the selected monitor.</para>
        /// </summary>
        /// <param name="window">The window to restore.</param>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        /// <exception cref="PlatformErrorGlfwException">This operation is not supported on this platform.</exception>
        /// <seealso cref="IconifyWindow"/>
        /// <seealso cref="MaximizeWindow"/>
        public static void RestoreWindow(IntPtr window)
        {
            Internal.RestoreWindow(window);
            HandleError();
        }

        /// <summary>
        /// Maximizes the specified window.
        /// <para>This function maximizes the specified window if it was previously not maximized.
        /// If the window is already maximized, this function does nothing.</para>
        /// <para>If the specified window is a full screen window, this function does nothing.</para>
        /// </summary>
        /// <param name="window">The window to maximize.</param>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        /// <exception cref="PlatformErrorGlfwException">This operation is not supported on this platform.</exception>
        /// <seealso cref="IconifyWindow"/>
        /// <seealso cref="RestoreWindow"/>
        public static void MaximizeWindow(IntPtr window)
        {
            Internal.MaximizeWindow(window);
            HandleError();
        }

        /// <summary>
        /// Makes the specified window visible.
        /// <para>This function makes the specified window visible if it was previously hidden.
        /// If the window is already visible or is in full screen mode, this function does nothing.</para>
        /// </summary>
        /// <param name="window">The window to make visible.</param>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        /// <exception cref="PlatformErrorGlfwException">This operation is not supported on this platform.</exception>
        /// <seealso cref="HideWindow"/>
        public static void ShowWindow(IntPtr window)
        {
            Internal.ShowWindow(window);
            HandleError();
        }

        /// <summary>
        /// Hides the specified window.
        /// <para>This function hides the specified window if it was previously visible.
        /// If the window is already hidden or is in full screen mode, this function does nothing.</para>
        /// </summary>
        /// <param name="window">The window to hide.</param>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        /// <exception cref="PlatformErrorGlfwException">This operation is not supported on this platform.</exception>
        /// <seealso cref="ShowWindow"/>
        public static void HideWindow(IntPtr window)
        {
            Internal.HideWindow(window);
            HandleError();
        }

        /// <summary>
        /// Brings the specified window to front and sets input focus.
        /// <para>This function brings the specified window to front and sets input focus.
        /// The window should already be visible and not iconified.</para>
        /// <para>By default, both windowed and full screen mode windows are focused when initially created.
        /// Set the <see cref="Glfw3.WindowHint.Focused"/> window hint to disable this behavior.</para>
        /// <para>Do not use this function to steal focus from other applications
        /// unless you are certain that is what the user wants.
        /// Focus stealing can be extremely disruptive.</para>
        /// </summary>
        /// <param name="window">The window to give input focus.</param>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        /// <exception cref="PlatformErrorGlfwException">This operation is not supported on this platform.</exception>
        public static void FocusWindow(IntPtr window)
        {
            Internal.FocusWindow(window);
            HandleError();
        }

        /// <summary>
        /// Returns the monitor that the window uses for full screen mode.
        /// </summary>
        /// <param name="window">The window to query.</param>
        /// <returns>The monitor, or <c>null</c> if the window is in windowed mode or an error occurred.</returns>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        /// <seealso cref="SetWindowMonitor"/>
        public static IntPtr GetWindowMonitor(IntPtr window)
        {
            var monitorPointer = Internal.GetWindowMonitor(window);
            HandleError();
            return monitorPointer;
        }

        /// <summary>
        /// Sets the mode, monitor, video mode, and placement of a window.
        /// <para>This function sets the monitor that the window uses for full screen mode or,
        /// if the monitor is <c>null</c>, makes it windowed mode.</para>
        /// <para>When setting a monitor, this function updates the width,
        /// height and refresh rate of the desired video mode and switches to the video mode closest to it.
        /// The window position is ignored when setting a monitor.</para>
        /// <para>When the monitor is <c>null</c>, the position, width and height
        /// are used to place the window client area.
        /// The refresh rate is ignored when no monitor is specified.</para>
        /// <para>If you only wish to update the resolution of a full screen window
        /// or the size of a windowed mode window, see <see cref="SetWindowSize"/>.</para>
        /// <para>When a window transitions from full screen to windowed mode,
        /// this function restores any previous window settings
        /// such as whether it is decorated, floating, resizable, has size or aspect ratio limits, etc..</para>
        /// </summary>
        /// <param name="window">The window whose monitor, size or video mode to set.</param>
        /// <param name="monitor">The desired monitor, or <c>null</c> to set windowed mode.</param>
        /// <param name="xpos">The desired x-coordinate of the upper-left corner of the client area.</param>
        /// <param name="ypos">The desired y-coordinate of the upper-left corner of the client area.</param>
        /// <param name="width">The desired with, in screen coordinates, of the client area or video mode.</param>
        /// <param name="height">The desired height, in screen coordinates, of the client area or video mode.</param>
        /// <param name="refreshRate">The desired refresh rate, in Hz, of the video mode,
        /// or <see cref="Glfw3.Glfw.Internal.DontCare"/>.</param>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        /// <exception cref="PlatformErrorGlfwException">This operation is not supported on this platform.</exception>
        /// <seealso cref="GetWindowMonitor"/>
        /// <seealso cref="SetWindowSize"/>
        public static void SetWindowMonitor(IntPtr window, IntPtr monitor, int xpos, int ypos, int width,
            int height, int refreshRate)
        {
            Internal.SetWindowMonitor(window, monitor, xpos, ypos, width, height, refreshRate);
            HandleError();
        }

        /// <summary>
        /// Returns an attribute of the specified window.
        /// <para>This function returns the value of an attribute of the specified window
        /// or its OpenGL or OpenGL ES context.</para>
        /// </summary>
        /// <param name="window">The window to query.</param>
        /// <param name="attrib">The window attribute whose value to return.</param>
        /// <returns>The value of the attribute, or zero if an error occurred.</returns>
        /// <remarks><para>Framebuffer related hints are not window attributes.
        /// See framebuffer related attributes for more information.</para>
        /// <para>Zero is a valid value for many window and context related attributes
        /// so you cannot use a return value of zero as an indication of errors.
        /// However, this function should not fail as long as it is passed valid arguments
        /// and the library has been initialized.</para></remarks>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        /// <exception cref="PlatformErrorGlfwException">This operation is not supported on this platform.</exception>
        /// <exception cref="InvalidEnumGlfwException">The <paramref name="attrib"/> specified is invalid.</exception>
        public static int GetWindowAttrib(IntPtr window, WindowAttribute attrib)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets the user pointer of the specified window.
        /// <para>This function sets the user-defined pointer of the specified window.
        /// The current value is retained until the window is destroyed.
        /// The initial value is <c>null</c>.</para>
        /// </summary>
        /// <param name="window">The window whose pointer to set.</param>
        /// <param name="pointer">The new value.</param>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        /// <seealso cref="GetWindowUserPointer"/>
        public static void SetWindowUserPointer(IntPtr window, IntPtr pointer)
        {
            Internal.SetWindowUserPointer(window, pointer);
            HandleError();
        }

        /// <summary>
        /// Returns the user pointer of the specified window.
        /// <para>This function returns the current value of the user-defined pointer of the specified window.
        /// The initial value is <c>null</c>.</para>
        /// </summary>
        /// <param name="window">The window whose pointer to return.</param>
        /// <returns>The existing user-defined pointer.</returns>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        /// <seealso cref="SetWindowUserPointer"/>
        public static IntPtr GetWindowUserPointer(IntPtr window)
        {
            var pointer = Internal.GetWindowUserPointer(window);
            HandleError();
            return pointer;
        }

        /// <summary>
        /// Sets the position callback for the specified window.
        /// <para>This function sets the position callback of the specified window,
        /// which is called when the window is moved.
        /// The callback is provided with the screen position
        /// of the upper-left corner of the client area of the window.</para>
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="callback">The new callback, or <c>null</c> to remove the currently set callback.</param>
        /// <returns>The previously set callback,
        /// or <c>null</c> if no callback was set or the library had not been initialized.</returns>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        public static WindowPosCallback SetWindowPosCallback(IntPtr window, WindowPosCallback callback)
        {
            return SetInternalCallback(Internal.SetWindowPosCallback, callback, window);
        }

        /// <summary>
        /// Sets the size callback for the specified window.
        /// <para>This function sets the size callback of the specified window,
        /// which is called when the window is resized.
        /// The callback is provided with the size, in screen coordinates, of the client area of the window.</para>
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="callback">The new callback, or <c>null</c> to remove the currently set callback.</param>
        /// <returns>The previously set callback,
        /// or <c>null</c> if no callback was set or the library had not been initialized.</returns>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        public static WindowSizeCallback SetWindowSizeCallback(IntPtr window, WindowSizeCallback callback)
        {
            return SetInternalCallback(Internal.SetWindowSizeCallback, callback, window);
        }

        /// <summary>
        /// Sets the close callback for the specified window.
        /// <para>This function sets the close callback of the specified window,
        /// which is called when the user attempts to close the window,
        /// for example by clicking the close widget in the title bar.</para>
        /// <para>The close flag is set before this callback is called,
        /// but you can modify it at any time with <see cref="SetWindowShouldClose"/>.</para>
        /// <para>The close callback is not triggered by <see cref="DestroyWindow"/>.</para>
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="callback">The new callback, or <c>null</c> to remove the currently set callback.</param>
        /// <returns>The previously set callback,
        /// or <c>null</c> if no callback was set or the library had not been initialized.</returns>
        /// <remarks><para>OS X: Selecting Quit from the application menu
        /// will trigger the close callback for all windows.</para></remarks>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        public static WindowCloseCallback SetWindowCloseCallback(IntPtr window, WindowCloseCallback callback)
        {
            return SetInternalCallback(Internal.SetWindowCloseCallback, callback, window);
        }

        /// <summary>
        /// Sets the refresh callback for the specified window.
        /// <para>This function sets the refresh callback of the specified window,
        /// which is called when the client area of the window needs to be redrawn,
        /// for example if the window has been exposed after having been covered by another window.</para>
        /// <para>On compositing window systems such as Aero, Compiz or Aqua,
        /// where the window contents are saved off-screen,
        /// this callback may be called only very infrequently or never at all.</para>
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="callback">The new callback, or <c>null</c> to remove the currently set callback.</param>
        /// <returns>The previously set callback,
        /// or <c>null</c> if no callback was set or the library had not been initialized.</returns>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        public static WindowRefreshCallback SetWindowRefreshCallback(IntPtr window, WindowRefreshCallback callback)
        {
            return SetInternalCallback(Internal.SetWindowRefreshCallback, callback, window);
        }

        /// <summary>
        /// Sets the focus callback for the specified window.
        /// <para>This function sets the focus callback of the specified window,
        /// which is called when the window gains or loses input focus.</para>
        /// <para>After the focus callback is called for a window that lost input focus,
        /// synthetic key and mouse button release events will be generated for all such that had been pressed.
        /// For more information, see <see cref="SetKeyCallback"/> and <see cref="SetMouseButtonCallback"/>.</para>
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="callback">The new callback, or <c>null</c> to remove the currently set callback.</param>
        /// <returns>The previously set callback,
        /// or <c>null</c> if no callback was set or the library had not been initialized.</returns>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        public static WindowFocusCallback SetWindowFocusCallback(IntPtr window, WindowFocusCallback callback)
        {
            return SetInternalCallback(Internal.SetWindowFocusCallback, callback, window);
        }

        /// <summary>
        /// Sets the iconify callback for the specified window.
        /// <para>This function sets the iconification callback of the specified window,
        /// which is called when the window is iconified<para>Possible errors include
        /// <see cref="ErrorCode.NotInitialized"/>, <see cref="ErrorCode.NoWindowContext"/>,
        /// and <see cref="ErrorCode.PlatformError"/>.</para>
        ///  or restored.</para>
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="callback">The new callback, or <c>null</c> to remove the currently set callback.</param>
        /// <returns>The previously set callback,
        /// or <c>null</c> if no callback was set or the library had not been initialized.</returns>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        public static WindowIconifyCallback SetWindowIconifyCallback(IntPtr window, WindowIconifyCallback callback)
        {
            return SetInternalCallback(Internal.SetWindowIconifyCallback, callback, window);
        }

        /// <summary>
        /// Sets the framebuffer resize callback for the specified window.
        /// <para>This function sets the framebuffer resize callback of the specified window,
        /// which is called when the framebuffer of the specified window is resized.</para>
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="callback">The new callback, or <c>null</c> to remove the currently set callback.</param>
        /// <returns>The previously set callback,
        /// or <c>null</c> if no callback was set or the library had not been initialized.</returns>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        public static FrameBufferSizeCallback SetFrameBufferSizeCallback(IntPtr window,
            FrameBufferSizeCallback callback)
        {
            return SetInternalCallback(Internal.SetFrameBufferSizeCallback, callback, window);
        }

        /// <summary>
        /// Processes all pending events.
        /// <para>This function processes only those events that are already in the event queue
        /// and then returns immediately.
        /// Processing events will cause the window
        /// and input callbacks associated with those events to be called.</para>
        /// <para>On some platforms, a window move, resize or menu operation will cause event processing to block.
        /// This is due to how event processing is designed on those platforms.
        /// You can use the window refresh callback to redraw the contents of your window
        /// when necessary during such operations.</para>
        /// <para>On some platforms, certain events are sent directly to the application
        /// without going through the event queue,
        /// causing callbacks to be called outside of a call to one of the event processing functions.</para>
        /// <para>Event processing is not required for joystick input to work.</para>
        /// </summary>
        /// <remarks>This function must not be called from a callback.</remarks>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        /// <exception cref="PlatformErrorGlfwException">This operation is not supported on this platform.</exception>
        /// <seealso cref="WaitEvents"/>
        /// <seealso cref="WaitEventsTimeout"/>
        public static void PollEvents()
        {
            Internal.PollEvents();
            HandleError();
        }

        /// <summary>
        /// Waits until events are queued and processes them.
        /// <para>This function puts the calling thread to sleep
        /// until at least one event is available in the event queue.
        /// Once one or more events are available, it behaves exactly like <see cref="PollEvents"/>,
        /// i.e. the events in the queue are processed and the function then returns immediately.
        /// Processing events will cause the window and input callbacks
        /// associated with those events to be called.</para>
        /// <para>Since not all events are associated with callbacks,
        /// this function may return without a callback having been called
        /// even if you are monitoring all callbacks.</para>
        /// <para>On some platforms, a window move, resize or menu operation will cause event processing to block.
        /// This is due to how event processing is designed on those platforms.
        /// You can use the window refresh callback to redraw
        /// the contents of your window when necessary during such operations.</para>
        /// <para>On some platforms, certain callbacks may be called outside of a call
        /// to one of the event processing functions.</para>
        /// <para>If no windows exist, this function returns immediately.
        /// For synchronization of threads in applications that do not create windows,
        /// use your threading library of choice.</para>
        /// <para>Event processing is not required for joystick input to work.</para>
        /// </summary>
        /// <remarks>This function must not be called from a callback.</remarks>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        /// <exception cref="PlatformErrorGlfwException">This operation is not supported on this platform.</exception>
        /// <seealso cref="PollEvents"/>
        /// <seealso cref="WaitEventsTimeout"/>
        public static void WaitEvents()
        {
            Internal.WaitEvents();
            HandleError();
        }

        /// <summary>
        /// Waits with timeout until events are queued and processes them.
        /// <para>This function puts the calling thread to sleep
        /// until at least one event is available in the event queue,
        /// or until the specified timeout is reached.
        /// If one or more events are available, it behaves exactly like <see cref="PollEvents"/>,
        /// i.e. the events in the queue are processed and the function then returns immediately.
        /// Processing events will cause the window and input callbacks
        /// associated with those events to be called.</para>
        /// <para>The timeout value must be a positive finite number.</para>
        /// <para>Since not all events are associated with callbacks,
        /// this function may return without a callback having been called
        /// even if you are monitoring all callbacks.</para>
        /// <para>On some platforms, a window move, resize or menu operation will cause event processing to block.
        /// This is due to how event processing is designed on those platforms.
        /// You can use the window refresh callback to redraw
        /// the cotents of your window when necessary during such operations.</para>
        /// <para>On some platforms, certain callbacks may be called outside of a call
        /// to one of the event processing functions.</para>
        /// <para>If no windows exist, this function returns immediately.
        /// For synchronization of threads in applications that do not create windows,
        /// use your threading library of choice.</para>
        /// <para>Event processing is not required for joystick input to work.</para>
        /// </summary>
        /// <param name="timeout">The maximum amount of time, in seconds, to wait.</param>
        /// <remarks>This function must not be called from a callback.</remarks>
        /// <seealso cref="PollEvents"/>
        /// <seealso cref="WaitEvents"/>
        public static void WaitEventsTimeout(double timeout)
        {
            Internal.WaitEventsTimeout(timeout);
            HandleError();
        }

        /// <summary>
        /// Posts an empty event to the event queue.
        /// <para>This function posts an empty event from the current thread to the event queue,
        /// causing <see cref="WaitEvents"/> or <see cref="WaitEventsTimeout"/> to return.</para>
        /// <para>If no windows exist, this function returns immediately.
        /// For synchronization of threads in applications that do not create windows,
        /// use your threading library of choice.</para>
        /// </summary>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        /// <exception cref="PlatformErrorGlfwException">This operation is not supported on this platform.</exception>
        /// <seealso cref="WaitEvents"/>
        /// <seealso cref="WaitEventsTimeout"/>
        public static void PostEmptyEvent()
        {
            Internal.PostEmptyEvent();
            HandleError();
        }

        /// <summary>
        /// Swaps the front and back buffers of the specified window.
        /// <para>This function swaps the front and back buffers of the specified window
        /// when rendering with OpenGL or OpenGL ES.
        /// If the swap interval is greater than zero,
        /// the GPU driver waits the specified number of screen updates before swapping the buffers.</para>
        /// <para>The specified window must have an OpenGL or OpenGL ES context.
        /// Specifying a window without a context will generate a <see cref="ErrorCode.NoWindowContext"/> error.</para>
        /// <para>This function does not apply to Vulkan.
        /// If you are rendering with Vulkan, see <see cref="QueuePresentKHR"/> instead.</para>
        /// </summary>
        /// <param name="window">The window whose buffers to swap.</param>
        /// <remarks><para>EGL: The context of the specified window
        /// must be current on the calling thread.</para></remarks>
        /// <exception cref="NotInitializedGlfwException">GLFW is not initialized.</exception>
        /// <exception cref="NoWindowContextGlfwException">The <paramref name="window"/>
        /// is not the current context.</exception>
        /// <exception cref="PlatformErrorGlfwException">This operation is not supported on this platform.</exception>
        /// <seealso cref="SetSwapInterval"/>
        public static void SwapBuffers(IntPtr window)
        {
            Internal.SwapBuffers(window);
            HandleError();
        }
    
        // ReSharper disable MemberHidesStaticFromOuterClass
        private static partial class Internal
        {
            /// <summary>
            /// Resets all window hints to their default values.
            /// </summary>
            /// <remarks>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</remarks>
            /// <seealso cref="WindowHint"/>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwDefaultWindowHints", CallingConvention = CallingConvention.Cdecl)]
            public static extern void DefaultWindowHints();

            /// <summary>
            /// Sets the specified window hint to the desired value.
            /// <para>This function sets hints for the next call to <see cref="CreateWindow"/>.
            /// The hints, once set, retain their values
            /// until changed by a call to <see cref="WindowHint"/> or <see cref="DefaultWindowHints"/>,
            /// or until the library is terminated.</para>
            /// <para>This function does not check whether the specified hint values are valid.
            /// If you set hints to invalid values
            /// this will instead be reported by the next call to <see cref="CreateWindow"/>.</para>
            /// </summary>
            /// <param name="hint">The window hint to set.</param>
            /// <param name="value">The new value of the window hint.</param>
            /// <remarks>Possible errors include
            /// <see cref="ErrorCode.NotInitialized"/> and <see cref="ErrorCode.InvalidEnum"/>.</remarks>
            /// <seealso cref="DefaultWindowHints"/>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwWindowHint", CallingConvention = CallingConvention.Cdecl)]
            public static extern void WindowHint(int hint, int value);

            /// <summary>
            /// Creates a window and its associated context.
            /// <para>This function creates a window and its associated OpenGL or OpenGL ES context.
            /// Most of the options controlling how the window and its context should be created
            /// are specified with window hints.</para>
            /// <para>Successful creation does not change which context is current.
            /// Before you can use the newly created context, you need to make it current.
            /// For information about the <paramref name="share"/> parameter, see Context object sharing.</para>
            /// <para>The created window, framebuffer and context may differ from what you requested,
            /// as not all parameters and hints are hard constraints.
            /// This includes the size of the window, especially for full screen windows.
            /// To query the actual attributes of the created window, framebuffer and context,
            /// see <see cref="GetWindowAttrib"/>, <see cref="GetWindowSize"/>,
            /// and <see cref="GetFramebufferSize"/>.</para>
            /// <para>To create a full screen window, you need to specify the monitor the window will cover.
            /// If no monitor is specified, the window will be windowed mode.
            /// Unless you have a way for the user to choose a specific monitor,
            /// it is recommended that you pick the primary monitor.
            /// For more information on how to query connected monitors, see Retrieving monitors.</para>
            /// <para>For full screen windows,
            /// the specified size becomes the resolution of the window's desired video mode.
            /// As long as a full screen window is not iconified,
            /// the supported video mode most closely matching the desired video mode is set for the specified monitor.
            /// For more information about full screen windows,
            /// including the creation of so called windowed full screen or borderless full screen windows,
            /// see "Windowed full screen" windows.</para>
            /// <para>Once you have created the window,
            /// you can switch it between windowed and full screen mode with <see cref="SetWindowMonitor"/>.
            /// If the window has an OpenGL or OpenGL ES context, it will be unaffected.</para>
            /// <para>By default, newly created windows use the placement recommended by the window system.
            /// To create the window at a specific position,
            /// make it initially invisible using the <see cref="Glfw3.WindowHint.Visible"/> window hint,
            /// set its position and then show it.</para>
            /// <para>As long as at least one full screen window is not iconified,
            /// the screensaver is prohibited from starting.</para>
            /// <para>Window systems put limits on window sizes.
            /// Very large or very small window dimensions may be overridden by the window system on creation.
            /// Check the actual size after creation.</para>
            /// <para>The swap interval is not set during window creation
            /// and the initial value may vary depending on driver settings and defaults.</para>
            /// </summary>
            /// <param name="width">The desired width, in screen coordinates, of the window.
            /// This must be greater than zero.</param>
            /// <param name="height">The desired height, in screen coordinates, of the window.
            /// This must be greater than zero.</param>
            /// <param name="title">The initial, UTF-8 encoded window title.</param>
            /// <param name="monitor">The monitor to use for full screen mode,
            /// or <see cref="IntPtr.Zero"/> for windowed mode.</param>
            /// <param name="share">The window whose context to share resources with,
            /// or <see cref="IntPtr.Zero"/> to not share resources.</param>
            /// <returns>The handle of the created window, or <see cref="IntPtr.Zero"/> if an error occurred.</returns>
            /// <remarks><para>Possible errors include
            /// <see cref="ErrorCode.NotInitialized"/>, <see cref="ErrorCode.InvalidEnum"/>,
            /// <see cref="ErrorCode.InvalidValue"/>, <see cref="ErrorCode.ApiUnavailable"/>,
            /// <see cref="ErrorCode.VersionUnavailable"/>, <see cref="ErrorCode.FormatUnavailable"/>,
            /// and <see cref="ErrorCode.PlatformError"/>.</para>
            /// <para>This function must not be called from a callback.</para>
            /// <para>Windows: Window creation will fail
            /// if the Microsoft GDI software OpenGL implementation is the only one available.</para>
            /// <para>Windows: If the executable has an icon resource named <c>Icon</c>,
            /// it will be set as the initial icon for the window.
            /// If no such icon is present, the <c>IDI_WINLOGO</c> icon will be used instead.
            /// To set a different icon, see <see cref="SetWindowIcon"/>.</para>
            /// <para>Windows: The context to share resources with must not be current on any other thread.</para>
            /// <para>OS X: The GLFW window has no icon, as it is not a document window,
            /// but the dock icon will be the same as the application bundle's icon.
            /// For more information on bundles, see the Bundle Programming Guide in the Mac Developer Library.</para>
            /// <para>OS X: The first time a window is created the menu bar is populated with common commands
            /// like Hide, Quit and About.
            /// The About entry opens a minimal about dialog with information from the application's bundle.
            /// The menu bar can be disabled with a compile-time option.</para>
            /// <para>OS X: On OS X 10.10 and later the window frame will not be rendered at full resolution
            /// on Retina displays unless the <c>NSHighResolutionCapable</c> key is enabled
            /// in the application bundle's <c>Info.plist</c>.
            /// For more information, see High Resolution Guidelines for OS X in the Mac Developer Library.
            /// The GLFW test and example programs use a custom <c>Info.plist</c> template for this,
            /// which can be found as <c>CMake/MacOSXBundleInfo.plist.in</c> in the source tree.</para>
            /// <para>X11: Some window managers will not respect the placement of initially hidden windows.</para>
            /// <para>X11: Due to the asynchronous nature of X11,
            /// it may take a moment for a window to reach its requested state.
            /// This means you may not be able to query the final size,
            /// position or other attributes directly after window creation.</para></remarks>
            /// <seealso cref="DestroyWindow"/>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwCreateWindow", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr CreateWindow(int width, int height, IntPtr title, IntPtr monitor, IntPtr share);

            /// <summary>
            /// Destroys the specified window and its context.
            /// <para>This function destroys the specified window and its context.
            /// On calling this function, no further callbacks will be called for that window.</para>
            /// <para>If the context of the specified window is current on the main thread,
            /// it is detached before being destroyed.</para>
            /// </summary>
            /// <param name="window">The window to destroy.</param>
            /// <remarks><para>Possible errors include
            /// <see cref="ErrorCode.NotInitialized"/> and <see cref="ErrorCode.PlatformError"/>.</para>
            /// <para>The context of the specified window must not be current on any other thread
            /// when this function is called.</para>
            /// <para>This function must not be called from a callback.</para></remarks>
            /// <seealso cref="CreateWindow"/>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwDestroyWindow", CallingConvention = CallingConvention.Cdecl)]
            public static extern void DestroyWindow(IntPtr window);

            /// <summary>
            /// Checks the close flag of the specified window.
            /// </summary>
            /// <param name="window">The window to query.</param>
            /// <returns>The value of the close flag.</returns>
            /// <remarks>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</remarks>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwWindowShouldClose", CallingConvention = CallingConvention.Cdecl)]
            public static extern int WindowShouldClose(IntPtr window);

            /// <summary>
            /// Sets the close flag of the specified window.
            /// <para>This function sets the value of the close flag of the specified window.
            /// This can be used to override the user's attempt to close the window,
            /// or to signal that it should be closed.</para>
            /// </summary>
            /// <param name="window">The window whose flag to change.</param>
            /// <param name="value">The new value.</param>
            /// <remarks>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</remarks>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwSetWindowShouldClose", CallingConvention = CallingConvention.Cdecl)]
            public static extern void SetWindowShouldClose(IntPtr window, int value);

            /// <summary>
            /// Sets the title of the specified window.
            /// <para>This function sets the window title, encoded as UTF-8, of the specified window.</para>
            /// </summary>
            /// <param name="window">The window whose title to change.</param>
            /// <param name="title">The UTF-8 encoded window title.</param>
            /// <remarks><para>Possible errors include
            /// <see cref="ErrorCode.NotInitialized"/> and <see cref="ErrorCode.PlatformError"/>.</para>
            /// <para>OS X: The window title will not be updated
            /// until the next time you process events.</para></remarks>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwSetWindowTitle", CallingConvention = CallingConvention.Cdecl)]
            public static extern void SetWindowTitle(IntPtr window, IntPtr title);

            /// <summary>
            /// Sets the icon for the specified window.
            /// <para>This function sets the icon of the specified window.
            /// If passed an array of candidate images,
            /// those of or closest to the sizes desired by the system are selected.
            /// If no images are specified, the window reverts to its default icon.</para>
            /// <para>The desired image sizes varies depending on platform and system settings.
            /// The selected images will be rescaled as needed.
            /// Good sizes include 16x16, 32x32 and 48x48.</para>
            /// </summary>
            /// <param name="window">The window whose icon to set.</param>
            /// <param name="count">The number of images in the specified array,
            /// or zero to revert to the default window icon.</param>
            /// <param name="images">The images to create the icon from.
            /// This is ignored if count is zero.</param>
            /// <remarks><para>Possible errors include
            /// <see cref="ErrorCode.NotInitialized"/> and <see cref="ErrorCode.PlatformError"/>.</para>
            /// <para>OS X: The GLFW window has no icon, as it is not a document window, so this function does nothing.
            /// The dock icon will be the same as the application bundle's icon.
            /// For more information on bundles,
            /// see the Bundle Programming Guide in the Mac Developer Library.</para></remarks>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwSetWindowIcon", CallingConvention = CallingConvention.Cdecl)]
            public static extern void SetWindowIcon(IntPtr window, int count, IntPtr images);

            /// <summary>
            /// Retrieves the position of the client area of the specified window.
            /// <para>This function retrieves the position, in screen coordinates,
            /// of the upper-left corner of the client area of the specified window.</para>
            /// </summary>
            /// <param name="window">The window to query.</param>
            /// <param name="xpos">Where to store the x-coordinate of the upper-left corner of the client area.</param>
            /// <param name="ypos">Where to store the y-coordinate of the upper-left corner of the client area.</param>
            /// <remarks>Possible errors include
            /// <see cref="ErrorCode.NotInitialized"/> and <see cref="ErrorCode.PlatformError"/>.</remarks>
            /// <seealso cref="SetWindowPos"/>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwGetWindowPos", CallingConvention = CallingConvention.Cdecl)]
            public static extern void GetWindowPos(IntPtr window, out int xpos, out int ypos);

            /// <summary>
            /// Sets the position of the client area of the specified window.
            /// <para>This function sets the position, in screen coordinates, of the upper-left corner
            /// of the client area of the specified windowed mode window.
            /// If the window is a full screen window, this function does nothing.</para>
            /// <para>Do not use this function to move an already visible window
            /// unless you have very good reasons for doing so, as it will confuse and annoy the user.</para>
            /// <para>The window manager may put limits on what positions are allowed.
            /// GLFW cannot and should not override these limits.</para>
            /// </summary>
            /// <param name="window">The window to query.</param>
            /// <param name="xpos">The x-coordinate of the upper-left corner of the client area.</param>
            /// <param name="ypos">The y-coordinate of the upper-left corner of the client area.</param>
            /// <remarks>Possible errors include
            /// <see cref="ErrorCode.NotInitialized"/> and <see cref="ErrorCode.PlatformError"/>.</remarks>
            /// <seealso cref="GetWindowPos"/>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwSetWindowPos", CallingConvention = CallingConvention.Cdecl)]
            public static extern void SetWindowPos(IntPtr window, int xpos, int ypos);

            /// <summary>
            /// Retrieves the size of the client area of the specified window.
            /// <para>This function retrieves the size, in screen coordinates,
            /// of the client area of the specified window.
            /// If you wish to retrieve the size of the framebuffer of the window in pixels,
            /// see <see cref="GetFramebufferSize"/>.</para>
            /// </summary>
            /// <param name="window">The window whose size to retrieve.</param>
            /// <param name="width">Where to store the width, in screen coordinates, of the client area.</param>
            /// <param name="height">Where to store the height, in screen coordinates, of the client area.</param>
            /// <remarks>Possible errors include
            /// <see cref="ErrorCode.NotInitialized"/> and <see cref="ErrorCode.PlatformError"/>.</remarks>
            /// <seealso cref="SetWindowSize"/>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwGetWindowSize", CallingConvention = CallingConvention.Cdecl)]
            public static extern void GetWindowSize(IntPtr window, out int width, out int height);

            /// <summary>
            /// Sets the size limits of the specified window.
            /// </summary>
            /// <param name="window">The window to set limits for.</param>
            /// <param name="minWidth">The minimum width, in screen coordinates, of the client area,
            /// or <see cref="Glfw3.Glfw.Internal.DontCare"/>.</param>
            /// <param name="minHeight">The minimum height, in screen coordinates, of the client area,
            /// or <see cref="Glfw3.Glfw.Internal.DontCare"/>.</param>
            /// <param name="maxWidth">The maximum width, in screen coordinates, of the client area,
            /// or <see cref="Glfw3.Glfw.Internal.DontCare"/>.</param>
            /// <param name="maxHeight">The maximum height, in screen coordinates, of the client area,
            /// or <see cref="Glfw3.Glfw.Internal.DontCare"/>.</param>
            /// <remarks><para>Possible errors include
            /// <see cref="ErrorCode.NotInitialized"/>, <see cref="ErrorCode.InvalidValue"/>,
            /// and <see cref="ErrorCode.PlatformError"/>.</para>
            /// <para>If you set size limits and an aspect ratio that conflict,
            /// the results are undefined.</para></remarks>
            /// <seealso cref="SetWindowAspectRatio"/>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwSetWindowSizeLimits", CallingConvention = CallingConvention.Cdecl)]
            public static extern void SetWindowSizeLimits(IntPtr window, int minWidth, int minHeight, int maxWidth,
                int maxHeight);

            /// <summary>
            /// Sets the aspect ratio of the specified window.
            /// <para>This function sets the required aspect ratio of the client area of the specified window.
            /// If the window is full screen, the aspect ratio only takes effect once it is made windowed.
            /// If the window is not resizable, this function does nothing.</para>
            /// <para>The aspect ratio is specified as a numerator and a denominator
            /// and both values must be greater than zero.
            /// For example, the common 16:9 aspect ratio is specified as 16 and 9, respectively.</para>
            /// <para>If the numerator and denominator is set to <see cref="Glfw3.Glfw.Internal.DontCare"/>
            /// then the aspect ratio limit is disabled.</para>
            /// <para>The aspect ratio is applied immediately to a windowed mode window
            /// and may cause it to be resized.</para>
            /// </summary>
            /// <param name="window">The window to set limits for.</param>
            /// <param name="numer">The numerator of the desired aspect ratio, or <see cref="Glfw3.Glfw.Internal.DontCare"/>.</param>
            /// <param name="denom">The denominator of the desired aspect ratio, or <see cref="Glfw3.Glfw.Internal.DontCare"/>.</param>
            /// <remarks><para>Possible errors include
            /// <see cref="ErrorCode.NotInitialized"/>, <see cref="ErrorCode.InvalidValue"/>,
            /// and <see cref="ErrorCode.PlatformError"/>.</para>
            /// <para>If you set size limits and an aspect ratio that conflict,
            /// the results are undefined.</para></remarks>
            /// <seealso cref="SetWindowSizeLimits"/>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwSetWindowAspectRatio", CallingConvention = CallingConvention.Cdecl)]
            public static extern void SetWindowAspectRatio(IntPtr window, int numer, int denom);

            /// <summary>
            /// Sets the size of the client area of the specified window.
            /// <para>For full screen windows, this function updates the resolution of its desired video mode
            /// and switches to the video mode closest to it, without affecting the window's context.
            /// As the context is unaffected, the bit depths of the framebuffer remain unchanged.</para>
            /// <para>If you wish to update the refresh rate of the desired video mode in addition to its resolution,
            /// see <see cref="SetWindowMonitor"/>.</para>
            /// <para>The window manager may put limits on what sizes are allowed.
            /// GLFW cannot and should not override these limits.</para>
            /// </summary>
            /// <param name="window">The window to resize.</param>
            /// <param name="width">The desired width, in screen coordinates, of the window client area.</param>
            /// <param name="height">The desired height, in screen coordinates, of the window client area.</param>
            /// <remarks>Possible errors include
            /// <see cref="ErrorCode.NotInitialized"/> and <see cref="ErrorCode.PlatformError"/>.</remarks>
            /// <seealso cref="GetWindowSize"/>
            /// <seealso cref="SetWindowMonitor"/>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwSetWindowSize", CallingConvention = CallingConvention.Cdecl)]
            public static extern void SetWindowSize(IntPtr window, int width, int height);

            /// <summary>
            /// Retrieves the size of the framebuffer of the specified window.
            /// <para>This function retrieves the size, in pixels, of the framebuffer of the specified window.
            /// If you wish to retrieve the size of the window in screen coordinates,
            /// see <see cref="GetWindowSize"/>.</para>
            /// </summary>
            /// <param name="window">The window whose framebuffer to query.</param>
            /// <param name="width">Where to store the width, in pixels, of the framebuffer.</param>
            /// <param name="height">Where to store the height, in pixels, of the framebuffer.</param>
            /// <remarks>Possible errors include
            /// <see cref="ErrorCode.NotInitialized"/> and <see cref="ErrorCode.PlatformError"/>.</remarks>
            /// <seealso cref="SetFrameBufferSizeCallback"/>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwGetFramebufferSize", CallingConvention = CallingConvention.Cdecl)]
            public static extern void GetFramebufferSize(IntPtr window, out int width, out int height);

            /// <summary>
            /// Retrieves the size of the frame of the window.
            /// <para>This function retrieves the size, in screen coordinates,
            /// of each edge of the frame of the specified window.
            /// This size includes the title bar, if the window has one.
            /// The size of the frame may vary depending on the window-related hints used to create it.</para>
            /// <para>Because this function retrieves the size of each window frame edge
            /// and not the offset along a particular coordinate axis,
            /// the retrieved values will always be zero or positive.</para>
            /// </summary>
            /// <param name="window">The window whose frame size to query.</param>
            /// <param name="left">Where to store the size, in screen coordinates,
            /// of the left edge of the window frame.</param>
            /// <param name="top">Where to store the size, in screen coordinates,
            /// of the top edge of the window frame</param>
            /// <param name="right">Where to store the size, in screen coordinates,
            /// of the right edge of the window frame</param>
            /// <param name="bottom">Where to store the size, in screen coordinates,
            /// of the bottom edge of the window frame</param>
            /// <remarks>Possible errors include
            /// <see cref="ErrorCode.NotInitialized"/> and <see cref="ErrorCode.PlatformError"/>.</remarks>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwGetWindowFrameSize", CallingConvention = CallingConvention.Cdecl)]
            public static extern void GetWindowFrameSize(IntPtr window, out int left, out int top, out int right,
                out int bottom);

            /// <summary>
            /// Iconifies the specified window.
            /// <para>This function iconifies (minimizes) the specified window if it was previously restored.
            /// If the window is already iconified, this function does nothing.</para>
            /// <para>If the specified window is a full screen window,
            /// the original monitor resolution is restored until the window is restored.</para>
            /// </summary>
            /// <param name="window">The window to iconify.</param>
            /// <remarks>Possible errors include
            /// <see cref="ErrorCode.NotInitialized"/> and <see cref="ErrorCode.PlatformError"/>.</remarks>
            /// <seealso cref="RestoreWindow"/>
            /// <seealso cref="MaximizeWindow"/>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwIconifyWindow", CallingConvention = CallingConvention.Cdecl)]
            public static extern void IconifyWindow(IntPtr window);

            /// <summary>
            /// Restores the specified window.
            /// <para>This function restores the specified window
            /// if it was previously iconified (minimized) or maximized.
            /// If the window is already restored, this function does nothing.</para>
            /// <para>If the specified window is a full screen window,
            /// the resolution chosen for the window is restored on the selected monitor.</para>
            /// </summary>
            /// <param name="window">The window to restore.</param>
            /// <remarks>Possible errors include
            /// <see cref="ErrorCode.NotInitialized"/> and <see cref="ErrorCode.PlatformError"/>.</remarks>
            /// <seealso cref="IconifyWindow"/>
            /// <seealso cref="MaximizeWindow"/>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwRestoreWindow", CallingConvention = CallingConvention.Cdecl)]
            public static extern void RestoreWindow(IntPtr window);

            /// <summary>
            /// Maximizes the specified window.
            /// <para>This function maximizes the specified window if it was previously not maximized.
            /// If the window is already maximized, this function does nothing.</para>
            /// <para>If the specified window is a full screen window, this function does nothing.</para>
            /// </summary>
            /// <param name="window">The window to maximize.</param>
            /// <remarks>Possible errors include
            /// <see cref="ErrorCode.NotInitialized"/> and <see cref="ErrorCode.PlatformError"/>.</remarks>
            /// <seealso cref="IconifyWindow"/>
            /// <seealso cref="RestoreWindow"/>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwMaximizeWindow", CallingConvention = CallingConvention.Cdecl)]
            public static extern void MaximizeWindow(IntPtr window);

            /// <summary>
            /// Makes the specified window visible.
            /// <para>This function makes the specified window visible if it was previously hidden.
            /// If the window is already visible or is in full screen mode, this function does nothing.</para>
            /// </summary>
            /// <param name="window">The window to make visible.</param>
            /// <remarks>Possible errors include
            /// <see cref="ErrorCode.NotInitialized"/> and <see cref="ErrorCode.PlatformError"/>.</remarks>
            /// <seealso cref="HideWindow"/>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwShowWindow", CallingConvention = CallingConvention.Cdecl)]
            public static extern void ShowWindow(IntPtr window);

            /// <summary>
            /// Hides the specified window.
            /// <para>This function hides the specified window if it was previously visible.
            /// If the window is already hidden or is in full screen mode, this function does nothing.</para>
            /// </summary>
            /// <param name="window">The window to hide.</param>
            /// <remarks>Possible errors include
            /// <see cref="ErrorCode.NotInitialized"/> and <see cref="ErrorCode.PlatformError"/>.</remarks>
            /// <seealso cref="ShowWindow"/>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwHideWindow", CallingConvention = CallingConvention.Cdecl)]
            public static extern void HideWindow(IntPtr window);

            /// <summary>
            /// Brings the specified window to front and sets input focus.
            /// <para>This function brings the specified window to front and sets input focus.
            /// The window should already be visible and not iconified.</para>
            /// <para>By default, both windowed and full screen mode windows are focused when initially created.
            /// Set the <see cref="Glfw3.WindowHint.Focused"/> window hint to disable this behavior.</para>
            /// <para>Do not use this function to steal focus from other applications
            /// unless you are certain that is what the user wants.
            /// Focus stealing can be extremely disruptive.</para>
            /// </summary>
            /// <param name="window">The window to give input focus.</param>
            /// <remarks>Possible errors include
            /// <see cref="ErrorCode.NotInitialized"/> and <see cref="ErrorCode.PlatformError"/>.</remarks>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwFocusWindow", CallingConvention = CallingConvention.Cdecl)]
            public static extern void FocusWindow(IntPtr window);

            /// <summary>
            /// Returns the monitor that the window uses for full screen mode.
            /// </summary>
            /// <param name="window">The window to query.</param>
            /// <returns>The monitor,
            /// <see cref="IntPtr.Zero"/> if the window is in windowed mode or an error occurred.</returns>
            /// <remarks>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</remarks>
            /// <seealso cref="SetWindowMonitor"/>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwGetWindowMonitor", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr GetWindowMonitor(IntPtr window);

            /// <summary>
            /// Sets the mode, monitor, video mode, and placement of a window.
            /// <para>This function sets the monitor that the window uses for full screen mode or,
            /// if the monitor is <see cref="IntPtr.Zero"/>, makes it windowed mode.</para>
            /// <para>When setting a monitor, this function updates the width,
            /// height and refresh rate of the desired video mode and switches to the video mode closest to it.
            /// The window position is ignored when setting a monitor.</para>
            /// <para>When the monitor is <see cref="IntPtr.Zero"/>, the position, width and height
            /// are used to place the window client area.
            /// The refresh rate is ignored when no monitor is specified.</para>
            /// <para>If you only wish to update the resolution of a full screen window
            /// or the size of a windowed mode window, see <see cref="SetWindowSize"/>.</para>
            /// <para>When a window transitions from full screen to windowed mode,
            /// this function restores any previous window settings
            /// such as whether it is decorated, floating, resizable, has size or aspect ratio limits, etc..</para>
            /// </summary>
            /// <param name="window">The window whose monitor, size or video mode to set.</param>
            /// <param name="monitor">The desired monitor, or <see cref="IntPtr.Zero"/> to set windowed mode.</param>
            /// <param name="xpos">The desired x-coordinate of the upper-left corner of the client area.</param>
            /// <param name="ypos">The desired y-coordinate of the upper-left corner of the client area.</param>
            /// <param name="width">The desired with, in screen coordinates, of the client area or video mode.</param>
            /// <param name="height">The desired height, in screen coordinates,
            /// of the client area or video mode.</param>
            /// <param name="refreshRate">The desired refresh rate, in Hz, of the video mode,
            /// or <see cref="Glfw3.Glfw.Internal.DontCare"/>.</param>
            /// <remarks>Possible errors include
            /// <see cref="ErrorCode.NotInitialized"/> and <see cref="ErrorCode.PlatformError"/>.</remarks>
            /// <seealso cref="GetWindowMonitor"/>
            /// <seealso cref="SetWindowSize"/>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwSetWindowMonitor", CallingConvention = CallingConvention.Cdecl)]
            public static extern void SetWindowMonitor(IntPtr window, IntPtr monitor, int xpos, int ypos, int width,
                int height, int refreshRate);

            /// <summary>
            /// Returns an attribute of the specified window.
            /// <para>This function returns the value of an attribute of the specified window
            /// or its OpenGL or OpenGL ES context.</para>
            /// </summary>
            /// <param name="window">The window to query.</param>
            /// <param name="attrib">The window attribute whose value to return.</param>
            /// <returns>The value of the attribute, or zero if an error occurred.</returns>
            /// <remarks><para>Possible errors include
            /// <see cref="ErrorCode.NotInitialized"/>, <see cref="ErrorCode.InvalidEnum"/>,
            /// and <see cref="ErrorCode.PlatformError"/>.</para>
            /// <para>Framebuffer related hints are not window attributes.
            /// See Framebuffer related attributes for more information.</para>
            /// <para>Zero is a valid value for many window and context related attributes
            /// so you cannot use a return value of zero as an indication of errors.
            /// However, this function should not fail as long as it is passed valid arguments
            /// and the library has been initialized.</para></remarks>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwGetWindowAttrib", CallingConvention = CallingConvention.Cdecl)]
            public static extern int GetWindowAttrib(IntPtr window, int attrib);

            /// <summary>
            /// Sets the user pointer of the specified window.
            /// <para>This function sets the user-defined pointer of the specified window.
            /// The current value is retained until the window is destroyed.
            /// The initial value is <see cref="IntPtr.Zero"/>.</para>
            /// </summary>
            /// <param name="window">The window whose pointer to set.</param>
            /// <param name="pointer">The new value.</param>
            /// <remarks>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</remarks>
            /// <seealso cref="GetWindowUserPointer"/>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwSetWindowUserPointer", CallingConvention = CallingConvention.Cdecl)]
            public static extern void SetWindowUserPointer(IntPtr window, IntPtr pointer);

            /// <summary>
            /// Returns the user pointer of the specified window.
            /// <para>This function returns the current value of the user-defined pointer of the specified window.
            /// The initial value is <see cref="IntPtr.Zero"/>.</para>
            /// </summary>
            /// <param name="window">The window whose pointer to return.</param>
            /// <returns>The existing user-defined pointer.</returns>
            /// <remarks>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</remarks>
            /// <seealso cref="SetWindowUserPointer"/>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwGetWindowUserPointer", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr GetWindowUserPointer(IntPtr window);

            /// <summary>
            /// Sets the position callback for the specified window.
            /// <para>This function sets the position callback of the specified window,
            /// which is called when the window is moved.
            /// The callback is provided with the screen position
            /// of the upper-left corner of the client area of the window.</para>
            /// </summary>
            /// <param name="window">The window whose callback to set.</param>
            /// <param name="cbfun">The new callback,
            /// or <see cref="IntPtr.Zero"/> to remove the currently set callback.</param>
            /// <returns>The previously set callback,
            /// or <see cref="IntPtr.Zero"/> if no callback was set or the library had not been initialized.</returns>
            /// <remarks>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</remarks>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwSetWindowPosCallback", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr SetWindowPosCallback(IntPtr window, IntPtr cbfun);

            /// <summary>
            /// Sets the size callback for the specified window.
            /// <para>This function sets the size callback of the specified window,
            /// which is called when the window is resized.
            /// The callback is provided with the size, in screen coordinates, of the client area of the window.</para>
            /// </summary>
            /// <param name="window">The window whose callback to set.</param>
            /// <param name="cbfun">The new callback,
            /// or <see cref="IntPtr.Zero"/> to remove the currently set callback.</param>
            /// <returns>The previously set callback,
            /// or <see cref="IntPtr.Zero"/> if no callback was set or the library had not been initialized.</returns>
            /// <remarks>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</remarks>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwSetWindowSizeCallback", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr SetWindowSizeCallback(IntPtr window, IntPtr cbfun);

            /// <summary>
            /// Sets the close callback for the specified window.
            /// <para>This function sets the close callback of the specified window,
            /// which is called when the user attempts to close the window,
            /// for example by clicking the close widget in the title bar.</para>
            /// <para>The close flag is set before this callback is called,
            /// but you can modify it at any time with <see cref="SetWindowShouldClose"/>.</para>
            /// <para>The close callback is not triggered by <see cref="DestroyWindow"/>.</para>
            /// </summary>
            /// <param name="window">The window whose callback to set.</param>
            /// <param name="cbfun">The new callback,
            /// or <see cref="IntPtr.Zero"/> to remove the currently set callback.</param>
            /// <returns>The previously set callback,
            /// or <see cref="IntPtr.Zero"/> if no callback was set or the library had not been initialized.</returns>
            /// <remarks><para>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</para>
            /// <para>OS X: Selecting Quit from the application menu
            /// will trigger the close callback for all windows.</para></remarks>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwSetWindowCloseCallback", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr SetWindowCloseCallback(IntPtr window, IntPtr cbfun);

            /// <summary>
            /// Sets the refresh callback for the specified window.
            /// <para>This function sets the refresh callback of the specified window,
            /// which is called when the client area of the window needs to be redrawn,
            /// for example if the window has been exposed after having been covered by another window.</para>
            /// <para>On compositing window systems such as Aero, Compiz or Aqua,
            /// where the window contents are saved off-screen,
            /// this callback may be called only very infrequently or never at all.</para>
            /// </summary>
            /// <param name="window">The window whose callback to set.</param>
            /// <param name="cbfun">The new callback,
            /// or <see cref="IntPtr.Zero"/> to remove the currently set callback.</param>
            /// <returns>The previously set callback,
            /// or <see cref="IntPtr.Zero"/> if no callback was set or the library had not been initialized.</returns>
            /// <remarks>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</remarks>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwSetWindowRefreshCallback",
                CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr SetWindowRefreshCallback(IntPtr window, IntPtr cbfun);

            /// <summary>
            /// Sets the focus callback for the specified window.
            /// <para>This function sets the focus callback of the specified window,
            /// which is called when the window gains or loses input focus.</para>
            /// <para>After the focus callback is called for a window that lost input focus,
            /// synthetic key and mouse button release events will be generated for all such that had been pressed.
            /// For more information, see <see cref="SetKeyCallback"/> and <see cref="SetMouseButtonCallback"/>.</para>
            /// </summary>
            /// <param name="window">The window whose callback to set.</param>
            /// <param name="cbfun">The new callback,
            /// or <see cref="IntPtr.Zero"/> to remove the currently set callback.</param>
            /// <returns>The previously set callback,
            /// or <see cref="IntPtr.Zero"/> if no callback was set or the library had not been initialized.</returns>
            /// <remarks>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</remarks>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwSetWindowFocusCallback", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr SetWindowFocusCallback(IntPtr window, IntPtr cbfun);

            /// <summary>
            /// Sets the iconify callback for the specified window.
            /// <para>This function sets the iconification callback of the specified window,
            /// which is called when the window is iconified or restored.</para>
            /// </summary>
            /// <param name="window">The window whose callback to set.</param>
            /// <param name="cbfun">The new callback,
            /// or <see cref="IntPtr.Zero"/> to remove the currently set callback.</param>
            /// <returns>The previously set callback,
            /// or <see cref="IntPtr.Zero"/> if no callback was set or the library had not been initialized.</returns>
            /// <remarks>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</remarks>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwSetWindowIconifyCallback",
                CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr SetWindowIconifyCallback(IntPtr window, IntPtr cbfun);

            /// <summary>
            /// Sets the framebuffer resize callback for the specified window.
            /// <para>This function sets the framebuffer resize callback of the specified window,
            /// which is called when the framebuffer of the specified window is resized.</para>
            /// </summary>
            /// <param name="window">The window whose callback to set.</param>
            /// <param name="cbfun">The new callback,
            /// or <see cref="IntPtr.Zero"/> to remove the currently set callback.</param>
            /// <returns>The previously set callback,
            /// or <see cref="IntPtr.Zero"/> if no callback was set or the library had not been initialized.</returns>
            /// <remarks>Possible errors include <see cref="ErrorCode.NotInitialized"/>.</remarks>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwSetFrameBufferSizeCallback",
                CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr SetFrameBufferSizeCallback(IntPtr window, IntPtr cbfun);

            /// <summary>
            /// Processes all pending events.
            /// <para>This function processes only those events that are already in the event queue
            /// and then returns immediately.
            /// Processing events will cause the window
            /// and input callbacks associated with those events to be called.</para>
            /// <para>On some platforms, a window move, resize or menu operation will cause event processing to block.
            /// This is due to how event processing is designed on those platforms.
            /// You can use the window refresh callback to redraw the contents of your window
            /// when necessary during such operations.</para>
            /// <para>On some platforms, certain events are sent directly to the application
            /// without going through the event queue,
            /// causing callbacks to be called outside of a call to one of the event processing functions.</para>
            /// <para>Event processing is not required for joystick input to work.</para>
            /// </summary>
            /// <remarks><para>Possible errors include
            /// <see cref="ErrorCode.NotInitialized"/> and <see cref="ErrorCode.PlatformError"/>.</para>
            /// <para>This function must not be called from a callback.</para></remarks>
            /// <seealso cref="WaitEvents"/>
            /// <seealso cref="WaitEventsTimeout"/>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwPollEvents", CallingConvention = CallingConvention.Cdecl)]
            public static extern void PollEvents();

            /// <summary>
            /// Waits until events are queued and processes them.
            /// <para>This function puts the calling thread to sleep
            /// until at least one event is available in the event queue.
            /// Once one or more events are available, it behaves exactly like <see cref="PollEvents"/>,
            /// i.e. the events in the queue are processed and the function then returns immediately.
            /// Processing events will cause the window and input callbacks
            /// associated with those events to be called.</para>
            /// <para>Since not all events are associated with callbacks,
            /// this function may return without a callback having been called
            /// even if you are monitoring all callbacks.</para>
            /// <para>On some platforms, a window move, resize or menu operation will cause event processing to block.
            /// This is due to how event processing is designed on those platforms.
            /// You can use the window refresh callback to redraw
            /// the contents of your window when necessary during such operations.</para>
            /// <para>On some platforms, certain callbacks may be called outside of a call
            /// to one of the event processing functions.</para>
            /// <para>If no windows exist, this function returns immediately.
            /// For synchronization of threads in applications that do not create windows,
            /// use your threading library of choice.</para>
            /// <para>Event processing is not required for joystick input to work.</para>
            /// </summary>
            /// <remarks><para>Possible errors include
            /// <see cref="ErrorCode.NotInitialized"/> and <see cref="ErrorCode.PlatformError"/>.</para>
            /// <para>This function must not be called from a callback.</para></remarks>
            /// <seealso cref="PollEvents"/>
            /// <seealso cref="WaitEventsTimeout"/>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwWaitEvents", CallingConvention = CallingConvention.Cdecl)]
            public static extern void WaitEvents();

            /// <summary>
            /// Waits with timeout until events are queued and processes them.
            /// <para>This function puts the calling thread to sleep
            /// until at least one event is available in the event queue,
            /// or until the specified timeout is reached.
            /// If one or more events are available, it behaves exactly like <see cref="PollEvents"/>,
            /// i.e. the events in the queue are processed and the function then returns immediately.
            /// Processing events will cause the window and input callbacks
            /// associated with those events to be called.</para>
            /// <para>The timeout value must be a positive finite number.</para>
            /// <para>Since not all events are associated with callbacks,
            /// this function may return without a callback having been called
            /// even if you are monitoring all callbacks.</para>
            /// <para>On some platforms, a window move, resize or menu operation will cause event processing to block.
            /// This is due to how event processing is designed on those platforms.
            /// You can use the window refresh callback to redraw
            /// the cotents of your window when necessary during such operations.</para>
            /// <para>On some platforms, certain callbacks may be called outside of a call
            /// to one of the event processing functions.</para>
            /// <para>If no windows exist, this function returns immediately.
            /// For synchronization of threads in applications that do not create windows,
            /// use your threading library of choice.</para>
            /// <para>Event processing is not required for joystick input to work.</para>
            /// </summary>
            /// <param name="timeout">The maximum amount of time, in seconds, to wait.</param>
            /// <remarks>This function must not be called from a callback.</remarks>
            /// <seealso cref="PollEvents"/>
            /// <seealso cref="WaitEvents"/>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwWaitEventsTimeout", CallingConvention = CallingConvention.Cdecl)]
            public static extern void WaitEventsTimeout(double timeout);

            /// <summary>
            /// Posts an empty event to the event queue.
            /// <para>This function posts an empty event from the current thread to the event queue,
            /// causing <see cref="WaitEvents"/> or <see cref="WaitEventsTimeout"/> to return.</para>
            /// <para>If no windows exist, this function returns immediately.
            /// For synchronization of threads in applications that do not create windows,
            /// use your threading library of choice.</para>
            /// </summary>
            /// <remarks>Possible errors include
            /// <see cref="ErrorCode.NotInitialized"/> and <see cref="ErrorCode.PlatformError"/>.</remarks>
            /// <seealso cref="WaitEvents"/>
            /// <seealso cref="WaitEventsTimeout"/>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwPostEmptyEvent", CallingConvention = CallingConvention.Cdecl)]
            public static extern void PostEmptyEvent();

            /// <summary>
            /// Swaps the front and back buffers of the specified window.
            /// <para>This function swaps the front and back buffers of the specified window
            /// when rendering with OpenGL or OpenGL ES.
            /// If the swap interval is greater than zero,
            /// the GPU driver waits the specified number of screen updates before swapping the buffers.</para>
            /// <para>The specified window must have an OpenGL or OpenGL ES context.
            /// Specifying a window without a context will generate
            /// a <see cref="ErrorCode.NoWindowContext"/> error.</para>
            /// <para>This function does not apply to Vulkan.
            /// If you are rendering with Vulkan, see <see cref="QueuePresentKHR"/> instead.</para>
            /// </summary>
            /// <param name="window">The window whose buffers to swap.</param>
            /// <remarks><para>Possible errors include
            /// <see cref="ErrorCode.NotInitialized"/>, <see cref="ErrorCode.NoWindowContext"/>,
            /// and <see cref="ErrorCode.PlatformError"/>.</para>
            /// <para>EGL: The context of the specified window must be current on the calling thread.</para></remarks>
            /// <seealso cref="SwapInterval"/>
            [SuppressUnmanagedCodeSecurity]
            [DllImport(DllName, EntryPoint = "glfwSwapBuffers", CallingConvention = CallingConvention.Cdecl)]
            public static extern void SwapBuffers(IntPtr window);
        }
    }
}