using UnityEngine;

namespace GattaiExtensionMethods
{
    public static class Texture2DExtensions
    {
        public static Sprite ToSprite(this Texture2D texture2D)
        {
            var rect = new Rect(0, 0, texture2D.width, texture2D.height);
            var sprite = Sprite.Create(texture2D, rect, Vector2.zero);
            return sprite;
        }
    }
}