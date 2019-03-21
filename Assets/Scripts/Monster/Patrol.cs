using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Patrol : Monster
{
    [SerializeField]
    private List<Transform> patrolRoute;
    private Rigidbody2D playerRb;

    void Start()
    {
        player = GameObject.FindWithTag(HashID.PLAYER);
        playerRb = player.GetComponent<Rigidbody2D>();
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


