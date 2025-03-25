using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class 物品
{
    public string 物品名称;
    public int 物品价值;
    public string 物品类别;
    public int 版权;
    public string 说明="";
    public int 物品等级;
    public int 物品头像地址;
    public int 数量;
    [NonSerialized] public Sprite 物品头像;

    public 物品(int 物品头像地址,string 物品类别,string 物品名称,int 物品等级,int 数量)
    {
        this.物品头像地址 = 物品头像地址;
        this.物品类别 = 物品类别;
        this.物品名称 = 物品名称;
        this.物品等级 = 物品等级;
        this.数量 = 数量;
    }

    public void 加载头像()
    {
        物品头像 = UI相关.加载本地图片("a0aPic_Icon\\Tu_"+物品头像地址.ToString()+".jpg");
    }
}
public class 物品管理 
{
    public Dictionary<string, List<物品>> 所有物品 = new Dictionary<string, List<物品>>();
    #region 单例模式
    public static 物品管理 instance;
    public static 物品管理 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new 物品管理();
                instance.所有物品 = 数据库.所有物品;
            }
            return instance;
        }
    }
    #endregion
    private void init()
    {

    }

}
