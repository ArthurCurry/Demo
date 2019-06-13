using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Straight : MonoBehaviour {

    private PlayerMovements pm;
    private Rigidbody2D playerRb;
    private Rigidbody2D rb;
    private Vector3 prePos;
    private float totalDis;
    [SerializeField]
    private Vector2 direction;

	// Use this for initialization
	void Start () {
        pm = GameObject.FindWithTag(HashID.PLAYER).GetComponent<PlayerMovements>();
        playerRb = GameObject.FindWithTag(HashID.PLAYER).GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
        prePos = this.transform.position;
        totalDis = 0f;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        GoAndBack();
        //Debug.Log(pm.isMoving+" "+rb.velocity);
        totalDis += (this.transform.position - prePos).magnitude;
        prePos = this.transform.position;
    }

    public void GoAndBack()
    {
        if(Mathf.Abs(totalDis%HashID.unitLength)<0.01f)
        {
            Vector2 selfPos = this.transform.position;
            RaycastHit2D[] hits = Physics2D.LinecastAll(selfPos, direction * HashID.unitLength + selfPos,LayerMask.GetMask("Replaceable"));
            Debug.Log(hits.Length+"  "+this.gameObject.name+" "+this.direction);
            if (hits.Length<=1||!hits[hits.Length - 1].transform.tag.Equals(HashID.Tag_Map))
                direction = -direction;
            //totalDis = 0f;
            rb.velocity = direction.normalized * playerRb.velocity.magnitude;
            return;
        }
        rb.velocity = direction.normalized * playerRb.velocity.magnitude;
    }
}
