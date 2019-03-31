using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttcakMode2 : MonoBehaviour {

    private GameObject player;
    private PlayerMovements pm;
    private Rigidbody2D playerRB;
    private List<Vector3> positions=new List<Vector3>();

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag(HashID.PLAYER);
        pm = player.GetComponent<PlayerMovements>();
        playerRB = player.GetComponent<Rigidbody2D>();
	}
	

    void LateUpdate()
    {
            Judge();
    }

    void Judge()
    {
        //Debug.Log(Mathf.Abs((player.transform.position - this.transform.position).magnitude - HashID.unitLength));
        if ((player.transform.position - this.transform.position).magnitude < HashID.unitLength)
        {
            UpdateRange();
            for(int i=0;i<positions.Count;i++)
            {
                if ((player.transform.position - positions[i]).magnitude < 0.01f)
                    Attack();
            }
        }
    }

    void Attack()
    {
        pm.isDead = true;
    }

    void ShowAttackRange()
    {

    }

    void UpdateRange()
    {
        positions.Clear();
        positions.Add(this.transform.position);
        positions.Add(this.transform.position + Vector3.up * HashID.unitLength);
        positions.Add(this.transform.position + Vector3.down * HashID.unitLength);
        positions.Add(this.transform.position + Vector3.right * HashID.unitLength);
        positions.Add(this.transform.position + Vector3.left * HashID.unitLength);
    }
}
