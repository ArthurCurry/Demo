using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : MonoBehaviour {
    public Vector3 latePos;
    public Transform pos;
    public Transform nextPos;
    public GameObject player;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public abstract void judge();

    public abstract void attack();

    public abstract void move();
}
