using System.Collections;
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
    public bool hasGot;
    public int number; 

    private void Start()
    {
        Init();
        number = 0;
        hasGot = false;
    }

    void Init()
    {
        Introduction p1 = new Introduction("基本的操作", "玩家可以通过WASD控制行走，每次只能行动一格。经过重重阻碍到达游戏目的地即视为成功通关。", "photo2");
        Introduction p2 = new Introduction("敌人·其一", "每一名敌人都有着自己的攻击范围，一旦被攻击到即判定死亡。", "photo3");
        Introduction p3 = new Introduction("敌人·其二", "敌人的机关的行动回合取决于玩家，即玩家每进行一次行走操作，敌人也会按照设定路径进行一次行走操作，否则将处于静止状态。", "photo4");
        Introduction p4 = new Introduction("攻击机关", "眼球机关的攻击范围为面前五格。玩家每进行一次行走操作，机关则会顺时针转90度，否则将处于静止状态。", "photo8");
        Introduction p5 = new Introduction("收集道具·其一", "地图中充满着各种各样的收集道具。", "photo5");
        Introduction p6 = new Introduction("收集道具·其二", "这些道具包含着女孩高三一年的往事，有助于玩家更好地理解游戏剧情。", "photo6");
        Introduction p7 = new Introduction("同步敌人", "在前方的敌人是同步敌人，其每一步都会模仿主角的行动。", "photo7");
        Introduction p8 = new Introduction("触发机关·其一", "这种有不详气息的机关无法由玩家进行操纵，必须诱导敌人踏上此机关以触发事件。", "photo11");
        Introduction p9 = new Introduction("地图碎片·其一", "在红线框定的范围内，会给予玩家特定的物件——地图碎片。可以拖拽放置地图碎片，将异常的地面（包括无法行走的地面，坍塌地面，冰面）变成能够正常行走的地面。", "photo12");
        Introduction p10 = new Introduction("地图碎片·其二", "请注意，地图碎片只对红线内地图有效。进入红线区域地图碎片会出现，一旦走出即会消失。", "photo13");
        Introduction p11 = new Introduction("冰面", "无论是玩家还是敌人，在冰面上面都会滑行，直到遇到阻碍或者正常路面。滑行只算做一步操作。", "photo13");
        Introduction p12 = new Introduction("触发机关·其二", "这种正常的机关可以由玩家进行触碰，并且触发相应的事件。", "photo13");
        Introduction p13 = new Introduction("异步敌人", "在前方的敌人是异步敌人，其每一步都会与主角的行动相反。", "photo13");
        Introduction p14 = new Introduction("传送门", "在传送门上面按E键，即可传送到另一相同颜色的传送门。", "photo13");
        Introduction p15 = new Introduction("针刺", "从地面冒出的针刺，碰到就会致死。", "photo13");
        Introduction p16 = new Introduction("通道", "从地方传送门中每隔固定回合会出现敌人，沿着固定的通道行走。", "photo13");
        Introduction p17 = new Introduction("坍塌地面", "如图所示为塌陷地块，只要人物经过就会掉落，成为无法行走的区域。", "photo13");
        instantiation = new Introduction[] { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17 };
        get = new Introduction[3] { new Introduction("", "", ""), new Introduction("", "", ""), new Introduction("", "", "") };
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
        if (!hasGot)
        {
            panel = GameObject.Find(HashID.CANVAS).transform.Find("Introduction").gameObject;
            hasGot = true;
        }
        panel.SetActive(true);
    }

    public void ClosePanel()
    {
        if (panel != null && hasGot)
        {
            if (panel.activeInHierarchy)
            {
                panel.SetActive(false);
                panel = null;
                hasGot = false;
            }
        }
    }
}
