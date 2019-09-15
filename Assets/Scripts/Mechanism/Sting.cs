using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sting : MonoBehaviour {

    [SerializeField]
    private bool ready;
    private bool statusLastFrame;//上一帧状态
    private PlayerMovements pm;
    private Animator animator;
    private BoxCollider2D box;

    private Sprite stingOn;
    private Sprite stingOff;

    [SerializeField]
    private List<Transform> triggerPoses;
    

	// Use this for initialization
	void Start () {
        pm = GameObject.FindWithTag(HashID.PLAYER).GetComponent<PlayerMovements>();
        statusLastFrame = ready;
        animator = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
        Switch();
	}
	
	// Update is called once per frame
	void Update () {
        if (Judge())
            ready = !ready;
        if (ready!=statusLastFrame)
            Switch();
        statusLastFrame = ready;
	}

    void OnTriggerEnter2D()
    {
        pm.isDead = true;
    }

    void Switch()
    {
        ControlAnimation();
        box.enabled = ready;
//Debug.Log("switched");
    }

    void ControlAnimation()
    {
        if (ready)
            animator.SetTrigger("rise");
        else
            animator.SetTrigger("fall");
        
    }

    bool Judge()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Vector3 playerPos = pm.transform.position;
            for(int i=0;i<triggerPoses.Count;i++)
            {
                if ((playerPos - triggerPoses[i].position).magnitude <= (HashID.unitLength-0.02f))
                    return true;
                continue;
            }
        }
        return false;
    }

    
}
