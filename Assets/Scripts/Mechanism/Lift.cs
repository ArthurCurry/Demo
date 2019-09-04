using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour {

    [SerializeField]
    [Tooltip("触发该机关的主动方")]
    private GameObject active;
    [SerializeField]
    [Tooltip("触发器")]
    private GameObject passive;
    [SerializeField]
    private bool triggered;
    [SerializeField]
    [Tooltip("联动触发的另一个机关")]
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
            if(child.name.Contains("door"))
            {
                Debug.Log("door");
                child.GetComponent<SpriteRenderer>().color = Color.white;
                continue;
            }
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        GetComponent<BoxCollider2D>().enabled = true;
    }

    void TriggerDown()
    {
        Sprite sprite = Resources.Load<Sprite>("Materials/map/round 2/triggerDown");
        Debug.Log(sprite);
        passive.GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
