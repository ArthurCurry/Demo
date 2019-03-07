using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UICtrl {



    public abstract void Init();



    protected UIView _view; 
    protected UIModel _model;

    public UIView View{
        set{ _view = value;}
    }
    public UIModel Model{
        set{ _model = value;}
    }

    public void Update()
    {
        this._view.Update();
        this.OnUpdate();
        
    }
    public void Create()
    {
         this._view.Show();
         this.OnCreate();
    }
    public void Show()
    {
        this._view.Show();
        this.OnShow();
    }
    public void Hide()
    {
        this._view.Hide();
        this.OnHide();
    }
    public void Close()
    {

        this._view.Close();
        this._view = null;
        this.OnClose();
    }
    protected abstract void OnCreate();


    protected abstract void OnShow();

    protected abstract void OnHide();
    protected abstract void OnClose();
    protected abstract void OnUpdate();
}
