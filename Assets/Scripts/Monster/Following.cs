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
    private List<RaycastHit2D> hits = new List<RaycastHit2D>();


    // Use this for initialization
    void Start()
    {

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
        totalDis = HashID.unitLength;
        prePos = this.transform.position;
        if (upperright != null && lowerleft != null)
        {
            edes.Add(lowerleft.position);
            edes.Add(upperright.position);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Reset();
        /*if (!triggered)
        {
            for (int i=0;i<positions.Count;i++)
            {
                if ((player.transform.position - positions[i]).magnitude < 0.1f && playerRB.velocity == Vector2.zero)
                {
                    triggered = true;
                    break;
                }
            }
        }*/
        if (OutOfRange())
            triggered = false;
        else
        {
            triggered = true;
            Move();
        }
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
        if (true)
        {
            hits.Clear();
            RaycastHit2D[] hitObs =  Physics2D.LinecastAll(thisPos, thisPos + direction.normalized * HashID.unitLength, LayerMask.GetMask("Replaceable"));
            foreach(RaycastHit2D rh in hitObs)
            {
                hits.Add(rh);
            }
        }
        //Debug.Log(hits.Count+" "+this.gameObject.name+direction+" "+ pm.targetArrived);
        if (hits.Count > 1)
        {
            if (!hits[1].transform.tag.Equals(HashID.Tag_Map))
            {
                if (Mathf.Abs((hits[1].transform.position - this.transform.position).magnitude-HashID.unitLength) < 0.01f)
                {
                    Debug.Log("stopped");
                    direction = Vector2.zero;
                }
            }
            else if(pm.targetArrived)
            {
                targetFloor = hits[1].transform;
            }
        }
        else if((totalDis/HashID.unitLength)%1<0.01f&& (totalDis / HashID.unitLength)>0.9f)
            direction = Vector2.zero;
        rb.velocity = direction;
        Debug.Log((totalDis / HashID.unitLength) % 1);
    }


    protected override void ShowAttackRange()
    {
        throw new System.NotImplementedException();
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
        if ((player.transform.position.x > lowerleft.position.x && player.transform.position.y > lowerleft.position.y) && (player.transform.position.x < upperright.position.x && player.transform.position.y < upperright.position.y))
            return false;
        else
            return true;
    }

    private void Reset()
    {
        if(pm.isDead)
        {
            totalDis = 0f;
            prePos = this.transform.position;
        }
    }
}
