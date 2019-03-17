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
    [SerializeField]
    private float mode;
    [SerializeField]
    private List<Transform> triggerPoses;
    [SerializeField]
    private bool triggered;

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
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!triggered)
        {
            foreach (Transform triggerPos in triggerPoses)
            {
                if ((player.transform.position - triggerPos.position).magnitude < 0.1f && playerRB.velocity == Vector2.zero)
                {
                    triggered = true;
                    break;
                }
            }
        }
        else
            Move();
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
            Follow();
    }
    private void Follow()
    {
        direction = playerRB.velocity * mode;
        thisPos = this.transform.position;
        RaycastHit2D[] hits = Physics2D.LinecastAll(thisPos, thisPos+  direction.normalized* HashID.unitLength);
        //Debug.Log(hits.Length);
        if (hits.Length > 1 && hits[1].transform.tag == "Map")
        {
                rb.velocity = direction;
        }
    }

    public void Stop()
    {
        rb.velocity = Vector2.zero;
    }

    protected override void ShowAttackRange()
    {
        throw new System.NotImplementedException();
    }
}
