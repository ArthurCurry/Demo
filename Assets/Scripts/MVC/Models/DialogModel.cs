using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogModel : UIModel {
    private GameObject dialogBox;
    public GameObject DialogBox
    {
        get
        {
            return dialogBox;
        }
    }

    public override void InitModel()
    {
        dialogBox = Resources.Load<GameObject>("Prefabs/DialogBox");
    }

}
