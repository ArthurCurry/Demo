using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide : MonoBehaviour {

    private int count;
    private int x;

    private bool toPause;
    private bool toDone;

    private string gname;

    private IntroductionCtrlB itb;

	// Use this for initialization
	void Start () {
        itb = GameObject.Find(HashID.CANVAS).GetComponent<IntroductionCtrlB>();
        count = 0;
        toPause = false;
        toDone = false;
	}
	
	// Update is called once per frame
	void Update () {
        ShowDialog();
	}

    public void GuideTo(string name)
    {
        this.gname = name;
        itb.CompareTo(name);
        itb.OpenPanel();
        itb.GetIntroductionText(itb.get[0]);
        itb.GetIntroductionTitle(itb.get[0]);
        itb.GetIntroductionSprite(itb.get[0]);
        x = 1;
        count = itb.number;
        toPause = true;
    }

    void ShowDialog()
    {
        if (toPause)
        {
            if (x < count)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    itb.GetIntroductionTitle(itb.get[x]);
                    itb.GetIntroductionText(itb.get[x]);
                    itb.GetIntroductionSprite(itb.get[x]);
                    x = x + 1;
                }
            }
            else
            {
                toPause = false;
                toDone = true;
                x = 0;
                itb.number = 0;

            }
        }
        else
        {
            if(Input .GetKeyDown (KeyCode .Space)||Input.GetMouseButtonDown(0))
                switch (gname)
                {
                    case "基本的操作":
                        this.GuideTo("敌人·其一");
                        break;
                    case "敌人·其一":
                        this.GuideTo("敌人·其二");
                        break;
                    case "攻击机关":
                        this.GuideTo("收集道具·其一");
                        break;
                    case "收集道具·其一":
                        this.GuideTo("收集道具·其二");
                        break;
                    case "同步敌人":
                        this.GuideTo("触发机关·其一");
                        break;
                    case "触发机关·其一":
                        this.GuideTo("地图碎片·其一");
                        break;
                    case "地图碎片·其一":
                        this.GuideTo("地图碎片·其二");
                        break ;
                    default:
                        itb.ClosePanel();
                        break;
                }
        }
    }
    }
