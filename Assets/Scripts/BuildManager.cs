using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager {
    
    public static void Init()
    {

    }

    public static void InitPlayer()
    {
        GameObject player = Resources.Load(HashID.playerPath) as GameObject;
        GameObject.Instantiate(player, player.transform.position, player.transform.rotation);
    }

    public static void InitMap()
    {

    }
}
