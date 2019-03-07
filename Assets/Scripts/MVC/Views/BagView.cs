using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BagView : UIView
{

    public GameObject IntroductionPanel;
    public GameObject BagPanel;
    public GameObject ToolTip;
    public Text OutlineText;
    public Text ContentText;
    public Text PanelText;
    public GameObject ItemImage;
    public Transform[] Grids = new Transform[20];

    protected override void BinObject()//绑定物体
    {
        GameObject root = GameObject.Find("Canvas");
        IntroductionPanel = root.transform.Find("IntroductionPanel").gameObject;
        ToolTip = root.transform.Find("Tooltip").gameObject;
        OutlineText = ToolTip.GetComponent<Text>();
        ContentText = ToolTip.transform.Find("Content").GetComponent<Text>();
        PanelText = IntroductionPanel.transform.Find("Text").GetComponent<Text>();
    }

    protected override void OnShow()//打开时
    {

    }
    protected override void OnHide()//隐藏时
    {

    }

    protected override void OnUpdate()
    {

    }

    public void OpenInroductionPanel()
    {
        IntroductionPanel.SetActive(true);
    }

    public void OpenBagPanel()
    {
        panelObject.SetActive(true);
    }

    public void UpdateTooltip(string text)
    {
        OutlineText.text = text;
        ContentText.text = text;
    }

    public void UpdateImage(GameObject a, Sprite s)
    {
        ItemImage = a;
        ItemImage.GetComponentInChildren<SpriteRenderer>().sprite = s;
    }

    public void UpdatePanel(string text)
    {
        PanelText.text = text;
    }

    public Transform GetEmptyGrid()
    {
        for (int i = 0; i < Grids.Length; i++)
        {
            if (Grids[i].childCount == 0)
                return Grids[i];
        }
        return null;
    }

    public void RegisterGrid()
    {
        Grids[0] = GameObject.Find("Grid").transform;
        Grids[1] = GameObject.Find("Grid1").transform;
        Grids[2] = GameObject.Find("Grid2").transform;
        Grids[3] = GameObject.Find("Grid3").transform;
        Grids[4] = GameObject.Find("Grid4").transform;
        Grids[5] = GameObject.Find("Grid5").transform;
        Grids[6] = GameObject.Find("Grid6").transform;
        Grids[7] = GameObject.Find("Grid7").transform;
        Grids[8] = GameObject.Find("Grid8").transform;
        Grids[9] = GameObject.Find("Grid9").transform;
        Grids[10] = GameObject.Find("Grid10").transform;
        Grids[11] = GameObject.Find("Grid11").transform;
        Grids[12] = GameObject.Find("Grid12").transform;
        Grids[13] = GameObject.Find("Grid13").transform;
        Grids[14] = GameObject.Find("Grid14").transform;
        Grids[15] = GameObject.Find("Grid15").transform;
        Grids[16] = GameObject.Find("Grid16").transform;
        Grids[17] = GameObject.Find("Grid17").transform;
        Grids[18] = GameObject.Find("Grid18").transform;
        Grids[19] = GameObject.Find("Grid19").transform;

    }
}
