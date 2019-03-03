using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager {
    private static XmlReader instance;
    public static XmlReader Instance
    {
        get { return instance; }
    }
    private static DialogCtrl dialog;
    private static bool isCG;
    public static bool IsCG
    {
        get { return isCG; }
        set { isCG = value; }
    }
    private static int x;
    public static int X
    {
        set { x = value; }
    }
    private static int count;
    public static int Count
    {
        set { count = value; }
    }
    private static string name;
    public static string Name
    {
        get { return name; }
        set { name = value; }
    }

    public static void WhileCG()
    {        
        if (isCG)
        {
            if (x < count)
            {
                //if(Input.GetKeyDown (KeyCode.E))
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Z))
                {
                    Dialog(x);
                    x = x + 1;
                }
            }
            else
            {
                isCG = false;
                x = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Z))
        {
            if (GameObject.FindWithTag("CG"))
            {
                
                GameObject.FindWithTag("CG").GetComponent<CG>().mStatuss = CG.FadeStatuss.FadeOut;
                
            }
            if (GameObject.Find("DialogBox(Clone)"))
                dialog.DestroyDialog();
            Talk.HasTalk = false;
        }
    }

    public static void Init()
    {
        InitPlayer();
        InitMap("Level_1-1");
        MonsterManager.InitMonster();
    }

    public static void InitAttribution(string name)
    {
        isCG = true;
        x = 1;
        name = "第一关";
        GetCount(name);
        instance.SetIndex(0);
        BuildManager.InitDialog();
    }

    public static void InitPlayer()//初始化玩家
    {
        if (GameObject.FindWithTag(HashID.PLAYER) != null)
            return;
        GameObject player = Resources.Load<GameObject>(HashID.playerPath);
        GameObject playerInstance=GameObject.Instantiate(player);
        //playerInstance.GetComponent<PlayerMovements>().InitData();
    }

    public static void InitMap(string levelName) //初始化地图
    {
        if (GameObject.FindWithTag("Level") != null)
            return;
        GameObject level = Resources.Load<GameObject>(HashID.levelPath+levelName);
        GameObject.Instantiate(level);
        PlayerMovements.InitData();
    }

    public static void InitCG(string cgName)//实例化CG
    {
        instance = new XmlReader();
        instance.ReadXML("Resources/剧情对话.xml");
        instance.SetIndex(0);
        name = "旁白";
        GetCount("旁白");
        x = 1;
        GameObject CG = Resources.Load<GameObject>(HashID.cgPath + cgName);
        GameObject canvas = GameObject.Find(HashID.CANVAS);
        GameObject.Instantiate(CG, canvas.transform);
        isCG = true;
    }

    public static void InitDialog()//实例化对话框
    {
        dialog = UIManager.Instance.CtrlManager.GetT<DialogCtrl>(PanelID.DialogPanel);
        dialog.CreateDialog();        
        dialog.SetDialogView(instance.GetXML(name, 0));
    }

    public static void Dialog(int x)//更新对话框
    {
        instance.SetIndex(x);
        dialog.SetDialogView(instance.GetXML(name, 0));
    }

    public static void GetCount(string s)
    {
        count = instance.getCount(s, 0); 
    }
}
