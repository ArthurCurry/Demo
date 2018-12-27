using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeStatue : MonoBehaviour {

    private Vector3[] positions;//判定位置
    private GameObject player;
    private bool isRotating;//是否在转动
    private Vector3 targetRotation;
    [SerializeField]
    private float rotateSpeed;
    [SerializeField]
    private GameObject eyeball;

	// Use this for initialization
	void Start () {
        positions = new Vector3[] { transform.position + HashID.unitLength * transform.right, transform.position + HashID.unitLength*transform.up
        ,transform.position+HashID.unitLength*-transform.right,transform.position+HashID.unitLength*transform.up};
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
        Debug.Log(targetRotation);
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
        while (target.transform.position.z != targetRotation.z)
        {
            Debug.Log("rotating");
            target.transform.Rotate(new Vector3(0, 0,  Time.deltaTime * rotateSpeed));
            isRotating = true;
            yield return null;
        }
        isRotating = false;
        StopAllCoroutines();
    }
}
