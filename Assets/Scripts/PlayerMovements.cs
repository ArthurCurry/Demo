using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovements : MonoBehaviour {
    public float moveSpeed;
    public bool isMoving;
    public bool targetArrived;
    private Dictionary<KeyCode, Vector3> directions=new Dictionary<KeyCode, Vector3>();
    private Rigidbody2D rb;
    private Transform targetFloor;

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
        targetFloor = this.transform;
        rb = transform.GetComponent<Rigidbody2D>();
        LoadDirection();
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
            if (directions.ContainsKey(key))
                targetFloor=Detect(key);
        }
        MoveTowards(targetFloor);
    }

    void MoveTowards(Transform target)//控制向特定方向移动
    {
            if (transform.position != target.position)
            {
                Vector2 pos = target.position;
                targetArrived = false;
                isMoving = true;
            //rb.MovePosition(rb.position+(pos-rb.position).normalized*moveSpeed*Time.deltaTime);
                rb.velocity = (target.position - transform.position).normalized * moveSpeed;
                if ((transform.position - target.position).magnitude < 0.01)
                    transform.position = target.transform.position;
            }
            else
            {
                rb.velocity = Vector2.zero;
                targetArrived = true;
                Debug.Log(targetArrived);
                isMoving = false;
            }
        //if(GameObject.FindWithTag(HashID.FOLLOWING))
        
    }

    void OnGUI()
    {
        Move();
    }


    void PickItems()
    {

    }

    void LoadDirection()
    {
        directions.Add(KeyCode.W, transform.up);
        directions.Add(KeyCode.S, -transform.up);
        directions.Add(KeyCode.A, -transform.right);
        directions.Add(KeyCode.D, transform.right);
    }

    Transform Detect(KeyCode key)
    {
        Vector3 direction = directions[key];
        RaycastHit2D[] hits = Physics2D.LinecastAll(transform.position, transform.position + direction * unitSize);
        if (hits.Length > 1 && hits[1].transform.tag == "Map")
        {
            //Debug.Log(hits[1].transform.name);
            if (GameObject.FindWithTag(HashID.FOLLOWING))
                GameObject.FindWithTag(HashID.FOLLOWING).GetComponent<Following>().Follow(direction);
            return hits[1].transform;
        }
        return this.transform;
    }
}
 