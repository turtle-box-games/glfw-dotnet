using System;
using System.Runtime.InteropServices;

namespace GLFW.Net.Native
{
    internal static partial class GLFW
    {
        /// <summary>
        /// Client API function pointer type.
        /// </summary>
        /// <seealso cref="GLFW.glfwGetProcAddress"/>
        public delegate void GlProc();

        /// <summary>
        /// Makes the context of the specified window current for the calling thread.
        /// <para>This function makes the OpenGL or OpenGL ES context of the specified window current on the calling thread.
        /// A context can only be made current on a single thread at a time
        /// and each thread can have only a single current context at a time.</para>
        /// <para>By default, making a context non-current implicitly forces a pipeline flush.
        /// On machines that support <c>GL_KHR_context_flush_control</c>,
        /// you can control whether a context performs this flush
        /// by setting the <see cref="ContextReleaseBehavior"/> window hint.</para>
        /// <para>The specified window must have an OpenGL or OpenGL ES context.
        /// Specifying a window without a context will generate a <see cref="NoWindowContext"/> error.</para>
        /// <para>Possible errors include
        /// <see cref="NotInitialized"/>, <see cref="NoWindowContext"/>, and <see cref="PlatformError"/>.</para>
        /// </summary>
        /// <param name="window">The window whose context to make current,
        /// or <c>null</c> to detach the current context.</param>
        /// <seealso cref="glfwGetCurrentContext"/>
        [DllImport(DllName)]
        public static extern void glfwMakeContextCurrent(IntPtr window);

        /// <summary>
        /// Returns the window whose context is current on the calling thread.
        /// <para>This function returns the window
        /// whose OpenGL or OpenGL ES context is current on the calling thread.</para>
        /// <para>Possible errors include <see cref="NotInitialized"/>.</para>
        /// </summary>
        /// <returns>The window whose context is current,
        /// or <c>null</c> if no window's context is current.</returns>
        /// <seealso cref="glfwMakeContextCurrent"/>
        [DllImport(DllName)]
        public static extern IntPtr glfwGetCurrentContext();

        /// <summary>
        /// Sets the swap interval for the current context.
        /// <para>This function sets the swap interval for the current OpenGL or OpenGL ES context,
        /// i.e. the number of screen updates to wait from the time <see cref="glfwSwapBuffers"/>
        /// was called before swapping the buffers and returning.
        /// This is sometimes called vertical synchronization, vertical retrace synchronization or just vsync.</para>
        /// <para>Contexts that support either of the <c>WGL_EXT_swap_control_tear</c>
        /// and <c>GLX_EXT_swap_control_tear</c> extensions also accept negative swap intervals,
        /// which allow the driver to swap even if a frame arrives a little bit late.
        /// You can check for the presence of these extensions using <see cref="glfwExtensionSupported"/>.
        /// For more information about swap tearing, see the extension specifications.</para>
        /// <para>A context must be current on the calling thread.
        /// Calling this function without a current context will cause a <see cref="NoCurrentContext"/> error.</para>
        /// <para>This function does not apply to Vulkan.
        /// If you are rendering with Vulkan, see the present mode of your swapchain instead.</para>
        /// <para>Possible errors include
        /// <see cref="NotInitialized"/>, <see cref="NoCurrentContext"/>, and <see cref="PlatformError"/>.</para>
        /// </summary>
        /// <param name="interval">The minimum number of screen updates to wait for
        /// until the buffers are swapped by <see cref="glfwSwapBuffers"/>.</param>
        /// <remarks>
        /// <para>This function is not called during context creation,
        /// leaving the swap interval set to whatever is the default on that platform.
        /// This is done because some swap interval extensions used by GLFW
        /// do not allow the swap interval to be reset to zero once it has been set to a non-zero value.</para>
        /// <para>Some GPU drivers do not honor the requested swap interval,
        /// either because of a user setting that overrides the application's request
        /// or due to bugs in the driver.</para>
        /// </remarks>
        /// <seealso cref="glfwSwapBuffers"/>
        [DllImport(DllName)]
        public static extern void glfwSwapInterval(int interval);

        /// <summary>
        /// Returns whether the specified extension is available.
        /// <para>This function returns whether the specified API extension
        /// is supported by the current OpenGL or OpenGL ES context.
        /// It searches both for client API extension and context creation API extensions.</para>
        /// <para>A context must be current on the calling thread.
        /// Calling this function without a current context will cause a <see cref="NoCurrentContext"/> error.</para>
        /// <para>As this functions retrieves and searches one or more extension strings each call,
        /// it is recommended that you cache its results if it is going to be used frequently.
        /// The extension strings will not change during the lifetime of a context,
        /// so there is no danger in doing this.</para>
        /// <para>This function does not apply to Vulkan.
        /// If you are using Vulkan, see <see cref="glfwGetRequiredInstanceExtensions"/>,
        /// <c>vkEnumerateInstanceExtensionProperties</c>
        /// and <c>vkEnumerateDeviceExtensionProperties</c> instead.</para>
        /// <para>Possible errors include
        /// <see cref="NotInitialized"/>, <see cref="NoCurrentContext"/>,
        /// <see cref="InvalidValue"/>, and <see cref="PlatformError"/>.</para>
        /// </summary>
        /// <param name="extension">The ASCII encoded name of the extension.</param>
        /// <returns><see cref="True"/> if the extension is available, or <see cref="False"/> otherwise.</returns>
        /// <seealso cref="glfwGetProcAddress"/>
        [DllImport(DllName)]
        public static extern int glfwExtensionSupported([MarshalAs(UnmanagedType.LPStr)] string extension);

        /// <summary>
        /// Returns the address of the specified function for the current context.
        /// <para>This function returns the address of the specified OpenGL or OpenGL ES core or extension function,
        /// if it is supported by the current context.</para>
        /// <para>A context must be current on the calling thread.
        /// Calling this function without a current context will cause a <see cref="NoCurrentContext"/> error.</para>
        /// <para>This function does not apply to Vulkan.
        /// If you are rendering with Vulkan, see <see cref="glfwGetInstanceProcAddress"/>,
        /// <c>vkGetInstanceProcAddr</c> and <c>vkGetDeviceProcAddr</c> instead.</para>
        /// <para>Possible errors include
        /// <see cref="NotInitialized"/>, <see cref="NoCurrentContext"/>, and <see cref="PlatformError"/>.</para>
        /// </summary>
        /// <param name="procName">The ASCII encoded name of the function.</param>
        /// <returns>The address of the function, or <c>null</c> if an error occurred.</returns>
        /// <remarks>
        /// <para>The address of a given function is not guaranteed to be the same between contexts.</para>
        /// <para>This function may return a non-<c>null</c> address
        /// despite the associated version or extension not being available.
        /// Always check the context version or extension string first.</para>
        /// </remarks>
        /// <seealso cref="glfwExtensionSupported"/>
        [DllImport(DllName)]
        [return: MarshalAs(UnmanagedType.FunctionPtr)]
        public static extern GlProc glfwGetProcAddress(string procName);
    }
}