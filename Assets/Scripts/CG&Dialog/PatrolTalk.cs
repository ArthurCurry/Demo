using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatrolTalk : MonoBehaviour {
    private Canvas canvas; 
    private GameObject box;
    private GameObject player;
    private Vector2 target;

    private Dictionary<Transform, string> dialog; //查找视图目标节点下的目标child并存进数组
    private string[] patrolsC;
    private Dictionary <GameObject ,Transform> instantiations;
    private List<GameObject> patrols;

    private string levelName;
    private int count;
    private int index;
    private float time;
    // Use this for initialization
    void Start () {
        patrolsC = new string[] {
            "李老师讲课不仅无聊，而且还经常点同学上去做题，真是烦透了。",
            "这次小考排名又比上次进步了一点，加油！",
            "我明明这么努力，怎么考试永远都考不好……",
            "听说邻省的十一中有个女孩跳楼了，也不知道是真的还是假的……",
            "一看见老李那张脸就烦，真是的，一天到晚板着张脸。",
            "困死了，一到高三上学时间又提早了。",
            "今天晚上游戏有新活动要开，我得早点回去开荒。",
            "好烦啊，钱又不够用了。"
        };
        dialog = new Dictionary<Transform, string> ();
        instantiations = new Dictionary<GameObject, Transform>();
        patrols = new List<GameObject>();
        box = Resources.Load<GameObject>("Prefabs/MonsterBox");
        player = GameObject.FindWithTag(HashID.PLAYER);
        canvas = GameObject.Find(HashID.CANVAS).GetComponent<Canvas>();
        time = 0;
        index = 0;
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time >= 4)
        {
            _Destroy();
            ToDestroy();
            time = 0;
        }
        if(dialog.Count == 0 && instantiations.Count == 0)
        {
            this.AddInto("portals");
        }
        else
        {
            PTalk();   
        }
        Reset();
    }

    void AddInto(string targetName)
    {
        dialog = new Dictionary<Transform, string>();
        GameObject level = GameObject.FindWithTag(HashID.LEVEL);
        levelName = level.name;
        count = level.transform.Find(targetName).childCount;
        for (int i = 0; i < count; i++)
        {
            if (Judge(level.transform.Find(targetName).GetChild(i).name) != null && dialog.Count <= 2)
            {
                if ((level.transform.Find(targetName).GetChild(i).transform.position - player.transform.position).magnitude <= 5)
                    dialog.Add(level.transform.Find(targetName).GetChild(i).transform, _Switch(Random.Range(0, 5)));
            }
        }
    }

    string Judge(string name)
    {
        if (name.Contains("fixedroute"))
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
            case 0: return patrolsC[0];
            case 1: return patrolsC[1];
            case 2: return patrolsC[2];
            case 3: return patrolsC[3];
            case 4: return patrolsC[4];
            default: return patrolsC[0];
        }
    }

    void PTalk()
    {
        foreach (KeyValuePair<Transform, string> kvp in dialog)
        {
            if (kvp.Key == null)
            {
                dialog.Remove(kvp.Key);
            }
            else
            {
                GameObject instantiation = this.CreatBox(kvp.Key);
                instantiations.Add(instantiation , kvp.Key);
                patrols.Add(instantiation);
                Transform rBox = instantiation.transform.Find("dialogText");
                Text dialogtext = rBox.GetComponent<Text>();
                dialogtext.text = kvp.Value;
                dialog.Remove(kvp.Key);              
            }
        }
    }

    GameObject CreatBox(Transform targetT)
    {
        GameObject a = Instantiate(box, canvas.transform);
        this.Translate(targetT);
        a.GetComponent<RectTransform>().position = target;
        return a;
    }

    private void Reset()
    {
        foreach(KeyValuePair<GameObject ,Transform> kvp in instantiations)
        {
            if (kvp.Value == null || kvp.Key == null)
            {
                Destroy(kvp.Key);
                instantiations.Remove(kvp.Key);
            }
            else
            {
                this.Translate(kvp.Value);
                kvp.Key.GetComponent<RectTransform>().position = target;
            }
        }
    }

    private void _Destroy()
    {
        foreach (KeyValuePair<GameObject, Transform> kvp in instantiations)
        {
            Destroy(kvp.Key);
            instantiations.Remove(kvp.Key);
        }
    }

    private void ToDestroy()
    {
        for(int i=0;i<patrols.Count; i++)
        {
            if (patrols[i] != null)
                Destroy(patrols[1]);
        }
    }

    private void Translate(Transform a)
    {
        float y = a.position.y + 1;
        target = new Vector2(a.position.x, y);
    }
}
