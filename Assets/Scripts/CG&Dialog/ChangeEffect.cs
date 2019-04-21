using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeEffect : MonoBehaviour {

    private RawImage rawImage;

    private float fadeTime;

    public enum State
    {
        FadeIn,
        none,
        FadeOut
    }

    private State m_State;
    public State M_State
    {
        set { m_State = value; }
    }

    // Use this for initialization
    void Start () {
        rawImage = GameObject.Find(HashID.CANVAS).transform.Find("RawImage").GetComponent<RawImage>();
        fadeTime = 0.5f;
    }
	
	// Update is called once per frame
	void Update () {
        if (m_State == State.FadeIn)
        {
            EndScene();
        }
        if (m_State == State.FadeOut)
        {
            StartScene();
        }
    }

    private void FadeOut() //淡出
    {
        rawImage.color = Color.Lerp(rawImage.color, Color.clear, fadeTime * Time.deltaTime);
    }

    private void FadeIn() //淡入
    {
        rawImage.color = Color.Lerp(rawImage.color, Color.black, fadeTime * Time.deltaTime);
    }

    void StartScene()
    {
        FadeOut();
        if (rawImage.color.a <= 0.05f)
        {
            rawImage.color = Color.clear;
            rawImage.enabled = false;
            m_State = State.none;
        }
    }

    void EndScene()
    {
        rawImage.enabled = true;
        FadeIn();
        if (rawImage.color.a >= 0.95f)
        {
            rawImage.color = Color.black;
            m_State = State.FadeOut;
        }
    }
}
