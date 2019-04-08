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

        Collector w1 = new Collector(1, "报纸——9月21日", "据本报记者报道，A，B市的高考政策改革已经对本市的教育环境发起了极大的冲击。今天早上，有大量的学生以及家长自发地组成了团体，在市教育局面前举旗抗议，为了避免引发大规模冲突，已经被警察镇压。但截至目前为止，本市教育局尚未有任何表态。", "bag newspaper");

        Collector w2 = new Collector(2, "破旧的试卷", "自己的数学考试卷，分数只有可怜的40分", "2.bag test paper");

        Collector w3 = new Collector(3, "同学A的备忘录", "待会去图书馆借英文书\n问同学B借上课笔记\n中午去张老师办公室领卷子\n回家记得看老师推荐的网课", "3.bag beiwanglu");

        Collector w4 = new Collector(4, "学校通知", "经过学校教务处慎重考虑，从这一届开始，高三学生将不参加学校运动会，改为在教室里面自修两天", "4.bag tongzhi");

        Collector w5 = new Collector(5, "来自母亲的信", "新学期已经开始有一段时间了，高三是最繁忙的时光，一定要好好学习，起码要对得起自己。我还是那句话，不想跟着你的死鬼老爹的话就跟我来生活。不明白就他那副德行为什么你还跟着他。还有，这周六别忘了到我这里来一趟领生活费。", "bag letter");

        Collector w6 = new Collector(6, "自己写的小说——片段1", "因为父母工作原因，我来到了一个完全陌生的地方上高中，家安在不远处一个破旧的小区，整个地方充斥着一种衰败的氛围。到了晚上，夜漆黑漆黑的，只有楼下“小柒发廊”四个歪掉的字还在发出淡淡的光。", "6&7.bag xiaoshuo");

        Collector w7 = new Collector(7, "自己写的小说——片段2", "这天放学路过楼下的咋杂货店，看见一位20来岁的大姐姐抱着一大堆东西很不方便地走着。还是春寒料峭，她却穿着一件露肩吊带衫，裤子口袋里稀稀落落地放着几根烟。我主动地帮她抱起了部分货物，费力地在她后面走着，直到头不小心撞到她的肩，抬头一看，发廊两个字破破烂烂地快要掉下来。她轻轻地捋了捋我的马尾，从口袋里掏出了一根糖给我。", "6&7.bag xiaoshuo");

        Collector w8 = new Collector(8, "自己写的小说——片段3", "回到家后我跟爸爸妈妈说了这件事，她们却告诉我大姐姐不是什么好人，眼神中明显露出了鄙夷的目光，还让我千万别靠近她。然而，我回家的时候看到她就住在我的隔壁，却常常忍不住和她打招呼。", "6&7.bag xiaoshuo");

        Collector w9 = new Collector(9, "自己的书1", "一本自己的书，标题是“如何创造难忘的人物”", "9&10.shu");

        Collector w10 = new Collector(10, "自己的书2", "一本自己的书，标题是“契诃夫短篇小说精选”", "9&10.shu");

        Collector w11 = new Collector(11, "家访通知", "高三已经来临，为了深入了解各位同学的家庭状况，学校拟定于十一长假之后到各位同学的家中进行访问，还请做好准备。请将附件填写完整，按照班级上交。", "bag tongzhi");

        ItemList.Add(w1.Id, w1);

        ItemList.Add(w2.Id, w2);

        ItemList.Add(w3.Id, w3);

        ItemList.Add(w4.Id, w4);

        ItemList.Add(w5.Id, w5);

        ItemList.Add(w6.Id, w6);

        ItemList.Add(w7.Id, w7);

        ItemList.Add(w8.Id, w8);

        ItemList.Add(w9.Id, w9);

        ItemList.Add(w10.Id, w10);

        ItemList.Add(w11.Id, w11);


        GridItem.Add(w1.Name, w1);
        GridItem.Add(w2.Name, w2);
        GridItem.Add(w3.Name, w3);
        GridItem.Add(w4.Name, w4);
        GridItem.Add(w5.Name, w5);
        GridItem.Add(w6.Name, w6);
        GridItem.Add(w7.Name, w7);
        GridItem.Add(w8.Name, w8);
        GridItem.Add(w9.Name, w9);
        GridItem.Add(w10.Name, w10);
        GridItem.Add(w11.Name, w11);
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
