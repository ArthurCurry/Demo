using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMode3 : MonoBehaviour {

    private List<Vector3> positions=new List<Vector3>();
    private LineRenderer line;
    private GameObject player;
    private PlayerMovements pm;
	// Use this for initialization
	void Start () { 
        player = GameObject.FindWithTag(HashID.PLAYER);
        pm = player.GetComponent<PlayerMovements>();
        line = this.GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		
	}

    void ShowAttackRange()
    {
        
    }

    void InitRange()
    {
        positions.Add(this.transform.position);
    }

}
