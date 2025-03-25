using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class 妃子封号界面UI管理 : MonoBehaviour
{
    public string 参数;
    public GameObject 妃子封号界面;
    public TMP_InputField 封号输入框;
    void Start()
    {
        封号输入框.text = 中间变量.Instance.赐封号妃子.姓;
    }
    public void 离开()
    {
        中间变量.Instance.赐封号妃子.封号 = 封号输入框.text;
        UI相关.销毁场景(妃子封号界面);
        if (参数=="选秀")
        {
            中间变量.Instance.赐封号妃子.更换宫殿();
        }
    }
}
