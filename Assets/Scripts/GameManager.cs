using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    static void MoveTo(Transform gameObject,Transform target)
    {
        gameObject.position = target.position;
        if (gameObject.tag == ("Player"))
            Camera.main.transform.position = gameObject.position;
    }
}
