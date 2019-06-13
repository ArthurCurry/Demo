using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MonsterTalkB : MonoBehaviour {

    private Canvas canvas;
    private GameObject boxA;
    private GameObject boxB;
    private GameObject player;
    private GameObject instantiation;

    [SerializeField]
    private Transform a;
    [SerializeField]
    private Transform b;

    private Dictionary<int, string> girlsC;

    private float time;

    // Use this for initialization

    // Update is called once per frame

    private void Start()
    {
        this.Add();
        boxA = Resources.Load<GameObject>("Prefabs/MonsterBoxC");
        boxB = Resources.Load<GameObject>("Prefabs/MonsterBoxB");
        player = GameObject.FindWithTag(HashID.PLAYER);
        canvas = GameObject.Find(HashID.CANVAS).GetComponent<Canvas>();
        time = 0;
    }

    void Update()
    {
        //Debug.Log(1);
        time += Time.deltaTime;
        if (instantiation != null)
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
        {
            if (instantiation != null)
            {
                Destroy(instantiation);
            }
        }
    }

    //下面为女孩讲话的代码
    void Add() //添加女孩对话内容
    {
        girlsC = new Dictionary<int, string> { };
        girlsC.Add(11, "呐，晨晨，你这么老是来图书馆看书啊？");
        girlsC.Add(21, "嘘！小声点，不要打搅到别人。");
        girlsC.Add(22, "你不觉得这里氛围很好吗，学校别的地方总是吵吵嚷嚷的，到晚上都不得安宁。");
        girlsC.Add(23, "只有这里永远是这么的安静，仿佛时间就在此刻停滞了。");
        girlsC.Add(12, "话虽如此，你也很喜欢看书吧？");
        girlsC.Add(24, "嗯，只有看书能让我暂时忘记掉学习的压力。");
        girlsC.Add(25, "有时我会想，如果我是一个作家该有多好，能够用笔尖描绘出这世间冷暖，幻想虚构，各种美好的想象。");
        girlsC.Add(26, "也能够用自己的笔触打开别人的心灵。");
        girlsC.Add(13, "那你可以尝试一下的嘛！");
        girlsC.Add(27, "那还是算了，不经历生之痛，哪来幻想绽放的养分。没有经历就谈不上写作。");
        girlsC.Add(14, "你怎么突然变得这么深奥哈哈，连我都听不懂了。");
        girlsC.Add(28, "啊，其实我自己也不是很懂……");
        girlsC.Add(15, "呀呀呀，你快看这本书。");
        girlsC.Add(29, "什么嘛，我看看。");
        girlsC.Add(20, "唔，《草原上的小木屋》，这本书我看过哇，挺不错的，你这么激动干什么？");
        girlsC.Add(16, "呀，只是这本书是老师推荐书单上的啦。");
        girlsC.Add(30, "……");
    }

    void GirlsTalk()//按顺序遍历女生对话并进行实例化
    {
        foreach (KeyValuePair<int, string> kvp in girlsC)
        {
            if ((kvp.Key / 10) == 1)
            {
                instantiation = this.CreatBox(a, boxA);
                Transform rBox = instantiation.transform.Find("dialogText");
                TextMeshProUGUI dialogtext = rBox.GetComponent<TextMeshProUGUI>();
                dialogtext.text = kvp.Value;
                girlsC.Remove(kvp.Key);
                time = 0;
                goto To;
            }
            else if ((kvp.Key / 10) == 2)
            {
                instantiation = this.CreatBox(a,boxB);
                Transform rBox = instantiation.transform.Find("dialogText");
                TextMeshProUGUI dialogtext = rBox.GetComponent<TextMeshProUGUI>();
                dialogtext.text = kvp.Value;
                girlsC.Remove(kvp.Key);
                time = 0;
                goto To;
            }
            else if ((kvp.Key / 10) == 3)
            {
                instantiation = this.CreatBox(a, boxB);
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
    GameObject CreatBox(Transform targetT ,GameObject box)
    {
        GameObject a = Instantiate(box, canvas.transform);
        a.GetComponent<RectTransform>().position = targetT.position;
        return a;
    }

    private void Reset()
    {
        instantiation.GetComponent<RectTransform>().position = a.position;
    }
}
