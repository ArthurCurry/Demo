using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovements : MonoBehaviour {
    public float moveSpeed;
    public bool isMoving;
    public bool targetArrived;

    [SerializeField]
    private float unitSize;
    [SerializeField]
    private float stopTime;
	// Use this for initialization
	public static void InitData () {
        Transform start = GameObject.Find("start").transform;
        GameObject.FindWithTag(HashID.PLAYER).transform.position = start.position;
	}
	
    void Start()
    {
        isMoving = false;
        targetArrived = true;
    }
	// Update is called once per frame
	void Update () {

	}

    void Move()//移动
    {
        if(Input.anyKey&&!isMoving)
        {
            KeyCode key=KeyCode.Space;
            Event e = Event.current;
            if (e.isKey)
                key = e.keyCode;
            //Debug.Log(key);
            switch(key)
            {
                case KeyCode.D:
                    StartCoroutine("MoveTowards", transform.right);
                    //StopAllCoroutines();
                    break;
                case KeyCode.A:
                    StartCoroutine("MoveTowards", -transform.right);
                    break;
                case KeyCode.S:
                    StartCoroutine("MoveTowards", -transform.up);
                    break;
                case KeyCode.W:
                    StartCoroutine("MoveTowards", transform.up);
                    break;
                default:
                    return;
            }
        }
    }

    IEnumerator MoveTowards(Vector3 direction)//协程控制向特定方向移动
    {

        RaycastHit2D[] hits = Physics2D.LinecastAll(transform.position, transform.position + direction*unitSize );
        //Debug.Log(hits.Length);
        if (hits.Length > 1 && hits[1].transform.tag == "Map")
        {
            while (transform.position != hits[1].transform.position)
            {
                targetArrived = false;
                isMoving = true;
                transform.position = Vector3.MoveTowards(transform.position, hits[1].transform.position, moveSpeed * Time.deltaTime);
                yield return null;
            }
            targetArrived = true;
            yield return new WaitForSeconds(stopTime);
            isMoving = false;
        }
        else
            StopAllCoroutines();
        GameObject.FindWithTag(HashID.FOLLOWING).GetComponent<Following>().Follow(direction);
    }

    void OnGUI()
    {
        Move();
    }

    void EnterHouse()
    {

    }

    void PickItems()
    {

    }
}
 