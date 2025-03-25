using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 椒房殿UI管理 : MonoBehaviour
{
    public GameObject 缓动黑幕界面;
    public Toggle 信息按钮;
    private GameObject 黑幕instance;
    private 妃子 拜访妃子;
    void Start()
    {
        拜访妃子 = UI相关.NPC宫殿拜访;
        UI相关.实例化(缓动黑幕界面);
    }
    public GameObject 妃子拜访界面;
    public void 离开()
    {
        UI相关.销毁场景(妃子拜访界面);
    }

    public void 打开信息面板()
    {
        bool 是否打开记事面板 = 信息按钮.isOn;
        if (是否打开记事面板)
        {
            拜访妃子.打开人物信息面板();
            信息按钮.isOn = false;
        }
    }
}
