using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager {
    private static XmlReader instance;
    public static XmlReader Instance
    {
        set { instance = value; }
        get { return instance; }
    }
    private static Dialog dialog;
    private static bool isCG;
    public static bool IsCG
    {
        get { return isCG; }
        set { isCG = value; }
    }
    private static bool need;
    public static bool Need
    {
        get { return need; }
        set { need = value; }
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
        get { return count; }
    }
    private static string name;
    public static string Name
    {
        get { return name; }
        set { name = value; }
    }
    private static int level;
    public static int Level
    {
        get { return level; }
        set { level = value; }
    }
    private static string levelName;
    public static string LevelName
    {
        get { return levelName; }
        set { levelName = value; }
    }
    private static string XMLname;
    public static string XMLName
    {
        get { return XMLname; }
        set { XMLname = value; }
    }

    private static GameObject map;
    public static GameObject Map
    {
        get { return map; }
        set { map = value; }
    }

    public static bool CGEnd = false;
    public static bool toDestroy = false;

    public static bool tocollect = false;

    private static AudioPlay ap = new AudioPlay();
    private static Guide guide = GameObject.Find(HashID.CANVAS).GetComponent<Guide>();

    public static void WhileCG()
    {        
        if (isCG)
        {
            if(Input .GetKeyDown (KeyCode.E))
            {
                isCG = false;
                x = 0;
                CGEnd = true;
                ap.PlayClipAtPoint(ap.AddAudioClip("Audio/点击"), Camera.main.transform.position, 1f);
                if (GameObject.FindWithTag("CG"))
                    GameObject.FindWithTag("CG").GetComponent<CG>().mStatuss = CG.FadeStatuss.FadeOut;
                dialog.DestoryDiaLog();
                Talk.HasTalk = false;
            }
            if (x < count)
            {
                if (Input.GetKeyDown(KeyCode.Space)|| Input .GetMouseButtonDown (0))
                {
                    if(x==2 && GameObject.Find(HashID.CANVAS).transform.Find("CG6(Clone)"))
                    {
                        ap.PlayClipAtPoint(ap.AddAudioClip("Audio/上课铃"), Camera.main.transform.position, 1f);
                    }
                    ap.PlayClipAtPoint(ap.AddAudioClip("Audio/点击"), Camera.main.transform.position, 1f);
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
    else if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            ap.PlayClipAtPoint(ap.AddAudioClip("Audio/点击"), Camera.main.transform.position, 1f);
            CGEnd = true;
            if (GameObject.FindWithTag("CG"))
                GameObject.FindWithTag("CG").GetComponent<CG>().mStatuss = CG.FadeStatuss.FadeOut;
            dialog.DestoryDiaLog();
            if (!GameObject.FindWithTag("CG"))
            {
                switch (level)
                {
                    case 1:
                        guide.GuideTo("基本的操作");
                        break;
                    case 2:
                        guide.GuideTo("攻击机关");
                        break;
                    case 3:
                        guide.GuideTo("同步敌人");
                        break;
                    case 4:
                        guide.GuideTo("冰面");
                        break;
                    case 5:
                        guide.GuideTo("触发机关·其二");
                        break;
                    case 6:
                        guide.GuideTo("异步敌人");
                        break;
                }
            }
            Talk.HasTalk = false;
        }

    }

    public static void Init()
    {
        if (instance == null)
        {
            instance = new XmlReader();
            instance.ReadXML("Resources/剧情对话.xml");
            instance.SetIndex(0);
        }
        InitPlayer();
        InitMap(levelName);
        MonsterManager.InitMonster();
    }

    public static void InitAttribute()  //初始化属性
    {
        isCG = true;
        x = 1;
        name = XMLname;
        GetCount(name);
        instance.SetIndex(0);
        if (need)
        {
            BuildManager.InitDialog();
            need = false;
        }
    }

    public static void InitPlayer()//初始化玩家
    {
        if (GameObject.FindWithTag(HashID.PLAYER) != null)
            return;
        GameObject player = Resources.Load<GameObject>(HashID.playerPath);
        GameObject playerInstance=GameObject.Instantiate(player);

        //playerInstance.GetComponent<PlayerMovements>().InitData();
    }

    public static void InitMap(string levelName)//初始化地图 备份地图
    {
        if (GameObject.FindWithTag("Level") != null)
            return;
        if(LevelName.Equals("Level_2"))
        {
            name = "异步敌人";
        }
        GameObject level = Resources.Load<GameObject>(HashID.levelPath+levelName);
        map = GameObject.Instantiate(level);
        map.SetActive(false);
        GameObject.Instantiate(level);
        PlayerMovements.InitData();
    }

    public static void InitCG(string cgName,string Xname)//实例化CG
    {
        instance = new XmlReader();
        instance.ReadXML("Resources/剧情对话.xml");
        instance.SetIndex(0);
        if (need)
        {
            name = Xname;
            GetCount(Xname);
            isCG = true;
        }
        else
        {
            count = 0;
            isCG = false;
            
        }
        x = 1;
        GameObject CG = Resources.Load<GameObject>(HashID.cgPath + cgName);
        GameObject canvas = GameObject.Find(HashID.CANVAS);
        GameObject.Instantiate(CG, canvas.transform);        
    }

    public static void InitDialog()//实例化对话框
    {
        dialog = new Dialog();
        dialog.ID = dialog.Split(instance.GetXML(name, 0), 0);
        dialog.showDialog(dialog.JudgeD(dialog.ID));
        dialog.setDialogText(dialog.Split(instance.GetXML(name, 0), 1));
    }

    public static void InitIntroduction()
    {
        dialog = new Dialog();
        dialog.ID = null;
        dialog.ShowIntroduction();
        dialog.setDialogText(instance.GetXML(name, 0));
    }

    public static void Dialog(int x)//更新对话框
    {
        instance.SetIndex(x);
        if (dialog.ID != null)
        {
            if (!JudgeD(dialog.ID))
            {
                dialog.DestoryDiaLog();
                dialog.ID = dialog.Split(instance.GetXML(name, 0), 0);
                dialog.showDialog(dialog.JudgeD(dialog.ID));
            }
            dialog.setDialogText(dialog.Split(instance.GetXML(name, 0), 1));
        }
        else
        {
            dialog.setDialogText(dialog.Split(instance.GetXML(name, 0), 0));
        }
    }

    public static bool JudgeD(string a)  //判断对话框的ID
    {
        if (a.Equals(dialog.Split(instance.GetXML(name, 0), 0)))
        {
            return true;
        }
        else return false;
    }

    public static void GetCount(string s)
    {
        count = instance.getCount(s, 0); 
    }

    public static void Judge()
    {
        switch (level)
        {
            case 1: level += 1; levelName = "Level_2";XMLname = "第二关"; break;
            case 2: level += 1; need = true; levelName = "Level_3"; XMLname = "第三关";  break;
            case 3: level += 1; need = true; levelName = "Level_4";XMLname = "第四关"; break;
            case 4: level += 1; levelName = "Level_5";XMLname = "第五关"; break;
            case 5: level += 1; levelName = "Level_6";XMLname = "第六关"; break;
        }
    }

    public static void Destroy_All()
    {
        if (GameObject.FindWithTag(HashID.LEVEL))
            Object.DestroyImmediate(GameObject.FindWithTag(HashID.LEVEL));
        if (GameObject.FindWithTag(HashID.PLAYER ))
            Object.DestroyImmediate(GameObject.FindWithTag(HashID.PLAYER ));
    }

}
