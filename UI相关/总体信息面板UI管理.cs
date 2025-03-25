using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 总体信息面板UI管理 : MonoBehaviour
{
    public Toggle 跳, 状态, 属性, 存档, 读档;
    public GameObject 属性面板,状态面板;
    public Button[] 属性按钮;
    void Start()
    {
    }

    public void 时辰推进()
    {
        if (跳.isOn)
        {
            时间体系.Instance.时辰推进();
            跳.isOn = false;
        }
    }
    public void 妃嫔一览按钮()
    {
        常用功能.Instance.打开妃嫔属性列表("人物列表展示");
        属性.isOn = false;
        更新属性面板();
    }


    public void 大臣一览按钮()
    {
        常用功能.Instance.打开大臣属性列表("人物列表展示");
        属性.isOn = false;
        更新属性面板();
    }

    public void 存档按钮()
    {
        if (存档.isOn)
        {
            常用功能.Instance.存档功能();
            存档.isOn = false;
        }
    }

    public void 读档按钮()
    {
        if (读档.isOn)
        {
            常用功能.Instance.读档功能();
            读档.isOn = false;
        }
    }

    public void 更新属性面板()
    {
        bool shouldShowPanel = 属性.isOn;
        属性面板.SetActive(shouldShowPanel);
    }

    public void 状态按钮()
    {
        if (状态面板 != null)
        {
            状态面板.SetActive(状态.isOn);
        }

    }

    public void 跳按钮()
    {
        if(属性.isOn==true)
        {

            属性.isOn = false;
        }
    }
}
