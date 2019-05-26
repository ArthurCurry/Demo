using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeLevel : MonoBehaviour {

    private Transform player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag(HashID.PLAYER).transform;       
    }
	
	// Update is called once per frame
	void Update () {
        Judge();
	}

    void Judge()
    {
        if(this.transform.position  == player.position)
        {
            if (BuildManager.Level == 1)
            {
                if (GameObject.Find("Level_1(Clone)"))
                {
                    GameObject level = GameObject.Find("Level_1(Clone)");
                    level.GetComponent<PatrolTalk>()._Destroy();
                    level.GetComponent<PatrolTalk>().enabled = false;
                }
            }
            BuildManager.Judge();
            BuildManager.Destroy_All();           
            GameObject root = GameObject.Find("Canvas");
            root.GetComponent<ChangeEffect>().M_State = ChangeEffect.State.FadeIn;
            root.GetComponent<ChangeEffect>().game = ChangeEffect.o_status.start;
            //if (BuildManager.Level != 3)
            //{
            //    BuildManager.Need = true;
            //    BuildManager.InitAttribute();
            //    BuildManager.Init();
            //   Camera.main.GetComponent<CameraController>().Init();
            //}
            //BuildManager.Name = "异步敌人";
        }
    }
}
