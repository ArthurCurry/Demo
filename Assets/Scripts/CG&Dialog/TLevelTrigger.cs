using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TLevelTrigger : MonoBehaviour {

    private bool toPause;
    private bool ahasTalk;
    private bool bhasTalk;
    private bool chasTalk;

    private XmlReader instance;
    private Dialog dialog;
    private string s;
    private int x;
    private int count;

    private GameObject player;
    private CameraController cm;
    [SerializeField]
    private GameObject npc3;
    [SerializeField]
    private GameObject npc5;


    // Use this for initialization
    void Start()
    {
        instance = new XmlReader();
        instance.ReadXML("Resources/剧情对话.xml");
        player = GameObject.FindWithTag(HashID.PLAYER);
        toPause = false;
        ahasTalk = false;
        bhasTalk = false;
        chasTalk = false;
        x = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Judge();
        ShowDialog();
        Reset();
    }

    void InitAttribution(string n) // 赋予触发剧情的属性
    {
        x = 1;
        s = n;
        count = instance.getCount(s, 0);
        instance.SetIndex(0);
    }

    void InitDialog()
    {
        dialog = new Dialog();
        dialog.ID = dialog.Split(instance.GetXML(name, 0), 0);
        dialog.showDialog(dialog.JudgeD(dialog.ID));
        dialog.setDialogText(dialog.Split(instance.GetXML(name, 0), 1));
    }

    void ShowDialog()
    {
        if (toPause)
        {
            if (x < count)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Q) || Input.GetMouseButtonDown(0))
                {
                    instance.SetIndex(x);
                    if (!JudgeD(dialog.ID))
                    {
                        dialog.DestoryDiaLog();
                        dialog.ID = dialog.Split(instance.GetXML(name, 0), 0);
                        dialog.showDialog(dialog.JudgeD(dialog.ID));
                    }
                    dialog.setDialogText(dialog.Split(instance.GetXML(name, 0), 1));
                    x = x + 1;
                }
            }
            else
            {
                toPause = false;
                x = 0;

            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Q) || Input.GetMouseButtonDown(0))
        {
            if (dialog != null)
            {
                dialog.DestoryDiaLog();
            }
        }
    }

    void Judge()
    {
        if ((player.transform.position - npc3.transform.position).magnitude < 0.3f && !ahasTalk)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                InitAttribution("npc3");
                InitDialog();
                toPause = true;
                ahasTalk = true;
            }
        }
        else if ((player.transform.position - npc3.transform.position).magnitude < 0.3f && !bhasTalk && !chasTalk)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                InitAttribution("npc51");
                InitDialog();
                toPause = true;
                bhasTalk = true;
            }
        }
        else if ((player.transform.position - npc3.transform.position).magnitude < 0.3f && bhasTalk && !chasTalk)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                InitAttribution("npc52");
                InitDialog();
                toPause = true;
                chasTalk = true;
            }
        }
    }

    public bool JudgeD(string name)  //判断对话框的ID
    {
        if (name.Equals(dialog.Split(instance.GetXML(name, 0), 0)))
        {
            return true;
        }
        else return false;
    }

    void Reset()
    {
        if (dialog != null)
        {
            if (dialog.instantiation != null)
            {
                int x = GameObject.Find(HashID.CANVAS).transform.childCount;
                dialog.instantiation.transform.SetSiblingIndex(x - 1);
            }
        }
    }

}
