﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;
using UnityEngine.EventSystems;

public class CGCollection : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public int CGNumber;
    public GameObject SpotImage;
    private bool canBeClick = false;
    public bool isWatched = false;
    private AudioPlay ap;

	void Start () {
        //SpotImage = GameObject.Find("SpotImage");
        ap = new AudioPlay();
	}
	
	void Update () {
        if (isWatched == true)
        {
            Sprite sp = Resources.Load<Sprite>("Materials/CG/CG" + CGNumber);
            this.GetComponent<Image>().sprite = sp;
        }
        if (canBeClick == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ap.PlayClipAtPoint(ap.AddAudioClip("Audio/点击"), Camera.main.transform.position, 1f);
                EnlargeImage(CGNumber);
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        canBeClick = true;
        Debug.Log(CGNumber);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        canBeClick = false;
        Debug.Log(CGNumber + 100);
    }

    public void EnlargeImage(int Number)
    {
        SpotImage.SetActive(true);
        Sprite sp = Resources.Load<Sprite>("Materials/CG/CG" + Number);
        SpotImage.GetComponent<Image>().sprite = sp;
    }
}
