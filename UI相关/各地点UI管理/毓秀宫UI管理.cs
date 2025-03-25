using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 毓秀宫UI管理 : MonoBehaviour
{
    public GameObject 缓动黑幕界面;
    void Start()
    {
        UI相关.实例化(缓动黑幕界面);
    }
    public GameObject 毓秀宫界面;
    public void 离开()
    {
        UI相关.销毁场景(毓秀宫界面);
    }

    public void 选秀()
    {
        GameObject instance = UI相关.实例化(Resources.Load<GameObject>("预制体/UI预制体/选秀/选秀界面"));
        instance.GetComponent<选秀界面UI管理>().参数 = "妃嫔选秀";
    }
}
