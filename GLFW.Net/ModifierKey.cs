using System;

namespace GLFW.Net
{
    /// <summary>
    /// Keyboard keys that can be held down to modify behavior of the key press.
    /// </summary>
    [Flags]
    public enum ModifierKey
    {
        /// <summary>
        /// If this bit is set one or more Shift keys were held down.
        /// </summary>
        Shift = 0x0001,
        
        /// <summary>
        /// If this bit is set one or more Control keys were held down.
        /// </summary>
        Control = 0x0002,
        
        /// <summary>
        /// If this bit is set one or more Alt keys were held down.
        /// </summary>
        Alt = 0x0004,
        
        /// <summary>
        /// If this bit is set one or more Super keys were held down.
        /// </summary>
        Super = 0x0008
    }
}