using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Glfw3
{
    public static partial class Glfw
    {
        /// <summary>
        /// Utility method for passing a delegate to a unmanaged callback setter.
        /// </summary>
        /// <param name="setter">Unmanaged callback setter.</param>
        /// <param name="callback">Managed delegate function to pass to the setter.</param>
        /// <typeparam name="TDelegate">Type of callback.</typeparam>
        /// <returns>Previously set delegate or <c>null</c>.</returns>
        private static TDelegate SetInternalCallback<TDelegate>(Func<IntPtr, IntPtr> setter, TDelegate callback)
        {
            var pointerForDelegate = callback.EqualsDefault()
                ? IntPtr.Zero
                : Marshal.GetFunctionPointerForDelegate(callback);
            var prevCallbackPointer = setter(pointerForDelegate);
            HandleError();
            return prevCallbackPointer == IntPtr.Zero
                ? default
                : Marshal.GetDelegateForFunctionPointer<TDelegate>(prevCallbackPointer);
        }

        /// <summary>
        /// Utility method for passing a delegate to a unmanaged callback setter.
        /// </summary>
        /// <param name="setter">Unmanaged callback setter.</param>
        /// <param name="callback">Managed delegate function to pass to the setter.</param>
        /// <param name="window">Pointer to the window to attach the callback to.</param>
        /// <typeparam name="TDelegate">Type of callback.</typeparam>
        /// <returns>Previously set delegate or <c>null</c>.</returns>
        private static TDelegate SetInternalCallback<TDelegate>(Func<IntPtr, IntPtr, IntPtr> setter,
            TDelegate callback, IntPtr window)
        {
            var pointerForDelegate = callback.EqualsDefault()
                ? IntPtr.Zero
                : Marshal.GetFunctionPointerForDelegate(callback);
            var prevCallbackPointer = setter(window, pointerForDelegate);
            HandleError();
            return prevCallbackPointer == IntPtr.Zero
                ? default
                : Marshal.GetDelegateForFunctionPointer<TDelegate>(prevCallbackPointer);
        }

        /// <summary>
        /// Checks whether an instance or value is equal to its default.
        /// This is useful to checking if a generic argument is null or zero.
        /// </summary>
        /// <param name="self">Instance or value to check.</param>
        /// <typeparam name="T">Type of the instance or value.</typeparam>
        /// <returns>True if <paramref name="self"/> equals its default.
        /// This means <c>null</c> for reference types or "zero" or value types.</returns>
        private static bool EqualsDefault<T>(this T self)
        {
            return EqualityComparer<T>.Default.Equals(self, default);
        }
    }
}
