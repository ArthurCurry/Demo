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
    [SerializeField]
    private Lift lift;
    private bool lifted;

    public bool m_triggered
    {
        get
        {
            return triggered;
        }
    }

	// Use this for initialization
	void Start () {
        triggered = false;
        if(active==null)
        {
            active = GameObject.FindWithTag(HashID.PLAYER);
        }
	}
	
    void LateUpdate()
    {
        if(!triggered)
        {
            if((active.transform.position-passive.transform.position).magnitude<0.2f)
            {
                triggered = true;
            }
        }
        else
        {
            if (lift==(null))
                LiftUp();
            else if (lift.m_triggered)
                LiftUp();
        }
        if(lifted!=triggered)
        {
            TriggerDown();
        }
        lifted = triggered;
    }

    void LiftUp()
    {
        
        foreach(Transform child in this.GetComponentInChildren<Transform>())
        {
            Debug.Log(child.name);
            child.gameObject.SetActive(true);
            if(child.name.Contains("door"))
            {
                Debug.Log("door");
                child.GetComponent<SpriteRenderer>().color = Color.white;
                continue;
            }
            if (child.name.Contains("gap"))
                child.gameObject.SetActive(false);
            if(child.name.Contains("Unreplaceable"))
            child.GetComponent<BoxCollider2D>().enabled = true;

        }
    }

    void TriggerDown()
    {
        Sprite sprite = Resources.Load<Sprite>("Materials/map/round 2/triggerDown");
        Debug.Log(sprite);
        passive.GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
