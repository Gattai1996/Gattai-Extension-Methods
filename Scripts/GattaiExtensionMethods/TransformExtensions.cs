using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GattaiExtensionMethods
{
    public static class TransformExtensions
    {
        public static IEnumerable<Transform> GetChildren(this Transform transform)
        {
            for (var i = 0; i < transform.childCount; i++)
            {
                yield return transform.GetChild(i);
            }
        }

        public static void DestroyChildren(this Transform transform)
        {
            var children = new Queue<Transform>(transform.GetChildren());
            
            while (children.Any())
            {
                var child = children.Dequeue();
                Object.Destroy(child.gameObject);
            }
        }
    }
}