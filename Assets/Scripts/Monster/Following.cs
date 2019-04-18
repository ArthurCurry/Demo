using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Following : Monster {

    private Rigidbody2D rb;
    private PlayerMovements pm;
    private Rigidbody2D playerRB;
    private Vector3 playerPrePos;//玩家上一帧位置
    private Vector2 thisPos;//自身位置
    private Vector2 direction;//前进方向
    private Vector3 prePos;
    private float totalDis;
    private Transform targetFloor;
    private bool targetArrived;
    private bool isMoving;
    [SerializeField]
    private float mode;
    [SerializeField]
    private List<Transform> triggerPoses;
    private List<Vector3> positions=new List<Vector3>();
    [SerializeField]
    private bool triggered;
    [SerializeField]
    private Transform upperright;
    [SerializeField]
    private Transform lowerleft;
    private List<Vector3> edes = new List<Vector3>();

    // Use this for initialization
    void Start()
    {
        
        prePos = this.transform.position;
        totalDis = 0f;

        triggered = false;
        latePos = GameObject.FindWithTag(HashID.PLAYER).transform.position;
        player = GameObject.FindWithTag(HashID.PLAYER);
        playerPrePos = player.transform.position;
        playerRB = player.GetComponent<Rigidbody2D>();
        pm = player.GetComponent<PlayerMovements>();
        rb = this.GetComponent<Rigidbody2D>();
        InitPositions();
        targetArrived = true;
        isMoving = false;
        if (upperright != null && lowerleft != null)
        {
            edes.Add(lowerleft.position);
            edes.Add(upperright.position);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (!triggered)
        {
            for (int i=0;i<positions.Count;i++)
            {
                if ((player.transform.position - positions[i]).magnitude < 0.1f && playerRB.velocity == Vector2.zero)
                {
                    triggered = true;
                    break;
                }
            }
        }
        else
            Move();
        totalDis += (this.transform.position - prePos).magnitude;
        prePos = this.transform.position;
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
        //Detect();
        //MoveTowards(targetFloor);
        Follow();

    }
    private void Follow()
    {
        direction = playerRB.velocity * mode;
        thisPos = this.transform.position;
        RaycastHit2D[] hits = Physics2D.LinecastAll(thisPos, thisPos + direction.normalized * HashID.unitLength, LayerMask.GetMask("Replaceable"));
        Debug.Log(hits.Length);
        if (hits.Length > 1)
        {
            if (!hits[1].transform.tag.Equals(HashID.Tag_Map))
            {
                if (Mathf.Abs((hits[1].transform.position - this.transform.position).magnitude - HashID.unitLength) < 0.01f)
                {
                    //Debug.Log("stopped");
                    direction = Vector2.zero;
                }
            }
            else
            {
                targetFloor = hits[1].transform;
            }
        }
        else
            direction = Vector2.zero;
        /*if (Mathf.Abs(totalDis - HashID.unitLength) < 0.05f)
        {
            if (hits.Length <= 1 || !hits[1].transform.tag.Equals(HashID.Tag_Map))
            {
                

            }
            totalDis = 0f;
        }*/
        rb.velocity = direction;
    }

    public void Stop()
    {
        rb.velocity = Vector2.zero;
    }

    protected override void ShowAttackRange()
    {
        throw new System.NotImplementedException();
    }

    void MoveTowards(Transform target)//控制向特定方向移动
    {
        if (transform.position != target.position)
        {
            Vector2 pos = target.position;
            targetArrived = false;
            rb.velocity = (target.position - transform.position).normalized * pm.moveSpeed;
            isMoving = true;
            StopAt(targetFloor);
        }
        else
        {
            targetFloor = this.transform;
            rb.velocity = Vector2.zero;
            targetArrived = true;
            isMoving = false;
        }

    }

    void StopAt(Transform target)
    {
        if ((transform.position - target.position).magnitude < 0.01f)
        {
            //Debug.Log(1);
            transform.position = target.transform.position;
            rb.velocity = Vector2.zero;
        }
    }

    void Detect()
    {
        direction = playerRB.velocity * mode;
        RaycastHit2D[] hits = Physics2D.LinecastAll(thisPos, thisPos + direction.normalized * HashID.unitLength, LayerMask.GetMask("Replaceable"));
        if(hits.Length > 1)
        {
            if (hits[1].transform.tag.Equals(HashID.Tag_Map))
            {
                targetFloor = hits[1].transform;
            }
            else
            {
                targetFloor = hits[0].transform;
            }
        }
    }

    private void InitPositions()
    {
        foreach(Transform pos in triggerPoses)
        {
            positions.Add(pos.position);
        }
    }

    private bool OutOfRange()
    {

        return false;
    }
}
