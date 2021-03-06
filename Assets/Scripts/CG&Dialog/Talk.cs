﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Talk : MonoBehaviour {
    private float distance;

    private GameObject player;

    private static bool hasTalk;
    public static bool HasTalk
    {
        set { hasTalk = value; }
    }

    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag(HashID.PLAYER);
        hasTalk = false;
	}
	
	// Update is called once per frame
	void Update () {
        TalkTo();
    }

    void TalkTo()
    {
        if ((this.transform.position-player.transform.position).magnitude<0.3f && !hasTalk)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                BuildManager.IsCG = true;
                BuildManager.Name = "老头";
                BuildManager.X = 1;
                BuildManager.GetCount(BuildManager.Name);
                BuildManager.Instance.SetIndex(0);
                BuildManager.InitDialog();
                hasTalk = true;
                this.gameObject.GetComponent<OldMTalk>().stop = true;
            }
        }
    }

}
