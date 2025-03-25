using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 大臣记事总览 
{
    public static Dictionary<int, List<string>> 大臣记事 = new Dictionary<int, List<string>>()
    {
       {1,new List<string>{ "[0]备礼往[1]家拜谒，称是远方侄儿，求[2]指点仕途。",
                            "[0]来家拜谒，称是远房侄儿，求自己指点仕途。",
                            "备礼往[0]家拜谒，称是远方侄儿，求[1]指点仕途。",
                            "[0]备礼往[1]家拜谒，称是远方侄儿, [2]将其打发出去。",
                            "[0]来家拜谒，称是远方侄儿。知其来路，不喜做派，将其打发出去。",
                            "备礼往[0]家拜谒，称是远方侄儿，被随意打发。",} },
        {2,new List<string>{ "[0]、[1]、[2]互为异姓兄弟，于桃园之中，焚香结拜，誓同生死。",
            "与[0]、[1]互为异姓兄弟，于桃园之中，焚香结拜，誓同生死。",
        } },
        {3,new List<string>{ "[0]好友[1]劝他续弦，[2]哀痛：“必得与先妻[3]并美的女子，方才娶她。”" ,
                            "劝好友[0]续弦，[0]哀痛：“必得与先妻[1]并美的女子，方才娶她。",
                            "好友[0]劝己续弦，哀痛不已，借酒消愁：“必得与先妻[1]并美的女子，方才娶她。",} },
        {4,new List<string>{    "[0]妒[1]有才，花钱请梨园子弟编他忘恩负义抛弃糟糠的戏码，满京城演出。",
                                "梨园子弟胡编自己忘恩负义抛弃糟糠的戏码，满京城演出。",
                                "妒[0]有才，花钱请梨园子弟编他忘恩负义抛弃糟糠的戏码，满京城演出。",} },
    };
}
