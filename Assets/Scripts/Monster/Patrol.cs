using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Patrol : Monster
{
    [SerializeField]
    private Dictionary<int, GameObject> patrols;
    private Transform stage;

    private bool moving;
    private bool finished;
    private bool isTime;

    [SerializeField]
    private Vector3 towards;
    private Vector3 first;

    private float time;
    private float lateTime;
    private string tagName;

    // Use this for initialization
    void Awake()
    {
        //first = GameObject.Find("PatrolPoint1").transform.position;
        //towards = GameObject.Find("PatrolPoint2").transform.position;
        tagName = this.gameObject.tag;
        stage = GameObject.Find("PatrolStage").transform;
        player = GameObject.FindWithTag(HashID.PLAYER);
        latePos = player.transform.position;
        finished = true;
        isTime = true;
        lateTime = 0;
    }

    public void Creat()
    {
        if (finished && isTime)
        {
            patrols = new Dictionary<int, GameObject>();
            switch (tagName)
            {
                case "PatrolA":
                    int a = Random.Range(0, 2);
                    Init(a);
                    this.transform.position = patrols[0].transform.position;
                    finished = false;
                    break;
                case "PatrolB": Init(2); finished = false; break;
                case "PatrolC": Init(3); finished = false; break;
                default: break;
            }
            
        }
    }

    private void Init(int x)
    {
        if (x == 1)
        {
            patrols.Add(0, GameObject.Find("PatrolPoint1"));
            patrols.Add(1, GameObject.Find("PatrolPoint2"));
            patrols.Add(2, GameObject.Find("PatrolPoint3"));
        }

        if (x == 0)
        {
            patrols.Add(0, GameObject.Find("PatrolPoint4"));
            patrols.Add(1, GameObject.Find("PatrolPoint5"));
            patrols.Add(2, GameObject.Find("PatrolPoint3"));
        }

        if (x == 2)
        {
            patrols.Add(0, GameObject.Find("PatrolPoint10"));
            patrols.Add(1, GameObject.Find("PatrolPoint11"));
        }
        if (x == 3)
        {
            patrols.Add(0, GameObject.Find("PatrolPoint6"));
            patrols.Add(1, GameObject.Find("PatrolPoint7"));
            patrols.Add(2, GameObject.Find("PatrolPoint8"));
            patrols.Add(3, GameObject.Find("PatrolPoint9"));
        }
    }
  
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        Creat();
        Judge();
        Attack();
        //if (moving)
        //{            
            //ToMove(towards);
        //}
        this.Move();
    }

    public override void Judge()
    {
        float t = time - lateTime;
        /*if (tagName.Equals("PatrolC"))    注释部分是适应自行移动模式patrol的移动
        {
            for (int i = 0; i < 4; i++)
            {
                if (patrols[i] == null)
                {
                    break;
                }
                if (this.transform.position.Equals(patrols[i].transform.position))
                {
                    //moving = true;
                    towards = patrols[i + 1].transform.position;
                }
            }
        }*/
        //else
        //{

        if (tagName.Equals("PatrolA"))
        {
            for (int i = 0; i < 2; i++)
            {
                if (this.transform.position.Equals(patrols[i].transform.position))
                {
                    //moving = true;
                    towards = patrols[i + 1].transform.position;
                }
            }
            if (this.transform.position.Equals(patrols[2].transform.position))
            {

                finished = true;
                towards = stage.position;
                lateTime = time;
            }
        }
        //}   
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

    public override void Move()  //随主角移动而移动
    {
        nextPos = player.transform;

        if(finished)
        {
            transform.Rotate(new Vector3(0, 0, -90));
            this.transform.position = towards;
        }
        if (!(nextPos.position == latePos) && player.GetComponent<PlayerMovements>().targetArrived)
        {
            moving = true;
            if(moving)
            {
                RaycastHit2D[] hits = Physics2D.LinecastAll(transform.position, transform.position + transform.right * 10);
                //Debug.Log(hits.Length);
                if (hits.Length > 1 && hits[1].transform.tag == "Map")
                {
                    while (transform.position != hits[1].transform.position)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, hits[1].transform.position, 2 * Time.deltaTime);
                    }
                    if (tagName.Equals("PatrolA"))
                    {
                        if (transform.position.Equals(patrols[1].transform.position))
                        {
                            transform.Rotate(new Vector3(0, 0, 90));
                        }
                    }
                    else
                    {
                        if (tagName == "PatrolC")
                        {
                            foreach (KeyValuePair<int, GameObject> patrol in patrols)
                                if (transform.position.Equals(patrol.Value.transform.position))
                                {
                                    transform.Rotate(new Vector3(0, 0, 90));
                                }
                        }
                        else
                        {
                            foreach (KeyValuePair<int, GameObject> patrol in patrols)
                                if (transform.position.Equals(patrol.Value.transform.position))
                                {
                                    transform.Rotate(new Vector3(0, 0, 180));
                                }
                        }
                    }
                    moving = false;
                    latePos = nextPos.position;
                }
            }

        }
    }

    public void ToMove(Vector3 a)
    {
        if(finished)
        {
            this.transform.position = towards;
        }
        if (moving && !this.transform.position.Equals(a))
            this.transform.position = Vector3.MoveTowards(transform.position, a, 3 * Time.deltaTime);
        else if(this.transform .position == a)
        {
            moving = false;
        }
        
    }  //自行移动

    protected override void ShowAttackRange()
    {
        throw new System.NotImplementedException();
    }
}


