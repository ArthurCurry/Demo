using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class backgroundchanged : MonoBehaviour {

    public GameObject Background;
    float ColorAlpha = 1f;//图片透明程度
    bool selected = false;
    bool restore = false;
    void Start()
    {

    }

    void Update()
    {
        if(selected == true)
        if (ColorAlpha >= 0.3)
        {
            ColorAlpha -= Time.deltaTime / 2;
                //Debug.Log(ColorAlpha);
            Background.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, ColorAlpha);
        }
        if (ColorAlpha <= 0.3)
            selected = false;

        if(restore == true)
        if(ColorAlpha<=1.0)
            {
                ColorAlpha += Time.deltaTime / 2;
                Debug.Log(ColorAlpha);
                Background.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, ColorAlpha);
            }
        if (ColorAlpha >= 1.0)
            restore = false;
    }


    public void Select()
    {
        selected = true;
    }

    public void Restore()
    {
        restore = true;
    }

}
