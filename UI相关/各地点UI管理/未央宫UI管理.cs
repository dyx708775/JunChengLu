using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 未央宫UI管理 : MonoBehaviour
{
    public GameObject 缓动黑幕界面;
    void Start()
    {
        UI相关.实例化(缓动黑幕界面);
    }
    public GameObject 未央宫界面;
    public void 离开()
    {
        UI相关.销毁场景(未央宫界面);
    }

    public void 宫殿迁移()
    {
        常用功能.Instance.打开妃嫔属性列表("安排宫殿");
    }
    public void 妃嫔晋位()
    {
        常用功能.Instance.打开妃嫔属性列表("妃嫔晋位");
    }
    public void 妃嫔降位()
    {
        常用功能.Instance.打开妃嫔属性列表("妃嫔降位");
    }
}
