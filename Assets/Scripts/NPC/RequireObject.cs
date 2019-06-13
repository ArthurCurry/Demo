using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequireObject : MonoBehaviour {

    [SerializeField]
    private GameObject requiredTool;
    private Tool tool;

	// Use this for initialization
	void Start () {
        tool = requiredTool.GetComponent<Tool>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if(tool.Picked)
        {
            foreach(Transform child in GetComponentsInChildren<Transform>(true))
            {
                child.gameObject.SetActive(true);
            }
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
	}
}
