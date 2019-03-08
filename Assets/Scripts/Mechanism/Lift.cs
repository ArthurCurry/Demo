using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour {

    [SerializeField]
    private GameObject active;
    [SerializeField]
    private GameObject passive;
    [SerializeField]
    private bool triggered;

	// Use this for initialization
	void Start () {
        triggered = false;
	}
	
    void LateUpdate()
    {
        if(!triggered)
        {
            if((active.transform.position-passive.transform.position).magnitude<0.2f)
            {
                triggered = true;
                LiftUp();
            }
        }
    }

    void LiftUp()
    {
        foreach(Transform child in this.GetComponentInChildren<Transform>())
        {
            if(!transform.name.Equals(this.transform.name))
            {
                if(child.name.Contains("door"))
                {
                    child.gameObject.SetActive(false);
                    continue;
                }
                child.GetComponent<BoxCollider2D>().enabled = true;
                child.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }
}
