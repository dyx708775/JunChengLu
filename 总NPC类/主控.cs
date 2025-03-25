using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 主控 : NPC
{
    public int 道德=100;
    public int 妃子怀孕 = 0;
    public int 体力=1000;
    public int 体力上限=9999;
    public static 主控 instance;
    public int 生病刚好 = 0;
    public static 主控 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new 主控();
                int id = NPCManager.Instance.all_people_count++;
                NPCManager.Instance.所有人物[id] = 主控.instance;
                instance.Initialize("皇帝","男",id);
            }
            return instance;
        }
    }
    public override void Initialize(string 类型,string type,int id)
    {
        base.Initialize(类型,type,id);
        随机立绘();
    }

    public override void 随机立绘()
    {
        int 随机 = Random.Range(0, 9);
        立绘编号 = 随机 * 1000 + 1080 + Random.Range(0,10);
        立绘地址 = "a0aPic_HuangZi\\Tu_"+立绘编号+".jpg";
        立绘 = UI相关.加载本地图片(立绘地址);
    }
}