using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroductionModel : MonoBehaviour
{
    public static Dictionary<int, Introduction> PageList = new Dictionary<int, Introduction>();

    public void Start()
    {
        Load();
    }
    private void Load()
    {
        PageList = new Dictionary<int, Introduction>();
        Introduction p1 = new Introduction( "游戏的起因", "高考结束，刚满18岁的少女本该迎来充满曙光的大学生活，却被发现惨遭谋杀，死因是脖子被勒窒息而死。\n作为一名侦探，你将潜入女孩的记忆，亲自体会女孩高三一年的点点滴滴，见证女孩高三一年的转变，找到出乎意料的凶手。", "photo1");
        Introduction p2 = new Introduction( "关卡的构成与目标", "游戏中的每一关都将展现女孩在高三生活中的一段往事。\n地图被划分成了一个一个的方格，玩家和敌人的行动轨迹都必须按格走。\n每一关都有一块出口，到达即宣告过关。", "photo2");
        Introduction p3 = new Introduction( "敌人和机关", "每一关中都充斥着各式各样的敌人和机关，\n一旦进入攻击范围即宣告关卡失败，请谨慎前行。", "photo3");
        Introduction p4 = new Introduction( "玩家和敌人的行动", "玩家可以通过WASD控制行走，每次只能走一格。\n敌人和机关的行动回合取决于玩家，即玩家移动几格，敌人也会移动几格，否则将处于静止状态。", "photo4");
        Introduction p5 = new Introduction( "收集物", "地图中充满着各种各样的收集道具，这些道具包含着女孩高三一年的往事，有助于玩家更好地理解游戏剧情。\n此外。部分道具会影响游戏分支。", "photo5");
        Introduction p6 = new Introduction( "地图碎片是什么", "地图碎片是玩家闯关中的一种稀缺的资源，\n有三种不同的大小，可以将基本所有的地图元素（包括崩塌的地面，机关，敌人等等）变成能够正常行走的地面。\n使用鼠标中键滚轮可以旋转地图碎片的角度。", "photo6");
        Introduction p7 = new Introduction( "地图碎片是什么", "地图碎片主要会随着关卡中流程得到，每一关独立计算，关卡重新开始后数量重置。\n请谨慎地使用地图碎片，避开机关和敌人，搭建一条通往收集物和终点的道路吧。", "photo7");
        Introduction p8 = new Introduction( "常用的操作键", "E：拾取道具/跳过大部分文本对话    \nB：打开背包    \nX：进行对话", "photo8");
        PageList.Add(1, p1);
        PageList.Add(2, p2);
        PageList.Add(3, p3);
        PageList.Add(4, p4);
        PageList.Add(5, p5);
        PageList.Add(6, p6);
        PageList.Add(7, p7);
        PageList.Add(8, p8);
       


    }
}