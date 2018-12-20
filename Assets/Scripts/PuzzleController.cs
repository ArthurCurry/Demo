using System.Collections;
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
        RaycastHit2D[] hits=Physics2D.LinecastAll(transform.position, worldPos, LayerMask.GetMask("Replaceable"));
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.transform != null)
            {
                transform.position = hit.transform.position;
                transform.parent = father.transform;
                transform.gameObject.layer = LayerMask.NameToLayer("Replaceable");
                transform.GetComponent<SpriteRenderer>().sortingOrder = 0;
                Destroy(hit.transform.gameObject);
                pickable = false;
            }
        }
        if (hits.Length<=0)
            Destroy(this.gameObject);
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
                RaycastHit2D[] hits = Physics2D.LinecastAll(childPos, childPos+(worldPos-childPos)*0.01f, LayerMask.GetMask("Replaceable"));
                foreach (RaycastHit2D hit in hits )
                {
                    if (hit.transform != null)
                    {
                        if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Replaceable"))
                            child.position = hit.transform.position;
                        targetToReplace.Add(hit.transform);
                    }
                }
            }
        }
        //Debug.Log(targetToReplace.Count+"  "+puzzleNum);
        if(targetToReplace.Count>=puzzleNum)
        {
            foreach(Transform child in children)
            {
                if (child.name != transform.name)
                {
                    child.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
                    child.gameObject.layer = LayerMask.NameToLayer("Replaceable");
                    child.GetComponent<SpriteRenderer>().sortingOrder = 0;
                    child.parent = GameObject.Find(fatherName).transform;
                }
            }
            foreach (Transform go in targetToReplace)
                Destroy(go.gameObject);
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
