using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Following : Monster {

	// Use this for initialization
	void Start () {
        latePos = GameObject.Find("Player").transform.position;
        player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
		
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
        nextPos = player.transform;

        if (!(nextPos.position == latePos) && !player.GetComponent<PlayerMovements>().isMoving)
        {
            RaycastHit2D[] hits = Physics2D.LinecastAll(transform.position, transform.position + a * 10);
            //Debug.Log(hits.Length);
            if (hits.Length > 1 && hits[1].transform.tag == "Map")
            {
                while (transform.position != hits[1].transform.position)
                {
                    transform.position = Vector3.MoveTowards(transform.position, hits[1].transform.position, 2 * Time.deltaTime);
                }
                latePos = nextPos.position;
            }
        }
    }
}
