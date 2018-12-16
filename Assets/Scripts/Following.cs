using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Following : Monster {

	// Use this for initialization
	void Start () {
        latePos = GameObject.FindWithTag(HashID .PLAYER).transform.position;
        player = GameObject.FindWithTag(HashID.PLAYER);
    }
	
	// Update is called once per frame
	void Update () {
        Judge();
	}

    public override void Judge()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);//1.28一个差不多
        Vector3 towards = player.transform.position - transform.position;
        float angel = Vector3.Angle(towards, transform.right);
        if (angel <= 45 && distance <= 0.62 && !player.GetComponent<PlayerMovements>().isMoving)//判断是否在两格而且主角停下
        {

            Attack();
        }
    }

    public override void Attack()
    {
        PlayerMovements.InitData();//重生方法更改，回到起点
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
