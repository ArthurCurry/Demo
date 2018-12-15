using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portals : MonoBehaviour {



    private List<GameObject> portals;
    private GameObject player;


    public int number;//传送门的数量
                      // Use this for initialization

    private void Awake()
    {
        portals = new List<GameObject> ();
        player = GameObject.Find("Player");
    }

    void Start () {
        portals.Add(GameObject.Find("Portal0"));
        portals.Add(GameObject.Find("Portal1"));
        
	}
	
	// Update is called once per frame
	void Update () {
        number = portals.Count;
        Judge();
	}

    private void Judge()//判断传送以及进行传送
    {
        foreach( GameObject a in portals )
        {
            
            if (player.transform.position == a.transform.position && !player.GetComponent<PlayerMovements>().isMoving)
            {
                
                int n = portals.IndexOf(a);
                if (n == number - 1)
                {
                    
                    GameObject next = portals[0];
                    float y = next.transform.position.y+ 0.626f;
                    Vector3 x = new Vector3(next.transform.position.x, y, next.transform.position.z);
                    player.transform.position = x;
                    Debug.Log(a.name);
                }
                else
                {

                    GameObject next = portals[n + 1];
                    float y = next.transform.position.y + 0.626f;
                    Vector3 x = new Vector3(next.transform.position.x, y, next.transform.position.z);
                    player.transform.position = x;
                    Debug.Log(player.transform.position);
                    Debug.Log(a.name);
                }
                
            }
            else continue;
        }
    }
}
