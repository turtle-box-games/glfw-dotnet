namespace Glfw3
{
    /// <summary>
    /// Windows have a number of attributes that can be returned using <see cref="Glfw.GetWindowAttrib"/>.
    /// Some reflect state that may change during the lifetime of the window,
    /// while others reflect the corresponding hints and are fixed at the time of creation.
    /// Some are related to the actual window and others to its context.
    /// </summary>
    public enum WindowAttribute
    {
        /// <summary>
        /// Indicates whether the specified window has input focus.
        /// Initial input focus is controlled by <see cref="WindowHint.Focused"/>.
        /// </summary>
        Focused = 0x00020001,
        
        /// <summary>
        /// Indicates whether the specified window is iconified (minimized),
        /// whether by the user or with <see cref="Glfw.IconifyWindow"/>.
        /// </summary>
        Iconified = 0x00020002,
        
        /// <summary>
        /// Indicates whether the specified window is maximized,
        /// whether by the user or with <see cref="Glfw.MaximizeWindow"/>.
        /// </summary>
        Maximized = 0x00020008,
        
        /// <summary>
        /// Indicates whether the specified window is visible.
        /// Window visibility can be controlled with <see cref="Glfw.ShowWindow"/> and <see cref="Glfw.HideWindow"/>
        /// and initial visibility is controlled by <see cref="WindowHint.Visible"/>.
        /// </summary>
        Visible = 0x00020004,
        
        /// <summary>
        /// Indicates whether the specified window is resizable by the user.
        /// This is set on creation with <see cref="WindowHint.Resizable"/>.
        /// </summary>
        Resizable = 0x00020003,
        
        /// <summary>
        /// Indicates whether the specified window has decorations such as a border, a close widget, etc.
        /// This is set on creation with <see cref="WindowHint.Decorated"/>.
        /// </summary>
        Decorated = 0x00020005,
        
        /// <summary>
        /// Indicates whether the specified window is floating, also called topmost or always-on-top.
        /// This is controlled by <see cref="WindowHint.Floating"/>.
        /// </summary>
        Floating = 0x00020007
    }
}
