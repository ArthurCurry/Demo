using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager {
    
    public static void Init()
    {
        InitPlayer();
        InitMap("Level_1-1");
    }

    public static void InitPlayer()//初始化玩家
    {
        if (GameObject.FindWithTag(HashID.PLAYER) != null)
            return;
        GameObject player = Resources.Load<GameObject>(HashID.playerPath);
        GameObject playerInstance=GameObject.Instantiate(player);
        //playerInstance.GetComponent<PlayerMovements>().InitData();
    }

    public static void InitMap(string levelName)//初始化地图
    {
        if (GameObject.FindWithTag("Level") != null)
            return;
        GameObject level = Resources.Load<GameObject>(HashID.levelPath+levelName);
        GameObject.Instantiate(level);
        PlayerMovements.InitData();
    }

    
}
