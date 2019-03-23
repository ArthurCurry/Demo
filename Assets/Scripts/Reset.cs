using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour {

    private Vector3 pos;
    private Vector3 rot;
    private GameObject start;
    private GameObject player;
    private PlayerMovements pm;

	// Use this for initialization
	void Start () {
        start = GameObject.Find("start");
        pos = transform.position;
        rot = transform.rotation.eulerAngles;
        player = GameObject.FindWithTag(HashID.PLAYER);
        pm = GameObject.FindWithTag(HashID.PLAYER).GetComponent<PlayerMovements>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        Recover();
	}

    void Recover()
    {
        if((player.transform.position-start.transform.position).magnitude<=0.01f)
        {
            transform.position = pos;
            transform.rotation = Quaternion.Euler(rot);
        }
    }
}
