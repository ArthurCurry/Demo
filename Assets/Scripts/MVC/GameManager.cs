﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager {
    private ModelManager modelManager;
    private CtrlManager ctrlManager;
    

    public void OpenPanel(string name)
    {
        
    }



    public void ShowPanel(string name)
    {

    }

    public void HidePanel(string name)
    {

    }

    public void ClosePanel(string name, bool isDestroyed)
    {

    }
    // Use this for initialization
    void Start () {
        Init();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Init()//初始化
    {
        BuildManager.Init();
    }
}
