using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class 官职
{
    public int 官员编号;
    public string 所属部门;
    public string 官职名称;
    public int 品阶;
    public 官职(string 官职名称, string 所属部门, int 官职品阶)
    {
        官员编号 = -1;
        this.所属部门 = 所属部门;
        this.官职名称 = 官职名称;
        this.品阶 = 官职品阶;
    }
    public 官职()
    {

    }
}


public class 官职管理
{
    #region 单例模式
    public static 官职管理 instance;
    public static 官职管理 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new 官职管理();
            }
            return instance;
        }
    }
    #endregion
    public void 初始官职生成(大臣 npc, int 上限, int 下限)
    {
        List<官职> 满足条件官职 = new List<官职>();
        foreach(官职 官 in 数据库.中央官职.Values)
        {
            if (官.品阶 >= 上限 && 官.品阶 <= 下限 && 官.官员编号==-1)
            {
                满足条件官职.Add(官);
            }
        }
        官职 官职 = 满足条件官职[Random.Range(0,满足条件官职.Count)];
        if (满足条件官职.Count == 0)
        {
            npc.官职 = new 官职("闲官", "无", Random.Range(15, 18));
            npc.品阶 = npc.官职.品阶;
            npc.功勋 = (18 - npc.品阶) * 120;
            NPCManager.Instance.闲官列表.Add(npc.编号);
        }
        else
        {
            官职.官员编号 = npc.编号;
            数据库.中央官职[官职.官职名称] = 官职;
            npc.品阶 = 官职.品阶;
            npc.功勋 = (18 - npc.品阶) * 120;
            npc.官职 = 官职;
        }
    }
}   
