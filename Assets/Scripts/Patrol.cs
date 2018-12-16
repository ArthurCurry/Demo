using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : Monster {
    private Dictionary <int,GameObject> patrols;
    private Transform stage;

    private bool moving;
    private bool finished;
    private bool isTime;
    private Vector3 towards;
    private Vector3 first;

    private float time;
    private float lateTime;

    // Use this for initialization
    public void Creat()
    {
        if (finished && isTime)
        {
            patrols = new Dictionary<int, GameObject>();
            int a = Random.Range(0, 2);
            Init(a);
            this.transform.position = patrols[0].transform.position;
            finished = false;
            
        }
    }

    private void Init(int x)
    {
        if(x==1)
        {
            patrols.Add(0, GameObject.FindWithTag("PatrolPoint1"));
            patrols.Add(1, GameObject.FindWithTag("PatrolPoint2"));
            patrols.Add(2, GameObject.FindWithTag("PatrolPoint3"));
        }
        else
        {
            patrols.Add(0, GameObject.FindWithTag("PatrolPoint4"));
            patrols.Add(1, GameObject.FindWithTag("PatrolPoint5"));
            patrols.Add(2, GameObject.FindWithTag("PatrolPoint3"));
        }
        
    }

	void Awake()
    {
        
        first = GameObject.Find("PatrolPoint1").transform.position;
        towards = GameObject.Find("PatrolPoint2").transform.position;
        stage = GameObject.Find("PatrolsStage").transform;
        player = GameObject.FindWithTag(HashID.PLAYER);
        latePos = player.transform.position;
        finished = true;
        isTime = true;
        lateTime = 0;
    }

    // Update is called once per frame
    void Update () {
        time += Time.deltaTime;
        Creat();
        Judge();
        if(moving)
        {
            ToMove(towards);
        }
        Attack();
	}
    
    public override void Judge()
    {
        float t = time - lateTime;

        for (int i= 0; i < 3; i++)
        {
            if(i!=2&&this.transform .position.Equals (patrols [i].transform.position ))
            {
                moving = true;
                towards = patrols[i+1].transform.position ;
            }
            else if(this .transform .position .Equals (patrols[2].transform.position))
            {
                
                finished = true;
                towards = stage.position;
                lateTime = time;
            }
        }
    }

    public override void Attack()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);//1.28一个差不多
        Vector3 towards = player.transform.position - transform.position;
        float angel = Vector3.Angle(towards, transform.right);
        if (angel <= 45 && distance <= 1.28 && !player.GetComponent<PlayerMovements>().isMoving)//判断是否在两格而且主角停下
        {
            PlayerMovements.InitData();//重生方法更改，回到起点
        }
    }

    public void ToMove(Vector3 a)
    {
        if (finished)
        {
            this.transform.position = stage.position;
        }
        this.transform.position = Vector3.MoveTowards(transform.position, a, 3 * Time.deltaTime);
        //moving = false;
    }

    public override void Move()
    {
        nextPos = player.transform;

        if (!(nextPos.position == latePos) && !player.GetComponent<PlayerMovements>().isMoving)
        {
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
}

