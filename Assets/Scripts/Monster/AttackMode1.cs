using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMode1 : MonoBehaviour {

    private GameObject player;
    private Rigidbody2D playerRB;
    private PlayerMovements pm;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag(HashID.PLAYER);
        playerRB = player.GetComponent<Rigidbody2D>();
        pm = player.GetComponent<PlayerMovements>();
        rb = this.GetComponent<Rigidbody2D>();
	}
	

    void LateUpdate()
    {
        if ((player.transform.position - transform.position).magnitude <= 0.01f)
            pm.isDead = true;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
       
    }
}
