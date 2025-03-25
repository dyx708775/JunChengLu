using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 昭台宫UI管理 : MonoBehaviour
{
    public GameObject 缓动黑幕界面;
    void Start()
    {
        UI相关.实例化(缓动黑幕界面);
    }
    public GameObject 昭台宫界面;
    public void 离开()
    {
        UI相关.销毁场景(昭台宫界面);
    }
}
