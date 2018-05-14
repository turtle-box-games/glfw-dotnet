namespace Glfw3
{
    /// <summary>
    /// Window creation hints that can alter behavior.
    /// <para>There are a number of hints that can be set before the creation of a window and context.
    /// Some affect the window itself, others affect the framebuffer or context.
    /// These hints are set to their default values each time the library is initialized with <see cref="Glfw.Initialize"/>,
    /// can be set individually with <see cref="Glfw.WindowHint"/>
    /// and reset all at once to their defaults with <see cref="Glfw.DefaultWindowHints"/>.</para>
    /// <para>Note that hints need to be set before the creation
    /// of the window and context you wish to have the specified attributes.</para>
    /// <para>Some window hints are hard constraints.
    /// These must match the available capabilities exactly for window and context creation to succeed.
    /// Hints that are not hard constraints are matched as closely as possible,
    /// but the resulting context and framebuffer may differ from what these hints requested.</para>
    /// </summary>
    public enum WindowHint
    {
        /// <summary>
        /// Specifies whether the windowed mode window will be resizable by the user.
        /// The window will still be resizable using the <see cref="Glfw.SetWindowSize"/> function.
        /// This hint is ignored for full screen windows.
        /// </summary>
        Resizable = WindowAttribute.Resizable,
        
        /// <summary>
        /// Specifies whether the windowed mode window will be initially visible.
        /// This hint is ignored for full screen windows.
        /// </summary>
        Visible = WindowAttribute.Visible,
        
        /// <summary>
        /// Specifies whether the windowed mode window will have window decorations
        /// such as a border, a close widget, etc.
        /// An undecorated window may still allow the user to generate close events on some platforms.
        /// This hint is ignored for full screen windows.
        /// </summary>
        Decorated = WindowAttribute.Decorated,
        
        /// <summary>
        /// Specifies whether the windowed mode window will be given input focus when created.
        /// This hint is ignored for full screen and initially hidden windows.
        /// </summary>
        Focused = WindowAttribute.Focused,
        
        /// <summary>
        /// Specifies whether the full screen window will automatically iconify
        /// and restore the previous video mode on input focus loss.
        /// This hint is ignored for windowed mode windows.
        /// </summary>
        AutoIconify = 0x00020006,
        
        /// <summary>
        /// Specifies whether the windowed mode window will be floating above other regular windows,
        /// also called topmost or always-on-top.
        /// This is intended primarily for debugging purposes
        /// and cannot be used to implement proper full screen windows.
        /// This hint is ignored for full screen windows.
        /// </summary>
        Floating = WindowAttribute.Floating,
        
        /// <summary>
        /// Specifies whether the windowed mode window will be maximized when created.
        /// This hint is ignored for full screen windows.
        /// </summary>
        Maximized = WindowAttribute.Maximized,
        
        /// <summary>
        /// Specifies the desired bit depth for the red channel of the default framebuffer.
        /// </summary>
        RedBits = 0x00021001,
        
        /// <summary>
        /// Specifies the desired bit depth for the green channel of the default framebuffer.
        /// </summary>
        GreenBits = 0x00021002,
        
        /// <summary>
        /// Specifies the desired bit depth for the blue channel of the default framebuffer.
        /// </summary>
        BlueBits = 0x00021003,
        
        /// <summary>
        /// Specifies the desired bit depth for the alpha channel of the default framebuffer.
        /// </summary>
        AlphaBits = 0x00021004,
        
        /// <summary>
        /// Specifies the desired bit depth for the depth buffer of the default framebuffer.
        /// </summary>
        DepthBits = 0x00021005,
        
        /// <summary>
        /// Specifies the desired bit depth for the stencil of the default framebuffer.
        /// </summary>
        StencilBits = 0x00021006,
        
        /// <summary>
        /// Specifies the desired bit depth of the red channel of the accumulation buffer.
        /// </summary>
        /// <remarks>Accumulation buffers are a legacy OpenGL feature and should not be used in new code.</remarks>
        AccumRedBits = 0x00021007,
        
        /// <summary>
        /// Specifies the desired bit depth of the green channel of the accumulation buffer.
        /// </summary>
        /// <remarks>Accumulation buffers are a legacy OpenGL feature and should not be used in new code.</remarks>
        AccumGreenBits = 0x00021008,
        
        /// <summary>
        /// Specifies the desired bit depth of the blue channel of the accumulation buffer.
        /// </summary>
        /// <remarks>Accumulation buffers are a legacy OpenGL feature and should not be used in new code.</remarks>
        AccumBlueBits = 0x00021009,
        
        /// <summary>
        /// Specifies the desired bit depth of the alpha channel of the accumulation buffer.
        /// </summary>
        /// <remarks>Accumulation buffers are a legacy OpenGL feature and should not be used in new code.</remarks>
        AccumAlphaBits = 0x0002100A,
        
        /// <summary>
        /// Specifies the desired number of auxiliary buffers.
        /// </summary>
        AuxBuffers = 0x0002100B,
        
        /// <summary>
        /// Specifies the desired number of samples to use for multisampling.
        /// Zero disables multisampling.
        /// </summary>
        Samples = 0x0002100D,
        
        /// <summary>
        /// Specifies the desired refresh rate for full screen windows.
        /// If set to <see cref="Glfw3.Glfw.Internal.DontCare"/>, the highest available refresh rate will be used.
        /// This hint is ignored for windowed mode windows.
        /// </summary>
        RefreshRate = 0x0002100F,
        
        /// <summary>
        /// Specifies whether to use stereoscopic rendering.
        /// This is a hard constraint.
        /// </summary>
        Stereo = 0x0002100C,
        
        /// <summary>
        /// Specifies whether the framebuffer should be sRGB capable.
        /// If supported, a created OpenGL context will support the <c>GL_FRAMEBUFFER_SRGB</c> enable,
        /// also called <c>GL_FRAMEBUFFER_SRGB_EXT</c>) for controlling sRGB rendering
        /// and a created OpenGL ES context will always have sRGB rendering enabled.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        SRGBCapable = 0x0002100E,
        
        /// <summary>
        /// Specifies whether the framebuffer should be double buffered.
        /// You nearly always want to use double buffering.
        /// This is a hard constraint.
        /// </summary>
        DoubleBuffer = 0x00021010,
        
        /// <summary>
        /// Specifies which client API to create the context for.
        /// Possible values are listed in <see cref="ClientApi"/>.
        /// This is a hard constraint.
        /// </summary>
        ClientApi = 0x00022001,
        
        /// <summary>
        /// Specifies which context creation API to use to create the context.
        /// Possible values are listed in <see cref="ContextApi"/>.
        /// This is a hard constraint.
        /// If no client API is requested, this hint is ignored.
        /// </summary>
        /// <remarks><para>OS X: The EGL API is not available on this platform and requests to use it will fail.</para>
        /// <para>Wayland, Mir: The EGL API is the native context creation API, so this hint will have no effect.</para>
        /// <para>An OpenGL extension loader library that assumes it knows which context creation API
        /// is used on a given platform may fail if you change this hint.
        /// This can be resolved by having it load via <see cref="Glfw.GetProcAddress"/>,
        /// which always uses the selected API.</para>
        /// <para>On some Linux systems, creating contexts via both the native and EGL APIs in a single process
        /// will cause the application to segfault.
        /// Stick to one API or the other on Linux for now.</para></remarks>
        ContextCreationApi = 0x0002200B,
        
        /// <summary>
        /// Specify the client API major version that the created context must be compatible with.
        /// The exact behavior of these hints depend on the requested client API.
        /// </summary>
        /// <remarks><para>While there is no way to ask the driver for a context of the highest supported version,
        /// GLFW will attempt to provide this when you ask for a version 1.0 context,
        /// which is the default for these hints.</para>
        /// <para>OpenGL: <see cref="ContextVersionMajor"/> and <see cref="ContextVersionMinor"/>
        /// are not hard constraints, but creation will fail
        /// if the OpenGL version of the created context is less than the one requested.
        /// It is therefore perfectly safe to use the default of version 1.0 for legacy code
        /// and you will still get backwards-compatible contexts of version 3.0 and above when available.</para>
        /// <para>OpenGL ES: <see cref="ContextVersionMajor"/> and <see cref="ContextVersionMinor"/>
        /// are not hard constraints, but creation will fail
        /// if the OpenGL ES version of the created context is less than the one requested.
        /// Additionally, OpenGL ES 1.x cannot be returned if 2.0 or later was requested, and vice versa.
        /// This is because OpenGL ES 3.x is backward compatible with 2.0,
        /// but OpenGL ES 2.0 is not backward compatible with 1.x.</para></remarks>
        ContextVersionMajor = 0x00022002,
        
        /// <summary>
        /// Specify the client API minor version that the created context must be compatible with.
        /// The exact behavior of these hints depend on the requested client API.
        /// </summary>
        /// <remarks><para>While there is no way to ask the driver for a context of the highest supported version,
        /// GLFW will attempt to provide this when you ask for a version 1.0 context,
        /// which is the default for these hints.</para>
        /// <para>OpenGL: <see cref="ContextVersionMajor"/> and <see cref="ContextVersionMinor"/>
        /// are not hard constraints, but creation will fail
        /// if the OpenGL version of the created context is less than the one requested.
        /// It is therefore perfectly safe to use the default of version 1.0 for legacy code
        /// and you will still get backwards-compatible contexts of version 3.0 and above when available.</para>
        /// <para>OpenGL ES: <see cref="ContextVersionMajor"/> and <see cref="ContextVersionMinor"/>
        /// are not hard constraints, but creation will fail
        /// if the OpenGL ES version of the created context is less than the one requested.
        /// Additionally, OpenGL ES 1.x cannot be returned if 2.0 or later was requested, and vice versa.
        /// This is because OpenGL ES 3.x is backward compatible with 2.0,
        /// but OpenGL ES 2.0 is not backward compatible with 1.x.</para></remarks>
        ContextVersionMinor = 0x00022003,
        
        /// <summary>
        /// Similar to <see cref="ContextVersionMajor"/> and <see cref="ContextVersionMinor"/>,
        /// but for specifying the context revision.
        /// This is typically not used due to its unnecessary granularity.
        /// </summary>
        ContextRevision = 0x00022004,
        
        /// <summary>
        /// Specifies whether the OpenGL context should be forward-compatible,
        /// i.e. one where all functionality deprecated in the requested version of OpenGL is removed.
        /// This must only be used if the requested OpenGL version is 3.0 or above.
        /// If OpenGL ES is requested, this hint is ignored.
        /// </summary>
        OpenGlForwardCompat = 0x00022006,
        
        /// <summary>
        /// Specifies whether to create a debug OpenGL context,
        /// which may have additional error and performance issue reporting functionality.
        /// If OpenGL ES is requested, this hint is ignored.
        /// </summary>
        OpenGlDebugContext = 0x00022007,
        
        /// <summary>
        /// Specifies which OpenGL profile to create the context for.
        /// Possible values are listed in <see cref="Glfw3.OpenGlProfile"/>.
        /// If requesting an OpenGL version below 3.2, <see cref="Glfw3.OpenGlProfile.Any"/> must be used.
        /// If OpenGL ES is requested, this hint is ignored.
        /// </summary>
        OpenGlProfile = 0x00022008,
        
        /// <summary>
        /// Specifies the robustness strategy to be used by the context.
        /// Possible values are listed in <see cref="Robustness"/>.
        /// </summary>
        ContextRobustness = 0x00022005,
        
        /// <summary>
        /// Specifies the release behavior to be used by the context.
        /// Possible values are listed in <see cref="ReleaseBehavior"/>.
        /// </summary>
        ContextReleaseBehavior = 0x00022009,
        
        /// <summary>
        /// Specifies whether errors should be generated by the context.
        /// If enabled, situations that would have generated errors instead cause undefined behavior.
        /// </summary>
        /// <remarks>This hint is experimental in its current state.
        /// As of October 2015, there are no corresponding WGL or GLX extensions.
        /// That makes this hint a hard constraint for those backends,
        /// as creation will fail if unsupported context flags are requested.
        /// Once the extensions are available, they will be required
        /// and creation of <c>GL_KHR_no_error</c> contexts may fail on early drivers
        /// where this flag is supported without those extensions being listed.</remarks>
        ContextNoError = 0x0002200A
    }
}
