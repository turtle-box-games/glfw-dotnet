using System;

namespace GLFW.Net.Native
{
    internal static partial class GLFW
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
        public delegate void WindowPosCallback(IntPtr window, int x, int y);
        
        /// <summary>
        /// The function signature for window resize callbacks.
        /// </summary>
        /// <param name="window">The window that was resized.</param>
        /// <param name="width">The new width, in screen coordinates, of the window.</param>
        /// <param name="height">The new height, in screen coordinates, of the window.</param>
        /// <seealso cref="SetWindowSizeCallback"/>
        public delegate void WindowSizeCallback(IntPtr window, int width, int height);
        
        /// <summary>
        /// The function signature for window close callbacks.
        /// </summary>
        /// <param name="window">The window that the user attempted to close.</param>
        /// <seealso cref="SetWindowCloseCallback"/>
        public delegate void WindowCloseCallback(IntPtr window);
        
        /// <summary>
        /// The function signature for window content refresh callbacks.
        /// </summary>
        /// <param name="window">The window whose content needs to be refreshed.</param>
        /// <seealso cref="SetWindowRefreshCallback"/>
        public delegate void WindowRefreshCallback(IntPtr window);
        
        /// <summary>
        /// The function signature for window focus/defocus callbacks.
        /// </summary>
        /// <param name="window">The window that gained or lost input focus.</param>
        /// <param name="focused"><see cref="True"/> if the window was given input focus,
        /// or <see cref="False"/> if it lost it.</param>
        /// <seealso cref="SetWindowFocusCallback"/>
        public delegate void WindowFocusCallback(IntPtr window, int focused);
        
        /// <summary>
        /// The function signature for window iconify/restore callbacks.
        /// </summary>
        /// <param name="window">The window that was iconified or restored.</param>
        /// <param name="iconified"><see cref="True"/> if the window was iconified,
        /// or <see cref="False"/> if it was restored.</param>
        /// <seealso cref="SetWindowIconifyCallback"/>
        public delegate void WindowIconifyCallback(IntPtr window, int iconified);
        
        /// <summary>
        /// The function signature for framebuffer resize callbacks.
        /// </summary>
        /// <param name="window">The window whose framebuffer was resized.</param>
        /// <param name="width">The new width, in pixels, of the framebuffer.</param>
        /// <param name="height">The new height, in pixels, of the framebuffer.</param>
        /// <seealso cref="SetFrameBufferSizeCallback"/>
        public delegate void FrameBufferSizeCallback(IntPtr window, int width, int height);

        public static extern void DefaultWindowHints();

        public static extern void WindowHint(int hint, int value);

        public static extern IntPtr CreateWindow(int width, int height, string title, IntPtr monitor, IntPtr share);

        public static extern void DestroyWindow(IntPtr window);

        public static extern int WindowShouldClose(IntPtr window);

        public static extern void SetWindowShouldClose(IntPtr window, int value);

        public static extern void SetWindowTitle(IntPtr window, string title);

        public static extern void SetWindowIcon(IntPtr window, int count, IntPtr images);

        public static extern void GetWindowPos(IntPtr window, out int xpos, out int ypos);

        public static extern void SetWindowPos(IntPtr window, int xpos, int ypos);

        public static extern void GetWindowSize(IntPtr window, out int width, out int height);

        public static extern void SetWindowSizeLimits(IntPtr window, int minWidth, int minHeight, int maxWidth,
            int maxHeight);

        public static extern void SetWindowAspectRation(IntPtr window, int numer, int denom);

        public static extern void SetWindowSize(IntPtr window, int width, int height);

        public static extern void GetFramebufferSize(IntPtr window, out int width, out int height);

        public static extern void GetWindowFrameSize(IntPtr window, out int left, out int top, out int right,
            out int bottom);

        public static extern void IconifyWindow(IntPtr window);

        public static extern void RestoreWindow(IntPtr window);

        public static extern void MaximizeWindow(IntPtr window);

        public static extern void ShowWindow(IntPtr window);

        public static extern void HideWindow(IntPtr window);

        public static extern void FocusWindow(IntPtr window);

        public static extern IntPtr GetWindowMonitor(IntPtr window);

        public static extern void SetWindowMonitor(IntPtr window, IntPtr monitor, int xpos, int ypos, int width,
            int height, int refreshRate);

        public static extern int GetWindowAttrib(IntPtr window, int attrib);

        public static extern void SetWindowUserPointer(IntPtr window, IntPtr pointer);

        public static extern IntPtr GetWindowUserPointer(IntPtr window);

        public static extern WindowPosCallback SetWindowPosCallback(IntPtr window, WindowPosCallback cbfun);

        public static extern WindowSizeCallback SetWindowSizeCallback(IntPtr window, WindowSizeCallback cbfun);

        public static extern WindowCloseCallback SetWindowCloseCallback(IntPtr window, WindowCloseCallback cbfun);

        public static extern WindowRefreshCallback SetWindowRefreshCallback(IntPtr window, WindowRefreshCallback cbfun);

        public static extern WindowFocusCallback SetWindowFocusCallback(IntPtr window, WindowFocusCallback cbfun);

        public static extern WindowIconifyCallback SetWindowIconifyCallback(IntPtr window, WindowIconifyCallback cbfun);

        public static extern FrameBufferSizeCallback SetFrameBufferSizeCallback(IntPtr window,
            FrameBufferSizeCallback cbfun);

        public static extern void PollEvents();

        public static extern void WaitEvents();

        public static extern void WaitEventsTimeout(double timeout);

        public static extern void PostEmptyEvent();

        public static extern void SwapBuffers(IntPtr window);
    }
}