using UnityEngine;

namespace GattaiExtensionMethods
{
    public static class SpriteExtensions
    {
        public static Texture2D ToTexture2D(this Sprite sprite)
        {
            var texture2D = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
            var spriteTextureRect = sprite.textureRect;
            var pixels = sprite.texture.GetPixels(
                (int)spriteTextureRect.x, 
                (int)spriteTextureRect.y, 
                (int)spriteTextureRect.width, 
                (int)spriteTextureRect.height);
            texture2D.SetPixels(pixels);
            texture2D.Apply();
            return texture2D;
        }
    }
}