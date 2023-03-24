using System;
using System.Collections.Generic;
using System.Linq;

namespace GattaiExtensionMethods
{
    /// <summary>
    /// This class contains extensions methods for the Enumerable class.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Checks if all elements in a enumerable are distinct.
        /// </summary>
        /// <param name="source">The source enumerable.</param>
        /// <typeparam name="T">The type of the elements of the enumerable.</typeparam>
        /// <returns>A boolean presenting whether all elements in the source enumerable are distinct.</returns>
        public static bool AllDistinct<T>(this IEnumerable<T> source)
        {
            var buffer = source.ToArray();
            return buffer.Distinct().Count() == buffer.Length;
        }

        /// <summary>
        /// Randomize the enumerable shuffling all the elements in it.
        /// </summary>
        /// <param name="source">The source enumerable.</param>
        /// <typeparam name="T">The type of the elements of the enumerable.</typeparam>
        /// <returns>The source enumerable shuffled.</returns>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source) 
        {
            var buffer = source.ToArray();
            
            for (var i = 0; i < buffer.Length; i++)
            {
                var next = UnityEngine.Random.Range(i, buffer.Length);
                yield return buffer[next];
                buffer[next] = buffer[i];
            }
        }

        /// <summary>
        /// Returns a random element in the source enumerable.
        /// </summary>
        /// <param name="source">The source enumerable.</param>
        /// <typeparam name="T">The type of the elements of the enumerable.</typeparam>
        /// <returns>Random element.</returns>
        public static T Random<T>(this IEnumerable<T> source)
        {
            var buffer = source.ToArray();
            var index = UnityEngine.Random.Range(0, buffer.Length);
            return !buffer.Any() ? default : buffer.ElementAt(index);
        }

        /// <summary>
        /// Returns the element at a given index position without removing it from the collection.
        /// </summary>
        /// <param name="source">The source collection.</param>
        /// <param name="index">The pretended index position.</param>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <returns>The object at the index position.</returns>
        public static T PeekAt<T>(this IEnumerable<T> source,  int index)
        {
            var buffer = source.ToArray();
            return buffer.Length - 1 < index ? default : buffer.Skip(index).First();
        }

        /// <summary>
        /// Select all child elements recursively.
        /// </summary>
        /// <param name="source">The source enumerable.</param>
        /// <param name="selector">The function to select the child elements.</param>
        /// <typeparam name="T">The type of the elements of the enumerable.</typeparam>
        /// <returns>All recursive child elements.</returns>
        public static IEnumerable<T> SelectRecursively<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> selector)
        {
            foreach (var parent in source)
            {
                yield return parent;

                var children = selector(parent);
                
                foreach (var child in SelectRecursively(children, selector))
                {
                    yield return child;
                }
            }
        }
    }
}