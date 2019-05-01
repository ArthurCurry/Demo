using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;
using UnityEngine.EventSystems;

public class CGCollection : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public int CGNumber;
    public bool isWatched = false;
	void Start () {
		
	}
	
	void Update () {
        if (isWatched == true)
        {
            Sprite sp = Resources.Load<Sprite>("Materials/CG/CG" + CGNumber);
            this.GetComponent<Image>().sprite = sp;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log(CGNumber);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log(CGNumber + 100);
    }
}
