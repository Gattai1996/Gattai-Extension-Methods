using System.Collections.Generic;
using UnityEngine;

namespace GattaiExtensionMethods
{
    public static class ListExtensions
    {
        public static bool AddUnique<T>(this IList<T> source, T item)
        {
            if (source.Contains(item)) return false;
            source.Add(item);
            return true;
        }
        
        public static bool TryRemove<T>(this IList<T> source, T item)
        {
            if (!source.Contains(item)) return false;
            source.Remove(item);
            return true;
        }
        
        /// <summary>
        /// Shuffle the elements of a list.
        /// </summary>
        /// <param name="list">The list that is about to shuffle its elements.</param>
        /// <typeparam name="T">Hidden parameter to make this method generic. The list's elements can be of any type.</typeparam>
        public static void Shuffle<T>(this IList<T> list)
        {
            for (var i = 0; i < list.Count; i++)
            {
                // Choose and cache a random element on the list
                var r = Random.Range(0, i);
                
                // Invert the random and current elements to shuffle the list
                (list[r], list[i]) = (list[i], list[r]);
            }
        }
    }
}