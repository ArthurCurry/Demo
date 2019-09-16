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
        fadeOut = false;
        target = this.gameObject.GetComponent<TextMeshProUGUI>();
        m_Alpha = 0f;
        speed = 1f;
        
        c = target.color;
        color = target.colorGradient;
	}

    void FadeIn()
    {
        target.color = Color.Lerp(target .color, Color.white, speed * Time.deltaTime);
    }

    void UpdateColor()
    {
        m_Alpha = target .color .a;
        if (fadeIn)
        {
            FadeIn();
            if (m_Alpha >= 0.92f)
            {
                target.color = Color.white;
                fadeIn = false;
                fadeOut = true;
            }
        }
    }
	
    void UpdateTR()
    {
        if (fadeOut && color .topRight .a != 0)
        {
            color.topRight = Color.Lerp(color.topRight, Color.clear, speed * Time.deltaTime);
            if(color .topRight .a <= 0.05f)
            {
                color.topRight = Color.clear;
            }
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
        UpdateTR();
        UpdateTL();
        UpdateBR();
        UpdateBL();
	}
}
