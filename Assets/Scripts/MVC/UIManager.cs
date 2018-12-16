using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    private Dictionary<string, GameObject> panelDict;
    private Canvas rootCanv;

    private CtrlManager ctrlManager;
    private ModelManager modelManager;

    public void Init(string name)
    {
        ctrlManager = new CtrlManager();
        modelManager = new ModelManager();

        rootCanv = GameObject.Find(HashID.CANVAS).GetComponent<Canvas>();
        panelDict = new Dictionary<string, GameObject>();
    }

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

    public void CreatCtrl(string name)
    {
        ctrlManager.Init(name);
    }

    public void InitPanel(Canvas rootCanv , bool active , string ctrlName,string name,Transform t)
    {
        ctrlManager.GetT<UICtrl>(ctrlName).Model().InitModel(GameObject.Find(name), name);
        ctrlManager.GetT<UICtrl>(ctrlName).OnCreat(t, name);
        panelDict = ctrlManager.GetT<UICtrl>(ctrlName).Model().modelDict();
    }

    public void ShowPanel(string ctrlName,string name)
    {
        ctrlManager.GetT<UICtrl>(ctrlName).OnShow(name);
    }

    public void HidePanel(string ctrlName,string name)
    {
        ctrlManager.GetT<UICtrl>(ctrlName).OnHide(name);
    }

    public void ClosePanel(string name,bool isDestroyed,string ctrlName)
    {
        ctrlManager.GetT<UICtrl>(ctrlName).OnClose(name);
    }


}
