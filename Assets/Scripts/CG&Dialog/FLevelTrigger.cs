using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FLevelTrigger : MonoBehaviour {

    private bool toPause;
    private bool level1;
    private bool level2;

    private float time;

    private XmlReader instance;
    private Dialog dialog;
    private string s;
    private int x;
    private int count;

    private GameObject player;
    private CameraController cm;
    [SerializeField]
    private GameObject square;
    [SerializeField]
    private GameObject monster;


	// Use this for initialization
	void Start () {
        instance = new XmlReader();
        instance.ReadXML("Resources/剧情对话.xml");
        player = GameObject.FindWithTag(HashID.PLAYER);
        cm = Camera.main.GetComponent<CameraController>();
        toPause = false;
        level1 = false;
        level2 = false;
        time = 0;
        x = 0;
	}
	
	// Update is called once per frame
	void Update () {
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
        dialog.ID = dialog.Split(instance.GetXML(s, 0), 0);
        dialog.showDialog(dialog.JudgeD(dialog.ID));
        dialog.setDialogText(dialog.Split(instance.GetXML(s, 0), 1));
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
        else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Q) || Input.GetMouseButtonDown(0))
        {
            if (dialog != null)
            {
                dialog.DestoryDiaLog();
            }
            cm.MoveCameraTo(player);
        }
    }

    void Judge()
    {
        if (Mathf.Abs(player.transform.position.y - 142.54f) <= 0.02f && !level1)
        {
            cm.MoveCameraTo(monster);
            InitAttribution("第87行");
            InitDialog();
            toPause = true;
            level1 = true;
        }
        else if ((player.transform.position - square.transform.position).magnitude <= 10.02f && !level2)
        {
            cm.MoveCameraTo(square);
            InitAttribution("广场");
            InitDialog();
            toPause = true;
            level2 = true;
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
}
