using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class 位分修改界面UI管理 : MonoBehaviour
{
    public TMP_Text 提示1, 提示2;
    public TMP_InputField 名称, 数量上限;
    public 妃子位分界面UI管理 UI;
    public GameObject 位分修改界面;
    public int index;
    void Start()
    {
        if(UI.参数=="修改大位分")
        {
            提示2.gameObject.SetActive(true);
            数量上限.gameObject.SetActive(true);
            名称.text = UI.所有位分[index].大位分名称;
            数量上限.text = UI.所有位分[index].上限人数.ToString();

        }
        else if(UI.参数=="修改小位分")
        {
            提示2.gameObject.SetActive(false);
            数量上限.gameObject.SetActive(false);
            名称.text = UI.小位分列表[index];
        }
    }
    public void 确认()
    {
        if(UI.参数=="修改大位分")
        {
            int number;
            int.TryParse(数量上限.text, out number);
            if(index==0)
            {
                number = 1;
                UI相关.小提示("最高位分只能有一个");
            }
            UI.所有位分[index].上限人数 = number;
            UI.所有位分[index].大位分名称 = 名称.text;
            if(number<100)
            UI.被修改按钮.GetComponentsInChildren<TMP_Text>()[1].text = "已有" + UI.所有位分[index].已有人数 + "人,上限" + UI.所有位分[index].上限人数 + "人";
            else UI.被修改按钮.GetComponentsInChildren<TMP_Text>()[1].text = "已有" + UI.所有位分[index].已有人数 + "人,无上限" ;
            UI.被修改按钮.GetComponentInChildren<Button>().GetComponentInChildren<TMP_Text>().text = UI.所有位分[index].大位分名称;
        }
        else if(UI.参数=="修改小位分")
        {
            UI.小位分列表[index] = 名称.text;
            UI.被修改按钮.GetComponentInChildren<Button>().GetComponentInChildren<TMP_Text>().text = UI.小位分列表[index];
            UI.被修改按钮.GetComponentsInChildren<TMP_Text>()[1].text = "";
        }
        UI相关.销毁场景(位分修改界面);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
