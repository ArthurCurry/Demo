using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : Item
{
    public Collector(int id, string name, string description,
       string icon)
       : base(id, name, description, icon)
    {
        base.ItemType = "Collection";
    }
}
