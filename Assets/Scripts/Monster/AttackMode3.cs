using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class AttackMode3 : MonoBehaviour {
    private List<Vector3> positions=new List<Vector3>();
    private LineRenderer line;
    private GameObject player;
    private Rigidbody2D rb;
    private PlayerMovements pm;
    private Vector3 faceDir;
    private Vector3 preDir;

	// Use this for initialization
	void Start () {
        faceDir = Vector2.up;
        preDir = faceDir;
        player = GameObject.FindWithTag(HashID.PLAYER);
        pm = player.GetComponent<PlayerMovements>();
        line = this.GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        DetectRange();
        if (faceDir != preDir)
            ChangeRange(faceDir);
        ShowAttackRange();
        if(Judge())
        {
            Attack();
        }
	}

    private void ShowAttackRange()
    {
        Debug.Log(faceDir);
        line.SetPositions(new Vector3[] { this.transform.position + faceDir * HashID.unitLength + Quaternion.Euler(0, 0, 90f) * faceDir*HashID.unitLength*1.5f, this.transform.position + faceDir * HashID.unitLength + Quaternion.Euler(0, 0, -90f) * faceDir * HashID.unitLength * 1.5f });
        line.startWidth = HashID.unitLength;
        line.endWidth = HashID.unitLength;
        /*line.startColor = new Color(1,0,0,0.5f);
        line.endColor = new Color(1, 0, 0, 0.5f);*/
    }

    private void ChangeRange(Vector3 forward)
    {
        positions.Clear();
        positions.Add(this.transform.position);
        positions.Add(this.transform.position + forward * HashID.unitLength);
        positions.Add(this.transform.position + forward * HashID.unitLength + Quaternion.Euler(0, 0, 90f) * forward);
        positions.Add(this.transform.position + forward * HashID.unitLength + Quaternion.Euler(0, 0, -90f) * forward);
        preDir = forward;
    }

    private void DetectRange()
    {
        if (rb.velocity != Vector2.zero)
        {
            faceDir = rb.velocity.normalized;
        }
        else if (pm.isDead)
            faceDir = Vector2.up;
    }

    private bool Judge()
    {
        foreach(Vector3 pos in positions)
        {
            if ((player.transform.position - pos).magnitude < 0.1f)
                return true;
        }
        return false;
    }

    private void Attack()
    {
        pm.isDead = true;
    }
}
