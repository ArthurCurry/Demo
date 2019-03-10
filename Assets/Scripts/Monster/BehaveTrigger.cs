using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaveTrigger : MonoBehaviour {

    [SerializeField]
    private Transform trigger;//触发判定方块
    private bool triggered;
    private GameObject player;
    private Rigidbody2D playerRB;

	// Use this for initialization
	void Start () {
        triggered = false;
        player = GameObject.FindWithTag(HashID.PLAYER);
        playerRB = player.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if(playerRB.velocity==Vector2.zero)
        {
            if(!triggered&&(player.transform.position-trigger.position).magnitude<0.2f)
            {
                triggered = true;
                this.GetComponent<Following>().enabled = true;
            }
        }
	}
}
