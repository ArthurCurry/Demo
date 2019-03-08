using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedPatrol : MonoBehaviour {

    public List<Vector3> route;//运动路径
    private GameObject player;
    private PlayerMovements pm;
    private Transform target;
    private Vector2 direction;//运动方向
    private Vector3 playerPrePos;
    private int index;//路径点目录
    private Rigidbody2D playerRB;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        index = 0;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag(HashID.PLAYER);
        playerPrePos = player.transform.position;
        playerRB = player.GetComponent<Rigidbody2D>();
        pm = player.GetComponent<PlayerMovements>();
	}
	
    void Update()
    {
        
    }

	// Update is called once per frame
	void LateUpdate () {
        //Debug.Log(route.Count);
        //Debug.Log((transform.position - route[route.Count - 1].position).magnitude);
        if (route.Count > 1)
        {
            if (playerRB.velocity!=Vector2.zero)
            {
                direction = route[index] - transform.position;
                rb.velocity = direction.normalized * pm.moveSpeed;
            }
            else
            {
                if ((transform.position - route[index]).magnitude < 0.1f&&player.transform.position!=playerPrePos)
                    index += 1;
                rb.velocity = Vector2.zero;
            }
        }
        //Debug.Log(index);
        //MoveTo(route[index]);
        if ((transform.position - route[route.Count - 1]).magnitude < 0.1f)
            DestroyImmediate(this.gameObject);
        playerPrePos = player.transform.position;
    }


}
