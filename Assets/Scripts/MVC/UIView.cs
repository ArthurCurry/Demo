using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIView{
    private UICtrl ctrl;

    public UIView(UICtrl ctrl)
    {
        this.ctrl = ctrl;
    }
    
    public Dictionary<string, Transform> viewDict() //存储位置位置信息
    {
        return this._viewDict;
    }

    private Dictionary<string, Transform> _viewDict;

    public GameObject FindObject(string name)
    {
        return GameObject.Find(name);
    }

    public void InitData()//初始化数据
    {
        foreach (KeyValuePair <string ,GameObject> model in ctrl.Model().modelDict())
        {
            _viewDict.Add(model.Key, null);
        }
    }

    public void InitView(string name ,Canvas canv)
    {
        GameObject a = GameObject.Instantiate(ctrl.Model().modelDict()[name], ctrl.view.viewDict()[name]) as GameObject;
        a.transform.parent = canv.transform;
    }
}
