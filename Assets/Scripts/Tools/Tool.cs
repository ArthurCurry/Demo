using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour {
    private GameObject player;
    private Vector3[] pickPosition;//捡拾位置
    [SerializeField]
    private int condition;
    [SerializeField]
    private string toolsName;
    public int curCondition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void BePicked()
    {
        
    }

    private void InitData()
    {

    }

    private void Appear()
    {
        this.GetComponent<BoxCollider2D>().enabled = true;
        this.GetComponent<SpriteRenderer>().enabled = true;
    }
}
