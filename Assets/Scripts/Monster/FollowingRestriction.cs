using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingRestriction : MonoBehaviour {

    private Following following;
    private GameObject player;
    private Vector3 urPos;
    private Vector3 llPos;

    private GameObject[] puzzleUIs;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag(HashID.PLAYER);
        following = GetComponent<Following>();
        urPos = following.URPos;
        llPos = following.LLPos;
        puzzleUIs = GameObject.FindGameObjectsWithTag("PuzzleUI");
	}
	
	// Update is called once per frame
	void LateUpdate () {
        /*if (PlayerInRange())
            this.GetComponent<Following>().enabled = true;
        else
            this.GetComponent<Following>().enabled = false;*/
	}

    bool PlayerInRange()
    {
        Vector3 playerPos = player.transform.position;
        if ((playerPos.x > urPos.x || playerPos.x < llPos.x) || (playerPos.y > urPos.y || playerPos.y < llPos.y))
            return false;
        return true;
    }
}
