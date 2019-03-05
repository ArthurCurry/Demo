using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ToSave{
    //public static string Path = "Assets/Resources/Prefabs/Save" + "/Save.prefab";
    
    [MenuItem("GameObject/ToSave")]
	// Use this for initialization
    //存储场景
    public static void Save()
    {
        GameObject level = GameObject.FindWithTag("Level");
        string Path = "Assets/Resources/Prefabs/Save/" + level.name + ".prefab";
        var prefab = PrefabUtility.CreateEmptyPrefab(Path);
        PrefabUtility.ReplacePrefab(level, prefab, ReplacePrefabOptions.ConnectToPrefab);
    }
}
