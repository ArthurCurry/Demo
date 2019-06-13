using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using TMPro;

public class IntroductionCtrlB : MonoBehaviour
{

    public GameObject introductionText;
    public GameObject introTitle;
    public GameObject introSprite;
    public int page = 1;
    Introduction introduction = null;
    bool Changed = true;

    void Start()
    {


    }
    public void GetIntroductionText(Introduction introduction)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("<color=black><size=20>游戏介绍：{0}</size></color>", introduction.IntroText);
        introductionText.GetComponent<Text>().text = introduction.IntroText;

    }

    public void GetIntroductionSprite(Introduction introduction)
    {
        //Debug.Log(introduction.ImageIcon);
        Sprite sp = Resources.Load<Sprite>("Prefabs/Introduction/" + introduction.ImageIcon);
        introSprite.GetComponent<Image>().sprite = sp;
    }

    public string GetIntroductionTitle(Introduction introduction)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("<color=black><size=40>{0}</size></color>", introduction.Title);
        introTitle.GetComponent<Text>().text = introduction.Title;
        return sb.ToString();

    }
}
