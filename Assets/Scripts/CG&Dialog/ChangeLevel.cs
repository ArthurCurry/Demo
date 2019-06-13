using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeLevel : MonoBehaviour {

    private Transform player;
    private AudioPlay ap;

    private XmlReader instance;
    private Dialog dialog;
    private string s;
    private int x;
    private int count;
    private bool toPause;
    private bool onlyOne;

    // Use this for initialization
    void Start () {
        ap = new AudioPlay();
        instance = new XmlReader();
        instance.ReadXML("Resources/剧情对话.xml");
        player = GameObject.FindWithTag(HashID.PLAYER).transform;
        toPause = false;
        onlyOne = false;
        x = 0;
    }
	
	// Update is called once per frame
	void Update () {
        Judge();
        ShowDialog();
    }

    void Judge()
    {
        if(this.transform.position  == player.position)
        {
            if (BuildManager.Level == 1)
            {
                if (!onlyOne)
                {
                    if (GameObject.Find("Level_1(Clone)")) // Debug会话框不会消失。
                    {
                        GameObject level = GameObject.Find("Level_1(Clone)");
                        level.GetComponent<PatrolTalk>()._Destroy();
                        level.GetComponent<PatrolTalk>().enabled = false;
                    }
                    InitAttribution("到达终点");
                    InitDialog();
                    toPause = true;
                    onlyOne = true;
                }
            }
            else if (BuildManager.Level == 4)
            {
                if (!onlyOne)
                {
                    InitAttribution("第四关结束");
                    InitDialog();
                    toPause = true;
                    onlyOne = true;
                }
            }
            else if (BuildManager.Level == 5)
            {
                if (!onlyOne)
                {
                    InitAttribution("第五关结束");
                    InitDialog();
                    toPause = true;
                    onlyOne = true;
                }
            }
            else if(BuildManager .Level == 6)
            {
                if (!onlyOne)
                {
                    InitAttribution("第六关结束");
                    InitDialog();
                    toPause = true;
                    onlyOne = true;
                }
            }
            else
            {
                BuildManager.Judge();
                BuildManager.Destroy_All();
                GameObject root = GameObject.Find("Canvas");
                root.GetComponent<ChangeEffect>().M_State = ChangeEffect.State.FadeIn;
                root.GetComponent<ChangeEffect>().game = ChangeEffect.o_status.start;
            }
        }
    }

    void InitDialog()
    {
        dialog = new Dialog();
        dialog.ID = dialog.Split(instance.GetXML(s, 0), 0);
        dialog.showDialog(dialog.JudgeD(dialog.ID));
        dialog.setDialogText(dialog.Split(instance.GetXML(s, 0), 1));
    }

    void InitAttribution(string n) // 赋予触发剧情的属性
    {
        x = 1;
        s = n;
        count = instance.getCount(s, 0);
        instance.SetIndex(0);
    }

    void ShowDialog()
    {
        if (toPause)
        {
            if (x < count)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    if (s.Equals("第四关结束") && x == 2)
                    {
                        ap.PlayClipAtPoint(ap.AddAudioClip("Audio/群人大笑"), Camera.main.transform.position, 1f);
                    }
                    else if(s.Equals("第六关结束") && x == 4)
                    {
                        ap.PlayClipAtPoint(ap.AddAudioClip("Audio/呕吐"), Camera.main.transform.position, 1f);
                    }
                    else if (s.Equals("第六关结束") && x == 11)
                    {
                        ap.PlayClipAtPoint(ap.AddAudioClip("Audio/传送"), Camera.main.transform.position, 1f);
                    }
                        instance.SetIndex(x);
                    if (!JudgeD(dialog.ID))
                    {
                        dialog.DestoryDiaLog();
                        dialog.ID = dialog.Split(instance.GetXML(s, 0), 0);
                        dialog.showDialog(dialog.JudgeD(dialog.ID));
                    }
                    dialog.setDialogText(dialog.Split(instance.GetXML(s, 0), 1));
                    x = x + 1;
                }
            }
            else
            {
                toPause = false;
                x = 0;

            }
        }
        else if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))&& this.transform.position == player.position)
        {
            if (dialog != null)
            {
                dialog.DestoryDiaLog();
            }
            if (BuildManager.Level == 4)
            {
                BuildManager.InitCG("CG8", "旁白");
            }
            else if(BuildManager.Level == 6)
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
            }
            else
            {
                BuildManager.Judge();
                BuildManager.Destroy_All();
                GameObject root = GameObject.Find("Canvas");
                root.GetComponent<ChangeEffect>().M_State = ChangeEffect.State.FadeIn;
                root.GetComponent<ChangeEffect>().game = ChangeEffect.o_status.start;
            }
        }
    }

    public bool JudgeD(string name)  //判断对话框的ID
    {
        if (name.Equals(dialog.Split(instance.GetXML(name, 0), 0)))
        {
            return true;
        }
        else return false;
    }
}
