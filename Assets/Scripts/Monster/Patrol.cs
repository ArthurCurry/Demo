using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Patrol : Monster
{
    [SerializeField]
    private List<Transform> route;
    private Rigidbody2D playerRB;
    private Vector3 direction;
    private PlayerMovements pm;
    private Rigidbody2D rb;
    private Vector3 playerPrePos;
    private int index;

    void Start()
    {
        player = GameObject.FindWithTag(HashID.PLAYER);
        playerRB = player.GetComponent<Rigidbody2D>();
        pm = player.GetComponent<PlayerMovements>();
        rb = GetComponent<Rigidbody2D>();
        playerPrePos = player.transform.position;
    }

    void LateUpdate()
    {
        if (route.Count > 1)
        {
            if (playerRB.velocity != Vector2.zero)
            {
                direction = route[index].position - transform.position;
                rb.velocity = direction.normalized * pm.moveSpeed;
            }
            else
            {
                if ((transform.position - route[index].position).magnitude < 0.1f && player.transform.position != playerPrePos)
                    index += 1;
                rb.velocity = Vector2.zero;
            }
        }
        if ((transform.position - route[route.Count - 1].position).magnitude < 0.1f)
        {
            index = 0;
        }
        playerPrePos = player.transform.position;
    }

    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

    public override void Judge()
    {
        throw new System.NotImplementedException();
    }

    public override void Move()
    {
        throw new System.NotImplementedException();
    }

    protected override void ShowAttackRange()
    {
        throw new System.NotImplementedException();
    }
}


