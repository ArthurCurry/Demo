using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    private Vector3 dis;
    private GameObject player;
    private PlayerMovements playerMov;
    public float dampTime;
    public List<GameObject> mapEdges;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        Vector3 position = player.transform.position;
        position.z = transform.position.z;
        transform.position = position;
        playerMov = player.GetComponent<PlayerMovements>();
        dis = Camera.main.transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        FollowPlayer();
	}

    void FollowPlayer()//色相头跟随
    {
        Vector3 currentV=Vector3.zero;
        Vector3 targetPos = player.transform.position;
        targetPos.z += dis.z;
        if (PlayerOutOfView())
            dampTime = 0.1f;
        else
            dampTime = 0.2f;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref currentV, dampTime,10f);
    }

    bool PlayerOutOfView()//判断角色是否即将越出视野
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(player.transform.position);
        if (screenPos.x <= 0.1 * Screen.width || screenPos.x > 0.9 * Screen.width || screenPos.y > 0.9 * Screen.height || screenPos.y < 0.1 * Screen.height)
            return true;
        return false;
    }

    private void BackgroundInView()//避免背景色出现在屏幕中
    {

    }
}
