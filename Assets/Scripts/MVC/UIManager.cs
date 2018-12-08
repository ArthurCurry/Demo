using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    private Dictionary<string, GameObject> panelDict;
    private Canvas rootCanv;
    private UICtrl ctrl;
   

    public void HideUICanvas()
    {
        rootCanv.enabled = false;
        //GetComponent<CanvasGroup>().alpha = 0;
        //GetComponent<CanvasGroup>().interactable = false;
        //GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void ShowUICanvas()
    {
        rootCanv.enabled = true;
        //GetComponent<CanvasGroup>().alpha = 1;
        //GetComponent<CanvasGroup>().interactable = true;
        //GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void CreatPanel(string name ,Transform t)
    {
        this.ctrl.Model().InitModel(GameObject.Find(name), name);
        this.ctrl.OnCreat(t, name);
    }

    public void InitPanel(Canvas rootCanv , bool active , string name)
    {

        ctrl.view.IsActive(name,rootCanv);
        panelDict = ctrl.Model().modelDict();
    }

    public void ShowPanel(string name)
    {
        this.ctrl.OnShow(name);
    }

    public void HidePanel(string name)
    {
        this.ctrl.OnHide(name);
    }

    public void ClosePanel(string name,bool isDestroyed)
    {
        this.ctrl.OnClose(name);
    }

    public void Init()
    {
        ctrl = new UICtrl();
        ctrl.view = new UIView(ctrl);
        rootCanv = GameObject.Find(HashID.CANVAS).GetComponent<Canvas>();
        panelDict = new Dictionary<string, GameObject>();
    }

    private void Awake()
    {
        Init();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
