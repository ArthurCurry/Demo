using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeStatue : MonoBehaviour {

    private Vector3[] positions;//判定位置
    private GameObject player;
    private bool isRotating;//是否在转动
    private Vector3 targetRotation;
    [SerializeField]
    private float rotateTime;
    [SerializeField]
    private GameObject eyeball;
    [SerializeField]
    private float targetRot;//得到道具所需要的旋转位置
    [SerializeField]
    private Tool targetTool;//机关对应的道具，如果有的话
    public bool inposition;

	// Use this for initialization
	void Start () {
        inposition = false;
        positions = new Vector3[] { transform.position + HashID.unitLength * Vector3.right, transform.position + HashID.unitLength*Vector3.up
        ,transform.position+HashID.unitLength*Vector3.left,transform.position+HashID.unitLength*Vector3.down};
        player = GameObject.FindWithTag(HashID.PLAYER);
        isRotating = false;
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.E)&&!isRotating)
        {
;
            if (Judge())
            {
                Vector3 angle = new Vector3(eyeball.transform.rotation.x, eyeball.transform.rotation.y, eyeball.transform.rotation.z + 90f);
                targetRotation = angle;
                StartCoroutine(RotateEye(eyeball));
            }
        }
        //Debug.Log(Mathf.Abs(eyeball.transform.rotation.eulerAngles.z - targetRot));
        if (Mathf.Abs(eyeball.transform.rotation.eulerAngles.z - targetRot) < 0.1f && !inposition)
        {
            inposition = true;
        }
        if (inposition)
        {
            targetTool.curCondition += 1;
            this.GetComponent<EyeStatue>().enabled = false;
        }
        //Debug.Log(targetRotation);
	}

    private bool Judge()
    {
        return MechManager.JudgePosition(positions,player);
    }

    public void MechRotate(GameObject target, Vector3 targetAngle, float rotateSpeed)
    {
        if (target.transform.rotation.eulerAngles.z != targetAngle.z)
        {
           
        }
        if(Mathf.Abs(target.transform.position.z-targetAngle.z)<0.01f)
        {
            Debug.Log(eyeball.transform.rotation.eulerAngles.z + "," + targetRotation.z);
            Debug.Log("stop");
            targetAngle = target.transform.rotation.eulerAngles;
            isRotating = false;
            eyeball.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        }
        else
        {
            target.GetComponent<Rigidbody2D>().angularVelocity = rotateSpeed;
            isRotating = true;
        }
    }

    IEnumerator RotateEye(GameObject target)
    {
        Debug.Log("start");
        int i = 0;
        float count = Mathf.Abs(90f) / 180f * rotateTime;
        float clip = 90f / count;
        while(i<(int)count)
        {
            target.transform.Rotate(new Vector3(0, 0, clip));
            i++;
            yield return null;
        }
        isRotating = false;
        StopAllCoroutines();
    }
}
