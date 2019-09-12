using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SLevelTrigger : MonoBehaviour {
    [SerializeField]
    private Transform a;

    private XmlReader instance;
    private Dialog dialog;
    private GameObject player;
    private string s;
    private int x;
    private int count;
    private bool toPause;
    private bool onlyOne;
    // Use this for initialization
    void Start () {
        instance = new XmlReader();
        instance.ReadXML("Resources/剧情对话.xml");
        player = GameObject.FindWithTag(HashID.PLAYER);
        toPause = false;
        onlyOne = false;
        x = 0;
	}
	
	// Update is called once per frame
	void Update () {
        ShowDialog();
    }

    void Judge()
    {
        if(Mathf .Abs(player .transform.position .x - a.position .x)<=3.42f&&Mathf .Abs (player .transform .position .y -a.position.y) <= 1.14f)
        {
            if (!onlyOne)
            {
                BuildManager.Need = true;
                BuildManager.InitCG("CG10", "第六关触发1");
                toPause = true;
                onlyOne = true;
            }
        }
    }

    void InitDialog()
    {
        dialog = new Dialog();
        dialog.ID = dialog.Split(instance.GetXML(s, 0), 0);
        dialog.showDialog(dialog.JudgeD(dialog.ID));
        dialog.setDialogText(dialog.Split(instance.GetXML(s, 0), 1));
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
                    if (!JudgeD(dialog.ID))
                    {
                        dialog.DestoryDiaLog();
                        dialog.ID = dialog.Split(instance.GetXML(s, 0), 0);
                        dialog.showDialog(dialog.JudgeD(dialog.ID));
                    }
                    dialog.setDialogText(dialog.Split(instance.GetXML(s, 0), 1));
                    x = x + 1;
                }
            }
            else
            {
                toPause = false;
                x = 0;

            }
        }
        else if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            if (dialog != null)
            {
                dialog.DestoryDiaLog();
            }
        }
    }

    public bool JudgeD(string name)  //判断对话框的ID
    {
        if (name.Equals(dialog.Split(instance.GetXML(s, 0), 0)))
        {
            return true;
        }
        else return false;
    }
}
