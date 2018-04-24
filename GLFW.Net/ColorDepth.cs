namespace GLFW.Net
{
    public struct ColorDepth
    {
        private byte _r, _g, _b;

        public ColorDepth(byte red, byte green, byte blue)
        {
            _r = red;
            _g = green;
            _b = blue;
        }

        public byte Red => _r;

        public byte Green => _g;

        public byte Blue => _b;
    }
}