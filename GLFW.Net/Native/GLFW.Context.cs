﻿using System.Runtime.InteropServices;

namespace GLFW.Net.Native
{
    internal static partial class GLFW
    {
        public delegate void GlProc();

        [DllImport(DllName)]
        public static extern void glfwMakeContextCurrent(GLFWwindow window);

        [DllImport(DllName)]
        public static extern GLFWwindow glfwGetCurrentContext();

        [DllImport(DllName)]
        public static extern void glfwSwapInterval(int interval);

        [DllImport(DllName)]
        public static extern int glfwExtensionSupported([MarshalAs(UnmanagedType.LPStr)] string extension);

        [DllImport(DllName)]
        [return: MarshalAs(UnmanagedType.FunctionPtr)]
        public static extern GlProc glfwGetProcAddress(string procName);
    }
}