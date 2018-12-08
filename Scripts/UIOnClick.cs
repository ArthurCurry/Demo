using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class UIOnClick : MonoBehaviour,IPointerDownHandler,IPointerEnterHandler,IPointerExitHandler {
    public GameObject puzzle;//拼图
    public int puzzleLeft;//剩下的可使用拼图数量
    Color c;
	// Use this for initialization
	void Start () {
        c = GetComponent<Image>().color;
	}
	
	// Update is called once per frame
	void Update () {
        
	}

   
    public void OnPointerDown(PointerEventData ped)//点击UI
    {
        //Debug.Log(name);
        //
        if(puzzleLeft>0)
            InstanitiatePuzzle(puzzle);
    }

    public void OnPointerEnter(PointerEventData ped)
    {
        GetComponent<Image>().color = Color.red;
    }

    public void OnPointerExit(PointerEventData ped)
    {
        GetComponent<Image>().color = c;
    }

    void InstanitiatePuzzle(GameObject puzzle)//生成拼图
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = 0;
        //Debug.Log(worldPos);
        Instantiate(puzzle,worldPos,puzzle.transform.rotation);
    }
}
