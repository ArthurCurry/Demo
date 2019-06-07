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

        Collector w1 = new Collector(11, "报纸——9月21日", "据本报记者报道，A，B市的高考政策改革已经对本市的教育环境发起了极大的冲击。今天早上，有大量的学生以及家长自发地组成了团体，在市教育局面前举旗抗议，为了避免引发大规模冲突，已经被警察镇压。但截至目前为止，本市教育局尚未有任何表态。", "bag newspaper");

        Collector w2 = new Collector(12, "报纸——9月21日", "根据进一步采访，记者了解到广大的学生及家长都对本省持续已久的应试教育感到不满，而临省的改革正好成了这次联合抗议的导火线。据悉，以第一中学为首的本省教育联盟也向教育局提出了改革建议。", "bag newspaper");

        Collector w3 = new Collector(13, "遗失的钥匙", "早餐店老板遗失的钥匙", "bag key");

        Collector w4 = new Collector(21, "破旧的试卷", "自己的数学考试卷，分数只有可怜的40分", "2.bag test paper");

        Collector w5 = new Collector(22, "同学A的备忘录", "待会去图书馆借英文书\n问同学B借上课笔记\n中午去张老师办公室领卷子\n回家记得看老师推荐的网课", "3.bag beiwanglu");

        Collector w6 = new Collector(23, "学校通知", "经过学校教务处慎重考虑，从这一届开始，高三学生将不参加学校运动会，改为在教室里面自修两天", "4.bag tongzhi");

        Collector w7 = new Collector(24, "隔壁班某同学A的奖状", "热烈祝贺高二（三）班的晨晨同学在第十七届校园诗词朗诵比赛中取得一等奖，特发此证，以资鼓励。", "4.bag tongzhi");//美术素材还没好

        Collector w8 = new Collector(25, "自己写的小说——片段1", "因为父母工作原因，我来到了一个完全陌生的地方上高中，家安在不远处一个破旧的小区，整个地方充斥着一种衰败的氛围。到了晚上，夜漆黑漆黑的，只有楼下“小柒发廊”四个歪掉的字还在发出淡淡的光。", "6&7.bag xiaoshuo");

        Collector w9 = new Collector(31, "一摞厚厚的已用的游戏点卡", "铁索已断，山河将倾，新战争资料片上线！现充值100元得双倍钻石！", "4.bag tongzhi");//美术素材还没好

        Collector w10 = new Collector(32, "来自母亲的信", "新学期已经开始有一段时间了，高三是最繁忙的时光，一定要好好学习，起码要对得起自己。我还是那句话，不想跟着你的死鬼老爹的话就跟我来生活。不明白就他那副德行为什么你还跟着他。还有，这周六别忘了到我这里来一趟领生活费。", "bag letter");
       
        Collector w11 = new Collector(33, "自己写的小说——片段2", "这天放学路过楼下的杂货店，看见一位20来岁的大姐姐抱着一大堆东西很不方便地走着。还是春寒料峭，她却穿着一件露肩吊带衫，裤子口袋里稀稀落落地放着几根烟。我主动地帮她抱起了部分货物，费力地跟在她后面走着，直到头不小心撞到她的肩，抬头一看，发廊两个字破破烂烂地快要掉下来。她轻轻地捋了捋我的马尾，从口袋里掏出了一根糖给我。", "6&7.bag xiaoshuo");

        Collector w12 = new Collector(34, "自己写的小说——片段3", "回到家后我跟爸爸妈妈说了这件事，她们却告诉我大姐姐不是什么好人，眼神中明显露出了鄙夷的目光，还让我千万别靠近她。然而，我回家的时候看到她就住在我的隔壁，却常常忍不住和她打招呼。", "6&7.bag xiaoshuo");

        Collector w13 = new Collector(41, "家访通知", "高三已经来临，为了深入了解各位同学的家庭状况，学校拟定于十一长假之后到各位同学的家中进行访问，还请做好准备。请将附件填写完整，按照班级上交。", "bag tongzhi");

        Collector w14 = new Collector(42, "自己写的小说——片段4", "这天，我在家门口背诗经，正逢我背不下去的时候，突然有个声音响起“求之不得，寤寐思服。悠哉悠哉，辗转反侧。对不？”我惊讶地装过头，却发现是之前的那个大姐姐。“你这样看着我干什么，好像我就应该不知道一样”，她笑着跟我打趣道。“姐姐你是对诗经了解很深吗？”我有点疑惑地问道。“嘛，哪有的事。”她有点避开了我的话，“我什么书都有看啦”。", "6&7.bag xiaoshuo");
    
        Collector w15 = new Collector(43, "一本自己的书，标题是“如何创造难忘的人物”", "“写作的一半是心理学，有一个稳定的核心，或者说与行为的协调一致性。人们不会随便给个理由就行动。要保持和人类行为的一致，你就必须知道在大多数情况下人们会怎么做，这需要丰富的人生阅历才能做到。”", "9&10.shu");

        Collector w16 = new Collector(44, "一本自己的书，标题是“契诃夫短篇小说精选”", "“生活是恼人的牢笼。一个有思想的人到成年时期，对生活有了成熟的感觉，他就不能不感到他关在一个无从脱逃的牢笼里面。”", "9&10.shu");

        Collector w17 = new Collector(51, "报纸——9月25日", "据记者报道，目前学区房的价格持续攀升。以目前风头正盛的一中为例，附近的核心区域房价已经飙升至6万/平方以上，专家表示这种热潮是违背市场正常发展的表现。", "bag newspaper");

        Collector w18 = new Collector(52, "一个破旧的小熊玩偶", "一个破旧的小熊玩偶，反面刻着“小玉”两个字，正面则是刻着“晨晨”，看起来像是两个小姑娘年幼时友情的印证。", "4.bag tongzhi");//美术素材还没好

        Collector w19 = new Collector(53, "报纸——9月25日", "根据记者卧底调查，发现许多学校老师均有私自在外上课的情况。这种情况屡见不鲜，也可以理解，政府和学校也往往睁一只眼闭一只眼。但是与教育机构的老师套话得知：很多老师完全疏于学校中的教育，上课一切从简，也从不开设答疑，却经常暗示学生去教育机构上他的课，以此牟利。目前这种情况还在调查中，欢迎关注后续。", "bag newspaper");

        Collector w20 = new Collector(61, "社区通知", "为了提高居民生活安全感，现执行一人一卡制度，晚上10点钟之后将会有社区门禁。小区居民必须刷卡才能进入。", "bag tongzhi");

        Collector w21 = new Collector(62, "掉落在地上的小广告", "由第一中学的特级英语教师——方老师开设的辅导班已经正式开启。先报名即可享受跳楼价200元/小时。课堂仅限50人，报名从速。", "bag tongzhi");//美术素材还没好

        Collector w22 = new Collector(63, "一个空的酒瓶", "酒精含量70%，目测是女孩父亲喝完扔掉的酒瓶，毕竟喝这么烈的酒的人很少。", "bag tongzhi");//美术素材还没好



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

        ItemList.Add(w12.Id, w12);

        ItemList.Add(w13.Id, w13);

        ItemList.Add(w13.Id, w13);

        ItemList.Add(w14.Id, w14);

        ItemList.Add(w15.Id, w15);

        ItemList.Add(w16.Id, w16);

        ItemList.Add(w17.Id, w17);

        ItemList.Add(w18.Id, w18);

        ItemList.Add(w19.Id, w19);

        ItemList.Add(w20.Id, w20);

        ItemList.Add(w21.Id, w21);

        ItemList.Add(w22.Id, w22);

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
        GridItem.Add(w12.Name, w12);
        GridItem.Add(w13.Name, w13);
        GridItem.Add(w14.Name, w14);
        GridItem.Add(w15.Name, w15);
        GridItem.Add(w16.Name, w16);
        GridItem.Add(w17.Name, w17);
        GridItem.Add(w18.Name, w18);
        GridItem.Add(w19.Name, w19);
        GridItem.Add(w20.Name, w20);
        GridItem.Add(w21.Name, w21);
        GridItem.Add(w22.Name, w22);

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
