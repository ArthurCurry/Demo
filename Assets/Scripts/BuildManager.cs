using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager {
    private static XmlReader instance;
    private static Dialog dialog;
    private static bool isCG;
    private static int x;
    private static int count;
    private static string name;

    public static void WhileCG()
    {        
        if (isCG)
        {
            if (x < count)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Z))
                {
                    Dialog(x);
                    x = x + 1;
                    Debug.Log(x);
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
                GameObject.FindWithTag("CG").GetComponent<CG>().mStatuss = CG.FadeStatuss.FadeOut;
            dialog.DestoryDiaLog();
        }

    }

    public static void Init()
    {
        InitPlayer();
        InitMap("Level_1-1");
    }

    public static void InitPlayer()//初始化玩家
    {
        if (GameObject.FindWithTag(HashID.PLAYER) != null)
            return;
        GameObject player = Resources.Load<GameObject>(HashID.playerPath);
        GameObject playerInstance=GameObject.Instantiate(player);
        isCG = true;
        x = 1;
        name = "第一关";
        GetCount(name);
        instance.SetIndex(0);
        BuildManager.InitDialog();
        //playerInstance.GetComponent<PlayerMovements>().InitData();
    }

    public static void InitMap(string levelName)//初始化地图
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
        instance.readXML("Resources/剧情对话.xml");
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
        dialog = new Dialog();
        dialog.showDialog();
        dialog.setDialogText(instance.getXML(name, 0));
    }

    public static void Dialog(int x)//更新对话框
    {
        instance.SetIndex(x);
        dialog.setDialogText(instance.getXML(name, 0));
    }

    public static void GetCount(string s)
    {
        count = instance.getCount(s, 0); 
    }
}
