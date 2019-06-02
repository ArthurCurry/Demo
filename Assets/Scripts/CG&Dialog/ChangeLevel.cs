using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeLevel : MonoBehaviour {

    private Transform player;

    private XmlReader instance;
    private Dialog dialog;
    private string s;
    private int x;
    private int count;
    private bool toPause;
    private bool onlyOne;

    // Use this for initialization
    void Start () {
        instance = new XmlReader();
        instance.ReadXML("Resources/剧情对话.xml");
        player = GameObject.FindWithTag(HashID.PLAYER).transform;
        toPause = false;
        onlyOne = false;
        x = 0;
    }
	
	// Update is called once per frame
	void Update () {
        Judge();
        ShowDialog();
    }

    void Judge()
    {
        if(this.transform.position  == player.position)
        {
            if (BuildManager.Level == 1)
            {
                if (!onlyOne)
                {
                    if (GameObject.Find("Level_1(Clone)")) // Debug会话框不会消失。
                    {
                        GameObject level = GameObject.Find("Level_1(Clone)");
                        level.GetComponent<PatrolTalk>()._Destroy();
                        level.GetComponent<PatrolTalk>().enabled = false;
                    }
                    InitAttribution("到达终点");
                    InitDialog();
                    toPause = true;
                    onlyOne = true;
                }
            }
            else
            {
                BuildManager.Judge();
                BuildManager.Destroy_All();
                GameObject root = GameObject.Find("Canvas");
                root.GetComponent<ChangeEffect>().M_State = ChangeEffect.State.FadeIn;
                root.GetComponent<ChangeEffect>().game = ChangeEffect.o_status.start;
            }
        }
    }

    void InitDialog()
    {
        dialog = new Dialog();
        dialog.showDialog();
        dialog.setDialogText(instance.GetXML(s, 0));
    }

    void InitAttribution(string n) // 赋予触发剧情的属性
    {
        x = 1;
        s = n;
        count = instance.getCount(s, 0);
        instance.SetIndex(0);
    }

    void ShowDialog()
    {
        if (toPause)
        {
            if (x < count)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    instance.SetIndex(x);
                    dialog.setDialogText(instance.GetXML(s, 0));
                    x = x + 1;
                }
            }
            else
            {
                toPause = false;
                x = 0;

            }
        }
        else if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))&& this.transform.position == player.position)
        {
            if (dialog != null)
            {
                dialog.DestoryDiaLog();
            }
            BuildManager.Judge();
            BuildManager.Destroy_All();
            GameObject root = GameObject.Find("Canvas");
            root.GetComponent<ChangeEffect>().M_State = ChangeEffect.State.FadeIn;
            root.GetComponent<ChangeEffect>().game = ChangeEffect.o_status.start;
        }
    }
}
