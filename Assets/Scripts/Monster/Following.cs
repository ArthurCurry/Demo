using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Following : Monster {

    private Rigidbody2D rb;
    private PlayerMovements pm;
    [SerializeField]
    private float mode;
    [SerializeField]
    private Transform trigger;

    // Use this for initialization
    void Start()
    {
        latePos = GameObject.FindWithTag(HashID.PLAYER).transform.position;
        player = GameObject.FindWithTag(HashID.PLAYER);
        pm = player.GetComponent<PlayerMovements>();
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void LateUpdate()
    {

    }


    public override void Judge()
    {
        throw new System.NotImplementedException();
    }
    public override void Attack()
    {
        throw new System.NotImplementedException();
    }
    public override void Move()
    {
    }
    public void Follow(Vector3 a)
    {
        a = a * mode;
        nextPos = player.transform;
        RaycastHit2D[] hits = Physics2D.LinecastAll(transform.position, transform.position + a * 10);
        //Debug.Log(hits.Length);
        if (hits.Length > 1 && hits[1].transform.tag == "Map")
        {
            if (transform.position != hits[1].transform.position)
            {
                rb.velocity = (hits[1].transform.position - transform.position).normalized * pm.moveSpeed;
                //Debug.Log(rb.velocity);
            }
            latePos = nextPos.position;
        }
    }

    public void Stop()
    {
        rb.velocity = Vector2.zero;
    }

    protected override void ShowAttackRange()
    {
        throw new System.NotImplementedException();
    }
}
