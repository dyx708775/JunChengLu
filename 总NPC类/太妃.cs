using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class 太妃 : NPC
{
    public int 妃子品阶;
    public string 位分;
    //public string 封号;
    public int 宠爱;
    public override void Initialize(string 类型, string type,int id)
    {
        base.Initialize(类型,type,id);
        年龄 = UnityEngine.Random.Range(20, 40);
        随机立绘();
        宠爱 = UnityEngine.Random.Range(0, 200);
        经验 = 宠爱 / (UnityEngine.Random.Range(10, 20));
        妃子品阶 = UnityEngine.Random.Range(1, 数据库.所有位分.Count);
        位分 = 数据库.所有位分[妃子品阶].所有小位分[0];
    }
    public void 增加孩子()
    {
        if (年龄 < 30) return;
        int 孩子数量 = 0;
        int 随机 = UnityEngine.Random.Range(0, 100);
        if (随机 > 95)
            孩子数量 = 2;
        else if (随机 > 85)
            孩子数量 = 1;
        string[] 性别 = { "男", "女" };
        孩子数量 = Math.Min(孩子数量, 游戏设定.Instance.初始宗室数量 - NPCManager.Instance.宗室列表.Count);
        for (int i = 0; i < 孩子数量; i++)
        {
            宗室 npc = (宗室)NPCManager.Instance.创建随机人物("宗室", 性别[UnityEngine.Random.Range(0, 2)]);
            npc.年龄 = Math.Max(1, 年龄 - UnityEngine.Random.Range(18, 30));
            NPCManager.Instance.所有人物[伴侣].孩子.Add(npc.编号);
            孩子.Add(npc.编号);
            npc.母亲 = 编号;
            npc.父亲 = 主控.Instance.父亲;
        }
    }
    public override void 随机立绘()
    {
        立绘编号 = UnityEngine.Random.Range(0, 2000);
        立绘地址 = "a0aPic_FeiZi\\Tu_" + 立绘编号 + ".jpg";
        立绘 = UI相关.加载本地图片(立绘地址);
    }
    public override void 打开人物信息面板()
    {
        base.打开人物信息面板();
        string[] 功能按钮名称 = { "", "", "", "", "", "", "", "删除人物", "修改", "下一页" };
        string[] 查看信息按钮名称 = { "", "记事", "" };
        //Debug.Log("打开人物信息面板");
        GameObject instance = UI相关.实例化(Resources.Load<GameObject>("预制体/信息展示预制体/人物信息展示"));
        Transform 查看信息面板 = instance.transform.Find("人物信息面板/查看信息面板");
        Transform 功能面板 = instance.transform.Find("功能面板");
        UnityEngine.UI.Image image = instance.transform.Find("人物信息面板/人物立绘").GetComponent<UnityEngine.UI.Image>();
        image.sprite = 立绘;
        TextMeshProUGUI text = instance.transform.Find("人物信息面板/人物介绍").GetComponent<TextMeshProUGUI>();
        text.text = 获取人物介绍().ToString();
        UnityEngine.UI.Button[] 查看信息按钮 = 查看信息面板.GetComponentsInChildren<UnityEngine.UI.Button>();
        UnityEngine.UI.Button[] buttons = 功能面板.GetComponentsInChildren<UnityEngine.UI.Button>();
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
        buttons[7].onClick.AddListener(() => 删除人物(instance));
        查看信息按钮[1].onClick.AddListener(() => 查看记事());
        //查看信息按钮[2].onClick.AddListener(() => 打开家眷面板());
    }

    public override void 查看记事()
    {
        base.查看记事();
        GameObject instance = UI相关.实例化(Resources.Load<GameObject>("预制体/信息展示预制体/记事一览滚动版"));
        instance.GetComponent<滚动版记事一览UI管理>().npc = this;
    }

    private StringBuilder 获取人物介绍()
    {
        StringBuilder str = new StringBuilder();
        str.Append(姓 + 名 + "   " + 年龄 + "岁   立绘编号:" + 立绘编号);
        str.Append("\n剩余寿命:" + 寿命 / 12 + "年" + 寿命 % 12 + "月");
        str.Append("\n出身:" + 籍贯 + " " + 出身 + "【" + 数据库.属相[属相] + "】" + "（" + 数据库.大写数字[生日] + "月)");
        str.Append("\n性情:" + 性情);
        if (喜好.Count != 0)
        {
            str.Append("\n喜好:");
            for (int i = 0; i < 喜好.Count; i++)
            {
                str.Append(喜好[i]);
                if (i != 喜好.Count - 1) str.Append("、");
            }
            str.Append("\n");
        }
        if (孕率 != -1)
        {
            if (孕率 == 0 && 年龄 >= 游戏设定.Instance.绝育年龄) str.Append("孕率:已绝经  ");
            else str.Append("孕率：" + 孕率 + "  ");
        }
        if (生育能力 != -1)
        {
            if (生育能力 == 0 && 年龄 >= 游戏设定.Instance.绝育年龄) str.Append("生育:已绝精  ");
            else str.Append("生育：" + 生育能力 + "  ");
        }
        return str;
    }
}
