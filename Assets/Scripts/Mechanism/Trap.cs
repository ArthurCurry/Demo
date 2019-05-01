using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    protected GameObject player;
    protected PlayerMovements pm;
    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected void InitTrap()
    {
        player = GameObject.FindWithTag(HashID.PLAYER);
        pm = player.GetComponent<PlayerMovements>();
    }

    protected virtual void Attack()
    {
        pm.isDead = true;
    }
    
}
