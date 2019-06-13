using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog {
    private static Dialog instance;
    public GameObject instantiation;
    private Canvas canvas;
    public GameObject dialogBox;                //用于保存对话框的预置体
    public GameObject dialog;                   //用于获取场景组件中的对话框
    public Transform dialogText;                //文本
    public string ID;
    /// <summary>
    /// 单例
    /// </summary>
    /// <value>The instance.</value>
    public static Dialog Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Dialog();
            }
            return instance;
        }
    }
    /// <summary>
    /// Shows the dialog.
    /// </summary>
    public void showDialog(string DName)
    {
        canvas = GameObject.Find(HashID.CANVAS).GetComponent <Canvas>();
        dialogBox = Resources.Load<GameObject>("Prefabs/" + DName);
        instantiation = GameObject.Instantiate(dialogBox,canvas .transform );
    }

    public void ShowIntroduction()
    {
        canvas = GameObject.Find(HashID.CANVAS).GetComponent<Canvas>();
        dialogBox = Resources.Load<GameObject>("Prefabs/IntroductionBox");
        instantiation = GameObject.Instantiate(dialogBox, canvas.transform);
    }
    /// <summary>
    /// Sets the dialog text.
    /// </summary>
    /// <param name="sentence">Sentence.</param>
    public void setDialogText(string sentence)
    {
        if (instantiation != null)
        {
            dialog = instantiation;
            dialogText = dialog.transform.Find("dialogText");
            TextMeshProUGUI dialogtext = dialogText.GetComponent<TextMeshProUGUI>();
            dialogtext.text = sentence;
            dialogtext.text = dialogtext.text.Replace("\\n", "\n");
        }
    }

    public string Split(string target ,int n)
    {
        string[] split = target.Split(' ');
        return split[n];
    }

    public string JudgeD(string a)
    {
        if (a.Equals("Z"))
        {
            return "ZTDialogBox";
        }
        else if (a.Equals("B"))
        {
            return "BDialogBox";
        }
        else return null;
    }
    /// <summary>
    /// Destories the dialog.
    /// </summary>
    public void DestoryDiaLog()
    {
        if (instantiation != null)
        {
            GameObject.Destroy(instantiation);
        }
    }
    /// <summary>
    /// Determines whether this instance is empty dialog.
    /// </summary>
    /// <returns><c>true</c> if this instance is empty dialog; otherwise, <c>false</c>.</returns>
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
}
