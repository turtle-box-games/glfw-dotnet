namespace GLFW.Net.Native
{
    internal static partial class GLFW
    {
        private const string DllName = "glfw3.dll";

        public const int True = 1;
        public const int False = 0;

        #region Error codes
        public const int ErrorCodeNotInitialized = 0x00010001;
        public const int ErrorCodeNoCurrentContext = 0x00010002;
        public const int ErrorCodeInvalidEnum = 0x00010003;
        public const int ErrorCodeInvalidValue = 0x00010004;
        public const int ErrorCodeOutOfMemory = 0x00010005;
        public const int ErrorCodeApiUnavailable = 0x00010006;
        public const int ErrorCodeVersionUnavailable = 0x00010007;
        public const int ErrorCodePlatformError = 0x00010008;
        public const int ErrorCodeFormatUnavailable = 0x00010009;
        public const int ErrorCodeNoWindowContext = 0x0001000A;
        #endregion
    }
}