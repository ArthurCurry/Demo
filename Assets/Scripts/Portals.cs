using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portals : MonoBehaviour {

    private GameObject player;

    public GameObject other;//对应另一个传送口


    void Start () {
        player = GameObject.FindWithTag(HashID.PLAYER);
	}
	
	// Update is called once per frame
	void Update () {
        Judge();
	}

    private void Judge()//传送
    {
        if ((player.transform.position == this.transform.position)&&Input.GetButtonDown("Jump"))
        {
            //Debug.Log(other.transform.position);
            StartCoroutine("Move");
        }
    }

    IEnumerator Move()
    {
        yield return new WaitForSeconds(0.5f);
        player.transform.position = other.transform.position;
        Camera.main.transform.position = player.transform.position;
    }
}
