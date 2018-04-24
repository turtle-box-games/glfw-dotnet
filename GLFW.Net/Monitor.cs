using System;

namespace GLFW.Net
{
    public struct Monitor
    {
        private IntPtr _monitorPointer;

        private Monitor(IntPtr monitorPointer)
        {
            throw new NotImplementedException();
        }
        
        public static Monitor[] List
        {
            get { throw new NotImplementedException(); }
        }

        public static Monitor Primary
        {
            get { throw new NotImplementedException(); }
        }

        public object Position
        {
            get { throw new NotImplementedException(); }
        }

        public object Size
        {
            get { throw new NotImplementedException(); }
        }

        public object PhysicalSize
        {
            get { throw new NotImplementedException(); }
        }

        public string Name
        {
            get { throw new NotImplementedException(); }
        }

        public object[] VideoModes
        {
            get { throw new NotImplementedException(); }
        }

        public object VideoMode
        {
            get { throw new NotImplementedException(); }
        }

        public object GammaRamp
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public void SetGamma(float gamma)
        {
            throw new NotImplementedException();
        }
    }
}