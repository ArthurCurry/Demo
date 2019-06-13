using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class numberChanged : MonoBehaviour {

    private int ID;
    public Text number;
	// Use this for initialization
	void Start () {
        number = this.GetComponent<Text>();
        ID = 1; 
	}
	
	// Update is called once per frame


    public void Add()
    {
        if (ID == 6) return;
        else
        {
            ID++;
            number.text = ID.ToString();
        }
    }

    public void Decrese()
    {
        if (ID == 1) return;
        else
        {
            ID--;
            number.text = ID.ToString();
        }
        
    }
}
