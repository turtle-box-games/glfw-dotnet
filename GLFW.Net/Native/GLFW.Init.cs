using System.Runtime.InteropServices;

namespace GLFW.Net.Native
{
    internal static partial class GLFW
    {
        public delegate void ErrorHandler(int errorCode, [MarshalAs(UnmanagedType.LPStr)] string message);

        [DllImport(DllName)]
        public static extern int glfwInit();

        [DllImport(DllName)]
        public static extern void glfwTerminate();

        [DllImport(DllName)]
        public static extern void glfwGetVersion(out int major, out int minor, out int rev);

        [DllImport(DllName)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        public static extern string glfwGetVersionString();

        [DllImport(DllName)]
        [return: MarshalAs(UnmanagedType.FunctionPtr)]
        public static extern ErrorHandler glfwSetErrorCallback([MarshalAs(UnmanagedType.FunctionPtr)] ErrorHandler callback);
    }
}