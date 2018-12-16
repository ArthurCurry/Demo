using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICtrl {
    public UIModel Model()
    {
        return this._model;
    }

    private UIModel _model = new UIModel();

    public UIView view
    {
        get
        {
            return this._view;
        }

        set
        {
            if (this._view == null)
                _view = value;
        }
    }

    private UIView _view; 

    public void OnCreat(Transform t,string name)
    {
        _view.viewDict()[name] = t;
    }

    public void OnShow(string name)
    {
        _model.modelDict()[name].SetActive(true);
    }

    public void OnHide(string name)
    {
        _model.modelDict()[name].SetActive(false);
    }

    public void OnClose(string name )
    {
        GameObject.Destroy(_model.modelDict()[name]);
    }
}
