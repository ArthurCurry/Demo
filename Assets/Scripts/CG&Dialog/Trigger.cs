using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {
    private Transform player;
    private IntroductionCtrlB itb;
    private bool dont;
    private bool toPause;
    private bool status;
    private int x;
	// Use this for initialization
	void Start () {
        itb = GameObject.Find(HashID.CANVAS).GetComponent<IntroductionCtrlB>();
        player = GameObject.FindWithTag(HashID.PLAYER).transform;
        dont = true;
        status = false;
        toPause = false;
        x = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(this.transform .position .Equals (player .position)&&dont)
        {
            itb.CompareTo("异步敌人");
            itb.OpenPanel();
            itb.GetIntroductionTitle(itb.get[0]);
            itb.GetIntroductionText(itb.get[0]);
            itb.GetIntroductionSprite(itb.get[0]);
            x = 1;
            dont = false;
            toPause = true;
        }
	}

    void ShowDialog()
    {
        if (toPause)
        {
            if (x < itb.number)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    itb.GetIntroductionTitle(itb.get[x]);
                    itb.GetIntroductionText(itb.get[x]);
                    itb.GetIntroductionSprite(itb.get[x]);
                    x = x + 1;
                }
            }
            else
            {
                toPause = false;
                x = 0;
                itb.number = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if(!dont&&!status)
            {
                itb.CompareTo("触发机关");
                itb.OpenPanel();
                itb.GetIntroductionTitle(itb.get[0]);
                itb.GetIntroductionText(itb.get[0]);
                itb.GetIntroductionSprite(itb.get[0]);
                x = 1;
                status = true;
                toPause = true;
            }
            itb.ClosePanel();
        }
    }
}
