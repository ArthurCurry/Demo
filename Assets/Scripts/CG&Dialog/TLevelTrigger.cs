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

    private IntroductionCtrlB itb;
    private bool status;
    private bool level;
    [SerializeField]
    private Transform upperright;
    [SerializeField]
    private Transform lowerleft;

    // Use this for initialization
    void Start()
    {
        itb = GameObject.Find(HashID.CANVAS).GetComponent<IntroductionCtrlB>();
        instance = new XmlReader();
        instance.ReadXML("Resources/剧情对话.xml");
        player = GameObject.FindWithTag(HashID.PLAYER);
        toPause = false;
        status = false;
        ahasTalk = false;
        bhasTalk = false;
        chasTalk = false;
        level = false;
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
                    if (status)
                    {
                        itb.GetIntroductionTitle(itb.get[x]);
                        itb.GetIntroductionText(itb.get[x]);
                        itb.GetIntroductionSprite(itb.get[x]);
                        x = x + 1;
                    }
                    else
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
            }
            else
            {
                if(status)
                {
                    status = false;
                    itb.number = 0;
                }
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
            itb.ClosePanel();

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
        else if(!OutOfRange(player)&&!status&&!level)
        {
            itb.CompareTo("同步敌人");
            count = itb.number;
            itb.OpenPanel();
            itb.GetIntroductionTitle(itb.get[0]);
            itb.GetIntroductionText(itb.get[0]);
            itb.GetIntroductionSprite(itb.get[0]);
            x = 1;
            status = true;
            toPause = true;
            level = true;
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

    private bool OutOfRange(GameObject character)
    {
        if ((character.transform.position.x >= lowerleft.position.x && character.transform.position.y >= lowerleft.position.y) && (character.transform.position.x <= upperright.position.x && character.transform.position.y <= upperright.position.y))
            return false;
        else
            return true;
    }
}
