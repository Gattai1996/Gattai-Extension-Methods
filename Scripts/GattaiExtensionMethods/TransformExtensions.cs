using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GattaiExtensionMethods
{
    public static class TransformExtensions
    {
        public static void DestroyChildren(this Transform transform)
        {
            var children = new Queue<Transform>();
            
            for (var i = 0; i < transform.childCount; i++)
            {
                children.Enqueue(transform.GetChild(i));
            }

            while (children.Any())
            {
                var child = children.Dequeue();
                Object.Destroy(child.gameObject);
            }
        }
    }
}