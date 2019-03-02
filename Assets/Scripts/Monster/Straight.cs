using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Straight : MonoBehaviour {

    private PlayerMovements pm;
    private Rigidbody2D rb;
    [SerializeField]
    private Vector2 direction;

	// Use this for initialization
	void Start () {
        pm = GameObject.FindWithTag(HashID.PLAYER).GetComponent<PlayerMovements>();
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        GoAndBack();
        //Debug.Log(pm.isMoving+" "+rb.velocity);
    }

    public void GoAndBack()
    {
        if (pm.isMoving)
            rb.velocity = direction.normalized * pm.moveSpeed;
        else
        {
            rb.velocity = Vector2.zero;
            Vector2 selfPos = this.transform.position;
            RaycastHit2D[] hits = Physics2D.LinecastAll(selfPos, direction * HashID.unitLength + selfPos);
            //Debug.Log(hits.Length);
            if (hits.Length < 3 || !hits[hits.Length-1].transform.tag.Equals(HashID.Tag_Map))
                direction = -direction;
        }
    }
}
