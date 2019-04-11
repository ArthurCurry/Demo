using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterTalk : MonoBehaviour {

    private GameObject box;
    private GameObject player;
    private GameObject instantiation;

    [SerializeField]
    private Transform a;
    [SerializeField]
    private Transform b;
    [SerializeField]
    private Transform c;

    private Dictionary<Transform , string> dialog; //查找视图目标节点下的目标child并存进数组
    private Dictionary<Transform, string> comment;
    private Dictionary<int, string> girlsC;
    private string[] patrolsC;

    private string levelName;
    private int count;
    private float time;
    private float fixTime;

    // Use this for initialization

    // Update is called once per frame

    private void Start()
    {
        patrolsC = new string[] {
            "李老师讲课不仅无聊，而且还经常点同学上去做题，真是烦透了",
            "这次小考排名又比上次进步了一点，加油！",
            "我明明这么努力，怎么考试永远都考不好……",
            "听说邻省的十一中有个女孩跳楼了，也不知道是真的还是假的……",
            "一看见老李那张脸就烦，真是的，一天到晚板着张脸!"
        };
        this.Add();
        box = Resources.Load<GameObject>("Prefabs/MonsterBox");
        player = GameObject.FindWithTag(HashID.PLAYER);
        time = 0;
    }

    void Update () {
        time += Time.deltaTime;
        fixTime += Time.deltaTime;
        if (time >= 2)
        {
            if (girlsC.Count == 0)
            {
                this.Add();
            }
            GirlsTalk();
            time = 0;
            fixTime = 0;
        }
        if (fixTime >= 1.8 && instantiation != null)
        {
            Destroy(instantiation);
        }
	}

    void AddInto(string targetName)
    {
        dialog = new Dictionary<Transform, string>();
        GameObject level = GameObject.FindWithTag(HashID.LEVEL);
        levelName = level.name;
        count = level.transform.Find(targetName).childCount;
        for (int i = 0; i < count; i++)
        {
            if (Judge(level.transform.GetChild(i).name) != null&&dialog .Count <=3)
            {
                if ((level.transform.GetChild(i).transform.position - player.transform.position).magnitude <= 10)
                    dialog.Add(level.transform.GetChild(i).transform, _Switch(Random.Range(0, 5)));
            }
        }
    }

    string Judge(string name)
    {
        if(name.Contains("fixedroute"))
        {
            return ("");
        }
        else
        {
            return null;
        }
    }

    string _Switch(int x)
    {
        switch (x)
        {
            case 0:return patrolsC[0];
            case 1:return patrolsC[1];
            case 2:return patrolsC[2];
            case 3:return patrolsC[3];
            case 4:return patrolsC[4];
            default:return patrolsC[0];
        }
    }

    void PatrolTalk()
    {
        foreach (KeyValuePair<Transform, string> kvp in dialog)
        {
            if (kvp.Key == null)
            {
                dialog.Remove(kvp.Key);
            }
            else
            {
                instantiation = CreatBox(kvp.Key);  // 给三个属性分别存储
                Transform rBox = instantiation.transform.Find("dialogText");
                Text dialogtext = rBox.GetComponent<Text>();
                dialogtext.text = kvp.Value;
                dialog.Remove(kvp.Key);
            }
        }
    }

    //下面为女孩讲话的代码
    void Add() //添加女孩对话内容
    {
        girlsC = new Dictionary<int, string> { };
        girlsC.Add(11, "我跟你说，XXX这个人，今天在课堂上又不知道在干什么，被老师狠狠地批评了一顿，叫到办公室去了");
        girlsC.Add(31, "这是活该，我以前音乐课见到过她，摆着一副受着多大畏惧委屈的样子，一个字也不说，跟贞子一样哈哈哈");
        girlsC.Add(21, "哈哈哈哈，你这形容真是绝了，我之前听小玉说过她好像是在写小说");
        girlsC.Add(32, "咦，真的吗真的吗，你们知道她在写什么东西吗");
        girlsC.Add(22, "我哪能知道，反正多半是一些乱七八糟的东西，看她也不像有什么才华的人，不知道好好学习净搞一些有的没的");
        girlsC.Add(12, "你怎么能这么说别人呢哈哈哈哈，不过也是事实");
        girlsC.Add(33, "对呀，说不定是在借小说逃避现实世界呢，我们以后少跟她接触");
        girlsC.Add(13, "对了，昨天我去东小门那边的冰淇淋店逛了下，他们说新品今天就要发售了，我们一起去吃吧!");
        girlsC.Add(23, "可以啊，是什么新品啊？");
        girlsC.Add(14, "说是芒果味的。");
        girlsC.Add(34, "啊，我最喜欢吃芒果了，那我们今天下午自修翘了去？");
        girlsC.Add(24, "可以啊，正好可以跟下课的人流错过嘻嘻");
    }

    void GirlsTalk()//按顺序遍历女生对话并进行实例化
    {
        foreach(KeyValuePair<int,string > kvp in girlsC)
        {
            if((kvp .Key/10) == 1)
            {
                instantiation = CreatBox(a);
                Transform rBox = instantiation.transform.Find("dialogText");
                Text dialogtext = rBox.GetComponent<Text>();
                dialogtext.text = kvp.Value;
                girlsC.Remove(kvp.Key);
                break;
            }
            else if((kvp.Key / 10) == 2)
            {
                instantiation = CreatBox(b);
                Transform rBox = instantiation.transform.Find("dialogText");
                Text dialogtext = rBox.GetComponent<Text>();
                dialogtext.text = kvp.Value;
                girlsC.Remove(kvp.Key);
                break;
            }
            else if((kvp.Key / 10) == 3)
            {
                instantiation = CreatBox(c);
                Transform rBox = instantiation.transform.Find("dialogText");
                Text dialogtext = rBox.GetComponent<Text>();
                dialogtext.text = kvp.Value;
                girlsC.Remove(kvp.Key);
                break;
            }
        }
    }
    //女该讲话方面的代码结束
    GameObject CreatBox(Transform targetT)
    {
        return Instantiate(box, targetT);
    }
}
