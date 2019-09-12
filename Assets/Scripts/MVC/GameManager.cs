using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager:MonoBehaviour {
    private ModelManager modelManager;
    private CtrlManager ctrlManager;
    private GameObject escape;
    private int count;
    private bool isBuild = false;

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
        //escape = root.transform.Find("Save").gameObject;
        BuildManager.Need = true;
        //BuildManager.Level = 1;
        GameObject root = GameObject.Find("Canvas");
        //escape = root.transform.Find("Escape").gameObject;
        root.GetComponent<ChangeEffect>().M_State = ChangeEffect.State.FadeIn;
    }
	
	// Update is called once per frame
	void Update () {
        Show();
        BuildManager.WhileCG();
        //if (BuildManager.Level ==4 && BuildManager.CGEnd == true && isBuild == false)
        //{
         //   BuildManager.Init();
          //  Camera.main.GetComponent<CameraController>().enabled = true;
         //   Camera.main.GetComponent<CameraController>().DetectEdges();
         //   isBuild = true;
       // }
    }

    public void Init(string CGName,string XMLName)//初始化
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
            if (escape.activeSelf)
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

    public void BackToMebu()
    {
        SceneManager.LoadScene(0);
    }

    public void BackToGame()
    {
        escape.SetActive(false);
    }

}
