using System.Collections;
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
    private FadeStatuss m_Statuss;

    public FadeStatuss mStatuss
    {
        set { m_Statuss = value; }
    }
    //效更新的速度
    public float m_UpdateTime;
    //场景名称
    public string m_ScenesName;

    // Use this for initialization
    void Start()
    {

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
        else if (m_Alpha < 0.5&&m_Statuss ==FadeStatuss.FadeOut)
        {
            if (BuildManager.Level == 1 && !GameObject.FindWithTag(HashID.LEVEL))
            {
                BuildManager.InitAttribute();
                BuildManager.Init();
                Camera.main.GetComponent<CameraController>().enabled = true;
                Camera.main.GetComponent<CameraController>().DetectEdges();
            }
            if (BuildManager.Level == 3)
            {
                if (this.name == "CG2(Clone)"&&!GameObject .Find ("CG3(Clone)"))
                {
                    BuildManager.InitCG("CG3", "旁白");
                }
                if (this.name == "CG3(Clone)"&&!GameObject.Find("CG4(Clone)"))
                {
                    BuildManager.Need = true;
                    BuildManager.InitCG("CG4", "第三关");                    
                }
            }
            if(m_Alpha < 0)
            {
                if (this.gameObject.name.Equals("CG4(Clone)"))
                {
                    BuildManager.InitDialog();
                }
                BuildManager.Need = false;
                Destroy(this.gameObject);
            }
        }
    }

}
