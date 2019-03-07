using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.SceneManagement;

public class DragMonitor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int i, x = 0,y = 0 ;
    private int passed = 1;
    private bool keyDownStatus;
    private int keyDownCount;
    private float lastTime;
    private float currentTime;

    //key -> 要监听的按键， timeElapse -> 双击之间最大时间间隔
    bool DoubleClick(double timeElapse)
    {
        //down --> mouseDownStatus = true; //up --> mouseDownStatus = false
        if (Input.GetMouseButtonDown(0))
        {
            if (!keyDownStatus)
            {
                keyDownStatus = true;
                //Debug.Log("clicked");
                if (keyDownCount == 0)
                {// 如果按住数量为 0
                    lastTime = Time.realtimeSinceStartup;// 记录最后时间
                }
                keyDownCount++;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            keyDownStatus = false;
        }
        if (keyDownStatus)
        {
            if (keyDownCount >= 2)
            {
                currentTime = Time.realtimeSinceStartup;
                if (currentTime - lastTime < timeElapse)
                {
                    lastTime = currentTime;
                    keyDownCount = 0;
                    //Debug.Log("Double clicked");
                    return true;//返回结果，确认双击
                }
                else
                {
                    lastTime = Time.realtimeSinceStartup;  // 记录最后时间
                    keyDownCount = 1;
                }
            }
        }
        return false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerEnter.tag == "Celection")
        {
            Debug.Log(1);
            x = 1;


        }

    }

    void Update()
    {
        if (x == 1 && passed >= i && Input.GetMouseButtonDown(0))
        {
            Debug.Log(2);
            y = 1;

        }

        if (y == 1 && DoubleClick(0.3)==true)
        {
            SceneManager.LoadScene(i);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        x = 0;
        y = 0;
    }
}
