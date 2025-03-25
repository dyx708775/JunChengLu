using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 御膳房UI管理 : MonoBehaviour
{
    public GameObject 缓动黑幕界面;
    void Start()
    {
        UI相关.实例化(缓动黑幕界面);
    }
    public GameObject 御膳房界面;
    public void 离开()
    {
        UI相关.销毁场景(御膳房界面);
    }
}
