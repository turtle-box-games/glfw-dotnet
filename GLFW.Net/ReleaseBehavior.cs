﻿namespace GLFW.Net
{
    /// <summary>
    /// Possible actions to take for releasing.
    /// </summary>
    public enum ReleaseBehavior
    {
        /// <summary>
        /// The default behavior of the context creation API will be used.
        /// </summary>
        Any = 0,
        
        /// <summary>
        /// The pipeline will be flushed whenever the context is released from being the current one.
        /// </summary>
        Flush = 0x00035001,
        
        /// <summary>
        /// The pipeline will not be flushed on release.
        /// </summary>
        None = 0x00035002
    }
}
