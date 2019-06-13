using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MonsterTalk : MonoBehaviour {

    private Canvas canvas; 
    private GameObject boxA;
    private GameObject boxB;
    private GameObject boxC;
    private GameObject player;
    private GameObject instantiation;

    [SerializeField]
    private Transform a;
    [SerializeField]
    private Transform b;
    [SerializeField]
    private Transform c;

    private Dictionary<int, string> girlsC;

    private float time;

    // Use this for initialization

    // Update is called once per frame

    private void Start()
    {
        this.Add();
        boxA = Resources.Load<GameObject>("Prefabs/MonsterBoxA");
        boxB = Resources.Load<GameObject>("Prefabs/MonsterBoxB");
        boxC = Resources.Load<GameObject>("Prefabs/MonsterBoxC");
        player = GameObject.FindWithTag(HashID.PLAYER);
        canvas = GameObject.Find(HashID.CANVAS).GetComponent<Canvas>();
        time = 0;
    }

    void Update () {
        //Debug.Log(1);
        time += Time.deltaTime;
        if(instantiation != null)
        {
            this.Reset();
        }
        //Debug.Log(time);
        if (time >= 4)
        {
            if (girlsC.Count == 0)
            {
                this.Add();
            }
            GirlsTalk();
            time = 0;
        }
        if (time >= 3)
        { if (instantiation != null)
            {
                Destroy(instantiation);
            }
        }
	}

    //下面为女孩讲话的代码
    void Add() //添加女孩对话内容
    {
        girlsC = new Dictionary<int, string> { };
        girlsC.Add(11, "我跟你说，XXX这个人，今天在课堂上又不知道在干什么，被老师狠狠地批评了一顿，叫到办公室去了。");
        girlsC.Add(31, "这是活该，我以前音乐课见到过她，摆着一副受着多大畏惧委屈的样子，一个字也不说，跟贞子一样哈哈哈。");
        girlsC.Add(21, "哈哈哈哈，你这形容真是绝了，小玉,你之前不是说过她好像是在写小说吗？");
        girlsC.Add(32, "是的呀，今天她在课堂上估计也在写东西，咦，你坐的离她近，有看到她写了什么吗？");
        girlsC.Add(22, "我哪能知道，反正多半是一些乱七八糟的东西，看她也不像有什么才华的人，不知道好好学习净搞一些有的没的。");
        girlsC.Add(12, "你怎么能这么说别人呢哈哈哈哈，不过也是事实。");
        girlsC.Add(33, "对呀，说不定是在借小说逃避现实世界呢，我们以后少跟她接触。");
        girlsC.Add(13, "对了，昨天我去东小门那边的冰淇淋店逛了下，他们说新品今天就要发售了，我们一起去吃吧!");
        girlsC.Add(23, "可以啊，是什么新品啊？");
        girlsC.Add(14, "说是芒果味的。");
        girlsC.Add(34, "啊，我最喜欢吃芒果了，那我们今天下午自修翘了去？");
        girlsC.Add(24, "可以啊，正好可以跟下课的人流错过嘻嘻!");
    }

    void GirlsTalk()//按顺序遍历女生对话并进行实例化
    {
        foreach (KeyValuePair<int, string> kvp in girlsC)
        {
            if ((kvp .Key/10) == 1)
            {
                instantiation = this.CreatBox(a, boxA);
                Transform rBox = instantiation.transform.Find("dialogText");
                TextMeshProUGUI dialogtext = rBox.GetComponent<TextMeshProUGUI>();
                dialogtext.text = kvp.Value;
                girlsC.Remove(kvp.Key);
                time = 0;
                goto To;
            }
            else if((kvp.Key / 10) == 2)
            {
                instantiation = this.CreatBox(a, boxB);
                Transform rBox = instantiation.transform.Find("dialogText");
                TextMeshProUGUI dialogtext = rBox.GetComponent<TextMeshProUGUI>();
                dialogtext.text = kvp.Value;
                girlsC.Remove(kvp.Key);
                time = 0;
                goto To;
            }
            else if((kvp.Key / 10) == 3)
            {
                instantiation = this.CreatBox(a, boxC);
                Transform rBox = instantiation.transform.Find("dialogText");
                TextMeshProUGUI dialogtext = rBox.GetComponent<TextMeshProUGUI>();
                dialogtext.text = kvp.Value;
                girlsC.Remove(kvp.Key);
                time = 0;
                goto To;
            }
        }
To:
        return;
    }
    //女该讲话方面的代码结束
    GameObject CreatBox(Transform targetT,GameObject box)
    {
        GameObject a = Instantiate(box,canvas .transform );
        a.GetComponent<RectTransform>().position= targetT.position;
        return a;
    }

    private void Reset()
    {
        instantiation.GetComponent<RectTransform>().position = a.position;
    }
}
