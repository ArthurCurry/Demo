using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlManager{
    private Dictionary<string, UICtrl> ctrls;

    public void Init()
    {
        ctrls["BagCtrl"] = new UICtrl();
    }

    public T GetT<T>(string name) where T:UICtrl 
    {
        return (T)ctrls[name];
    }
}
