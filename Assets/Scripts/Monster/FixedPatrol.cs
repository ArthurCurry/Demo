using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedPatrol : MonoBehaviour {


    public float moveSpeed=2f;
    public bool isMoving;
    public bool targetArrived;
    private Dictionary<KeyCode, Vector3> directions = new Dictionary<KeyCode, Vector3>();
    [SerializeField]
    private Transform targetFloor;


    public List<Vector3> route;//运动路径
    private GameObject player;
    private PlayerMovements pm;
    private Transform target;
    private Vector2 direction;//运动方向
    private Vector3 playerPrePos;
    private int index;//路径点目录
    private Rigidbody2D playerRB;
    private Rigidbody2D rb;

    private Vector3 prePos;
    private float totalDis;

    // Use this for initialization
    void Start () {
        index = 0;
        rb = GetComponent<Rigidbody2D>();
        prePos = this.transform.position;
        player = GameObject.FindWithTag(HashID.PLAYER);
        playerPrePos = player.transform.position;
        playerRB = player.GetComponent<Rigidbody2D>();
        pm = player.GetComponent<PlayerMovements>();
        Init();
    }
	
    void Update()
    {
        Move();
        prePos = this.transform.position;
    }

	// Update is called once per frame
	void LateUpdate () {
        //Debug.Log(route.Count);
        //Debug.Log((transform.position - route[route.Count - 1].position).magnitude);
        /*if (route.Count > 1)
        {
            if (playerRB.velocity!=Vector2.zero)
            {
                direction = route[index] - transform.position;
                rb.velocity = direction.normalized * pm.moveSpeed;
            }
            else
            {
                
                rb.velocity = Vector2.zero;
            }
        }*/
        //Debug.Log(index);
        //MoveTo(route[index]);
        if ((transform.position - route[index]).magnitude < 0.1f && player.transform.position != playerPrePos)
            index += 1;
        if ((transform.position - route[route.Count - 1]).magnitude < 0.1f)
        {
                DestroyImmediate(this.gameObject);
        }
        playerPrePos = player.transform.position;
    }


    public void Init()
    {
        isMoving = false;
        targetArrived = true;
        targetFloor = this.transform;

        rb = transform.GetComponent<Rigidbody2D>();
        LoadDirection();
    }

    void Move()//移动
    {
        if (Input.anyKey && !isMoving)
        {
            KeyCode key = KeyCode.None;
            /*Event e = Event.current;
            if (e.isKey)
                key = e.keyCode;*/
            foreach (KeyCode code in directions.Keys)
            {
                if (Input.GetKey(code))
                {
                    key = code;
                    break;
                }
            }
            if (directions.ContainsKey(key))
            {
                if (Detect(key) != this.transform)
                {
                     ;
                }
                targetFloor = Detect(key);
            }
        }
        MoveTowards(targetFloor);
    }

    public void MoveTowards(Transform target)//控制向特定方向移动
    {
        //Debug.Log(target);
        if (transform.position != target.position)
        {
            Vector2 pos = target.position;
            targetArrived = false;
            rb.velocity = (target.position - transform.position).normalized * moveSpeed;
            isMoving = true;
            //ap.PlayClipAtPoint(ap.AddAudioClip("Audio/走路2"), Camera.main.transform.position, 1f);
            //Debug.Log(2);
            StopAt(targetFloor);
        }
        else
        {
            targetFloor = this.transform;
            rb.velocity = Vector2.zero;
            targetArrived = true;
            //MonsterManager.UpdateMonsters(float.PositiveInfinity);
            isMoving = false;
        }

    }


    void LoadDirection()
    {
        directions.Add(KeyCode.W, Vector3.up);
        directions.Add(KeyCode.S, Vector3.down);
        directions.Add(KeyCode.A, Vector3.left);
        directions.Add(KeyCode.D, Vector3.right);
    }

    Transform Detect(KeyCode key)
    {
        Vector3 direction = (route[index]-this.transform.position).normalized;
        RaycastHit2D[] hits = Physics2D.LinecastAll(transform.position, transform.position + direction * 1.28f, LayerMask.GetMask(HashID.Layer_Replaceable, "Unwalkable"));
        if (hits.Length > 1 && hits[1].transform.tag == "Map")
        {
            if (hits[hits.Length - 1].transform.name.Contains("ice"))
            {
                RaycastHit2D[] ices = new RaycastHit2D[20];
                int i = Physics2D.LinecastNonAlloc(hits[hits.Length - 1].transform.position, hits[hits.Length - 1].transform.position + direction * HashID.unitLength
                    * 20f, ices);
                for (int n = 1; n < i; n++)
                {
                    if (!ices[n].transform.name.Contains("ice"))
                    {
                        if (!ices[n].transform.tag.Equals("Map"))
                            return ices[n - 1].transform;
                        return ices[n].transform;
                    }
                    if (n == i - 1)
                        return ices[n].transform;
                }
            }
            return hits[1].transform;
        }
        else
            return this.transform;
    }



    void StopAt(Transform target)
    {
        if ((transform.position - target.position).magnitude < 0.01f)
        {
            //Debug.Log(1);
            transform.position = target.transform.position;
            rb.velocity = Vector2.zero;
        }
    }
}
