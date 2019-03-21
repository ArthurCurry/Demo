using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class UIManager : MonoBehaviour {

    [SerializeField]
    private UIOnClick[] puzzles;

    // private Dictionary<string, UIView> panelDict = new Dictionary<string, UIView>();
    public static UIManager Instance;

    private Dictionary<string,Type> viewTypeDict = new Dictionary<string, Type>();
    private Canvas rootCanv;


    private CtrlManager ctrlManager;
    private ModelManager modelManager;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        Instance=this;
        this.Init();
    }
    public void Init()
    {
        ctrlManager = new CtrlManager();
        modelManager = new ModelManager();

        rootCanv = GameObject.Find(HashID.CANVAS).GetComponent<Canvas>();
        GameObject.DontDestroyOnLoad(rootCanv.gameObject);
        this.RigisterViewType();
        ctrlManager.RigisterCtrls();
        modelManager.RigisterModels();
        MouseMonitor.OnEnter += ctrlManager.GetT<BagCtrl>(PanelID.BagPanel).GridUI_OnEnter;
        MouseMonitor.OnExit += ctrlManager.GetT<BagCtrl>(PanelID.BagPanel).GridUI_OnExit;


        //  panelDict = new Dictionary<string, GameObject>();
    }

    public void HideUICanvas()
    {
        rootCanv.gameObject.SetActive(false);
        //rootCanv.enabled = false;
        //GetComponent<CanvasGroup>().alpha = 0;
        //GetComponent<CanvasGroup>().interactable = false;
        //GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void ShowUICanvas()
    {
        rootCanv.gameObject.SetActive(true);
        //GetComponent<CanvasGroup>().alpha = 1;
        //GetComponent<CanvasGroup>().interactable = true;
        //GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    void Update()
    {
        ctrlManager.UpdateCtrls();    
    }


    public void OpenPanel(string panelName)
    {
        

        
        Type viewType = viewTypeDict[panelName];
        if(viewType == null)
        {
            Debug.LogError("未找到输入字符串对应的UI面板");
            return;
        }
        string path = UIConst.UIPrefabPathPrefix+panelName;
        GameObject UIGameObjetPrefab = (GameObject)Resources.Load(path);
        GameObject UIGameObjet = GameObject.Instantiate(UIGameObjetPrefab);
        UIGameObjet.transform.parent=rootCanv.transform;
        UIView view = (UIView)Activator.CreateInstance(viewType, true);
        UICtrl ctrl = ctrlManager.GetCtrl(panelName);
        UIModel model = modelManager.GetModel(panelName);
        view.Init(ctrl,UIGameObjet);
        ctrl.View=view;
        ctrl.Model=model;
        ctrl.Create();
        ctrl.Show();
        //ctrlManager.GetT<UICtrl>(ctrlName).Model().InitModel(GameObject.Find(name), name);
        //ctrlManager.GetT<UICtrl>(ctrlName).OnCreat(t, name);



       // panelDict = ctrlManager.GetT<UICtrl>(ctrlName).Model().modelDict();
    }


    public void ShowPanel(string panelName)
    {

        ctrlManager.GetCtrl(panelName).Show();
        //ctrlManager.GetT<UICtrl>(ctrlName).OnShow(name);
    }

    public void HidePanel(string panelName)
    {
         ctrlManager.GetCtrl(panelName).Hide();
        //ctrlManager.GetT<UICtrl>(ctrlName).OnHide(name);
    }

    public void ClosePanel(string panelName)
    {

        ctrlManager.GetCtrl(panelName).Close();
    
        //ctrlManager.GetT<UICtrl>(ctrlName).OnClose(name);
    }


    private void RigisterViewType()
    {
        viewTypeDict.Add(PanelID.BagPanel,typeof(BagView));


    }

    public UIModel GetModel(string a)
    {
        return this.modelManager.GetModel(a);
    }


    public void PuzzleAdd(int a, int b, int c)
    {
        puzzles[0].puzzleLeft += a;
        puzzles[1].puzzleLeft += b;
        puzzles[2].puzzleLeft += c;
    }
}
