using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagModel : UIModel
{

    public static Dictionary<int, Item> ItemList;
    private static Dictionary<string, Item> GridItem = new Dictionary<string, Item>();

    public override void InitModel()
    {
        Load();
    }

    private void Load()
    {
        ItemList = new Dictionary<int, Item>();

        Collector w1 = new Collector(0, "钥匙", "一个不知道是哪儿的钥匙。", "bag key");

        Collector w2 = new Collector(1, "信封", "一个信封，里面有一封信。", "bag letter");

        Collector w3 = new Collector(2, "报纸", "一份被翻阅得破旧的报纸。", "bag newspaper");

        Collector w4 = new Collector(3, "试卷", "一张不及格的试卷，上面满是红×。", "bag test paper");

        Consumable c1 = new Consumable(4, "红瓶", "加血", "blood bottle");

        Consumable c2 = new Consumable(5, "蓝瓶", "加蓝", "mana bottle");

        Debug.Log(w1.Name);

        ItemList.Add(w1.Id, w1);

        ItemList.Add(w2.Id, w2);

        ItemList.Add(w3.Id, w3);

        ItemList.Add(w4.Id, w4);

        ItemList.Add(c1.Id, c1);

        ItemList.Add(c2.Id, c2);

        GridItem.Add(w1.Name, w1);
        GridItem.Add(w2.Name, w2);
        GridItem.Add(w3.Name, w3);
        GridItem.Add(w4.Name, w4);
        GridItem.Add(c1.Name, c1);
        GridItem.Add(c2.Name, c2);
    }

    public static void StoreItem(string name, Item item)
    {
        if (GridItem.ContainsKey(name))
            DeleteItem(name);

        GridItem.Add(name, item);
    }
    public static Item GetItem(string name)
    {
        if (GridItem.ContainsKey(name))
        {
            return GridItem[name];
        }
        else
            return null;
    }
    public static void DeleteItem(string name)
    {
        if (GridItem.ContainsKey(name))
            GridItem.Remove(name);
    }


}
