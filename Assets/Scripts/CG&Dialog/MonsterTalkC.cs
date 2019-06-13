using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MonsterTalkC : MonoBehaviour {

    private Canvas canvas;
    private GameObject boxA;
    private GameObject player;
    private GameObject instantiation;

    [SerializeField]
    private Transform a;

    private Dictionary<int, string> girlsC;

    private float time;

    // Use this for initialization

    // Update is called once per frame

    private void Start()
    {
        this.Add();
        boxA = Resources.Load<GameObject>("Prefabs/MonsterBoxC");
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
        girlsC.Add(1, "啊啊啊！这种被书籍所包围的感觉！");
        girlsC.Add(2, "就仿佛整个人置身于无垠的海洋！");
        girlsC.Add(3, "那么盛大，而蔓延开来的实感，啊！实在太幸福了！");
    }

    void GirlsTalk()//按顺序遍历女生对话并进行实例化
    {
        foreach (KeyValuePair<int, string> kvp in girlsC)
        {
            instantiation = this.CreatBox(a, boxA);
            Transform rBox = instantiation.transform.Find("dialogText");
            TextMeshProUGUI dialogtext = rBox.GetComponent<TextMeshProUGUI>();
            dialogtext.text = kvp.Value;
            girlsC.Remove(kvp.Key);
            time = 0;
            goto To;
        }
        To:
        return;
    }
    //女该讲话方面的代码结束
    GameObject CreatBox(Transform targetT, GameObject box)
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
