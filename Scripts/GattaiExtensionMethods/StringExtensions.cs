using System.Linq;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace GattaiExtensionMethods
{
    public static class StringExtensions
    {
        /// <summary>
        /// Puts the string into the Clipboard.
        /// </summary>
        public static void CopyToClipboard(this string source)
        {
            GUIUtility.systemCopyBuffer = source;
#if UNITY_EDITOR
            EditorUtility.DisplayDialog("Copied to clipboard", $"Text: \n \n{source}", "OK");
#endif
        }

        public static string Bold(this string source) => $"<b>{source}</b>";

        public static string Italic(this string source) => $"<i>{source}</i>";

        public static string Size(this string source, int size) => $"<size={size}>{source}</size>";

        public static string Color(this string source, string hex)
        {
            if (hex.ToCharArray().First() != '#')
            {
                hex = $"#{hex}";
            }
            
            return $"<color={hex}>{source}</color>";
        }

        public static string Color(this string source, Color color)
        {
            var hex = ColorUtility.ToHtmlStringRGBA(color);
            return source.Color(hex);
        }

        public static string Color(this string source, int r, int g, int b, int a = 255)
        {
            var color = new Color(r, g, b, a);
            return source.Color(color);
        }
    }
}