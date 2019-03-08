using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager:MonoBehaviour {
    private ModelManager modelManager;
    private CtrlManager ctrlManager;

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
        Init("CG1","旁白");
        BuildManager.XMLName = "第一关";
        BuildManager.LevelName = "Level_2";
    }
	
	// Update is called once per frame
	void Update () {        
        BuildManager.WhileCG();
	}

    void Init(string CGName,string XMLName)//初始化
    {
        BuildManager.InitCG(CGName,XMLName);
    }

}
