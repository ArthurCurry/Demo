using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Talk : MonoBehaviour {
    private float distance;

    private Canvas canvas;
    private GameObject box;
    private GameObject player;
    private GameObject instantiation;

    [SerializeField]
    private Transform a;

    private Dictionary<Transform, string> dialog; //查找视图目标节点下的目标child并存进数组
    private Dictionary<int, string> comment;
    private string[] comments;

    private static bool hasTalk;
    public static bool HasTalk
    {
        set { hasTalk = value; }
    }

    private int status;
    private float time;

    private bool done;

    // Use this for initialization
    void Start () {
        comments = new string[3]
        {
            "我的钥匙呢？",
            "真是奇怪了……",
            "明明我昨天散步前还用过的。"
        };
        box = Resources.Load<GameObject>("Prefabs/MonsterBox");
        player = GameObject.FindWithTag(HashID.PLAYER);
        canvas = GameObject.Find(HashID.CANVAS).GetComponent<Canvas>();
        time = 0;
        hasTalk = false;
        done = true;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (instantiation != null)
        {
            this.Reset();
        }
        //Debug.Log(time);
        if (time >= 3)
        {
            GirlsTalk();
            time = 0;
        }
        if (time >= 2.2)
        {
            if (instantiation != null)
            {
                Destroy(instantiation);
                done = true;
            }
        }
        TalkTo();
	}

    void TalkTo()
    {
        if ((this.transform.position-player.transform.position).magnitude<0.3f && !hasTalk)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                BuildManager.IsCG = true;
                BuildManager.Name = "老头";
                BuildManager.X = 1;
                BuildManager.GetCount(BuildManager.Name);
                BuildManager.Instance.SetIndex(0);
                BuildManager.InitDialog();
                hasTalk = true;
            }
        }
    }

    void Reflash()
    {
        if (status == 2)
        {
            status = 0;
        }
        else
        {
            status += 1;
        }
    }

    void GirlsTalk()//按顺序遍历女生对话并进行实例化
    {
        if (done)
        {
            //this.CreatBox(a);
            instantiation = GameObject.Find("MonsterBox(Clone)");
            Transform rBox = instantiation.transform.Find("dialogText");
            Text dialogtext = rBox.GetComponent<Text>();
            dialogtext.text = comments[status];
            time = 0;
            done = false;
        }
        Reflash();
    }
    //女该讲话方面的代码结束
    void CreatBox(Transform targetT)
    {
        GameObject a = Instantiate(box, canvas.transform);
        a.GetComponent<RectTransform>().position = targetT.position;
    }

    private void Reset()
    {
        instantiation.GetComponent<RectTransform>().position = a.position;
    }
}
