﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : Monster {
    private bool moving;
    private Vector3 towards;
    private Vector3 first;
	// Use this for initialization
	void Start () {
        first = GameObject.Find("PatrolPoint1").transform.position;
        towards = GameObject.Find("PatrolPoint2").transform.position;
        latePos = GameObject.Find("Player").transform.position;
        player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
        /*if(transform.position.Equals(latePos))
        {
            moving = true;
            towards = latePos;
        }
        else if(transform .position .Equals (nextPos .position ))
        {
            moving = true;
            towards = nextPos.position;
        }
        if(moving)
        {
            toMove(towards);
        }*/
        move();
	}
    
    public override void judge()
    {

    }

    public override void attack()
    {

    }

    public override void move()
    {
        /*if (transform .position.Equals (latePos))
        {
            moving = true;
            this.transform.Rotate(new Vector3(0, 0, 180));
            while (moving)
            {
                //transform.Translate(x * Time.deltaTime);
                if (transform .position .Equals (nextPos .position))
                {     
                        moving = false;
                }
            }
            //this.transform.position = Vector3.SmoothDamp(transform.position, nextPos.position, ref currentV, 1f);          
        }
        else if(transform .position .Equals (nextPos .position ))
        {
            moving = true;
            this.transform.Rotate(new Vector3(0, 0, 180));
            while (moving)
            {
                this.transform.position = Vector3.SmoothDamp(transform.position, latePos, ref currentV, 1f);
                if (transform.position.Equals(latePos))
                {
                    moving = false;
                }
            }
           
        }*/
        nextPos = player.transform;

        if (!(nextPos.position == latePos) && !player.GetComponent<PlayerMovements>().isMoving){
            RaycastHit2D[] hits = Physics2D.LinecastAll(transform.position, transform.position - transform.up * 10);
            //Debug.Log(hits.Length);
            if (hits.Length > 1 && hits[1].transform.tag == "Map")
            {
                while (transform.position != hits[1].transform.position)
                {
                    transform.position = Vector3.MoveTowards(transform.position, hits[1].transform.position, 2 * Time.deltaTime);
                }
                latePos = nextPos.position;
            }
            if (transform.position.Equals(first) || transform.position.Equals(towards))
            {
                this.transform.Rotate(new Vector3(0, 0, 180));
            }
        }
    }

    public void toMove(Vector3 a)
    {
        RaycastHit2D[] hits = Physics2D.LinecastAll(transform.position, transform.position - transform.up * 10);
        //Debug.Log(hits.Length);
        if (hits.Length > 1 && hits[1].transform.tag == "Map")
        {
            while (transform.position != hits[1].transform.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, hits[1].transform.position, 2 * Time.deltaTime);
            }

            //yield return new WaitForSeconds(0.1f);  //嫌麻烦注释掉了

        }
        /*this.transform.position = Vector3.MoveTowards(transform.position, a, 3*Time.deltaTime );
            if (transform.position.Equals(latePos) || transform.position.Equals(nextPos.position))
            {
                moving = false;
            }*/
    }
}
