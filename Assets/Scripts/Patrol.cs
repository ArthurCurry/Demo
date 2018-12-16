using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : Monster {
    private bool moving;
    private Vector3 towards;
	// Use this for initialization
	void Start () {
        latePos = GameObject.Find("PatrolPoint1").transform.position;
        nextPos = GameObject.Find("PatrolPoint2").transform;
    }
	
	// Update is called once per frame
	void Update () {
        if(transform.position.Equals(latePos))
        {
            moving = true;
            towards = nextPos.position;
        }
        else if(transform .position .Equals (nextPos .position ))
        {
            moving = true;
            towards = latePos;
        }
        if(moving)
        {
            ToMove(towards);
        }
	}
    
    public override void Judge()
    {

    }

    public override void Attack()
    {

    }

    public override void Move()
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
    }
    public void ToMove(Vector3 a)
    {
            this.transform.position = Vector3.MoveTowards(transform.position, a, 3*Time.deltaTime );
            if (transform.position.Equals(latePos) || transform.position.Equals(nextPos.position))
            {
                moving = false;
            }
    }
    /*IEnumerator todo()
    {
        this.transform.Rotate(new Vector3(0, 0, 180));
        moving = false;
    }*/ //协程但没必要
}
