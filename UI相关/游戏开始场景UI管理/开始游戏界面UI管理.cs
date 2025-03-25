using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 开始游戏界面UI管理 : MonoBehaviour
{
    public GameObject instance;
    public void 跳转界面(GameObject 跳转界面)
    {
        UI相关.销毁场景(instance);
        UI相关.实例化(跳转界面);
    }
}
