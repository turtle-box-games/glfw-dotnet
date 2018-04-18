namespace GLFW.Net.Native
{
    internal static partial class GLFW
    {
        private const string DllName = "glfw3.dll";

        public const int True = 1;
        public const int False = 0;

        #region Error codes
        public const int NotInitialized = 0x00010001;
        public const int NoCurrentContext = 0x00010002;
        public const int InvalidEnum = 0x00010003;
        public const int InvalidValue = 0x00010004;
        public const int OutOfMemory = 0x00010005;
        public const int ApiUnavailable = 0x00010006;
        public const int VersionUnavailable = 0x00010007;
        public const int PlatformError = 0x00010008;
        public const int FormatUnavailable = 0x00010009;
        public const int NoWindowContext = 0x0001000A;
        #endregion
    }
}