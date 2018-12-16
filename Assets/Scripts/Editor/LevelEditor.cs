using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LevelEditor:EditorWindow{
    public float unitSize;
    private GameObject unit;
    private GameObject basePoint;
    private Vector2 relPos;
    private Object objectToPlace;
    private bool fold;
    private static string[] options = { "up", "down", "left", "right" };//下拉框选项
    private static Vector3[] directions = { Vector3.up, Vector3.down, Vector3.left, Vector3.right };
    int index = 0;//下拉框目录
    int cloneTimes;//克隆次数

    [MenuItem("Level/LevelEditor")]
    static void InitWindow()
    {
        LevelEditor levelWindow = (LevelEditor)EditorWindow.GetWindow(typeof(LevelEditor), false, null);
        
    }

    void Update()
    {

    }

    void OnGUI()
    {
        if(GUILayout.Button("初始化数据"))
        {
            GetData();
        }
        if(GUILayout.Button("设置原点"))
        {
            SetBasePoint(Selection.activeTransform.gameObject);
        }
        GUILayout.TextArea(unitSize.ToString());
        cloneTimes = EditorGUILayout.IntField("克隆次数",cloneTimes);
        GUILayout.Label("克隆方向");
        index = EditorGUILayout.Popup(index, options);
        if(GUILayout.Button("复制"))
        {
            Align(cloneTimes);
        }
        relPos = EditorGUILayout.Vector2Field("相对位置", relPos);
        if(GUILayout.Button("设置相对位置"))
        {
            SetRelativePosition(relPos.x, relPos.y, Selection.activeTransform.gameObject);
        }
        fold = EditorGUILayout.Foldout(fold,"指定放置");
        if(fold)
        {
            objectToPlace = EditorGUILayout.ObjectField(objectToPlace,typeof(GameObject),true);
            if(GUILayout.Button("放置"))
            {
                SetPosition(Selection.activeTransform.gameObject);
            }
        }
    }

    void Align(int times)//复制并排列
    {
        GameObject target = Selection.activeTransform.gameObject;
        //Debug.Log(target.name);
        for(int i=0;i<cloneTimes;i++)
        {
            GameObject clone = GameObject.Instantiate(target, target.transform.position + (i+1) * unitSize * directions[index], target.transform.rotation);
            clone.name = basePoint.name + "_" + i;
            clone.transform.parent = unit.transform.parent;
        }
    }

    void GetData()//刷新数据
    {
        unit = GameObject.FindWithTag("Map");
        SetBasePoint(unit);
        if (unit == null)
            Debug.Log("未找到指定物体");
        else
        {
            //Debug.Log(unit.name);
            unitSize = unit.GetComponent<BoxCollider2D>().size.x;
        }
    }


    void SetBasePoint(GameObject go)//设置某个地图单元为编辑器的原点
    {
        basePoint = go;
    }

    void SetRelativePosition(float x,float y,GameObject selected)//和上面方法配合，设置相对位置
    {
        Vector3 relativePos = new Vector3(x * unitSize, y * unitSize, 0);
        selected.transform.position = basePoint.transform.position + relativePos;
    }

    void SetPosition(GameObject target)//设置指定位置，方便设置敌人障碍等
    {
        GameObject clone=(GameObject)GameObject.Instantiate(objectToPlace,null);
        clone.transform.position = target.transform.position;
    }
}
