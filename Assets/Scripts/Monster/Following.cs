using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Following : MonoBehaviour{

 
    [SerializeField]
    private float mode;
    [SerializeField]
    private Transform targetFloor;
    private Rigidbody2D playerRB;
    private PlayerMovements pm;
    private GameObject player;
    private Vector3 playerPrePos;


    private Dictionary<KeyCode, Vector3> directions = new Dictionary<KeyCode, Vector3>();
    private Vector3 prePos;
    private Rigidbody2D rb;
    public float moveSpeed;
    public bool isMoving;
    public bool targetArrived;

    [SerializeField]
    private Transform upperright;
    [SerializeField]
    private Transform lowerleft;

    private Vector3 urPos;
    private Vector3 llPos;


    void Start()
    {
        urPos = upperright.position;
        llPos = lowerleft.position;

        prePos = this.transform.position;
        player = GameObject.FindWithTag(HashID.PLAYER);
        playerPrePos = player.transform.position;
        playerRB = player.GetComponent<Rigidbody2D>();
        pm = player.GetComponent<PlayerMovements>();
        Init();
    }

    public Vector3 URPos
    {
        get
        {
            return urPos;
        }
    }

    public Vector3 LLPos
    {
        get
        {
            return llPos;
        }
    }

    public void Init()
    {
        isMoving = false;
        targetArrived = true;
        targetFloor = this.transform;

        rb = transform.GetComponent<Rigidbody2D>();
        LoadDirection();
    }
    // Update is called once per frame
    void Update()
    {
        moveSpeed = playerRB.velocity.magnitude * IsPlayerInRange();
    }

    void LateUpdate()
    {
        //moveSpeed = playerRB.velocity.magnitude;

        //Debug.Log(targetFloor.name);
        //Debug.Log(this.transform.position);
        //Debug.Log(rb.velocity);
        //if(IsPlayerInRange())
        
        Move();
        prePos = this.transform.position;
        playerPrePos = player.transform.position;
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
        if(!IsOutOfRange(targetFloor))
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
        Vector3 direction = directions[key]*mode;
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

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(0.1f);
    }


    bool IsOutOfRange(Transform target)
    {
        Vector3 targetFloor = target.position;
        if ((targetFloor.x > urPos.x || targetFloor.x <llPos.x) || (targetFloor.y > urPos.y || targetFloor.y < llPos.y))
            return true;
        return false;
    }

    float IsPlayerInRange()
    {
        Vector3 playerPos = player.transform.position;
        if ((playerPos.x > urPos.x || playerPos.x < llPos.x) || (playerPos.y > urPos.y || playerPos.y < llPos.y))
            return 0f;
        return 1f;
    }
   
}
