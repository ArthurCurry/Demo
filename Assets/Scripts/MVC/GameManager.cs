using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager:MonoBehaviour {
    private ModelManager modelManager;
    private CtrlManager ctrlManager;

    public GameObject B;

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
        Init();
        Debug.Log(B.transform .position);
    }
	
	// Update is called once per frame
	void Update () {        
        BuildManager.WhileCG();
        this.Show_Save_Panel();
	}

    void Init()//初始化
    {
        BuildManager.InitCG("CG1");
        //BuildManager.Init();
    }

    public void To_Save()
    {
        ToSave.Save();
        Save.ExportXML();
    }

    void To_Load()
    {
        LoadGame.LoadSenceXML();
        ToLoad.Load();
    }

    void Show_Save_Panel()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (B.gameObject.activeInHierarchy)
            {
                B.gameObject.SetActive(false);
            }
            else
            {
                B.gameObject.SetActive(true);
            }
        }
    }
}
