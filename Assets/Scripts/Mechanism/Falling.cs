using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour {

    //private List<Transform> fallings;
    private GameObject player;
    private Rigidbody2D playerRb;
    private PlayerMovements pm;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag(HashID.PLAYER);
        playerRb = player.GetComponent<Rigidbody2D>();
        pm = player.GetComponent<PlayerMovements>();

	}

	void LateUpdate () {
		
	}


    private void FindChildren()
    {

    }

    public static void Fall(Transform target)
    {
        GameObject replace = Resources.Load("Prefabs/void") as GameObject;
        Instantiate(replace, target.position,replace.transform.rotation,GameObject.FindWithTag("Level").transform);
        Destroy(target.gameObject);

    }
}
