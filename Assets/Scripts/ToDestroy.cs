using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToDestroy : MonoBehaviour {


    // Use this for initialization
    private void Awake()
    {
        if(BuildManager .toDestroy == true)
        {
            Destroy(this.gameObject);
        }
        else
        {
            BuildManager.toDestroy = true;
        }
    }
}
