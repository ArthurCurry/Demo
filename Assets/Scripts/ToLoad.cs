using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ToLoad {

    [MenuItem ("GameObject/ToLoad")]


    public static void Load()
    {
        string Path = "Prefabs/Save/" + "Level_1-1(Clone)";
        GameObject go = Resources.Load<GameObject>(Path);
        GameObject.Instantiate(go);

    }
}
