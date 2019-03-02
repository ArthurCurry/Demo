using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogCtrl : UICtrl {
    private DialogView dialogView;
    private DialogModel dialogModel;
    public GameObject dialogBox;

    public override void Init()
    {
        dialogModel = (DialogModel)UIManager.Instance.GetModel(PanelID.DialogPanel);
        dialogView = new DialogView();
        this.dialogBox = dialogModel.DialogBox; 
        dialogView.Init(this, dialogBox);
        View = dialogView;
        this.Model = dialogModel;
    }

    public void CreateDialog()
    {
        dialogView.Create();
    }

    public void SetDialogView(string sentence)
    {
        if (!dialogView.IsEmptyDialog())
            dialogView.SetDialogText(sentence);
    }

    public void DestroyDialog()
    {
        dialogView.DestoryDiaLog();
    }

    protected override void OnUpdate()
    {
        BuildManager.WhileCG();
    }

    protected override void OnClose()
    {
        
    }

    protected override void OnCreate()
    {
        
    }

    protected override void OnHide()
    {
        
    }

    protected override void OnShow()
    {
        
    }
}
