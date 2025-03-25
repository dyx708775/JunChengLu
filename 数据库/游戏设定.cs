using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class 国家属性
{
    #region 单例模式
    public static 国家属性 instance;
    public static 国家属性 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new 国家属性();
            }
            return instance;
        }
    }
    #endregion

}
public  class 游戏设定
{
    public static 游戏设定 instance;
    public static 游戏设定 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new 游戏设定();
            }
            return instance;
        }
    }
    public string 都城 = "长安";
    public int 党派跳槽 = 1;
    public int 少主模式 = 0;
    public int 每月存档开关 = 0;
    public int 高位妃 = 4;
    public int 中位妃 = 8;
    public int 最小随机妃子年龄 = 15;
    public int 最大随机妃子年龄 = 19;
    public int 初始宗室数量 = 15;
    public int 绝育年龄 = 45;
    public int 恩宠设定 = 8;
    public int 宠爱判定 = 1;
    public int 宋仁宗模式 = 1;
    public int _con_tianjiang = 0;
    public int 最小选秀年龄 = 15;
    public int 最大选秀年龄 = 19;
    public int 协理六宫啊 = -1;
    public int 事件六 = 0;
    public int 国子监丞 = -1;
    public int 国子监祭酒代行 = -1;
    public int 国子监司业 = -1;
    public int 祝福 = 0;
    public int 后宫模式 = 0;
    public int 教坊收入 = 0;
    public string 年号;
    public int 皇后 = -1;
    public int 太后 = -1;
    public int 阿娇 = 0;
    public string 崇文馆名称 = "";
}
