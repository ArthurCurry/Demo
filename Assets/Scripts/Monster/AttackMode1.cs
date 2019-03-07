using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMode1 : MonoBehaviour {

    private GameObject player;
    private Rigidbody2D playerRB;
    private PlayerMovements pm;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag(HashID.PLAYER);
        playerRB = player.GetComponent<Rigidbody2D>();
        pm = player.GetComponent<PlayerMovements>();
	}
	

    void LateUpdate()
    {
        if(playerRB.velocity==Vector2.zero)
        {
            if ((player.transform.position - this.transform.position).magnitude < 0.1f)
                pm.isDead = true;
        }
    }
}
