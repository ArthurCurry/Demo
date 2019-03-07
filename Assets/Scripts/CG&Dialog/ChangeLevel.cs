using System.Collections;
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
            BuildManager.Init();
        }
    }
}
