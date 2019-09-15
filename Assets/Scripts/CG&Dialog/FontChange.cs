using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FontChange : MonoBehaviour {
    public enum FadeStatus
    {
        FadeIn,
        None,
        FadeOut
    }

    private FadeStatus m_fs;

    private TextMeshProUGUI target;
    private float speed;
    private float m_Alpha;
    private Color c;
    private VertexGradient color;

    public bool fadeIn;
    public bool fadeOut;
    // Use this for initialization
    void Start () {
        fadeIn = true ;
        fadeOut = true;
        target = this.gameObject.GetComponent<TextMeshProUGUI>();
        m_Alpha = 0f;
        speed = 10000f;
        
        c = target.color;
        Debug.Log(c.a);
        color = target.colorGradient;
	}

    void FadeIn()
    {

        target.color = Color.Lerp(c, Color.white, speed * Time.deltaTime);
    }

    void UpdateColor()
    {
        Debug.Log(c.a);
        m_Alpha = c.a;
        if (fadeIn)
        {
            FadeIn();
            if (m_Alpha >= 0.98f)
            {
                c = Color.white;
                //fadeIn = false;
                fadeOut = true;
            }
        }
    }
	
    void UpdateTR()
    {
        Debug.Log(color.topRight.a);
        if (fadeOut && color .topRight .a != 0)
        {
            color.topRight.a -= speed * Time.deltaTime;
            //color.topRight = Color.Lerp(color.topRight, Color.clear, speed * Time.deltaTime);
            if(color .topRight .a <= 0.05f)
            {
                color.topRight = Color.clear;
            }
        }
        if (color.topRight.a <= 0.05f)
        {
            color.topRight = Color.clear;
        }
    }

    void UpdateTL()
    {
        if (fadeOut && color.topRight.a == 0 && color .topLeft.a !=0)
        {
            color.topLeft = Color.Lerp(color.topLeft, Color.clear, speed * Time.deltaTime);
            if (color.topLeft.a <= 0.05f)
            {
                color.topLeft = Color.clear;
            }
        }
    }

    void UpdateBR()
    {
        if (fadeOut && color.topRight.a == 0 && color.bottomRight.a != 0)
        {
            color.bottomRight = Color.Lerp(color.bottomRight, Color.clear, speed * Time.deltaTime);
            if (color.bottomRight.a <= 0.05f)
            {
                color.bottomRight = Color.clear;
            }
        }
    }

    void UpdateBL()
    {
        if (fadeOut && color.topRight.a == 0 && color.bottomLeft.a != 0)
        {
            color.bottomLeft  = Color.Lerp(color.bottomLeft , Color.clear, speed * Time.deltaTime);
            if (color.bottomLeft .a <= 0.05f)
            {
                color.bottomLeft = Color.clear;
                fadeOut = false;
            }
        }
    }

    // Update is called once per frame
    void Update () {
        UpdateColor();
        //UpdateTR();
       // UpdateTL();
        //UpdateBR();
        //UpdateBL();
	}
}
