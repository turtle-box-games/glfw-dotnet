using System;

namespace GLFW.Net
{
    /// <summary>
    /// High resolution timer.
    /// <para>The timer starts as soon as it is constructed.
    /// To reset the timer to zero, call the <see cref="Reset"/> method.</para>
    /// </summary>
    public class Timer
    {
        /// <summary>
        /// Ten million ticks per second.
        /// </summary>
        private const long TicksPerSecond = 10000000;

        /// <summary>
        /// Number of nanoseconds in a second.
        /// </summary>
        private const long NanosecondsPerSecond = 1000000000;

        /// <summary>
        /// Hertz of the underlying hardware OS timer operates at.
        /// </summary>
        private static readonly long Frequency = (long) GLFW.GetTimerFrequency();

        /// <summary>
        /// Conversion ratio from .NET ticks to the underlying timer unit.
        /// <para>Multiply by the ticks to get the underlying timer unit.</para>
        /// </summary>
        private static readonly long TicksToRawRatio = Frequency / TicksPerSecond;

        /// <summary>
        /// Conversion ratio from the underlying timer unit to .NET ticks.
        /// <para>Multiply by the underlying timer unit to get ticks.</para>
        /// </summary>
        /// <remarks>Because of integer division, this value will be zero
        /// if the underlying timer is more precise than a tick.
        /// If that is the case, divide by <see cref="TicksToRawRatio"/> to convert to ticks.</remarks>
        private static readonly long RawToTicksRatio = TicksPerSecond / Frequency;

        /// <summary>
        /// Conversion ratio from nanoseconds to the underlying timer unit.
        /// <para>Multiply by the nanoseconds to get the underlying timer unit.</para>
        /// </summary>
        private static readonly long NanoToRawRatio = Frequency / NanosecondsPerSecond;

        /// <summary>
        /// Conversion ratio from the underlying timer unit to nanoseconds.
        /// <para>Multiply by the underlying timer unit to get nanoseconds.</para>
        /// </summary>
        /// <remarks>Because of integer division, this value will be zero
        /// if the underlying timer is more precise than a nanosecond.
        /// If that is the case, divide by <see cref="NanoToRawRatio"/> to convert to nanoseconds.</remarks>
        private static readonly long RawToNanoRatio = NanosecondsPerSecond / Frequency;

        /// <summary>
        /// Stored offset from the underlying timer.
        /// <para>The underlying timer is always incrementing.
        /// This value stores the value of the underlying timer when the instance was created or reset.</para>
        /// </summary>
        private ulong _offset;

        /// <summary>
        /// Creates a new timer.
        /// The timer starts immediately after creation.
        /// </summary>
        public Timer()
        {
            Reset();
        }

        /// <summary>
        /// Gets the elapsed time that has elapsed in units used by the underlying timer.
        /// </summary>
        private long RawTime => (long) (GLFW.GetTime() - _offset);

        /// <summary>
        /// Resets the timer to zero and begins counting again.
        /// </summary>
        public void Reset()
        {
            _offset = GLFW.GetTime();
        }

        /// <summary>
        /// Retrieves the number of ticks that have elapsed since the timer was started.
        /// <para>A tick is 100 nanoseconds.
        /// 1 microsecond is 10 ticks.
        /// 1 millisecond is 10,000 ticks.
        /// 1 second is 10,000,000 ticks.</para>
        /// </summary>
        public long Ticks
        {
            get
            {
                if (RawToTicksRatio == 0)
                    return RawTime / TicksToRawRatio;
                return RawTime * RawToTicksRatio;
            }
        }

        /// <summary>
        /// Retrieves the number of nanoseconds that have elapsed since the timer was started.
        /// </summary>
        public long Nanoseconds
        {
            get
            {
                if (RawToNanoRatio == 0)
                    return RawTime / NanoToRawRatio;
                return RawTime * RawToNanoRatio;
            }
        }

        /// <summary>
        /// Retrieves the time that has passed as a span.
        /// </summary>
        public TimeSpan Elapsed => new TimeSpan(Ticks);
    }
}
