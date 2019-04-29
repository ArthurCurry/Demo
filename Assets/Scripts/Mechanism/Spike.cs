using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : Trap {

    [SerializeField]
    private List<Transform> triggers;

    private bool triggered;

	// Use this for initialization
	void Start () {
        InitTrap();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
}
