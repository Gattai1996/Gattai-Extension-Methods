using UnityEngine;
using UnityEngine.UI;

namespace GattaiExtensionMethods
{
    public static class ImageExtensions
    {
        public static void SetTexture2D(this Image image, Texture2D texture2D)
        {
            image.sprite = texture2D.ToSprite();
        }
    }
}