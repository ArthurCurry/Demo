using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour {
    private GameObject player;
    private List<Vector3> pickPosition=new List<Vector3>();//捡拾位置
    [SerializeField]
    private int condition;
    [SerializeField]
    private int ID;
    [SerializeField]
    private bool hidden;
    [SerializeField]
    private int[] number;
    private bool picked;
    private UIManager um;
    public int curCondition;

    private bool toPause;
    private bool status;
    private XmlReader instance;
    private Dialog dialog;
    private string s;
    private int x;
    private int count;

    private AudioPlay ap;
    [SerializeField]
    private Vector2 position;
    private AudioClip audioClip;

    // Use this for initialization
    void Start() {
        instance = new XmlReader();
        ap = new AudioPlay();
        //audioClip = ap.AddAudioClip("Audio/开门.mp3");
        instance.ReadXML("Resources/剧情对话.xml");
        hidden = true;
        picked = false;
        status = false;
        um = GameObject.Find("Canvas").GetComponent<UIManager>();
        InitData();
    }
	
	// Update is called once per frame
	void Update () {
        if (curCondition == condition && hidden)
        {
            Appear();
            hidden = false;
        }
        if(!hidden)
        {
            if (Input.GetKey(KeyCode.E))
            {
                BePicked();
            }
        }
        ShowDialog();
	}

    private void BePicked()
    {
        foreach(Vector3 pos in pickPosition)
        {
            if ((player.transform.position - pos).magnitude < 0.5f)
            {
                if (!picked)
                {
                    if(number.Length > 1 )
                        PuzzleSupply.UpdatePuzzle(number[0], number[1], number[2]);
                    um._cm.GetT<BagCtrl>("BagPanel").StoreItem(ID);
                }
                picked = true;
                Debug.Log("picked");
            }
        }
        if(picked && !status)
        {
            InitAttribution("捡起钥匙");
            InitDialog();
            toPause = true;
            status = true;
        }
    }

    private void InitData()
    {
        player = GameObject.FindWithTag(HashID.PLAYER);
        pickPosition.Add(transform.position + Vector3.up * HashID.unitLength);
        pickPosition.Add(transform.position + Vector3.left * HashID.unitLength);
        pickPosition.Add(transform.position + Vector3.down * HashID.unitLength);
        pickPosition.Add(transform.position + Vector3.right * HashID.unitLength);
        pickPosition.Add(transform.position);
    }

    private void Appear()
    {
        this.GetComponent<BoxCollider2D>().enabled = true;
        this.GetComponent<SpriteRenderer>().enabled = true;
    }

    void ShowDialog()
    {
        if (toPause)
        {
            if (x < count)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Q) || Input.GetMouseButtonDown(0))
                {
                    instance.SetIndex(x);
                    dialog.setDialogText(instance.GetXML(s, 0));
                    x = x + 1;
                }
            }
            else
            {
                toPause = false;
                x = 0;

            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Q) || Input.GetMouseButtonDown(0))
        {
            dialog.DestoryDiaLog();
            //ap.PlayClipAtPoint(audioClip, position);
        }
    }

    void InitDialog()
    {
        dialog = new Dialog();
        dialog.showDialog();
        dialog.setDialogText(instance.GetXML(s, 0));
    }

    void InitAttribution(string n) // 赋予触发剧情的属性
    {
        x = 1;
        s = n;
        count = instance.getCount(s, 0);
        instance.SetIndex(0);
    }
}
