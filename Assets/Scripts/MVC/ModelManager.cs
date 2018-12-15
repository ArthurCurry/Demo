using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelManager {
    private Dictionary<string, UIModel> models;

    public void Init()
    {
        models["BagModel"] = new UIModel();
    }

    public T GetT<T>(string name)where T:UIModel
    {
        return (T)models[name];
    }
}
