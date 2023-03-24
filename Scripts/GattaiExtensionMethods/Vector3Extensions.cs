using UnityEngine;

namespace GattaiExtensionMethods
{
    public static class Vector3Extensions
    {
        /// <summary>
        /// Round all the source axis coordinates.
        /// </summary>
        /// <param name="source">The source Vector3 to round.</param>
        /// <returns>The Vector3 with rounded coordinates.</returns>
        public static void Round(this ref Vector3 source)
        {
            source.x = Mathf.RoundToInt(source.x);
            source.y = Mathf.RoundToInt(source.y);
            source.z = Mathf.RoundToInt(source.z);
        }

        public static Vector3Int ToVector3Int(this Vector3 source)
        {
            source.Round();
            return new Vector3Int((int)source.x, (int)source.y, (int)source.z);
        }
    }
}