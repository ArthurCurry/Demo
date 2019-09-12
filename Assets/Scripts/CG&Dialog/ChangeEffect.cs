using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeEffect : MonoBehaviour {

    public enum o_status
    {
        start,
        none,
        end
    }
    public o_status game;

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

    private AudioPlay ap;
    // Use this for initialization
    void Start () {
        ap = new AudioPlay();
        game = o_status.start;
        rawImage = GameObject.Find(HashID.CANVAS).transform.Find("RawImage").GetComponent<RawImage>();
        fadeTime = 1f;
    }
	
	// Update is called once per frame
	void Update () {
        if (m_State == State.FadeIn)
        {
            EndScene();
            if (rawImage.color.a >= 0.98f && game == o_status.end)
            {
                ap.Play(Camera.main.gameObject);
                BuildManager.Init();
                Camera.main.GetComponent<CameraController>().enabled = true;
                Camera.main.GetComponent<CameraController>().Init();
                BuildManager.InitAttribute();
            }
        }
        if (m_State == State.FadeOut)
        {
            StartScene();
            if(rawImage.color.a <= 0.8f&& game == o_status .start)
            {
                if (BuildManager.Level == 1)
                {
                    BuildManager.InitCG("CG1", "旁白");
                }
                else if (BuildManager.Level == 3)
                {
                    BuildManager.InitCG("CG2", "第三关CG1");
                }
                else if (BuildManager.Level == 4)
                {
                    BuildManager.InitCG("CG5", "第四关CG1");
                }
                else if(BuildManager .Level == 5)
                {
                    BuildManager.InitCG("CG8", "第四关结束CG");
                }
                else if (BuildManager .Level == 6)
                {
                    BuildManager.InitCG("CG9", "第五关结束CG");
                }
                else if(BuildManager .Level == 8)
                {
                    BuildManager.InitCG("CG9", "第七关结束CG");
                }
                else
                {
                    if (!(BuildManager.Level == 7 || BuildManager.Level == 8 || BuildManager.Level == 9))
                    {
                        BuildManager.Need = true;
                    }
                    ap.Play(Camera.main.gameObject);
                    BuildManager.Init();
                    Camera.main.GetComponent<CameraController>().enabled = true;
                    Camera.main.GetComponent<CameraController>().Init();
                    BuildManager.InitAttribute();
                }
                game = o_status.none;
            }            
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
