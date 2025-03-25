using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum 字辈类型
{
    第一个字,
    第二个字,
    草字头
}
public struct 字辈
{
    public 字辈类型 类型;
    public string 字;

    public 字辈(字辈类型 类型,string 字)
    {
        this.类型 = 类型;
        this.字 = 字;
    }
}


public class 家族
{
    public int 所属派系 = -1;
    public string 家族名;
    public List<int> 家族成员 = new List<int>();
    public List<int> 根成员 = new List<int>();
    public Dictionary<int, 字辈> 女字辈 = new Dictionary<int, 字辈>();
    public Dictionary<int, 字辈> 男字辈 = new Dictionary<int, 字辈>();
    public int 族长编号 = -1;
    public List<int> 后宫成员 = new List<int>();
    public List<int> 朝廷成员 = new List<int>();
    public double 支持皇嗣 = -1;
    public double 总势力值 = 0;
    public double 后宫势力 = 0;
    public double 朝廷势力 = 0;
    public Dictionary<int, int> 派系归属度;//对于每个派系的归属度

    public 家族(string 家族名)
    {
        this.家族名 = 家族名;
    }

    public void 打开族谱界面()
    {
        GameObject instance = UI相关.实例化(Resources.Load<GameObject>("预制体/信息展示预制体/族谱"));
        族谱UI管理 UI = instance.GetComponent<族谱UI管理>();
        UI.家族名 = 家族名;
    }

    public void 势力计算()
    {
        
        总势力值 = 后宫势力 + 朝廷势力;
    }
}
public class 家族管理
{
    public Dictionary<string, 家族> 所有家族 = new Dictionary<string, 家族>();
    #region 单例模式
    public static 家族管理 instance;
    public static 家族管理 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new 家族管理();
            }
            return instance;
        }
    }
    #endregion
}
