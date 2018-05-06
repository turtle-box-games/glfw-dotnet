using System;
using System.Runtime.InteropServices;

namespace GLFW.Net
{
    /// <summary>
    /// Custom marshalling utilities.
    /// </summary>
    internal static class MarshalUtil
    {
        /// <summary>
        /// Extracts structure elements from a pointer to an unmanaged array.
        /// </summary>
        /// <param name="pointerToArray">Pointer to an unmanaged array of structures.</param>
        /// <param name="count">Number of items in the array.</param>
        /// <param name="itemSize">Size, in bytes, of each element in the array.</param>
        /// <typeparam name="T">Type of elements in the array.</typeparam>
        /// <returns>Managed array of structure data copied from the unmanaged array.</returns>
        public static T[] PtrToStructureArray<T>(this IntPtr pointerToArray, int count, int itemSize)
        {
            var array = new T[count];
            for (var i = 0; i < count; i++)
                array[i] = Marshal.PtrToStructure<T>(pointerToArray + i * itemSize);
            return array;
        }
    }
}
