using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LevelEditor:EditorWindow{
    public float unitSize;//地图单位长度
    private GameObject unit;
    private GameObject basePoint;
    private Vector2 relPos;
    private Object objectToPlace;
    private bool fold_1;//窗口第一处折叠
    private bool fold_2;//窗口第二处折叠
    private int  horizontal;//地图水平长度
    private int vertical;//地图竖直长度
    private static string[] options = { "up", "down", "left", "right" };//下拉框选项
    private static Vector3[] directions = { Vector3.up, Vector3.down, Vector3.left, Vector3.right };
    int index_1 = 0;//第一个下拉框目录,以下类推
    int index_2 = 0;
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


        index_1 = EditorGUILayout.Popup(index_1, options);
        if(GUILayout.Button("复制"))
        {
            Align(cloneTimes);
        }


        relPos = EditorGUILayout.Vector2Field("相对位置", relPos);
        if(GUILayout.Button("设置相对位置"))
        {
            SetRelativePosition(relPos.x, relPos.y, Selection.activeTransform.gameObject);
        }


        fold_1 = EditorGUILayout.Foldout(fold_1,"指定放置");
        if(fold_1)
        {
            EditorGUILayout.BeginHorizontal();
            objectToPlace = EditorGUILayout.ObjectField(objectToPlace,typeof(GameObject),true);
            index_2 = EditorGUILayout.Popup(index_2, new string[] { "重叠", "替换" });
            EditorGUILayout.EndHorizontal();
            if(GUILayout.Button("放置"))
            {
                SetPosition(Selection.transforms,index_2);
            }
        }


        fold_2 = EditorGUILayout.Foldout(fold_2, "创建地图");
        if(fold_2)
            CreatMap();


    }

    void Align(int times)//复制并排列
    {
        GameObject target = Selection.activeTransform.gameObject;
        //Debug.Log(target.name);
        for(int i=0;i<cloneTimes;i++)
        {
            GameObject clone = GameObject.Instantiate(target, target.transform.position + (i+1) * unitSize * directions[index_1], target.transform.rotation);
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

    void SetPosition(Transform[] targets,int index) //设置指定位置，方便设置敌人障碍等
    {
        Debug.Log(index);
        int num = 1;
        foreach (Transform target in targets)
        {
            GameObject clone = (GameObject)GameObject.Instantiate(objectToPlace, null);
            if(!clone.name.Contains("start")&&!clone.name.Contains("end"))
                clone.name = clone.name.Split('(')[0] + "_" + num;
            clone.transform.position = target.transform.position;
            if (clone.name.Contains("void"))
                clone.transform.parent = GameObject.Find("voids").transform;
            if (clone.name.Contains("obstacle"))
                clone.transform.parent = GameObject.Find("obstacles").transform;
            if(index==1)
            {
                DestroyImmediate(target.gameObject);
            }
            num++;
        }
    }

    void CreatMap()//创建行列地图
    {
        //EditorGUILayout.BeginHorizontal();
        horizontal= EditorGUILayout.IntField("横", horizontal);
        vertical = EditorGUILayout.IntField("竖", vertical);
        //EditorGUILayout.EndHorizontal();
        if(GUILayout.Button("创建格"))
        {
            List<GameObject> roads = new List<GameObject>();
            GameObject father = new GameObject(HashID.Map_Roads);
            GameObject temp = Resources.Load<GameObject>(HashID.mapUnit);
            GameObject origin = GameObject.Instantiate(temp, Vector3.zero, temp.transform.rotation);
            origin.transform.parent = father.transform;
            origin.name = "floor";
            //DestroyImmediate(temp);
            roads.Add(origin);
            for(int i =0;i<horizontal-1;i++)
            {
                GameObject go = GameObject.Instantiate(origin, origin.transform.position + (i + 1) * unitSize * Vector3.right, origin.transform.rotation);
                go.transform.parent = father.transform;
                go.name = origin.name + "_" + (i+1)
;               roads.Add(go);
            }
            foreach(GameObject unit in roads)
            {
                for(int i=0;i<vertical-1;i++)
                {
                    GameObject go = GameObject.Instantiate(unit, unit.transform.position + (i + 1) * unitSize * Vector3.up, unit.transform.rotation);
                    go.transform.parent = unit.transform.parent;
                    go.name = unit.name + "_" + (i + 1);
                }
            }
        }
    }
}
