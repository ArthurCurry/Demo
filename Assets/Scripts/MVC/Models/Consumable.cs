using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : Item
{

    public Consumable(int id, string name, string description,
       string icon)
       : base(id, name, description, icon)
    {
        base.ItemType = "Consumable";
    }
}
