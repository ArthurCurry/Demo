using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.SceneManagement;

public class DragMonitor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int level=1, x = 0,y = 0 ;
    public static int passed = 6;
    private bool keyDownStatus;
    private int keyDownCount;
    private float lastTime;
    private float currentTime;
    private GameObject gameManager;

    private AudioPlay ap;
    private AudioClip clip1;
    private AudioClip clip2;


    void Awake()
    {
        ap = new AudioPlay();
        clip1 = ap.AddAudioClip("Audio/转场（选关界面进入游戏）");
        clip2 = ap.AddAudioClip("Audio/点击");
        gameManager = GameObject.Find("GameManager");
    }

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
            //Debug.Log(1);
            x = 1;


        }

    }

    void Update()
    {
        if (x == 1 && passed >= level && Input.GetMouseButtonDown(0))
        {
            //Debug.Log(2);
            y = 1;

        }

        if (y == 1 && DoubleClick(0.3)==true)
        {
            
            switch (level)
            {
                case 1:
                    BuildManager.XMLName = "第一关";
                    BuildManager.LevelName = "Level_1";
                    BuildManager.Level = 1;
                    break;
                case 2:
                    BuildManager.XMLName = "第二关";
                    BuildManager.LevelName = "Level_2";
                    BuildManager.Level = 2;
                    break;
                case 3:
                    BuildManager.XMLName = "第三关";
                    BuildManager.LevelName = "Level_3";
                    BuildManager.Level = 3;
                    break;
                case 4:
                    BuildManager.XMLName = "第四关";
                    BuildManager.LevelName = "Level_4";
                    BuildManager.Level = 4;
                    break;
                case 5:
                    BuildManager.XMLName = "第五关";
                    BuildManager.LevelName = "Level_5";
                    BuildManager.Level = 5;
                    break;
                case 6:
                    BuildManager.XMLName = "第六关";
                    BuildManager.LevelName = "Level_6";
                    BuildManager.Level = 6;
                    break;
            }
            ap.PlayClipAtPoint(clip1, Camera.main.transform.position, 1f);
            DontDestroyOnLoad(GameObject.Find("One shot audio"));
            SceneManager.LoadScene(3);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        x = 0;
        y = 0;
    }

    public void PlayAudio()
    {
        ap.PlayClipAtPoint(clip2, Camera.main.transform.position , 1f);
        DontDestroyOnLoad(GameObject.Find("One shot audio"));
    }

    public void Add()
    {
        if (level == 6)
            return;
        level++;
    }

    public void Decrese()
    {
        if (level == 1)
            return;
        level--;
    }
}
