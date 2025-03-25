using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 皇帝 : NPC
{
    public override void Initialize(string 类型,string type, int id)
    {
        base.Initialize(类型, type, id);
        随机立绘();
    }
    public override void 随机立绘()
    {
        int 随机 = Random.Range(0, 9);
        立绘编号 = 10001;
        立绘地址 = "a0aPic_HuangZi\\Tu_" + 立绘编号 + ".jpg";
        立绘 = UI相关.加载本地图片(立绘地址);
    }
}
