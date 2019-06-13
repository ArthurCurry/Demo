using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundChanged : MonoBehaviour {

    public GameObject Background;
    float ColorAlpha = 1f;
    bool Clicked = false;
    bool restore = false;

	// Update is called once per frame
	void Update () {
        if(Clicked == true)
        if (ColorAlpha >= 0.3)
        {
            ColorAlpha -= Time.deltaTime / 2;
                SpriteRenderer sr = Background.transform.GetComponent<SpriteRenderer>();
               sr.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, ColorAlpha);              
        }
        if (ColorAlpha <= 0.3)
        {
            Clicked = false;
        }
        if(restore == true)
        {
            if (ColorAlpha <= 1.0)
            {
                ColorAlpha += Time.deltaTime / 2;
                SpriteRenderer sr = Background.transform.GetComponent<SpriteRenderer>();
                sr.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, ColorAlpha);
            }
        }
        if (ColorAlpha >= 1.0)
        {
            restore = false;
        }
    }

    public void Click()
    {
        Clicked = true;
    }

    public void Restore()
    {
        restore = true;
    }
}
