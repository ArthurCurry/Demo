﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovements : MonoBehaviour {
    public float moveSpeed;
    public bool isMoving;
    public bool targetArrived;

    private GameObject follow;
	// Use this for initialization
	void Start () {
        isMoving = false;
        targetArrived = true;
        follow = GameObject.Find("Follow");
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

        RaycastHit2D[] hits = Physics2D.LinecastAll(transform.position, transform.position + direction * 10);
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
            //yield return new WaitForSeconds(0.1f);  //嫌麻烦注释掉了
            isMoving = false;
            follow.GetComponent<Following>().follow(direction);
        }
        else
            StopAllCoroutines();
    }

    void OnGUI()
    {
        Move();
    }
}
 