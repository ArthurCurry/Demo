using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanel : MonoBehaviour {


	void Update () {
        if (Input.GetMouseButtonDown(0))
            this.gameObject.SetActive(false);
	}
}
