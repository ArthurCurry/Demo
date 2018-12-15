using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LevelEditor:EditorWindow{
    public float unitSize;
    private GameObject unit;
    private GameObject basePoint;
    private static string[] options = { "up", "down", "left", "right" };//下拉框选项
    private static Vector3[] directions = { Vector3.up, Vector3.down, Vector3.left, Vector3.right };
    int index = 0;//下拉框目录
    int cloneTimes;//克隆次数
    //static Dictionary<int, Vector3> directionsPair;//下拉框选项和方向的键值对

    [MenuItem("Level/LevelEditor")]
    static void InitWindow()
    {
        LevelEditor levelWindow = (LevelEditor)EditorWindow.GetWindow(typeof(LevelEditor), false, null);
        /*for(int i=0;i<options.Length;i++)
        {
            directionsPair.Add(i, directions[i]);
        }*/
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
        GUILayout.TextArea(unitSize.ToString());
        cloneTimes = EditorGUILayout.IntField("克隆次数",cloneTimes);
        GUILayout.Label("克隆方向");
        index = EditorGUILayout.Popup(index, options);
        if(GUILayout.Button("复制"))
        {
            Align(cloneTimes);
        }
    }

    void Align(int times)//复制并排列
    {
        GameObject target = Selection.activeTransform.gameObject;
        //Debug.Log(target.name);
        for(int i=0;i<cloneTimes;i++)
        {
            GameObject clone = GameObject.Instantiate(target, target.transform.position + (i+1) * unitSize * directions[index], target.transform.rotation);
        }
    }

    void GetData()//刷新数据
    {
        unit = GameObject.FindWithTag("Map");
        if (unit == null)
            Debug.Log("未找到指定物体");
        else
        {
            //Debug.Log(unit.name);
            unitSize = unit.GetComponent<BoxCollider2D>().size.x;
        }
    }

    void Place()//将选定物体安排至指定位置
    {

    }

    void SetBasePoint()//设置某个地图单元为编辑器的原点
    {
        basePoint = Selection.activeTransform.gameObject;
    }
}
