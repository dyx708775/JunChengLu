using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 宗室 : NPC
{
    public override void Initialize(string 类型, string type,int id)
    {
        base.Initialize(类型, type,id);
        
        年龄 = Random.Range(3, 18);
        随机立绘();
    }
    public override void 随机立绘()
    {
        if (年龄 < 10 && 性别 == "男")
            立绘编号 = Random.Range(1, 3) * 200 + Random.Range(80, 90);
        else if (年龄 < 10 && 性别 == "女")
            立绘编号 = Random.Range(2, 5) * 100 + Random.Range(80, 90);
        else 
            立绘编号 = Random.Range(1, 10) * 1000 + Random.Range(80, 90);
        if (性别=="男")
            立绘地址 = "a0aPic_HuangZi\\Tu_" + 立绘编号 + ".jpg";
        else
            立绘地址 = "a0aPic_HiMe\\Tu_" + 立绘编号 + ".jpg";
        立绘 = UI相关.加载本地图片(立绘地址);
    }
}
