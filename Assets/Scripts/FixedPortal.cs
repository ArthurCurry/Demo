using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedPortal : MonoBehaviour {
    [SerializeField]
    private List<Transform> patrolRoute;
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
	}
	
    void Update()
    {
        
    }

	void LateUpdate () {
        //Debug.Log(counter);
		if(playerRB.velocity==Vector2.zero)
        {
            distance += (player.transform.position - prePlayerPos).magnitude;
            prePlayerPos = player.transform.position;
        }
        if (Mathf.Abs(distance - HashID.unitLength) < 0.1f)
        {
            counter += 1;
            distance = 0f;
        }
        if (counter >= count)
        {
            GameObject child=Instantiate(patrol, transform.position, patrol.transform.rotation);
            FixedPatrol fp = child.GetComponent<FixedPatrol>();
            foreach(Transform pos in patrolRoute)
            {
                fp.route.Add(pos);
            }
            counter = 0;
        }
    }
}
