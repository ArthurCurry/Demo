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
	// Use this for initialization
	void Start () {
        m_fs = FadeStatus.None;
        target = this.gameObject.GetComponent<TextMeshProUGUI>();
        m_Alpha = 0f;
        speed = 1f;
        c = target.color;
        color = target.colorGradient;
	}

    void UpdateAlpha()
    {
        if(m_fs == FadeStatus.FadeIn)
        {
            m_Alpha += speed * Time.deltaTime;
        }
        else if(m_fs==FadeStatus.FadeOut)
        {
            m_Alpha -= speed * Time.deltaTime;
        }
    }

    void UpdateColor()
    {
        c.a = m_Alpha;
        if(m_Alpha > 1f)
        {
            m_fs = FadeStatus.None;
            m_Alpha = 1f;
        }
        else if(m_Alpha <0f)
        {
            m_fs = FadeStatus.None;
            m_Alpha = 0f;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
