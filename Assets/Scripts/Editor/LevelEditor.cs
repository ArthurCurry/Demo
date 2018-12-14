using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LevelEditor:EditorWindow{
    private float unitSize;
    int cloneTimes;

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
        GUILayout.TextArea(unitSize.ToString());
        cloneTimes = EditorGUILayout.IntField("克隆次数",cloneTimes);

    }

    void Align()//排列
    {

    }

    void GetData()
    {
        GameObject unit = GameObject.FindWithTag("Map");
        if (unit == null)
            Debug.Log("未找到指定物体");
        else
        {
            //Debug.Log(unit.name);
            unitSize = unit.GetComponent<BoxCollider2D>().size.x;
        }
    }
}
