using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Control_ScrollFlow_Item : MonoBehaviour
{
    private UI_Control_ScrollFlow parent;
    [HideInInspector]
    public RectTransform rect;
    public Image img;

    public float v=0;
    private Vector3 p, s;
    /// <summary>
    /// 缩放值
    /// </summary>
    public float sv;
   // public float index = 0,index_value;
    private Color color;

    public void Init(UI_Control_ScrollFlow _parent)
    {
        rect =this. GetComponent<RectTransform>();
        img = this.GetComponent<Image>();
        parent = _parent;
        color = img.color;
    }

    public void Drag(float value)
    {
        v += value;
        p=rect.localPosition;
        p.x=parent.GetPosition(v);
        rect.localPosition = p;

        color.a = parent.GetApa(v);
        img.color = color;
        sv = parent.GetScale(v);
        s.x = sv;
        s.y = sv;
        s.z=1;
        rect.localScale = s;
    }
}
