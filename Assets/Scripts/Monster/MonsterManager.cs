using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager {
    static PlayerMovements player;


    public static void  InitMonster()
    {
        player = GameObject.FindWithTag(HashID.PLAYER).GetComponent<PlayerMovements>();
    }


    public static void UpdateMonsters(float length)
    {
        GameObject[] monsters = GameObject.FindGameObjectsWithTag(HashID.ENEMY);
        foreach (GameObject monster in monsters)
        {
            if (monster.name.Contains(HashID.ENEMY_EYE))
            {
                //EyesMonster em = monster.GetComponent<EyesMonster>();
                //em.Move();
                monster.GetComponent<Rigidbody2D>().angularVelocity = 90 / (length / player.moveSpeed);
                if (length != float.PositiveInfinity)
                    monster.GetComponent<EyesMonster>().inPosition = false;
                else if (length == float.PositiveInfinity)
                {
                    monster.GetComponent<EyesMonster>().inPosition = true;
                }
            }
        }
    }
}
