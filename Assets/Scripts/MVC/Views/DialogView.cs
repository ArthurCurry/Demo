using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogView : UIView
{
    private Canvas canvas;
    private Transform dialogText;
    private GameObject dialogBox;                //用于保存对话框的预置体
    private GameObject dialog;                   //用于获取场景组件中的对话框

    protected override void BinObject()
    {
        dialogBox = this.panelObject;
        canvas = GameObject.Find(HashID.CANVAS).GetComponent<Canvas>();
    }

    protected override void OnHide()
    {
        throw new System.NotImplementedException();
    }

    protected override void OnShow()
    {
        
    }

    protected override void OnUpdate()
    {
        return;
    }

    public void Create()
    {
        GameObject.Instantiate(dialogBox, canvas.transform);
    }

    public void SetDialogText(string sentence)
    {
        if (GameObject.Find("DialogBox(Clone)"))
        {
            dialog = GameObject.Find("DialogBox(Clone)");
            dialogText = dialog.transform.Find("dialogText");
            Text text = dialogText.GetComponent<Text>();
            text.text = sentence;
            text.text = text.text.Replace("\\n", "\n");
        }
    }

    public bool IsEmptyDialog()
    {
        if (GameObject.Find("DialogBox(Clone)"))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void DestoryDiaLog()
    {
            GameObject d = GameObject.Find("DialogBox(Clone)");
            GameObject.Destroy(d);
    }
}
