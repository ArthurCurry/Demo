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
        playerMovements = player.GetComponent<PlayerMovements>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Judge();
    }

    public override void Attack()
    {
        Destroy(player.gameObject);//重生方法待定，暂时先采用销毁
    }

    public override void Judge()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);//0.626一个差不多
        Vector3 towards = player.transform.position - transform.position;
        float angel = Vector3.Angle(towards, transform.right);
        if (angel <= 45 && distance <= 3)//判断是否在两格
        {

            Attack();
        }
    }

    public override void Move()
    {
        nextPos = GameObject.Find("Player").transform;

        if (nextPos.position != latePos&&playerMovements.targetArrived)
        {
            this.transform.Rotate(new Vector3(0, 0, 90));
            latePos = nextPos.position;
        }
    }

    void Detect()
    {

    }
}
