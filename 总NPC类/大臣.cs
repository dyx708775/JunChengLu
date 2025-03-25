using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 大臣 : NPC
{
    public string 爵位="";
    public string 大臣类别 = "文";
    public int 忠诚;
    public int 世子 = -1;
    public int 品阶 = -1;
    public int 任务中;
    public int 入仕时长 = 0;
    public string 来源 = "";
    public string 城市 = "长安";
    public int 功勋;
    public int 策答 = 0;
    public string 职务 = "";
    public string 特殊标记 = "";
    public 官职 官职;
    public override void Initialize(string 类型, string type,int id)
    {
        base.Initialize(类型,type,id);
        随机立绘();
        年龄 = Random.Range(15, 60);
        爵位 = "无";
        忠诚 = Random.Range(0, 101);
        籍贯 = 数据库.籍贯[Random.Range(0, 数据库.籍贯.Length)];
        家族 = 籍贯 + 家族 + "氏";
        功勋 = Random.Range(1500, 2500);
    }
    public override void 随机立绘()
    {
        立绘编号 = Random.Range(0, 358);
        立绘地址 = "a0aPic_MingChen\\Tu_" + 立绘编号 + ".jpg";
        立绘 = UI相关.加载本地图片(立绘地址);
    }
    #region 人物信息面板
    public override void 打开人物信息面板()
    {
        string[] 功能按钮名称 = { "", "卸职", "奴婢", "党派", "", "", "", "策答", "修改", "下一页" };
        string[] 查看信息按钮名称 = { "职务", "记事", "家眷" };
        GameObject instance = UI相关.实例化(Resources.Load<GameObject>("预制体/信息展示预制体/人物信息展示"));
        Transform 查看信息面板 = instance.transform.Find("人物信息面板/查看信息面板");
        Transform 功能面板 = instance.transform.Find("功能面板");
        Image image = instance.transform.Find("人物信息面板/人物立绘").GetComponent<Image>();
        image.sprite = 立绘;
        TextMeshProUGUI text = instance.transform.Find("人物信息面板/人物介绍").GetComponent<TextMeshProUGUI>();
        text.text = 获取人物介绍().ToString();
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
        buttons[1].onClick.AddListener(() => 卸职());
        buttons[2].onClick.AddListener(() => 增加奴婢());
        buttons[3].onClick.AddListener(() => 查看党派());
        buttons[7].onClick.AddListener(() => 策答按钮());
        buttons[8].onClick.AddListener(() => 修改());
        buttons[9].onClick.AddListener(() => 下一页());
        查看信息按钮[0].onClick.AddListener(() => 职务按钮());
        查看信息按钮[1].onClick.AddListener(() => 查看记事());
        查看信息按钮[2].onClick.AddListener(() => 打开家眷面板());
        #endregion
    }
    private StringBuilder 获取人物介绍()
    {
        StringBuilder str = new StringBuilder();
        str.Append(姓+名+"   "+年龄+"岁   立绘编号:"+立绘编号);
        str.Append("\n剩余寿命:" + 寿命 / 12 + "年" + 寿命 % 12 + "月");
        if(品阶 != -1||官职!=null)
        {
            if (品阶 == -1) 品阶 = 官职.品阶;
            if (官职 != null)
            {
                str.Append("\n【" + 数据库.所有官员品阶[官职.品阶] + " " + 官职.所属部门 + " " + 官职.官职名称 + "】" + " ");
            }
            if (大臣类别 == "文") str.Append("\n【" + 数据库.所有官员品阶[品阶] + "  文  " + 数据库.文散官[品阶] + " 】");
            else str.Append("\n【" + 数据库.所有官员品阶[品阶] + "  武  " + 数据库.武散官[品阶] + " 】");
        }
        str.Append("\n出身:" + 籍贯 + " " +出身+ "【" + 数据库.属相[属相] + "】" + "（" + 数据库.大写数字[生日] + "月)");
        str.Append("\n性情:" + 性情 );
        if(喜好.Count!=0)
        {
            str.Append("\n喜好:");
            for (int i = 0; i < 喜好.Count; i++)
            {
                str.Append(喜好[i]);
                if (i != 喜好.Count - 1) str.Append("、");
            }
            str.Append("\n");
        }
        str.Append("字:"+字+ "  号:" +号+"  魅力:"+魅力);
        if (心 != -1) str.Append("  心仪:" + NPCManager.Instance.所有人物[心].姓 + NPCManager.Instance.所有人物[心].名);
        str.Append("\n个性:" +性情编号+"  后宫派系:"+后宫派系);
        if (性取向 == 1 || 性取向 == 0) str.Append("\n性向:" + 数据库.性取向[性取向]+" ");
        if(孕率!=-1)
        {
            if (孕率 == 0 && 年龄 >= 游戏设定.Instance.绝育年龄) str.Append("孕率:已绝经  ");
            else str.Append("孕率：" + 孕率+"  ");
        }
        if (生育能力 != -1)
        {
            if (生育能力 == 0 && 年龄 >= 游戏设定.Instance.绝育年龄) str.Append("生育:已绝精  ");
            else str.Append("生育：" + 生育能力 + "  ");
        }
        str.Append("妾室:" + 妾室.Count + "人");
        if (性别=="男"&&尺寸!=-1)    str.Append("尺寸:" + 尺寸 + "  ");
        if (性别 == "女" && 胸围 != -1) str.Append("胸围:" + 胸围);
        if (爵位 != "") str.Append("\n爵位:" + 爵位);
        if (伴侣 != -1)
        {
            NPC npc = NPCManager.Instance.所有人物[伴侣];
            str.Append("\n配偶:" + npc.封号 + npc.姓 + npc.名 + "  " + "恩爱:" + 夫妻恩爱值 + "  " + "经验:" + 经验);
        }
        else str.Append("\n经验:" + 经验);
        if (祖父 != -1 && 祖母 == -1) str.Append("\n祖父:" + NPCManager.Instance.所有人物[祖父].姓 + NPCManager.Instance.所有人物[祖父].名);
        else if (祖父 != -1 && 祖母 != -1) str.Append("\n祖父:" + NPCManager.Instance.所有人物[祖父].姓 + NPCManager.Instance.所有人物[祖父].名 + "  " + "祖母:" + NPCManager.Instance.所有人物[祖母].姓 + NPCManager.Instance.所有人物[祖母].名);
        else if (祖父 == -1 && 祖母 != -1) str.Append("\n祖母:" + NPCManager.Instance.所有人物[祖母].姓 + NPCManager.Instance.所有人物[祖母].名);
        if (外祖父 != -1 && 外祖母 == -1) str.Append("\n外祖父:" + NPCManager.Instance.所有人物[外祖父].姓 + NPCManager.Instance.所有人物[外祖父].名);
        else if (外祖父 != -1 && 外祖母 != -1) str.Append("\n外祖父:" + NPCManager.Instance.所有人物[外祖父].姓 + NPCManager.Instance.所有人物[外祖父].名 + "  " + "外祖母:" + NPCManager.Instance.所有人物[外祖母].姓 + NPCManager.Instance.所有人物[外祖母].名);
        else if (外祖父 == -1 && 外祖母 != -1) str.Append("\n外祖母:" + NPCManager.Instance.所有人物[外祖母].姓 + NPCManager.Instance.所有人物[外祖母].名);
        if (生父 != -1 && 生母 == -1) str.Append("\n生父:" + NPCManager.Instance.所有人物[生父].姓 + NPCManager.Instance.所有人物[生父].名);
        else if (生父 != -1 && 生母 != -1) str.Append("\n生父:" + NPCManager.Instance.所有人物[生父].姓 + NPCManager.Instance.所有人物[生父].名 + "  " + "生母:" + NPCManager.Instance.所有人物[生母].姓 + NPCManager.Instance.所有人物[生母].名);
        else if (生父 == -1 && 生母 != -1) str.Append("\n生母:" + NPCManager.Instance.所有人物[生母].姓 + NPCManager.Instance.所有人物[生母].名);
        if (父亲 != -1 && 母亲 == -1) str.Append("\n父亲:" + NPCManager.Instance.所有人物[父亲].姓 + NPCManager.Instance.所有人物[父亲].名);
        else if (父亲 != -1 && 母亲 != -1) str.Append("\n父亲:" + NPCManager.Instance.所有人物[父亲].姓 + NPCManager.Instance.所有人物[父亲].名 + "  " + "母亲:" + NPCManager.Instance.所有人物[母亲].姓 + NPCManager.Instance.所有人物[母亲].名);
        else if (父亲 == -1 && 母亲 != -1) str.Append("\n母亲:" + NPCManager.Instance.所有人物[母亲].姓 + NPCManager.Instance.所有人物[母亲].名);
        str.Append("\n金钱:" + 金钱 + "两" + "  " + "清廉:" + 清廉 + "  " + "野心:" + 野心);
        str.Append("\n儿子:" + 儿子数量 + "人     女儿:" + 女儿数量 + "人");
        str.Append("\n孙子:" + 孙子数量 + "人     孙女:" + 孙女数量 + "人");
        if (家族管理.Instance.所有家族.ContainsKey(家族))
        {
            家族 家族 = 家族管理.Instance.所有家族[this.家族];
            str.Append("\n家族总势力:" + 家族.总势力值.ToString("F1") + "  后宫势力" + 家族.后宫势力.ToString("F1") + "  朝廷势力:" + 家族.朝廷势力.ToString("F1"));
        }
        if (世子 != -1) str.Append("\n世子:" + NPCManager.Instance.所有人物[世子].姓 + NPCManager.Instance.所有人物[世子].名);
        if (孕 > 0) str.Append("\n【怀胎" + 数据库.大写数字[孕] + "月】");
        return str;
    }
    public override void 拜访()
    {
        base.拜访();
        Debug.Log(姓 + 名);
    }
    private void 查看家眷()
    {
        Debug.Log("查看家眷");
    }
    public override void 查看记事()
    {
        base.查看记事();
    }
    private void 职务按钮()
    {
        Debug.Log("职务");
    }
    private void 下一页()
    {
        Debug.Log("下一页");
    }
    private void 修改()
    {
        Debug.Log("修改");
    }
    private void 策答按钮()
    {
        Debug.Log("策答");
    }
    private void 查看党派()
    {
        Debug.Log("查看党派");
    }
    private void 增加奴婢()
    {
        Debug.Log("增加奴婢");
    }
    private void 卸职()
    {
        Debug.Log("卸职");
    }
    public override void 打开家眷面板()
    {
        base.打开家眷面板();
    }
    #endregion
}
