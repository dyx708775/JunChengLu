using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void 信息列表刷新(int index);
public class 中间变量
{
    public static 中间变量 instance;
    public static 中间变量 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new 中间变量();
            }
            return instance;
        }
    }

    public int 太后妃子家族统一 = -1;
    public 妃子 被安排宫殿妃子 = null;
    public 信息列表UI管理 UI = null;
    public 妃子 册封妃子 = null;
    public 妃子 赐封号妃子 = null;
    public 信息列表刷新 dl;
    public int 开科考试 = 0;
    public int 祭祀活动 = 0;
    public int 挑选侍卫 = 0;
    public int 挑选监生 = 0;
    public int 征召女官 = 0;
    public int 朝廷策答 = 0;
    public int 监生考试 = 0;

}
