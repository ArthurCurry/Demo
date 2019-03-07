using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour {

    private Animator playerAnimator;
    private Rigidbody2D rb;
    private PlayerMovements pm;
    private Vector2 direction;

	// Use this for initialization
	void Start () {
        playerAnimator = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
        pm = this.GetComponent<PlayerMovements>();
	}
	

    void LateUpdate()
    {
        playerAnimator.SetFloat("speed_x", rb.velocity.x);
        playerAnimator.SetFloat("speed_y", rb.velocity.y);
        if (rb.velocity==Vector2.zero)
        {
            playerAnimator.SetInteger("speed",0);
        }
        else
        {
            playerAnimator.SetInteger("speed", 1);
        }
        direction = rb.velocity;
    }
}
