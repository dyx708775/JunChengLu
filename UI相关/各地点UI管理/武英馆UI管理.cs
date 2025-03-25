using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 武英馆UI管理 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject 缓动黑幕界面;
    void Start()
    {
        UI相关.实例化(缓动黑幕界面);
    }
    public GameObject 武英馆界面;
    public void 离开()
    {
        UI相关.销毁场景(武英馆界面);
    }
}
