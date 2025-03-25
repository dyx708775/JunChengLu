using DG.Tweening.Plugins;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 取名字字库
{
    // Start is called before the first frame update
    
    public static 取名字字库 instance;
    public static 取名字字库 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new 取名字字库();
            }
            return instance;
        }
    }
    public string 获取姓()
    {
        int 随机 = Random.Range(0, 数据库.姓.Length);
        string 姓氏 = 数据库.姓[随机];
        return 姓氏;
    }

    public string 获取名(int num,string type)
    {
        if(type=="男")
        {
            if (num == 1) return 数据库.男单字[Random.Range(0, 数据库.男单字.Length)];
            else
            {
                return 数据库.男前名[Random.Range(0, 数据库.男前名.Length)] + 数据库.男后名[Random.Range(0, 数据库.男后名.Length)];
            }
        }
        else if (type == "女")
        {
            if (num == 1) return 数据库.女单字[Random.Range(0, 数据库.女单字.Length)];
            else
            {
                return 数据库.女前名[Random.Range(0, 数据库.女前名.Length)] + 数据库.女后名[Random.Range(0, 数据库.女后名.Length)];
            }
        }
        return "undefined";
    }

    //public string 获取字辈名(字辈 字辈, string type)
    //{
    //    if(字辈.类型 == 字辈类型.第一个字)
    //    {

    //    }
    //    else if(字辈.类型==字辈类型.第二个字)
    //    {

    //    }
    //    else if(字辈.类型 == 字辈类型.草字头)
    //    {

    //    }
    //}

}
