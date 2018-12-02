using UnityEditor;
using UnityEngine;

public class RectTransformContextMenu
{
    [MenuItem("CONTEXT/RectTransform/SetEasyAnchors", false, 151)]
    static void SetEasyAnchors()
    {
        var objs = Selection.gameObjects;

        foreach (var o in objs)
        {
            if (o != null && o.GetComponent<RectTransform>() != null)
            {
                var r = o.GetComponent<RectTransform>();
                var p = o.transform.parent.GetComponent<RectTransform>();

                var offsetMin = r.offsetMin;
                var offsetMax = r.offsetMax;
                var _anchorMin = r.anchorMin;
                var _anchorMax = r.anchorMax;

                var parent_width = p.rect.width;
                var parent_height = p.rect.height;

                var anchorMin = new Vector2(_anchorMin.x + (offsetMin.x / parent_width),
                    _anchorMin.y + (offsetMin.y / parent_height));
                var anchorMax = new Vector2(_anchorMax.x + (offsetMax.x / parent_width),
                    _anchorMax.y + (offsetMax.y / parent_height));

                r.anchorMin = anchorMin;
                r.anchorMax = anchorMax;

                r.offsetMin = new Vector2(0, 0);
                r.offsetMax = new Vector2(0, 0);
                r.pivot = new Vector2(0.5f, 0.5f);
            }
        }
    }
}
