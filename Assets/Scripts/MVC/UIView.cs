using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIView : MonoBehaviour {
    private UICtrl ctrl;

    public UIView(UICtrl ctrl)
    {
        this.ctrl = ctrl;
    }
    
    public Dictionary<string, Transform> viewDict()
    {
        return this._viewDict;
    }

    private Dictionary<string, Transform> _viewDict;

    public GameObject FindObject(string name)
    {
        return GameObject.Find(name);
    }

    public void InitView()
    {
        foreach (KeyValuePair <string ,GameObject> model in ctrl.Model().modelDict())
        {
            _viewDict.Add(model.Key, null);
        }
    }

    public void IsActive(string name ,Canvas canv)
    {
        GameObject a = Instantiate(ctrl.Model().modelDict()[name], ctrl.view.viewDict()[name]) as GameObject;
        a.transform.parent = canv.transform;
    }
}
