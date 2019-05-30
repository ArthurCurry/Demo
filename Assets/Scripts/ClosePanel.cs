using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanel : MonoBehaviour {

    private AudioPlay ap;

    private void Start()
    {
        ap = new AudioPlay();
    }

    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            ap.PlayClipAtPoint(ap.AddAudioClip("Audio/点击"), Camera.main.transform.position, 1f);
            this.gameObject.SetActive(false);
        }
	}
}
