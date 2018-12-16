using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIModel {
    public Dictionary<string, GameObject> modelDict()
    {
        return this._modelDict;
    }
    private Dictionary<string, GameObject> _modelDict;


    public void InitModel(GameObject a, string name)
    {
        name = a.name;
        _modelDict[name] = a;
    }

    public void OnHide(string name)
    {
        _modelDict[name].SetActive(false);
    }

    public void OnRemove(string name)
    {
        _modelDict.Remove(name);
    }
}
