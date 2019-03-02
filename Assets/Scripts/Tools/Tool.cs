﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour {
    private GameObject player;
    private List<Vector3> pickPosition;//捡拾位置
    [SerializeField]
    private int condition;
    [SerializeField]
    private string toolsName;
    private bool hidden;
    public int curCondition;

	// Use this for initialization
	void Start () {
        hidden = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (curCondition == condition && hidden)
        {
            Appear();
            hidden = false;
        }
        if(!hidden)
        {
            if (Input.GetKey(KeyCode.E))
                BePicked();
        }
	}

    private void BePicked()
    {
        foreach(Vector3 pos in pickPosition)
        {
            if ((player.transform.position - pos).magnitude < 0.1f)
            {
                Debug.Log("picked");
            }
        }
    }

    private void InitData()
    {
        player = GameObject.FindWithTag(HashID.PLAYER);
        pickPosition.Add(transform.position + Vector3.up * HashID.unitLength);
        pickPosition.Add(transform.position + Vector3.left * HashID.unitLength);
        pickPosition.Add(transform.position + Vector3.down * HashID.unitLength);
        pickPosition.Add(transform.position + Vector3.right * HashID.unitLength);
        pickPosition.Add(transform.position);
    }

    private void Appear()
    {
        this.GetComponent<BoxCollider2D>().enabled = true;
        this.GetComponent<SpriteRenderer>().enabled = true;
    }
}
