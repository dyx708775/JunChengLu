using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 宣政殿UI管理 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject 缓动黑幕界面;
    void Start()
    {
        UI相关.实例化(缓动黑幕界面);
    }
    public GameObject 宣政殿界面;
    public void 离开()
    {
        GameObject 删除确认 = Instantiate(Resources.Load<GameObject>("预制体/UI预制体/提示框面板2"));
        提示框面板UI管理 UI = 删除确认.GetComponent<提示框面板UI管理>();
        UI.参数 = "退朝";
        UI.instance = 宣政殿界面;
        UI.提示语 = "确认退朝吗？";
    }
}
