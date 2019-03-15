using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Following : Monster {

    private Rigidbody2D rb;
    private PlayerMovements pm;
    private Rigidbody2D playerRB;
    private Vector3 playerPrePos;//玩家上一帧位置
    private Vector2 thisPos;//自身位置
    private Vector2 direction;//前进方向
    [SerializeField]
    private float mode;

    // Use this for initialization
    void Start()
    {
        latePos = GameObject.FindWithTag(HashID.PLAYER).transform.position;
        player = GameObject.FindWithTag(HashID.PLAYER);
        playerPrePos = player.transform.position;
        playerRB = player.GetComponent<Rigidbody2D>();
        pm = player.GetComponent<PlayerMovements>();
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (playerPrePos != player.transform.position)
        {
            Follow();
        }
        else
        {
            Stop();
        }
        playerPrePos = player.transform.position;
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
    private void Follow()
    {
        direction = playerRB.velocity * mode;
        thisPos = this.transform.position;
        RaycastHit2D[] hits = Physics2D.LinecastAll(thisPos, thisPos+  direction* 10);
        //Debug.Log(hits.Length);
        if (hits.Length > 1 && hits[1].transform.tag == "Map")
        {
            if (transform.position != hits[1].transform.position)
            {
                rb.velocity = direction;
                //Debug.Log(rb.velocity);
            }
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
