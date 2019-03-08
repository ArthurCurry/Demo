using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ToSave{
    //public static string Path = "Assets/Resources/Prefabs/Save" + "/Save.prefab";
    
    //[MenuItem("GameObject/ToSave")]
	// Use this for initialization
    //存储场景
    public static void Save()
    {
        GameObject level = GameObject.FindWithTag("Level");
        string Path = "Assets/Resources/Prefabs/Save/" + level.name + ".prefab";
#if UNITY_EDITOR
        var prefab = PrefabUtility.CreateEmptyPrefab(Path);
        PrefabUtility.ReplacePrefab(level, prefab, ReplacePrefabOptions.ConnectToPrefab);
#endif
    }
}
