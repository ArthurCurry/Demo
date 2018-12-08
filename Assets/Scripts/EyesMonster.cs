using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesMonster : Monster {
    public float distance;
    // Use this for initialization
    void Start()
    {
        latePos = GameObject.Find("Player").transform.position;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        move();
        judge();
    }

    public override void attack()
    {
        Destroy(player.gameObject);
    }

    public override void judge()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);//0.626一个差不多
        Vector3 towards = player.transform.position - transform.position;

        float angel = Vector3.Angle(towards, transform.right);
        if (angel <= 25 && distance <= 3)//判断是否在两格
        {
            attack();
        }
    }

    public override void move()
    {
        nextPos = GameObject.Find("Player").transform;

        float distance = Vector3.Distance(latePos, nextPos.position);
        Vector3 towards = nextPos.position - transform.position;

        if (towards == this.transform.right && distance <= 10)
        {
            //fire
        }

        if (!(nextPos.position == latePos)&&!player.GetComponent<PlayerMovements >().isMoving)
        {
            this.transform.Rotate(new Vector3(0, 0, 90));
            latePos = nextPos.position;
        }
    }
}
