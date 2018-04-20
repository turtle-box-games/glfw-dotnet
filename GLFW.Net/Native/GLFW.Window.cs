using System;
using System.Runtime.InteropServices;

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

        [DllImport(DllName, EntryPoint = "glfwDefaultWindowHints")]
        public static extern void DefaultWindowHints();

        [DllImport(DllName, EntryPoint = "glfwWindowHint")]
        public static extern void WindowHint(int hint, int value);

        [DllImport(DllName, EntryPoint = "glfwCreateWindow")]
        public static extern IntPtr CreateWindow(int width, int height, [MarshalAs(UnmanagedType.LPStr)] string title, IntPtr monitor, IntPtr share);

        [DllImport(DllName, EntryPoint = "glfwDestroyWindow")]
        public static extern void DestroyWindow(IntPtr window);

        [DllImport(DllName, EntryPoint = "glfwWindowShouldClose")]
        public static extern int WindowShouldClose(IntPtr window);

        [DllImport(DllName, EntryPoint = "glfwSetWindowShouldClose")]
        public static extern void SetWindowShouldClose(IntPtr window, int value);

        [DllImport(DllName, EntryPoint = "glfwSetWindowTitle")]
        public static extern void SetWindowTitle(IntPtr window, [MarshalAs(UnmanagedType.LPStr)] string title);

        [DllImport(DllName, EntryPoint = "glfwSetWindowIcon")]
        public static extern void SetWindowIcon(IntPtr window, int count, IntPtr images);

        [DllImport(DllName, EntryPoint = "glfwGetWindowPos")]
        public static extern void GetWindowPos(IntPtr window, out int xpos, out int ypos);

        [DllImport(DllName, EntryPoint = "glfwSetWindowPos")]
        public static extern void SetWindowPos(IntPtr window, int xpos, int ypos);

        [DllImport(DllName, EntryPoint = "glfwGetWindowSize")]
        public static extern void GetWindowSize(IntPtr window, out int width, out int height);

        [DllImport(DllName, EntryPoint = "glfwSetWindowSizeLimits")]
        public static extern void SetWindowSizeLimits(IntPtr window, int minWidth, int minHeight, int maxWidth,
            int maxHeight);

        [DllImport(DllName, EntryPoint = "glfwSetWindowAspectRation")]
        public static extern void SetWindowAspectRation(IntPtr window, int numer, int denom);

        [DllImport(DllName, EntryPoint = "glfwSetWindowSize")]
        public static extern void SetWindowSize(IntPtr window, int width, int height);

        [DllImport(DllName, EntryPoint = "glfwGetFramebufferSize")]
        public static extern void GetFramebufferSize(IntPtr window, out int width, out int height);

        [DllImport(DllName, EntryPoint = "glfwGetWindowFrameSize")]
        public static extern void GetWindowFrameSize(IntPtr window, out int left, out int top, out int right,
            out int bottom);

        [DllImport(DllName, EntryPoint = "glfwIconifyWindow")]
        public static extern void IconifyWindow(IntPtr window);

        [DllImport(DllName, EntryPoint = "glfwRestoreWindow")]
        public static extern void RestoreWindow(IntPtr window);

        [DllImport(DllName, EntryPoint = "glfwMaximizeWindow")]
        public static extern void MaximizeWindow(IntPtr window);

        [DllImport(DllName, EntryPoint = "glfwShowWindow")]
        public static extern void ShowWindow(IntPtr window);

        [DllImport(DllName, EntryPoint = "glfwHideWindow")]
        public static extern void HideWindow(IntPtr window);

        [DllImport(DllName, EntryPoint = "glfwFocusWindow")]
        public static extern void FocusWindow(IntPtr window);

        [DllImport(DllName, EntryPoint = "glfwGetWindowMonitor")]
        public static extern IntPtr GetWindowMonitor(IntPtr window);

        [DllImport(DllName, EntryPoint = "glfwSetWindowMonitor")]
        public static extern void SetWindowMonitor(IntPtr window, IntPtr monitor, int xpos, int ypos, int width,
            int height, int refreshRate);

        [DllImport(DllName, EntryPoint = "glfwGetWindowAttrib")]
        public static extern int GetWindowAttrib(IntPtr window, int attrib);

        [DllImport(DllName, EntryPoint = "glfwSetWindowUserPointer")]
        public static extern void SetWindowUserPointer(IntPtr window, IntPtr pointer);

        [DllImport(DllName, EntryPoint = "glfwGetWindowUserPointer")]
        public static extern IntPtr GetWindowUserPointer(IntPtr window);

        [DllImport(DllName, EntryPoint = "glfwSetWindowPosCallback")]
        [return: MarshalAs(UnmanagedType.FunctionPtr)]
        public static extern WindowPosCallback SetWindowPosCallback(IntPtr window,
            [MarshalAs(UnmanagedType.FunctionPtr)] WindowPosCallback cbfun);

        [DllImport(DllName, EntryPoint = "glfwSetWindowSizeCallback")]
        [return: MarshalAs(UnmanagedType.FunctionPtr)]
        public static extern WindowSizeCallback SetWindowSizeCallback(IntPtr window,
            [MarshalAs(UnmanagedType.FunctionPtr)] WindowSizeCallback cbfun);

        [DllImport(DllName, EntryPoint = "glfwSetWindowCloseCallback")]
        [return: MarshalAs(UnmanagedType.FunctionPtr)]
        public static extern WindowCloseCallback SetWindowCloseCallback(IntPtr window,
            [MarshalAs(UnmanagedType.FunctionPtr)] WindowCloseCallback cbfun);

        [DllImport(DllName, EntryPoint = "glfwSetWindowRefreshCallback")]
        [return: MarshalAs(UnmanagedType.FunctionPtr)]
        public static extern WindowRefreshCallback SetWindowRefreshCallback(IntPtr window,
            [MarshalAs(UnmanagedType.FunctionPtr)] WindowRefreshCallback cbfun);

        [DllImport(DllName, EntryPoint = "glfwSetWindowFocusCallback")]
        [return: MarshalAs(UnmanagedType.FunctionPtr)]
        public static extern WindowFocusCallback SetWindowFocusCallback(IntPtr window,
            [MarshalAs(UnmanagedType.FunctionPtr)] WindowFocusCallback cbfun);

        [DllImport(DllName, EntryPoint = "glfwSetWindowIconifyCallback")]
        [return: MarshalAs(UnmanagedType.FunctionPtr)]
        public static extern WindowIconifyCallback SetWindowIconifyCallback(IntPtr window,
            [MarshalAs(UnmanagedType.FunctionPtr)] WindowIconifyCallback cbfun);

        [DllImport(DllName, EntryPoint = "glfwSetFrameBufferSizeCallback")]
        [return: MarshalAs(UnmanagedType.FunctionPtr)]
        public static extern FrameBufferSizeCallback SetFrameBufferSizeCallback(IntPtr window,
            [MarshalAs(UnmanagedType.FunctionPtr)] FrameBufferSizeCallback cbfun);

        [DllImport(DllName, EntryPoint = "glfwPollEvents")]
        public static extern void PollEvents();

        [DllImport(DllName, EntryPoint = "glfwWaitEvents")]
        public static extern void WaitEvents();

        [DllImport(DllName, EntryPoint = "glfwWaitEventsTimeout")]
        public static extern void WaitEventsTimeout(double timeout);

        [DllImport(DllName, EntryPoint = "glfwPostEmptyEvent")]
        public static extern void PostEmptyEvent();

        [DllImport(DllName, EntryPoint = "glfwSwapBuffers")]
        public static extern void SwapBuffers(IntPtr window);
    }
}