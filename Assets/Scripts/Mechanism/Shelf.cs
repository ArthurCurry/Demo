using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour {

    [SerializeField]
    private Transform triggerPos;
    [SerializeField]
    private Transform active;
    [SerializeField]
    private bool triggered;

	// Use this for initialization
	void Start () {
        triggered = false;
        if (active == null)
            active = GameObject.FindWithTag(HashID.PLAYER).transform;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if(Mathf.Abs((active.position-triggerPos.position).magnitude)<0.01f&&!triggered)
        {
            triggered = true;
            transform.GetComponent<SpriteRenderer>().enabled = false;
            Transform[] children = GetComponentsInChildren<Transform>(true);
            foreach(Transform child in children)
            {
                Debug.Log(child.name);
                child.gameObject.SetActive(true);
            }
        }
	}
}
