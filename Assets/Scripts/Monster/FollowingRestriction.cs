using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingRestriction : MonoBehaviour {

    private Following following;
    private GameObject player;
    private Vector3 urPos;
    private Vector3 llPos;
    private bool passed;

    private GameObject[] puzzleUIs;

    [SerializeField]
    [Tooltip("每一种类型拼图给予的数量")]
    private int puzzleNumber=4;

	// Use this for initialization
	void Start () {
        passed = false;
        player = GameObject.FindWithTag(HashID.PLAYER);
        following = GetComponent<Following>();
        urPos = following.URPos;
        llPos = following.LLPos;
        puzzleUIs = GameObject.FindGameObjectsWithTag("PuzzleUI");
	}
	
	// Update is called once per frame
	void LateUpdate () {
        ControlUI();
	}

    bool PlayerInRange()
    {
        Vector3 playerPos = player.transform.position;
        if ((playerPos.x > urPos.x || playerPos.x < llPos.x) || (playerPos.y > urPos.y || playerPos.y < llPos.y))
            return false;
        return true;
    }

    void ControlUI()
    {
        if (PlayerInRange())
            ActiveUI();
        else
            DeactiveUI();
    }

    void ActiveUI()
    {
        foreach(GameObject ui in puzzleUIs)
        {
            UIOnClick puzzle = ui.GetComponent<UIOnClick>();
            if (!passed)
            {
                puzzle.puzzleLeft += puzzleNumber;
            }
            ui.SetActive(true);
        }
        passed = true;
    }

    void DeactiveUI()
    {
        foreach (GameObject ui in puzzleUIs)
        {
            ui.SetActive(false);
        }
    }
}
