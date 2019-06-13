using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class numberChange : MonoBehaviour {

    public GameObject Door;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Add(int level)
    {
        if (level == 6)
            return;
        level++;
    }

    public void decrese(int level)
    {
        if (level == 1)
            return;
        level--;
    }
}
