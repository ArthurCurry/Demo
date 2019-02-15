using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIView{
    protected GameObject panelObject;
    protected UICtrl _ctrl;

    public void Init(UICtrl ctrl ,GameObject obj)
    {
        this._ctrl = ctrl;
        this.panelObject = obj;
        this.BinObject();
    }

    public void Show()
    {
        panelObject.SetActive(true);
        this.OnShow();
    }

    public void Hide()
    {
        panelObject.SetActive(false);
        this.OnHide();
    }

    public void Update()
    {
        this.OnUpdate();
    }

    public void Close()
    {
        GameObject.Destroy(panelObject);
    }

    protected abstract void OnShow();

    protected abstract void OnHide();

    protected abstract void OnUpdate();

    protected abstract void BinObject();

}
