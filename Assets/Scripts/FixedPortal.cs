using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedPortal : MonoBehaviour {
    [SerializeField]
    private List<Transform> patrolRoute;
    private List<Vector3> route=new List<Vector3>();
    [SerializeField]
    private bool reversed;
    [SerializeField]
    private int count;
    [SerializeField]
    private int counter;
    public GameObject patrol;
    private float distance;
    private bool counted;
    private Vector3 prePlayerPos;
    private GameObject player;
    private PlayerMovements pm;
    private Rigidbody2D playerRB;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag(HashID.PLAYER);
        pm = player.GetComponent<PlayerMovements>();
        playerRB = player.GetComponent<Rigidbody2D>();
        prePlayerPos = player.transform.position;
        counter = 0;
        distance = 0f;
        if(reversed)
        {
            patrolRoute.Reverse();
        }
        InitRoute();
        //Debug.Log(patrolRoute[0].name+" "+this.name);
	}
	
    void Update()
    {
        
    }

	void LateUpdate () {
        //Debug.Log(counter);
		Debug.Log(distance);
        if (Mathf.Abs(distance - HashID.unitLength) < 0.1f|| Mathf.Abs(distance - HashID.unitLength)>2*HashID.unitLength)
        {
            counter += 1;
            distance = 0f;
        }
        if (counter >= count)
        {
            GameObject child=Instantiate(patrol, transform.position, patrol.transform.rotation);
            child.transform.parent = this.transform.parent;
            FixedPatrol fp = child.GetComponent<FixedPatrol>();
            foreach(Vector3 node in route)
            {
                fp.route.Add(node);
            }
            counter = 0;
        }
        if (playerRB.velocity == Vector2.zero)
        {
            distance += (player.transform.position - prePlayerPos).magnitude;
            prePlayerPos = player.transform.position;
        }
    }

    void InitRoute()
    {
        foreach(Transform node in patrolRoute)
        {
            route.Add(node.position);
        }
    }
}
