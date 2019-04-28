using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OldMTalk : MonoBehaviour {

    private Canvas canvas;
    private GameObject box;
    private GameObject player;
    private GameObject instantiation;

    [SerializeField]
    private Transform a;

    private Dictionary<Transform, string> dialog; //查找视图目标节点下的目标child并存进数组
    private string[] comments;

    private int status;
    private float time;

    private bool done;
    public bool stop;
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
        done = true;
        instantiation = null;
        stop = false;
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        //Debug.Log(time);
        if (time >= 3 && done)
        {
            GirlsTalk();
            time = 0;
        }
        if (time >= 2.5 && instantiation != null)
        {
            Destroy(instantiation);
            instantiation = null;
            done = true;
        }
        if (instantiation != null)
        {
            this.Reset();
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

    void GirlsTalk()
    {
        if (done)
        {
            if (instantiation == null)
            {
                instantiation = this.CreatBox(a);
            }
            Transform rBox = instantiation.transform.Find("dialogText");
            TextMeshProUGUI dialogtext = rBox.GetComponent<TextMeshProUGUI>();
            dialogtext.text = comments[status];
            time = 0;
            done = false;
        }
        Reflash();
        return;
    }

    GameObject CreatBox(Transform targetT)
    {
        GameObject a = Instantiate(box, canvas.transform);
        a.GetComponent<RectTransform>().position = targetT.position;
        return a;
    }

    private void Reset()
    {
        instantiation.GetComponent<RectTransform>().position = a.position;
        if (stop)
        {
            time = 0;
            Destroy(instantiation);
            this.enabled = false;
        }
    }
}
