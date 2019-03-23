using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttcakMode2 : MonoBehaviour {

    private GameObject player;
    private PlayerMovements pm;
    private Rigidbody2D playerRB;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag(HashID.PLAYER);
        pm = player.GetComponent<PlayerMovements>();
        playerRB = player.GetComponent<Rigidbody2D>();
	}
	

    void LateUpdate()
    {
        if(playerRB.velocity==Vector2.zero)
        {
            Judge();
        }
    }

    void Judge()
    {
        if (Mathf.Abs((player.transform.position - this.transform.position).magnitude - HashID.unitLength) < 0.1f)
            Attack();
    }

    void Attack()
    {
        pm.isDead = true;
    }

    void ShowAttackRange()
    {

    }
}
