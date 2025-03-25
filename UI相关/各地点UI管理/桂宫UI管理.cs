using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 桂宫UI管理 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject 缓动黑幕界面;
    public GameObject 桂宫界面;

    void Start()
    {
        UI相关.实例化(缓动黑幕界面);
        剧情管理.Instance.桂宫进入剧情();
    }
    public void 离开()
    {
        UI相关.销毁场景(桂宫界面);
    }
}
