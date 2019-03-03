using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedPatrol : MonoBehaviour {

    [SerializeField]
    private List<Transform> route;//运动路径
    private GameObject player;
    private PlayerMovements pm;
    private Vector2 direction;//运动方向
    private int index;//路径点目录
    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        index = 0;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag(HashID.PLAYER);
        pm = player.GetComponent<PlayerMovements>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        //Debug.Log(index);
		if(pm.isMoving)
        {
            direction = route[index + 1].position - route[index].position;
            rb.velocity = direction.normalized * pm.moveSpeed;
        }
        else
        {
            if ((transform.position - route[index].position).magnitude < 0.1f)
                index += 1;
            rb.velocity = Vector2.zero;
        }
	}
}
