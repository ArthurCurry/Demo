using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class IntroductionCtrl : MonoBehaviour
{

    public GameObject introductionText;
    public GameObject introTitle;
    public GameObject introSprite;
    public int page = 1;
    Introduction introduction = null;
    bool Changed = true;

	void Start () {
        
        //IntroductionModel.PageList.TryGetValue(page, out introduction);
        
	}
    public string GetIntroductionText(Introduction introduction)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("<color=black><size=20>游戏介绍：{0}</size></color>",introduction.IntroText);
        introductionText.GetComponent<Text>().text = introduction.IntroText;
        return sb.ToString();
       
    }

    public void GetIntroductionSprite(Introduction introduction)
    {
        //Debug.Log(introduction.ImageIcon);
        Sprite sp = Resources.Load<Sprite>("Prefabs/Introduction/"+introduction.ImageIcon);
        introSprite.GetComponent<Image>().sprite = sp;
    }

    public string GetIntroductionTitle(Introduction introduction)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("<color=white><size=40>{0}</size></color>", introduction.Title);
        introTitle.GetComponent<Text>().text = introduction.Title;
        return sb.ToString();

    }

    private void Update()
    {
        if(Changed == true)
        {
            IntroductionModel.PageList.TryGetValue(page, out introduction);
            Debug.Log(1);
             GetIntroductionSprite(introduction);
            Debug.Log(2);
            introductionText.GetComponent<Text>().text = GetIntroductionText(introduction);
            introTitle.GetComponent<Text>().text = GetIntroductionTitle(introduction);
            Changed = false;
        }
    }
    public void AddPage()
    {
        if (page == 8) return;
        else
        {
            page++;
            Changed = true;
        }       
    }

    public void DecresePage()
    {
        if (page == 1) return;
        else
        {
            page--;
            Changed = true;
        }       
    }
}
