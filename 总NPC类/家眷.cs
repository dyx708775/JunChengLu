using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 家眷 : NPC
{
    public override void Initialize(string 类型, string type, int id)
    {
        base.Initialize(类型, type, id);
        随机立绘();
    }
    public override void 随机立绘()
    {
        base.随机立绘();
        if (年龄 < 10 && 性别 == "男")
            立绘编号 = Random.Range(1, 3) * 200 + Random.Range(80, 90);
        else if (年龄 < 10 && 性别 == "女")
            立绘编号 = Random.Range(2, 5) * 100 + Random.Range(80, 90);
        else
            立绘编号 = Random.Range(1, 10) * 1000 + Random.Range(80, 90);
        if (性别 == "男")
            立绘地址 = "a0aPic_HuangZi\\Tu_" + 立绘编号 + ".jpg";
        else
            立绘地址 = "a0aPic_HiMe\\Tu_" + 立绘编号 + ".jpg";
        立绘 = UI相关.加载本地图片(立绘地址);
    }
    public override void 打开人物信息面板()
    {
        string[] 功能按钮名称 = { "亲眷", "", "", "", "", "", "", "删除人物", "修改", "下一页" };
        string[] 查看信息按钮名称 = { "职务", "记事", "家眷" };
        GameObject instance = UI相关.实例化(Resources.Load<GameObject>("预制体/信息展示预制体/人物信息展示"));
        Transform 查看信息面板 = instance.transform.Find("人物信息面板/查看信息面板");
        Transform 功能面板 = instance.transform.Find("功能面板");
        Image image = instance.transform.Find("人物信息面板/人物立绘").GetComponent<Image>();
        image.sprite = 立绘;
        TextMeshProUGUI text = instance.transform.Find("人物信息面板/人物介绍").GetComponent<TextMeshProUGUI>();
        //text.text = 获取人物介绍().ToString();
        Button[] 查看信息按钮 = 查看信息面板.GetComponentsInChildren<Button>();
        Button[] buttons = 功能面板.GetComponentsInChildren<Button>();
        #region 更改按钮名称与可见程度
        for (int i = 0; i < buttons.Length; i++)
        {
            if (功能按钮名称[i].Length == 0)
            {
                buttons[i].GetComponent<CanvasGroup>().interactable = false;
                buttons[i].GetComponent<CanvasGroup>().alpha = 0.0f;
            }
            else
            {
                buttons[i].GetComponent<CanvasGroup>().interactable = true;
                buttons[i].GetComponent<CanvasGroup>().alpha = 1.0f;
                buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = 功能按钮名称[i];
            }
        }
        for (int i = 0; i < 查看信息按钮.Length; i++)
        {
            查看信息按钮[i].GetComponentInChildren<TextMeshProUGUI>().text = 查看信息按钮名称[i];
        }
        #endregion
        #region 添加按钮点击事件
        //buttons[0].onClick.AddListener(() => 打开家眷面板());
        //buttons[1].onClick.AddListener(() => 卸职());
        //buttons[2].onClick.AddListener(() => 增加奴婢());
        //buttons[3].onClick.AddListener(() => 查看党派());
        buttons[7].onClick.AddListener(() => 删除人物(instance));
        //buttons[8].onClick.AddListener(() => 修改());
        //buttons[9].onClick.AddListener(() => 下一页());
        //查看信息按钮[0].onClick.AddListener(() => 职务());
        //查看信息按钮[1].onClick.AddListener(() => 查看记事());
        //查看信息按钮[2].onClick.AddListener(() => 查看家眷());
        #endregion
    }
    public override void 删除人物(GameObject instance)
    {
        base.删除人物(instance);
    }
}
