﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using TMPro;

public class IntroductionCtrlB : MonoBehaviour
{
    private Introduction[] instantiation;
    public Introduction[] get;
    public GameObject introductionText;
    public GameObject introTitle;
    public GameObject introSprite;
    public GameObject panel;
    bool Changed = true;
    public int number; 

    private void Start()
    {
        Init();
        number = 0;
    }

    void Init()
    {
        Introduction p1 = new Introduction("关卡的构成与目标", "游戏中的每一关都将展现女孩在高三生活中的一段往事。地图被划分成了一个一个的方格，玩家和敌人的行动轨迹都必须按格走。每一关都有一块出口，到达即宣告过关。", "photo2");
        Introduction p2 = new Introduction("敌人和机关", "每一关中都充斥着各式各样的敌人和机关，一旦进入攻击范围即宣告关卡失败，请谨慎前行。", "photo3");
        Introduction p3 = new Introduction("玩家和敌人的行动", "玩家可以通过WASD控制行走，每次只能走一格。敌人和机关的行动回合取决于玩家，即玩家移动几格，敌人也会移动几格，否则将处于静止状态。", "photo4");
        Introduction p4 = new Introduction("常用的操作键", "E：拾取道具     B：打开背包     X：进行对话", "photo8");
        Introduction p5 = new Introduction("收集物", "地图中充满着各种各样的收集道具，这些道具包含着女孩高三一年的往事，有助于玩家更好地理解游戏剧情。此外。部分道具会影响游戏分支。", "photo5");
        Introduction p6 = new Introduction("地图碎片是什么", "地图碎片是玩家闯关中的一种稀缺的资源，有三种不同的大小，可以将基本所有的地图元素（包括崩塌的地面，机关，敌人等等）变成能够正常行走的地面。使用鼠标中键滚轮可以旋转地图碎片的角度。", "photo6");
        Introduction p7 = new Introduction("地图碎片是什么", "地图碎片主要会随着关卡中流程得到，每一关独立计算，关卡重新开始后数量重置。请谨慎地使用地图碎片，避开机关和敌人，搭建一条通往收集物和终点的道路吧。", "photo7");
        Introduction p8 = new Introduction("异步敌人", "前方的敌人每一步都会往主角移动方向的反方向进行。", "photo11");
        Introduction p9 = new Introduction("触发机关", "大门和铁栅栏不可以被覆盖。有机关可以打开大门，试着分析怎么样行动能让异步敌人触发该机关", "photo12");
        Introduction p10 = new Introduction("同步敌人", "前方的敌人每一步都会模仿主角的行动。", "photo13");
        instantiation = new Introduction[] { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 };
        get = new Introduction[2] { new Introduction("", "", ""), new Introduction("", "", "") };
    }

    public void GetIntroductionText(Introduction introduction)
    {
        introductionText.GetComponent<TextMeshProUGUI>().text = introduction.IntroText;
    }

    public void GetIntroductionSprite(Introduction introduction)
    {
        Sprite sp = Resources.Load<Sprite>("Prefabs/Introduction/" + introduction.ImageIcon);
        introSprite.GetComponent<Image>().sprite = sp;
    }

    public void GetIntroductionTitle(Introduction introduction)
    {
        introTitle.GetComponent<TextMeshProUGUI>().text = introduction.Title;

    }

    public void CompareTo(string toCompare)
    {
        for (int i = 0; i < instantiation.Length; i++)
        {
            if(instantiation [i].Title.Equals (toCompare))
            {
                get[number] = instantiation[i];
                number++;
            }
        }
    }

    public void OpenPanel()
    {

        panel = GameObject.Find(HashID.CANVAS).transform.Find("Introduction").gameObject;
        panel.SetActive(true);

        //else panel.SetActive(true);
    }

    public void ClosePanel()
    {
        if (panel != null)
        {
            if (panel.active)
            {
                panel.SetActive(false);
                panel = null;
            }
        } 
    }
}
