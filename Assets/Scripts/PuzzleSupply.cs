using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSupply : MonoBehaviour {


    [SerializeField]
    private UIOnClick[] puzzleUI;
    [SerializeField]
    private int[] number = new int[3];
    [SerializeField]
    private GameObject active;
    [SerializeField]
    private bool triggered;

	// Use this for initialization
	void Start () {
        triggered = false;
        puzzleUI[0] = GameObject.Find("Puzzle_1").GetComponent<UIOnClick>();
        puzzleUI[1] = GameObject.Find("Puzzle_2").GetComponent<UIOnClick>();
        puzzleUI[2] = GameObject.Find("Puzzle_3").GetComponent<UIOnClick>();
        if (transform.name.Contains("start"))
        {
            active = GameObject.FindWithTag(HashID.PLAYER);
        }
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if((active.transform.position-this.transform.position).magnitude<0.2f&&!triggered)
        {
            UpdateNumOfPuzzle(number[0],number[1],number[2]);
            triggered = true;
        }
	}


    void UpdateNumOfPuzzle(int a, int b, int c)
    {
        puzzleUI[0].puzzleLeft += a;
        puzzleUI[1].puzzleLeft += b;
        puzzleUI[2].puzzleLeft += c;
    }

    public static void UpdatePuzzle(int a,int b,int c)
    {
        GameObject[] puzzles = GameObject.FindGameObjectsWithTag("PuzzleUI");
        puzzles[0].GetComponent<UIOnClick>().puzzleLeft += a;
        puzzles[1].GetComponent<UIOnClick>().puzzleLeft += b;
        puzzles[2].GetComponent<UIOnClick>().puzzleLeft += c;
    }
}
