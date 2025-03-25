using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 国家
{
    public static 国家 instance;
    public static 国家 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new 国家();
            }
            return instance;
        }
    }
       
}


public class 国家管理
{
    #region 单例模式
    public static 国家管理 instance;
    public static 国家管理 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new 国家管理();
            }
            return instance;
        }
    }
    #endregion
}