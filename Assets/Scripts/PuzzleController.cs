<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour {
    Vector3 worldPos;//鼠标转为世界坐标
    public bool pickable;//拼图能否被捡起
    private GameObject father;//
    public string fatherName;

    void Awake () {
        pickable = true;
	}

    void Start()
    {
        father = GameObject.Find(fatherName);
    }
	
	// Update is called once per frame
	void Update () {
        if(pickable)
            DragAndLoose();
	}

    void DragAndLoose()//拖拽和释放拼图的行为
    {
        worldPos= Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = 0;
        if (Input.GetMouseButton(0))
        {
            transform.position = worldPos;
            Scroll();
        }
        if(Input.GetMouseButtonUp(0))
        {
            if (transform.childCount > 0)
                Replace(transform.childCount);
            else
                Replace();
        }
    }

    void Replace()//替换单个地图单位
    {
        Vector3 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 worldPos = new Vector2(temp.x, temp.y);
        RaycastHit2D hit=Physics2D.Linecast(transform.position, worldPos, LayerMask.GetMask("Replaceable"));
        if (hit.transform != null)
        {
            transform.position = hit.transform.position;
            transform.parent = father.transform;
            transform.gameObject.layer = LayerMask.NameToLayer("Replaceable");
            Destroy(hit.transform.gameObject);
            pickable = false;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Replace(int puzzleNum)//替换多个地图单位
    {
        Vector3 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 worldPos = new Vector2(temp.x, temp.y);
        Transform[] children = transform.GetComponentsInChildren<Transform>();
        List<Transform> targetToReplace = new List<Transform>();
        foreach(Transform child in children)
        {
            Vector2 childPos = new Vector2(child.position.x, child.position.y);
            if (child.name != transform.name)
            {
                RaycastHit2D hit = Physics2D.Linecast(childPos, childPos+(worldPos-childPos)*0.1f, LayerMask.GetMask("Replaceable"));
                if (hit.transform != null)
                {
                    targetToReplace.Add(hit.transform);
                }
            }
        }
        //Debug.Log(targetToReplace.Count);
        if(targetToReplace.Count==puzzleNum)
        {
            int index = 0;
            foreach(Transform child in children)
            {
                if (child.name != transform.name)
                {
                    child.position = targetToReplace[index].position;
                    child.gameObject.layer = LayerMask.NameToLayer("Replaceable");
                    child.parent = GameObject.Find(fatherName).transform;
                    Destroy(targetToReplace[index].gameObject);
                    index++;
                }
            }
            Destroy(this.gameObject);
            return;
        }
        Destroy(this.gameObject);
    }

    void Scroll()//拼图旋转
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
            transform.Rotate(0, 0, 90);
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
            transform.Rotate(0, 0, -90);
    }

}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour {
    Vector3 worldPos;//鼠标转为世界坐标
    public bool pickable;//拼图能否被捡起
    private GameObject father;//
    public string fatherName;

    void Awake () {
        pickable = true;
	}

    void Start()
    {
        father = GameObject.Find(fatherName);
    }
	
	// Update is called once per frame
	void Update () {
        if(pickable)
            DragAndLoose();
	}

    void DragAndLoose()//拖拽和释放拼图的行为
    {
        worldPos= Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = 0;
        if (Input.GetMouseButton(0))
        {
            transform.position = worldPos;
            Scroll();
        }
        if(Input.GetMouseButtonUp(0))
        {
            if (transform.childCount > 0)
                Replace(transform.childCount);
            else
                Replace();
        }
    }

    void Replace()//替换单个地图单位
    {
        Vector3 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 worldPos = new Vector2(temp.x, temp.y);
        RaycastHit2D hit=Physics2D.Linecast(transform.position, worldPos, LayerMask.GetMask("Replaceable"));
        if (hit.transform != null)
        {
            transform.position = hit.transform.position;
            transform.parent = father.transform;
            transform.gameObject.layer = LayerMask.NameToLayer("Replaceable");
            Destroy(hit.transform.gameObject);
            pickable = false;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Replace(int puzzleNum)//替换多个地图单位
    {
        Vector3 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 worldPos = new Vector2(temp.x, temp.y);
        Transform[] children = transform.GetComponentsInChildren<Transform>();
        List<Transform> targetToReplace = new List<Transform>();
        foreach(Transform child in children)
        {
            Vector2 childPos = new Vector2(child.position.x, child.position.y);
            if (child.name != transform.name)
            {
                RaycastHit2D hit = Physics2D.Linecast(childPos, childPos+(worldPos-childPos)*0.1f, LayerMask.GetMask("Replaceable"));
                if (hit.transform != null)
                {
                    targetToReplace.Add(hit.transform);
                }
            }
        }
        //Debug.Log(targetToReplace.Count);
        if(targetToReplace.Count==puzzleNum)
        {
            int index = 0;
            foreach(Transform child in children)
            {
                if (child.name != transform.name)
                {
                    child.position = targetToReplace[index].position;
                    child.gameObject.layer = LayerMask.NameToLayer("Replaceable");
                    child.parent = GameObject.Find(fatherName).transform;
                    Destroy(targetToReplace[index].gameObject);
                    index++;
                }
            }
            Destroy(this.gameObject);
            return;
        }
        Destroy(this.gameObject);
    }

    void Scroll()//拼图旋转
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
            transform.Rotate(0, 0, 90);
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
            transform.Rotate(0, 0, -90);
    }

}
>>>>>>> 2104896dafa688d0f62fa8b89666425aae67c5b8
