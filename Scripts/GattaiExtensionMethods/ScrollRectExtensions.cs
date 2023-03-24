using UnityEngine;
using UnityEngine.UI;

namespace GattaiExtensionMethods
{
    public static class ScrollRectExtensions
    {
        public static void SnapTo(this ScrollRect scrollRect, RectTransform targetRectTransform)
        {
            var contentPos = (Vector2) scrollRect.transform.InverseTransformPoint(scrollRect.content.position);
            
            var childPos = (Vector2) scrollRect.transform.InverseTransformPoint(targetRectTransform.position);
            
            var endPos = contentPos - childPos;
            
            if (!scrollRect.horizontal)
            {
                endPos.x = contentPos.x;
            }

            if (!scrollRect.vertical)
            {
                endPos.y = contentPos.y;
            }
            
            scrollRect.content.anchoredPosition = endPos;
        }

        public static void SnapToTop(this ScrollRect scrollRect)
        {
            SnapTo(scrollRect, scrollRect.transform.GetChild(0).GetComponent<RectTransform>());
        }
    }
}