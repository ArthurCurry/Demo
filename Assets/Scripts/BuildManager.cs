using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager {
    private static XmlReader instance;
    private static Dialog dialog;
    private static bool isCG;
    private static int x;

    public static void WhileCG()
    {        
        if (isCG)
        {
            if (x < 6)
            {
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
        x = 1;
        GameObject CG = Resources.Load<GameObject>(HashID.cgPath + cgName);
        GameObject canvas = GameObject.Find(HashID.CANVAS);
        GameObject.Instantiate(CG, canvas.transform);
        isCG = true;
        
    }

    public static void InitDialog()//实例化对话框
    {
        instance = new XmlReader();
        instance.readXML("Resources/剧情对话.xml");
        instance.SetIndex(0);
        dialog = new Dialog();
        dialog.showDialog();
        dialog.setDialogText(instance.getXML("旁白", 0));
    }

    public static void Dialog(int x)//更新对话框
    {
        instance.SetIndex(x);
        dialog.setDialogText(instance.getXML("旁白", 0));
    }
}
