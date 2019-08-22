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
        
        
	}
    public void GetIntroductionText(Introduction it)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("<color=black><size=20>游戏介绍：{0}</size></color>",it.IntroText);
        introductionText.GetComponent<Text>().text = it.IntroText;
       
    }

    public void GetIntroductionSprite(Introduction it)
    {
        //Debug.Log(introduction.ImageIcon);
        Sprite sp = Resources.Load<Sprite>("Prefabs/Introduction/"+it.ImageIcon);
        introSprite.GetComponent<Image>().sprite = sp;
    }

    public void GetIntroductionTitle(Introduction it)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("<color=black><size=40>{0}</size></color>", it.Title);
        introTitle.GetComponent<Text>().text = it.Title;

    }

    private void Update()
    {
        if(Changed == true)
        {
            IntroductionModel.PageList.TryGetValue(page, out introduction);
            GetIntroductionText(introduction);
            GetIntroductionSprite(introduction);
            GetIntroductionTitle(introduction);
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
