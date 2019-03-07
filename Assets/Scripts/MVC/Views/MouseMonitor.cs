using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class MouseMonitor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public static Action<Transform> OnEnter;
    public static Action OnExit;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log(1);
        if (eventData.pointerEnter.tag == "Grid")
        {
            Debug.Log(2);
            if (OnEnter != null)
            {
                OnEnter(transform);
                Debug.Log(3);
            }

        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerEnter.tag == "Grid")
        {
            if (OnExit != null)
                OnExit();
        }
    }
}
