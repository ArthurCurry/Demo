﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovements : MonoBehaviour {
    public float moveSpeed;
    public bool isMoving;
    public bool targetArrived;
    private Dictionary<KeyCode, Vector3> directions = new Dictionary<KeyCode, Vector3>();
    private Rigidbody2D rb;
    [SerializeField]
    private Transform targetFloor;
    public bool isDead;
    public bool disEqUnit;
    private Vector3 prePos;
    private float totalDis;

    [SerializeField]
    private float unitSize;
    [SerializeField]
    private float stopTime;
    // Use this for initialization
    public static void InitData()
    {
        Transform start = GameObject.Find("start").transform;
        GameObject.FindWithTag(HashID.PLAYER).transform.position = start.position;
        GameObject.FindWithTag(HashID.PLAYER).GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    void Start()
    {
        prePos = this.transform.position;
        Init();
    }

    public void Init()
    {
        isDead = false;
        isMoving = false;
        targetArrived = true;
        targetFloor = this.transform;
        
        rb = transform.GetComponent<Rigidbody2D>();
        LoadDirection();
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(targetFloor.name);
        //Debug.Log(this.transform.position);
        //Debug.Log(rb.velocity);
        Move();
        if (isDead)
            Reborn();
        prePos = this.transform.position;
    }

    void LateUpdate()
    {

    }

    void Move()//移动
    {
        if (Input.anyKey && !isMoving)
        {
            KeyCode key = KeyCode.None;
            /*Event e = Event.current;
            if (e.isKey)
                key = e.keyCode;*/
            foreach (KeyCode code in directions.Keys)
            {
                if (Input.GetKey(code))
                {
                    key = code;
                    break;
                }
            }
            if (directions.ContainsKey(key))
                targetFloor = Detect(key);
        }
        MoveTowards(targetFloor);
    }

    public void MoveTowards(Transform target)//控制向特定方向移动
    {
        Debug.Log(target);
        if (transform.position != target.position)
        {
            Vector2 pos = target.position;
            targetArrived = false;
            rb.velocity = (target.position - transform.position).normalized * moveSpeed;
            isMoving = true;
            //Debug.Log(2);
            StopAt(targetFloor);
        }
        else
        {
            targetFloor = this.transform;
            rb.velocity = Vector2.zero;
            targetArrived = true;
            //MonsterManager.UpdateMonsters(float.PositiveInfinity);
            isMoving = false;
        }

    }

    void OnGUI()
    {
        //Move();
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
        RaycastHit2D[] hits = Physics2D.LinecastAll(transform.position, transform.position + direction * 1.28f, LayerMask.GetMask(HashID.Layer_Replaceable,"Unwalkable"));
        if (hits.Length > 1 && hits[1].transform.tag == "Map" )
        {
            if (hits[0].transform.name.Contains("falling"))
            {
                Falling.Fall(hits[0].transform);
            }
            if (hits[hits.Length - 1].transform.name.Contains("ice"))
            {
                RaycastHit2D[] ices = new RaycastHit2D[20];
                int i = Physics2D.LinecastNonAlloc(hits[hits.Length - 1].transform.position, hits[hits.Length - 1].transform.position + direction * HashID.unitLength
                    * 20f, ices);
                for (int n = 1; n < i; n++)
                {
                    if (!ices[n].transform.name.Contains("ice"))
                    {
                        if(!ices[n].transform.tag.Equals("Map"))
                            return ices[n-1].transform;
                        return ices[n].transform;
                    }
                }
            }
            
            //Debug.Log(hits[1].transform.name);
            /*if (GameObject.FindWithTag(HashID.FOLLOWING))
                GameObject.FindWithTag(HashID.FOLLOWING).GetComponent<Following>().Follow(direction);*/
            MonsterManager.UpdateMonsters((hits[1].transform.position - transform.position).magnitude);
            return hits[1].transform;
        }
        else
            return this.transform;
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
        if ((transform.position - target.position).magnitude < 0.01f)
        {
            //Debug.Log(1);
            transform.position = target.transform.position;
            rb.velocity = Vector2.zero;
        }
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(0.1f);
    }
}
 