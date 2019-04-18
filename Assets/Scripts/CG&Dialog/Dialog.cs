using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog {
    private static Dialog instance;
    private Canvas canvas;
    public GameObject dialogBox;                //用于保存对话框的预置体
    public GameObject dialog;                   //用于获取场景组件中的对话框
    public Transform dialogText;                //文本
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
    public void showDialog()
    {
        canvas = GameObject.Find(HashID.CANVAS).GetComponent <Canvas>();
        dialogBox = Resources.Load<GameObject>("Prefabs/DialogBox");
        GameObject.Instantiate(dialogBox,canvas .transform );
    }
    /// <summary>
    /// Sets the dialog text.
    /// </summary>
    /// <param name="sentence">Sentence.</param>
    public void setDialogText(string sentence)
    {
        if (GameObject.Find("DialogBox(Clone)"))
        {
            dialog = GameObject.Find("DialogBox(Clone)");
            dialogText = dialog.transform.Find("dialogText");
            Text dialogtext = dialogText.GetComponent<Text>();
            dialogtext.text = sentence;
            dialogtext.text = dialogtext.text.Replace("\\n", "\n");
        }
        else if(GameObject.Find("IntroductionBox(Clone)"))
        {
            dialog = GameObject.Find("IntroductionBox(Clone)");
            dialogText = dialog.transform.Find("dialogText");
            Text dialogtext = dialogText.GetComponent<Text>();
            dialogtext.text = sentence;
            dialogtext.text = dialogtext.text.Replace("\\n", "\n");
        }
    }
    /// <summary>
    /// Destories the dialog.
    /// </summary>
    public void DestoryDiaLog()
    {
        if (GameObject.Find("DialogBox(Clone)"))
        {
            dialog = GameObject.Find("DialogBox(Clone)");
            GameObject.Destroy(dialog);
        }
        else if (GameObject.Find("IntroductionBox(Clone)"))
        {
            dialog = GameObject.Find("IntroductionBox(Clone)");
            GameObject.Destroy(dialog);
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

    public void ShowIntroduction()
    {
        canvas = GameObject.Find(HashID.CANVAS).GetComponent<Canvas>();
        dialogBox = Resources.Load<GameObject>("Prefabs/IntroductionBox");
        GameObject.Instantiate(dialogBox, canvas.transform);
    }
}
