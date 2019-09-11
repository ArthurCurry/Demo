using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sting : MonoBehaviour {

    [SerializeField]
    private bool ready;
    private bool statusLastFrame;//上一帧状态
    private PlayerMovements pm;

    private Sprite stingOn;
    private Sprite stingOff;
    

	// Use this for initialization
	void Start () {
        pm = GameObject.FindWithTag(HashID.PLAYER).GetComponent<PlayerMovements>();
        statusLastFrame = ready;
	}
	
	// Update is called once per frame
	void Update () {
        if (statusLastFrame != ready)
            Switch();
	}

    void OnTriggerEnter2D()
    {
        pm.isDead = true;
    }

    void Switch()
    {
        ready = !ready;
    }

    void ShowSprite()
    {
        if (ready)
            GetComponent<SpriteRenderer>().sprite = stingOn;
        else
            GetComponent<SpriteRenderer>().sprite = stingOff;
    }
}
