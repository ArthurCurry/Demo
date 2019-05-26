using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    private Vector3 dis;
    private GameObject player;
    private PlayerMovements playerMov;
    public float dampTime;
    public Transform[] mapEdges;
    private Transform mapLowerlf;//地图左下
    private Transform mapUpperrt;//地图右上
    private float width;//屏幕实际长度和宽度
    private float height;
    private bool lockX;
    private bool lockY;
    private Vector3 targetPos;
    private Vector3 currentV;
    [SerializeField]
    private bool bgInView;


    // Use this for initialization
    void Start () {
        Init();
        //DetectEdges();
	}
	
    public void Init()
    {
        player = GameObject.FindWithTag("Player");
        Vector3 position = player.transform.position;
        position.z = transform.position.z;
        transform.position = position;
        playerMov = player.GetComponent<PlayerMovements>();
        dis = Camera.main.transform.position - player.transform.position;
        DetectEdges();
    }

	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKey(KeyCode.Mouse1))
            FollowMouse();
        else
            FollowPlayer();
        if (mapEdges.Length > 1 && player.transform.position.y < mapUpperrt.transform.position.y)
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, mapLowerlf.position.x + (width - HashID.unitLength) / 2, mapUpperrt.position.x - (width  - HashID.unitLength)/2),
            Mathf.Clamp(transform.position.y, mapLowerlf.position.y + (height - HashID.unitLength) / 2, mapUpperrt.position.y - (height - HashID.unitLength) / 2), transform.position.z);
    }

    void LateUpdate()
    {

    }

    void FollowPlayer()//色相头跟随
    {
        currentV=Vector3.zero;
        targetPos = player.transform.position;
        if (PlayerOutOfView() && !bgInView)
            dampTime = 0.06f;
        else
            dampTime = 0.15f;
        //bgInView =BackgroundInView();
        targetPos.z += dis.z;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref currentV, dampTime,10f);
        
    }

    public void MoveCameraTo(GameObject target)  // 镜头移动
    {
        player = target;
        Vector3 position = player.transform.position;
        position.z = transform.position.z;
        transform.position = position;
        dis = Camera.main.transform.position - player.transform.position;
        DetectEdges();
    }

    bool PlayerOutOfView()//判断角色是否即将越出视野
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(player.transform.position);
        if (screenPos.x <= 0.1 * Screen.width || screenPos.x > 0.9 * Screen.width || screenPos.y > 0.9 * Screen.height || screenPos.y < 0.1 * Screen.height)
            return true;
        return false;
    }

    private bool BackgroundInView()//避免背景色出现在屏幕中
    {
        if((transform.position.x-mapLowerlf.position.x)<=(width-HashID.unitLength)/2)
        {
            Vector3 temp = this.transform.position;
            temp.x = mapLowerlf.position.x + (width - HashID.unitLength) / 2;
            this.transform.position = temp;
            targetPos.x = transform.position.x;
            return true;
        }
        if((transform.position.y - mapLowerlf.position.y) <= (height - HashID.unitLength) / 2)
        {
            Vector3 temp = this.transform.position;
            temp.y = mapLowerlf.position.y + (height - HashID.unitLength) / 2;
            this.transform.position = temp;
            targetPos.y = transform.position.y;
            return true;
        }
        if((mapUpperrt.position.x-transform.position.x)<= (width - HashID.unitLength) / 2)
        {
            Vector3 temp = this.transform.position;
            temp.x = mapUpperrt.position.x - (width - HashID.unitLength) / 2;
            this.transform.position = temp;
            targetPos.x = transform.position.x;
            return true;
        }
        if ((mapUpperrt.position.y-transform.position.y)<=(height - HashID.unitLength) / 2)
        {
            Vector3 temp = this.transform.position;
            temp.y = mapUpperrt.position.y - (height - HashID.unitLength) / 2;
            this.transform.position = temp;
            targetPos.y = transform.position.y;
            return true;
        }
        return false;
    }

    public void DetectEdges()
    {
        mapEdges = GameObject.Find(HashID.Edges).GetComponentsInChildren<Transform>();
        foreach(Transform edge in mapEdges)
        {
            if(!edge.name.Equals(HashID.Edges))
            {
                //Debug.Log(edge.name);
                if (edge.name.Contains("left"))
                    mapLowerlf = edge;
                else if (edge.name.Contains("right"))
                    mapUpperrt = edge;
            }
        }
        Vector3 cornerPos = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, Mathf.Abs(Camera.main.transform.position.z)));
        float leftBorder = Camera.main.transform.position.x - (cornerPos.x - Camera.main.transform.position.x);
        float rightBorder = cornerPos.x;
        float topBorder = cornerPos.y;
        float downBorder = Camera.main.transform.position.y - (cornerPos.y - Camera.main.transform.position.y);
        width = rightBorder - leftBorder;
        height = topBorder - downBorder;
        //Debug.Log(width + "  " + height);
    }

    private void FollowMouse()
    {
        Vector3 pos = Input.mousePosition;
        pos.z = 10;
        targetPos = Camera.main.ScreenToWorldPoint(pos);
        targetPos.z = transform.position.z;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref currentV, dampTime, 10f);
    }
}
