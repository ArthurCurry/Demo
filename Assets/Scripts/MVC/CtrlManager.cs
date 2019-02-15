using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlManager{
    private Dictionary<string, UICtrl> ctrls = new Dictionary<string, UICtrl>();

    public void RigisterCtrls()
    {
        
        //ctrls.Add(PanelID.BagPanel,new BagCtrl());
        ctrls.Add(PanelID.DialogPanel, new DialogCtrl());

        this.InitCtrls();
    }
    public void UpdateCtrls()
    {
        foreach(UICtrl ctrl in ctrls.Values)
        {
            ctrl.Update();
        }
    }
    private void InitCtrls()
    {
        foreach(UICtrl ctrl in ctrls.Values)
        {
            ctrl.Init();
        }
    }

    public UICtrl GetCtrl(string name)
    {
        UICtrl ctrl = ctrls[name];
        return ctrl;
    }

    public T GetT <T>(string name) where T:UICtrl
    {
        return (T)ctrls[name];
    }
}
