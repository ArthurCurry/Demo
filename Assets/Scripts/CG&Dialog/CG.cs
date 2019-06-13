﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CG : MonoBehaviour
{
    //状态效果值
    public enum FadeStatuss
    {
        FadeIn,
        None,
        FadeOut
    }

    //设置的图片
    [SerializeField]
    public Image m_Sprite;
    //透明值
    private float m_Alpha;
    //淡入淡出状态

    private int status;

    private FadeStatuss m_Statuss;

    public FadeStatuss mStatuss
    {
        set { m_Statuss = value; }
    }
    //效更新的速度
    public float m_UpdateTime;
    //场景名称
    public string m_ScenesName;

    private AudioPlay ap;

    // Use this for initialization
    void Start()
    {
        ap = new AudioPlay();
        status = 0;
        m_Sprite = this.gameObject.GetComponent<Image>();
        m_Alpha = 0f;
        m_UpdateTime = 1;
        //默认设置为淡入效果
        m_Statuss = FadeStatuss.FadeIn;
    }

    // Update is called once per frame
    public void Update()
    {
        //控制透明值变化
        if (m_Statuss == FadeStatuss.FadeIn)
        {
            m_Alpha += m_UpdateTime * Time.deltaTime;
        }
        else if (m_Statuss == FadeStatuss.FadeOut)
        {
            m_Alpha -= m_UpdateTime * Time.deltaTime;
        }
        UpdateColorAlpha();
    }

    void UpdateColorAlpha()
    {
        //获取到图片的透明值
        Color ss = m_Sprite.color;
        ss.a = m_Alpha;
        //将更改过透明值的颜色赋值给图片
        m_Sprite.color = ss;
        //透明值等于的1的时候 转换成淡出效果
        if (m_Alpha > 1f)
        {
            if (BuildManager.Need)
            {
                BuildManager.InitDialog();
            }
            m_Statuss = FadeStatuss.None;
            m_Alpha = 1f;            
        }
        //值为0的时候跳转场景
        else if (m_Statuss ==FadeStatuss.FadeOut&&m_Alpha<=0.98)
        {
            if (BuildManager.Level == 1 && !GameObject.FindWithTag(HashID.LEVEL))
            {
                GameObject root = GameObject.Find("Canvas");
                root.GetComponent<ChangeEffect>().M_State = ChangeEffect.State.FadeIn;
                root.GetComponent<ChangeEffect>().game = ChangeEffect.o_status.end;
                ap.Play(Camera.main.gameObject);
                BuildManager.Need = true;
                //BuildManager.Init();
                //Camera.main.GetComponent<CameraController>().enabled = true;
                //Camera.main.GetComponent<CameraController>().DetectEdges();
                //BuildManager.InitAttribute();
            }
            else if (BuildManager.Level == 3)
            {
                if (this.name == "CG2(Clone)"&&!GameObject .Find ("CG3(Clone)"))
                {
                    BuildManager.Need = false;
                    BuildManager.InitCG("CG3", "旁白");
                }
                else if (this.name == "CG3(Clone)"&&!GameObject.Find("CG4(Clone)"))
                {
                    BuildManager.Need = true;
                    BuildManager.InitCG("CG4", "第三关CG2");                    
                }
            }
            else if(BuildManager.Level == 4)
            {
                if (this.name == "CG5(Clone)" && !GameObject.Find("CG6(Clone)"))
                {
                    BuildManager.Need = true;
                    BuildManager.InitCG("CG6", "第四关CG2");
                }
                else if (this.name == "CG3(Clone)" && !GameObject.Find("CG4(Clone)"))
                {
                    BuildManager.Need = true;
                    BuildManager.InitCG("CG7", "第四关CG3");
                }
            }
            if(m_Alpha < 0)
            {
                if (this.gameObject.name.Equals("CG4(Clone)") || this.gameObject.name.Equals("CG7(Clone)") || this.gameObject.name.Equals("CG8(Clone)"))
                {
                    GameObject root = GameObject.Find("Canvas");
                    root.GetComponent<ChangeEffect>().M_State = ChangeEffect.State.FadeIn;
                    root.GetComponent<ChangeEffect>().game = ChangeEffect.o_status.end;
                }
                Destroy(this.gameObject);
            }
        }
    }

}
