using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelManager {
    private Dictionary<string, UIModel> models = new Dictionary<string, UIModel>();


    public void RigisterModels()
    {
        //models.Add(PanelID.BagPanel,new BagModel());
        models.Add(PanelID.DialogPanel, new DialogModel());
        this.InitModels();
    }

    private void InitModels()
    {
        foreach(UIModel model in models.Values)
        {
            model.InitModel();
        }
    }
    public UIModel GetModel(string name)
    {
        return models[name];
    }

}
