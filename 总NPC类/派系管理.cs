using ParadoxNotion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class 派系
{
    public List<string> 成员家族;//只存放名称
    public string 领袖家族;
    public double 总势力值 = 0;
    public double 后宫势力值 = 0;
    public double 朝廷势力值 = 0;
    public double 支持皇嗣 = -1;

    public 派系(string 领袖家族,double 后宫势力值,double 朝廷势力值,double 总势力值)
    {
        this.领袖家族 = 领袖家族;
        this.后宫势力值 = 后宫势力值;
        this.朝廷势力值 = 朝廷势力值;
        this.总势力值 = 总势力值;
    }
}
public class 派系管理
{
    #region 单例模式
    public static 派系管理 instance;

    public static 派系管理 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new 派系管理();
            }
            return instance;
        }
    }
    #endregion
    public Dictionary<int,派系>所有派系 = new Dictionary<int, 派系> ();
    private int count=0;

    public void 刷新派系势力值()
    {
        foreach(KeyValuePair<int,派系>kvp in 所有派系)
        {
            double 后宫势力值 = 0;
            double 朝廷势力值 = 0;
            派系 派系 = kvp.Value;
            if(家族管理.Instance.所有家族.ContainsKey(派系.领袖家族))
            {
                后宫势力值 += 家族管理.Instance.所有家族[派系.领袖家族].后宫势力;
                朝廷势力值 += 家族管理.Instance.所有家族[派系.领袖家族].朝廷势力;
            }
            for(int i=0;i<派系.成员家族.Count;i++)
            {
                if (家族管理.Instance.所有家族.ContainsKey(派系.成员家族[i]))
                {
                    后宫势力值 += 家族管理.Instance.所有家族[派系.成员家族[i]].后宫势力;
                    朝廷势力值 += 家族管理.Instance.所有家族[派系.成员家族[i]].朝廷势力;
                }
            }
            派系.后宫势力值 = 后宫势力值;
            派系.朝廷势力值 = 朝廷势力值;
        }
    }
    public static double 获取官员势力值(大臣 大臣)
    {
        return 大臣.功勋 / 7.0 + Random.Range(0, 30);
    }

    public static void 朝廷势力增长(string 家族名,double 随机势力增长)
    {
        if (家族管理.Instance.所有家族.ContainsKey(家族名))
        {
            家族 家族 = 家族管理.Instance.所有家族[家族名];
            家族.朝廷势力 += 随机势力增长 / 2.0;
            家族.总势力值 = 家族.朝廷势力 + 家族.后宫势力;
        }
    }
    public static double 获取妃子势力值(妃子 妃子)
    {
        return 妃子.宠 * (1 + (数据库.所有位分.Count - 妃子.妃子品阶) * 0.2) + UnityEngine.Random.Range(0, 30);
    }
    public void 初始派系生成()
    {
        所有派系.Add(0, new 派系("皇室",0,0,0));
        foreach(KeyValuePair<string,家族>kvp in 家族管理.Instance.所有家族)//初始派系生成
        {
            家族 家族 = kvp.Value;
            if (家族.总势力值 > 750 || (家族.总势力值 > 600 && 家族.族长编号 != -1 && NPCManager.Instance.所有人物[家族.族长编号].野心>80))
            {
                所有派系.Add(++count, new 派系(家族.家族名,家族.后宫势力,家族.朝廷势力,家族.总势力值));
                家族.所属派系 = count;
            }
            else
            {
                派系 派系 = 所有派系[0];
                派系.后宫势力值 += 家族.后宫势力;
                派系.朝廷势力值 += 家族.朝廷势力;
                派系.总势力值 += 家族.总势力值;
            }
        }
        foreach (KeyValuePair<string, 家族> kvp in 家族管理.Instance.所有家族)//初始归属度分配
        {
            家族 家族 = kvp.Value;
            for(int i=0;i<=count;i++)
            {
                if (家族.所属派系 != -1&&家族.所属派系!=0)
                {
                    if (家族.所属派系 == i) 家族.派系归属度.Add(i, 100);
                    else if (i == 0) 家族.派系归属度.Add(0, UnityEngine.Random.Range(30, 100));
                    else 家族.派系归属度.Add(i, 0);
                }
                else
                {
                    if (i == 0) 家族.派系归属度.Add(0, UnityEngine.Random.Range(80,100));
                    else 家族.派系归属度.Add(i, UnityEngine.Random.Range(0, 60));
                }
            }
        }
    }
}
