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
        //Debug.Log(B.transform .position);
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
            Debug.Log(1);
            if (B.gameObject.activeInHierarchy)
            {
                Debug.Log(2);
                B.gameObject.SetActive(false);
                Debug.Log(3);
            }
            else
            {
                Debug.Log(4);
                B.gameObject.SetActive(true);
                Debug.Log(5);
            }
        }
    }
}
