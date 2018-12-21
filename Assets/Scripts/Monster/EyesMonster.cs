using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesMonster : Monster {
    public float distance;
    private float rotateSpeed;
    public  bool inPosition;//旋转到位
    private List<Transform> attackRangeUnit = new List<Transform>();
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
        Judge();
        //Move();
        //Debug.Log(attackRangeUnit.Count);
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
            Debug.Log(attackRangeUnit.Count);
            Debug.DrawLine(transform.position+ transform.right * HashID.unitLength, transform.position + transform.right * attackRange * HashID.unitLength,Color.red);
            RaycastHit2D[] hits = Physics2D.LinecastAll(transform.position+transform.right*HashID.unitLength, transform.position + transform.right * attackRange * HashID.unitLength, LayerMask.GetMask(HashID.Layer_Replaceable));
            //Debug.Log(hits.Length);
            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].transform.tag.Equals(HashID.Tag_Map))
                {
                    if (!hits[i].transform.gameObject.name.Contains("obstacle"))
                    { 
                            //Debug.Log(hits[i].transform.name);
                            if(!attackRangeUnit.Contains(hits[i].transform))
                                attackRangeUnit.Add(hits[i].transform);
                            hits[i].transform.GetComponent<SpriteRenderer>().color= Color.red;
                    }
                    
                }
                else
                    break;
            }
        }
        else
        {
            if(attackRangeUnit.Count>0)
            {
                
                foreach(Transform unit in attackRangeUnit)
                {
                    //Debug.Log("change");
                    transform.GetComponent<SpriteRenderer>().color = Color.white;
                }
                attackRangeUnit.Clear();
            }
        }
    }
}
