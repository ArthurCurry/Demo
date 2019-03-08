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
        this.RegisterGrid();
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
        GameObject root = GameObject.Find("Canvas");
        Grids[0] = root.transform.Find("BagPanel").gameObject.transform.Find("Grid").gameObject.transform;
        Grids[1] = root.transform.Find("BagPanel").gameObject.transform.Find("Grid1").gameObject.transform;
        Grids[2] = root.transform.Find("BagPanel").gameObject.transform.Find("Grid2").gameObject.transform;
        Grids[3] = root.transform.Find("BagPanel").gameObject.transform.Find("Grid3").gameObject.transform;
        Grids[4] = root.transform.Find("BagPanel").gameObject.transform.Find("Grid4").gameObject.transform;
        Grids[5] = root.transform.Find("BagPanel").gameObject.transform.Find("Grid5").gameObject.transform;
        Grids[6] = root.transform.Find("BagPanel").gameObject.transform.Find("Grid6").gameObject.transform;
        Grids[7] = root.transform.Find("BagPanel").gameObject.transform.Find("Grid7").gameObject.transform;
        Grids[8] = root.transform.Find("BagPanel").gameObject.transform.Find("Grid8").gameObject.transform;
        Grids[9] = root.transform.Find("BagPanel").gameObject.transform.Find("Grid9").gameObject.transform;
        Grids[10] = root.transform.Find("BagPanel").gameObject.transform.Find("Grid10").gameObject.transform;
        Grids[11] = root.transform.Find("BagPanel").gameObject.transform.Find("Grid11").gameObject.transform;
        Grids[12] = root.transform.Find("BagPanel").gameObject.transform.Find("Grid12").gameObject.transform;
        Grids[13] = root.transform.Find("BagPanel").gameObject.transform.Find("Grid13").gameObject.transform;
        Grids[14] = root.transform.Find("BagPanel").gameObject.transform.Find("Grid14").gameObject.transform;
        Grids[15] = root.transform.Find("BagPanel").gameObject.transform.Find("Grid15").gameObject.transform;
        Grids[16] = root.transform.Find("BagPanel").gameObject.transform.Find("Grid16").gameObject.transform;
        Grids[17] = root.transform.Find("BagPanel").gameObject.transform.Find("Grid17").gameObject.transform;
        Grids[18] = root.transform.Find("BagPanel").gameObject.transform.Find("Grid18").gameObject.transform;
        Grids[19] = root.transform.Find("BagPanel").gameObject.transform.Find("Grid19").gameObject.transform;
    }
}
