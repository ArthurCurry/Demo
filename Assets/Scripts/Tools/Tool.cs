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
    private Vector3 position;
    private AudioClip audioClip;
    private bool toDone;

    // Use this for initialization
    void Start() {
        instance = new XmlReader();
        ap = new AudioPlay();
        position = Camera.main.transform.position;
        audioClip = ap.AddAudioClip("Audio/上课铃");
        toDone = false;
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
                    um._cm.GetT<BagCtrl>("Bag").StoreItem(ID);
                    ap.PlayClipAtPoint(ap.AddAudioClip("Audio/捡起东西"), Camera.main.transform.position, 1f);
                }
                picked = true;
                Debug.Log("picked");
            }
        }
        if (picked && !status && this.name == "key")
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
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    instance.SetIndex(x);
                    if (!JudgeD(dialog.ID))
                    {
                        dialog.DestoryDiaLog();
                        dialog.ID = dialog.Split(instance.GetXML(name, 0), 0);
                        dialog.showDialog(dialog.JudgeD(dialog.ID));
                    }
                    dialog.setDialogText(dialog.Split(instance.GetXML(name, 0), 1));
                    x = x + 1;
                }
            }
            else
            {
                toPause = false;
                toDone = true;
                x = 0;

            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (dialog != null)
            {
                dialog.DestoryDiaLog();
            }
            if (toDone && this.name == "key")
            {
                toDone = false;
                ap.PlayClipAtPoint(audioClip, position);
            }
        }
    }

    void InitDialog()
    {
        dialog = new Dialog();
        dialog.ID = dialog.Split(instance.GetXML(name, 0), 0);
        dialog.showDialog(dialog.JudgeD(dialog.ID));
        dialog.setDialogText(dialog.Split(instance.GetXML(name, 0), 1));
    }

    public bool JudgeD(string name)  //判断对话框的ID
    {
        if (name.Equals(dialog.Split(instance.GetXML(name, 0), 0)))
        {
            return true;
        }
        else return false;
    }

    void InitAttribution(string n) // 赋予触发剧情的属性
    {
        x = 1;
        s = n;
        count = instance.getCount(s, 0);
        instance.SetIndex(0);
    }
}
