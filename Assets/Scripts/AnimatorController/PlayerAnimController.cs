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
	
	// Update is called once per frame
	void Update () {
        
    }

    void LateUpdate()
    {
        playerAnimator.SetFloat("speed_x", rb.velocity.x);
        playerAnimator.SetFloat("speed_y", rb.velocity.y);
        if (rb.velocity==Vector2.zero&&direction!=Vector2.zero)
        {
            
        }
        direction = rb.velocity;
    }
}
