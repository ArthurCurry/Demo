using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {
    private Transform player;
    private bool dont;
	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag(HashID.PLAYER).transform;
        dont = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(this.transform .position .Equals (player .position)&&dont)
        {
            BuildManager.IsCG = true;
            BuildManager.GetCount(BuildManager.Name);
            BuildManager.InitDialog();
            dont = false;
        }
	}
}
