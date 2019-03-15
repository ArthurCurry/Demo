using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager:MonoBehaviour {
    private ModelManager modelManager;
    private CtrlManager ctrlManager;

    private GameObject escape;
    private int count;

    public void OpenPanel(string name)
    {
        
    }

    public void ShowPanel(string name)
    {

    }

    public void HidePanel(string name)
    {

    }

    public void ClosePanel(string name, bool isDestroyed)
    {

    }
    // Use this for initialization
    void Start () {
        GameObject root = GameObject.Find("Canvas");
        //escape = root.transform.Find("Save").gameObject;
        BuildManager.Level = 1;
        BuildManager.XMLName = "第一关";
        BuildManager.LevelName = "Level_2";
        Init("CG1","旁白");
       // BuildManager.LevelName = "Level_2";
    }
	
	// Update is called once per frame
	void Update () {
        Show();
        BuildManager.WhileCG();
	}

    void Init(string CGName,string XMLName)//初始化
    {
        BuildManager.InitCG(CGName,XMLName);
    }

    /*public void To_Save()
    {
        ToSave.Save();
        Save.ExportXML();
    }

    public void To_Load()
    {
        LoadGame.LoadSenceXML();  //先实例化人物
        ToLoad.Load();
    }
    */
    public void Show()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (escape.active)
            {
                escape.SetActive(false);
            }
            else
            {
                GameObject root = GameObject.Find("Canvas");
                count = root.transform.childCount;
                escape.SetActive(true);
                escape.transform.SetSiblingIndex(count - 1);
            }
        }
    }
}
