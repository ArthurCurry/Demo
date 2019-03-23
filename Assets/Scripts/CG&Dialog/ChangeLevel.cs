﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevel : MonoBehaviour {

    private Transform player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag(HashID.PLAYER).transform;
    }
	
	// Update is called once per frame
	void Update () {
        Judge();
	}

    void Judge()
    {
        if(this.transform.position  == player.position)
        {
            BuildManager.Judge();
            BuildManager.Destroy_All();
            BuildManager.Need = true;
            BuildManager.InitAttribute();
            BuildManager.Init();
            Camera.main.GetComponent<CameraController>().Init();
            //BuildManager.Name = "异步敌人";
        }
    }
}
