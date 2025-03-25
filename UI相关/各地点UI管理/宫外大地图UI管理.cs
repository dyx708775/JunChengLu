using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 宫外大地图UI管理 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject 缓动黑幕界面;
    void Start()
    {
        UI相关.实例化(缓动黑幕界面);
    }

    // Update is called once per frame
    public GameObject 宫外大地图界面;
    public void 离开()
    {
        UI相关.销毁场景(宫外大地图界面);
    }
    public void 打开界面(GameObject prefab)
    {
        UI相关.实例化(prefab);
    }
}
