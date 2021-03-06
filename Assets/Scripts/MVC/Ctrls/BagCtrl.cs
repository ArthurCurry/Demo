﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.EventSystems;
using System;

public class BagCtrl : UICtrl
{
    bool BeRegister = false;
    bool IsOpened = false;
    bool IntroIsOpened = false;
    BagView bagview = new BagView();

    private AudioPlay ap;

    public override void Init()
    {
        ap = new AudioPlay();
        GameObject root = GameObject.Find("Canvas");
        GameObject bag = root.transform.Find("Bag").gameObject;
        bagview.Init(this, root.transform.Find("Bag").gameObject);
        this.View = bagview;
    }
    protected override void OnCreate()
    {

    }
    protected override void OnShow()//在背包打开时才能打开Introduction
    {
        //条件判断是否点击图片
        if(Input.GetMouseButtonDown(0))
        bagview.OpenInroductionPanel();
    }
    protected override void OnHide()
    {

    }
    protected override void OnClose()
    {

    }
    protected override void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.B) && IsOpened == false)
        {
            //Debug.Log("open");
            //Debug.Log(IsOpened);
            ap.PlayClipAtPoint(ap.AddAudioClip("Audio/打开背包"), Camera.main.transform.position, 1f);
            UIManager.Instance.ShowPanel("Bag");
            IsOpened = true;
            //Debug.Log(IsOpened);
        }
        else if (Input.GetKeyDown(KeyCode.B) && IsOpened == true)
        {
            ap.PlayClipAtPoint(ap.AddAudioClip("Audio/打开背包"), Camera.main.transform.position, 1f);
            Debug.Log("Close");            
            UIManager.Instance.HidePanel("Bag");
           // UIManager.Instance.HidePanel("IntroductionPanel");
            IsOpened = false;
        }
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(GameObject.Find
            ("Canvas").transform as RectTransform, Input.mousePosition, Camera.main, out position);
        if (IntroIsOpened)
        {
            Show();
            SetLocalPosition(position);
        }

        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    int index = UnityEngine.Random.Range(0, 6);
        //    StoreItem(index);
        //}
    }

    public void ToolTipShow()
    {
        bagview.ToolTip.SetActive(true);
    }

    public void ToolTipHide()
    {

        bagview.ToolTip.SetActive(false);
    }

    public void SetLocalPosition(Vector2 position)
    {

        bagview.ToolTip.transform.localPosition = position;
    }

    public void StoreItem(int itemId)
    {
        if (!BagModel.ItemList.ContainsKey(itemId))
            return;

        Transform emptyGrid = bagview.GetEmptyGrid();
        if (emptyGrid == null)
        {
            Debug.LogWarning("背包已满!!");
            return;
        }
        Item temp = BagModel.ItemList[itemId];
        GameObject itemPrefab = Resources.Load<GameObject>("Prefabs/UI/Item");
        Sprite s = Resources.Load<Sprite>("Materials/map/round 1/bag item/" + temp.Icon);
        bagview.UpdateImage(itemPrefab, s);
        GameObject itemGo = GameObject.Instantiate(itemPrefab);
        itemGo.transform.SetParent(emptyGrid);
        itemGo.transform.localPosition = Vector3.zero;
        itemGo.transform.localScale = Vector3.one;
        BagModel.StoreItem(emptyGrid.name, temp);
    }


    private string GetTooltipText(Item item)
    {
        if (item == null)
            return "";
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("{0}", item.Name);
        return sb.ToString();
    }

    private string GetPanelText(Item item)
    {
        if (item == null)
            return "";
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("<color=black><size=16>描述:{0}</size></color>"
           , item.Description);
        return sb.ToString();
    }

    public void GridUI_OnEnter(Transform gridTransform)
    {

        //Debug.Log(gridTransform.name);
        Item item = BagModel.GetItem(gridTransform.name);
        if (item == null)
            return;
        //Debug.Log(1);
        string text = GetTooltipText(item);
        bagview.UpdateTooltip(text);
        string text1 = GetPanelText(item);
        bagview.UpdatePanel(text1);
        IntroIsOpened = true;
        ToolTipShow();
    }

    public void GridUI_OnExit()
    {
        //Debug.Log(2);
        IntroIsOpened = false;
        ToolTipHide();
    }
}
