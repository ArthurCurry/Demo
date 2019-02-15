﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesMonster : Monster {
    public float distance;
    private float rotateSpeed;
    public  bool inPosition;//旋转到位
    private List<Transform> attackRangeUnit = new List<Transform>();
    private List<Transform> tempUnit = new List<Transform>();
    private LineRenderer line;
    [SerializeField]
    private int attackRange;

    // Use this for initialization
    void Start()
    {
        latePos = GameObject.FindWithTag(HashID .PLAYER).transform.position;
        player = GameObject.FindWithTag(HashID .PLAYER);
        playerMovements = player.GetComponent<PlayerMovements>();
        rotateSpeed = (HashID.unitLength / playerMovements.moveSpeed);
        inPosition = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Judge();
        
        ShowAttackRange();
    }

    void LateUpdate()
    {
        //ShowAttackRange();
    }

    public override void Attack()
    {
        playerMovements.isDead=true;//重生方法更改，回到起点
        
    }

    public override void Judge()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);//0.626一个差不多
        Vector3 towards = player.transform.position - transform.position;
        float angel = Vector3.Angle(towards, transform.right);
        if (angel <= 45 && distance <= 3 && !player.GetComponent<PlayerMovements>().isMoving)//判断是否在两格而且主角停下
        {
            if(playerMovements.targetArrived)
                Attack();
        }
    }

    public override void Move()
    {
        //nextPos = GameObject.FindWithTag(HashID.PLAYER).transform;

        //if (nextPos.position != latePos&&playerMovements.targetArrived)
        //{
        Vector3 targetRot = transform.rotation.eulerAngles + new Vector3(0, 0, 90);
        StartCoroutine(Rotate(targetRot));
        inPosition = true;
        //StopAllCoroutines();
        //this.transform.Rotate(new Vector3(0, 0, 90));
        //latePos = nextPos.position;
        //}
    }

    IEnumerator Rotate(Vector3 targetRot)
    {

        //Debug.Log(targetRot);
        while (transform.rotation.eulerAngles!=targetRot)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(targetRot), rotateSpeed*Time.deltaTime);
            inPosition = false;
            //transform.Rotate(0, 0, 90 * Time.deltaTime*rotateSpeed);
            yield return null;
        }
        StopAllCoroutines();
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
    }

    void Detect()
    {

    }

    protected override void ShowAttackRange()
    {
        //throw new System.NotImplementedException();
        if (inPosition)
        {
            Vector3 end;
            Vector3 start=transform.position+ transform.right * HashID.unitLength*0.5f;
            RaycastHit2D[] hits = Physics2D.LinecastAll(transform.position + transform.right * HashID.unitLength, transform.position + transform.right * attackRange * HashID.unitLength, LayerMask.GetMask(HashID.Layer_Replaceable));
            if (hits.Length > 0)
                end = hits[hits.Length - 1].transform.position + transform.right * HashID.unitLength*0.5f;
            else
                end = transform.position+0.5f*HashID.unitLength*transform.right;
            foreach(RaycastHit2D hit in hits)
            {
                if (hit.transform.tag.Equals(HashID.Tag_Map)||hit.transform.tag.Equals("Void")||hit.transform.tag.Equals(HashID.ENEMY))
                {
                    if (hit.transform.gameObject.name.Contains(this.gameObject.name.Split('_')[1]))
                    {
                        start = hit.transform.position+transform.right*0.5f*HashID.unitLength;
                        //Debug.Log(hits[i].transform.name);
                        continue;
                    }
                }
                else
                {
                    end = hit.transform.position - 0.5f * HashID.unitLength * transform.right;
                }
            }
            Vector3 direction = end - start;
            Vector3 playerDir = player.transform.position - this.transform.position;
            if (Vector3.Angle(direction, playerDir) < 1f)
                Attack();
            line = GetComponent<LineRenderer>();
            line.enabled = true;
            line.SetPositions(new Vector3[2] { start, end});
            line.startColor = new Color(1,0,0,0.5f);
            line.endColor = new Color(1, 0, 0, 0.5f);
            line.startWidth = 1.28f;
            line.endWidth = 1.28f;
            
        }
        else
        {
            GetComponent<LineRenderer>().enabled = false;
        }
    }

}
