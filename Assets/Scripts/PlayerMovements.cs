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
    [SerializeField]
    private Transform targetFloor;
    public bool isDead;

    [SerializeField]
    private float unitSize;
    [SerializeField]
    private float stopTime;
	// Use this for initialization
	public static void InitData () {
        Transform start = GameObject.Find("start").transform;
        GameObject.FindWithTag(HashID.PLAYER).transform.position = start.position;
        GameObject.FindWithTag(HashID.PLAYER).GetComponent<Rigidbody2D>().velocity = Vector2.zero;
	}
	
    void Start()
    {
        isDead = false;
        isMoving = false;
        targetArrived = true;
        targetFloor = this.transform;
        rb = transform.GetComponent<Rigidbody2D>();
        LoadDirection();
    }
	// Update is called once per frame
	void Update () {
        //Debug.Log(rb.velocity);
        if (isDead)
            Reborn();
    }

    void LateUpdate()
    {
        
    }

    void Move()//移动
    {
        if (Input.anyKey && !isMoving)
        {
            KeyCode key = KeyCode.None;
            Event e = Event.current;
            if (e.isKey)
                key = e.keyCode;
            if (directions.ContainsKey(key))
                targetFloor = Detect(key);
        }
        MoveTowards(targetFloor);
    }

    public void MoveTowards(Transform target)//控制向特定方向移动
    {
        //Debug.Log(target);
        if (transform.position != target.position)
        {
            Vector2 pos = target.position;
            targetArrived = false;
            //rb.MovePosition(rb.position+(pos-rb.position).normalized*moveSpeed*Time.deltaTime);
            rb.velocity = (target.position - transform.position).normalized * moveSpeed;
            //transform.position += (target.position - transform.position).normalized * Time.deltaTime*moveSpeed;
            //transform.Translate((target.position - transform.position).normalized * moveSpeed * Time.deltaTime);
            isMoving = true;
            StopAt(targetFloor);
        }
        else
        {
            targetFloor = this.transform;
            if(GameObject.FindWithTag(HashID.FOLLOWING))
                GameObject.FindWithTag(HashID.FOLLOWING).GetComponent<Following>().Stop();
            rb.velocity = Vector2.zero;
            targetArrived = true;
            MonsterManager.UpdateMonsters(float.PositiveInfinity);
            isMoving = false;
        }
        
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
        directions.Add(KeyCode.W, Vector3.up);
        directions.Add(KeyCode.S, Vector3.down);
        directions.Add(KeyCode.A, Vector3.left);
        directions.Add(KeyCode.D, Vector3.right);
    }

    Transform Detect(KeyCode key)
    {
        Vector3 direction = directions[key];
        RaycastHit2D[] hits = Physics2D.LinecastAll(transform.position, transform.position + direction * 1.28f,LayerMask.GetMask(HashID.Layer_Replaceable));
        if (hits.Length > 1 && hits[1].transform.tag == "Map")
        {
            //Debug.Log(hits[1].transform.name);
            if (GameObject.FindWithTag(HashID.FOLLOWING))
                GameObject.FindWithTag(HashID.FOLLOWING).GetComponent<Following>().Follow(direction);
            MonsterManager.UpdateMonsters((hits[1].transform.position-transform.position).magnitude);
            return hits[1].transform;
        }
        else return this.transform;
    }


    void Reborn()//重生
    {
        rb.velocity = Vector2.zero;
        targetFloor = GameObject.Find(HashID.StartPoint).transform;
        transform.position = targetFloor.transform.position;
        Camera.main.transform.position = this.transform.position;
        targetArrived = true;
        isMoving = false;
        isDead = false;
    }

    void StopAt(Transform target)
    {
        if ((transform.position - target.position).magnitude < 0.001f)
        {
            transform.position = target.transform.position;
            rb.velocity = Vector2.zero;
        }
    }
}
 