using UnityEngine;

namespace GattaiExtensionMethods
{
    public static class ArrayExtensions
    {
        public static void ClearAll(this Collider[] colliders)
        {
            for (var i = 0; i < colliders.Length; i++)
            {
                colliders[i] = null;
            }
        }
    }
}