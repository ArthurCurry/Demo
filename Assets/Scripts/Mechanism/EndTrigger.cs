using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour {

    [SerializeField]
    private GameObject end;
    private GameObject player;
    private bool triggered;
    private bool statusLF;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag(HashID.PLAYER);
        triggered = false;
        statusLF = triggered;
	}
	
	// Update is called once per frame
	void Update () {
		if(triggered&&statusLF!=triggered)
        {
            end.SetActive(true);
        }
        statusLF = triggered;
	}
}
