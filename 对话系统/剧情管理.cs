using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class 随机剧情
{
    public string 剧情名称;
    [Range(0f, 1f)] public float 发生概率;
    public System.Action 剧情;
    public void 剧情发生()
    {
        if (剧情 != null)
        {
            剧情();
        }
    }
    public 随机剧情(string 剧情名称,float 发生概率, System.Action 剧情) 
    {
        this.剧情名称 = 剧情名称;
        this.发生概率 = 发生概率;
        this.剧情 = 剧情;
    }
}

public class 剧情综合
{
    public string 总剧情名;
    public bool 是否允许不发生剧情;
    public float 不发生剧情概率;
    public List<随机剧情> 所有剧情;
    public 剧情综合(string name, bool type, float 概率, List<随机剧情>所有剧情)
    {
        总剧情名 = name;    是否允许不发生剧情 = type; 不发生剧情概率 = 概率; this.所有剧情 = 所有剧情;
    }
}

public class 剧情管理
{
    #region 单例模式
    public static 剧情管理 instance;
    public static 剧情管理 Instance
    {
        get
        {
            //保证对象的唯一性
            if (instance == null)
            {
                if (instance == null)
                {
                    instance = new 剧情管理();//创建游戏对象
                }
            }
            return instance;
        }
    }
    #endregion
    public Dictionary<string,bool>剧情汇总 = new Dictionary<string, bool>();
    public int 太后诏书 = -1;
    public int 桂花树下埋麝香 = 0;
    public int 清心还魂丹 = 0;
    void 随机剧情发生(剧情综合 综合剧情)
    {
        float 随机 = Random.Range(0f, 1f);
        if (随机 <= 综合剧情.不发生剧情概率) return;
        float 总和概率 = 0;
        for (int i = 0; i < 综合剧情.所有剧情.Count; i++)
        {
            总和概率 += 综合剧情.所有剧情[i].发生概率;
        }
        随机 = Random.Range(0f, 总和概率);
        float kk = 0f;
        for (int i = 0; i < 综合剧情.所有剧情.Count; i++)
        {
            kk += 综合剧情.所有剧情[i].发生概率;
            if (随机 <= kk)
            {
                综合剧情.所有剧情[i].剧情发生();
                return;
            }
        }
    }

    #region 获取剧情综合
    public 剧情综合 获取桂宫进入剧情()
    {
        剧情综合 桂宫进入剧情 = new 剧情综合("桂宫进入剧情", true, 0.5f, new List<随机剧情>() {
        new 随机剧情("桂宫妃子带吃的邀宠",1f,剧情总览.Instance.桂宫妃子带吃的邀宠),
        new 随机剧情("桂宫妃子带吃的邀宠",0.3f,剧情总览.Instance.喂葡萄),
        new 随机剧情("带娃请安",0.3f,剧情总览.Instance.带娃请安),
        });
        return 桂宫进入剧情;
    }

    public 剧情综合 获取妃子宫女侍寝()
    {
        剧情综合 妃子宫女侍寝 = new 剧情综合("妃子宫女侍寝", false, 0f, new List<随机剧情>()
        {
            
        });
        return 妃子宫女侍寝;
    }
    #endregion
    #region 剧情发生
    public void 桂宫进入剧情()
    {
        随机剧情发生(获取桂宫进入剧情());
    }
    #endregion

}