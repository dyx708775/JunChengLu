using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public enum 记事类型
{
    妃子记事,
    大臣记事,
    家眷记事
}

public class 记事
{
    public 记事类型 记事类型;
    public int 记事编号;
    public int 视角编号;
    public string 年号;
    public int 月;
    public int 年;
    public Dictionary<int, string> 替换名;
    public 记事(记事类型 记事类型, int 记事编号, int 视角编号, Dictionary<int, string> 替换名)
    {
        this.记事类型 = 记事类型;
        this.记事编号 = 记事编号;
        this.视角编号 = 视角编号;
        this.替换名 = 替换名;
        this.年号 = 游戏设定.Instance.年号;
        this.月 = 时间体系.Instance.月;
        this.年 = 时间体系.Instance.年;
    }
    public string 记事生成()
    {
        string result = "";
        switch (this.记事类型)
        {
            case 记事类型.妃子记事:
                result = 妃子记事总览.妃子记事[this.记事编号][this.视角编号];
                break;
            case 记事类型.大臣记事:
                result = 大臣记事总览.大臣记事[this.记事编号][this.视角编号];
                break;
            case 记事类型.家眷记事:
                break;
        }
        return 年号 + 年 + "年" + 月 + "月," + 记事替换(result, this.替换名);
    }
    private string 记事替换(string 记事, Dictionary<int, string> replacements)
    {
        string result = Regex.Replace(记事, @"\[(\d+)\]", match => {
            int index;
            //Debug.Log(match.Groups[1].Value);
            if (int.TryParse(match.Groups[1].Value, out index) && replacements.TryGetValue(index, out string replacement))
            {
                //Debug.Log("hahaha");
                return replacement;
            }
            return match.Value;
        });
        Debug.Log(result);
        return result;
    }

}

public class 记事管理
{
    public GameObject 记事一览翻页版;
    public GameObject 记事一览滚动版;
    public List<记事> 大臣大事 = new List<记事>();
    public List<记事> 后宫大事 = new List<记事>();
    public List<记事> 青楼大事 = new List<记事>();
    public List<记事> 彤史 = new List<记事>();
    #region 单例模式
    public static 记事管理 instance;
    public static 记事管理 Instance
    {
        get
        {
            //保证对象的唯一性
            if (instance == null)
            {
                instance = new 记事管理();
            }
            return instance;
        }
    }
    #endregion
    public void 大臣记事总览()
    {
        GameObject instance = UI相关.实例化(记事一览翻页版);
        翻页版记事一览UI管理 UI = instance.GetComponent<翻页版记事一览UI管理>();
        UI.所有记事 = 大臣大事;
    }
    public void 后宫记事总览()
    {
        GameObject instance = UI相关.实例化(记事一览翻页版);
        翻页版记事一览UI管理 UI = instance.GetComponent<翻页版记事一览UI管理>();
        UI.所有记事 = 后宫大事;
    }
    public void 青楼记事总览()
    {
        GameObject instance = UI相关.实例化(记事一览翻页版);
        翻页版记事一览UI管理 UI = instance.GetComponent<翻页版记事一览UI管理>();
        UI.所有记事 = 青楼大事;
    }
    #region 大臣社交记事
    private void 大臣社交记事一()
    {
        List<大臣> 随机大臣列表 = new List<大臣>();
        for (int i = 0; i < NPCManager.Instance.大臣列表.Count; i++)
        {
            大臣 kk = (大臣)NPCManager.Instance.所有人物[NPCManager.Instance.大臣列表[i]];
            if (kk.死亡判断 == false && kk.性别 == "男" && kk.入仕时长 == 0 && kk.来源 == "科举")
            {
                if (家族管理.Instance.所有家族.ContainsKey(kk.家族) && 家族管理.Instance.所有家族[kk.家族].所属派系==-1)
                    随机大臣列表.Add(kk);
            }
        }
        if (随机大臣列表.Count <= 0) return;
        大臣 大臣 = 随机大臣列表[UnityEngine.Random.Range(0, 随机大臣列表.Count)];
        随机大臣列表 = new List<大臣>();
        for (int i = 0; i < NPCManager.Instance.大臣列表.Count; i++)
        {
            大臣 kk = (大臣)NPCManager.Instance.所有人物[NPCManager.Instance.大臣列表[i]];
            if (kk.死亡判断 == false && kk.编号 != 大臣.编号 && kk.性别 == "男" && kk.姓 == 大臣.姓 && (kk.出身啊 != 大臣.出身啊 || kk.籍贯 != 大臣.籍贯) && kk.年龄 >= 大臣.年龄 + 10 && kk.功勋 > 2500 && kk.性别 == "男" && kk.城市 == 大臣.城市)
            {
                if (家族管理.Instance.所有家族.ContainsKey(kk.家族) && 家族管理.Instance.所有家族[kk.家族].所属派系 != -1)
                    随机大臣列表.Add(kk);
            }
        }
        if(随机大臣列表.Count <= 0) return;   
        大臣 长辈 = 随机大臣列表[UnityEngine.Random.Range(0, 随机大臣列表.Count)];
        if (长辈.清廉 < 80 && 游戏设定.Instance.党派跳槽 == 1)
        {
            大臣大事.Add(new 记事(记事类型.大臣记事,1,0,new Dictionary<int, string> { { 0, 大臣.职务 + 大臣.爵位 + UI相关.颜色代码(大臣.姓+大臣.名 ,"ff0000")},{1, 长辈.职务 + 长辈.爵位 + "" +UI相关.颜色代码(长辈.姓+长辈.名, "5f5ffc") },{ 2, 长辈.姓+长辈.名 } }));
            长辈.记事.Add(new 记事(记事类型.大臣记事,1,1,new Dictionary<int, string> { { 0, 大臣.职务 + 大臣.爵位 + 大臣.姓+大臣.名} }));
            大臣.记事.Add(new 记事(记事类型.大臣记事, 1, 2, new Dictionary<int, string> { {0, 长辈.职务 + 长辈.爵位 + 长辈.姓+长辈.名 },{1,长辈.姓+长辈.名 } }));
            家族管理.Instance.所有家族[大臣.家族].所属派系 = 家族管理.Instance.所有家族[长辈.家族].所属派系;
            派系管理.Instance.所有派系[家族管理.Instance.所有家族[大臣.家族].所属派系].成员家族.Add(大臣.家族);
            大臣.所属党派 = 长辈.所属党派;
        }
        else
        {
            大臣大事.Add(new 记事(记事类型.大臣记事, 1, 3, new Dictionary<int, string> { { 0, 大臣.职务 + 大臣.爵位 + UI相关.颜色代码(大臣.姓 + 大臣.名, "ff0000") }, { 1, 长辈.职务 + 长辈.爵位 + "" + UI相关.颜色代码(长辈.姓 + 长辈.名, "5f5ffc") }, { 2, 长辈.姓 + 长辈.名 } }));
            长辈.记事.Add(new 记事(记事类型.大臣记事, 1,4, new Dictionary<int, string> { { 0, 大臣.职务 + 大臣.爵位 + 大臣.姓 + 大臣.名 } }));
            大臣.记事.Add(new 记事(记事类型.大臣记事, 1,5, new Dictionary<int, string> { { 0, 长辈.职务 + 长辈.爵位 + 长辈.姓 + 长辈.名 }}));
        }
    }
    private void 大臣社交记事二()
    {
        List<大臣> 随机大臣列表 = new List<大臣>();
        for (int i = 0; i < NPCManager.Instance.大臣列表.Count; i++)
        {
            大臣 kk = (大臣)NPCManager.Instance.所有人物[NPCManager.Instance.大臣列表[i]];
            if (kk.死亡判断 == false && kk.性别 == "男" && kk.年龄 >= 14)
            {
                随机大臣列表.Add(kk);
            }
        }
        if (随机大臣列表.Count <= 0) return;
        大臣 大臣 = 随机大臣列表[UnityEngine.Random.Range(0, 随机大臣列表.Count)];
        随机大臣列表 = new List<大臣>();
        for (int i = 0; i < NPCManager.Instance.大臣列表.Count; i++)
        {
            大臣 kk = (大臣)NPCManager.Instance.所有人物[NPCManager.Instance.大臣列表[i]];
            if (kk.姓!=大臣.姓&&kk.死亡判断 == false && kk.性别 == "男" && kk.所属党派 == 大臣.所属党派 && kk.编号 != 大臣.编号)
            {
                if ((kk.年龄 >= 大臣.年龄 - 5 && kk.年龄 <= 大臣.年龄 + 5))
                {
                    随机大臣列表.Add(kk);
                }
            }
        }
        if (随机大臣列表.Count <= 0) return;
        大臣 野生大臣 = 随机大臣列表[UnityEngine.Random.Range(0, 随机大臣列表.Count)];
        随机大臣列表 = new List<大臣>();
        for (int i = 0; i < NPCManager.Instance.大臣列表.Count; i++)
        {
            大臣 kk = (大臣)NPCManager.Instance.所有人物[NPCManager.Instance.大臣列表[i]];
            if (kk.姓!=大臣.姓&&kk.姓!=野生大臣.姓&&kk.死亡判断 == false && kk.性别 == "男" && kk.所属党派 == 大臣.所属党派 && kk.编号 != 大臣.编号 && kk.编号 != 野生大臣.编号)
            {
                if ((kk.年龄 >= 大臣.年龄 - 5 && kk.年龄 <= 大臣.年龄 + 5))
                {
                    随机大臣列表.Add(kk);
                }
            }
        }
        if (随机大臣列表.Count <= 0) return;
        大臣 野生大臣啊 = 随机大臣列表[UnityEngine.Random.Range(0, 随机大臣列表.Count)];
        if (野生大臣啊 != null && 野生大臣 != null && 大臣 != null)
        {
            大臣大事.Add(new 记事(记事类型.大臣记事, 2, 0, new Dictionary<int, string>{
                { 0, 野生大臣.职务 + 野生大臣.爵位 + UI相关.颜色代码(野生大臣.姓 + 野生大臣.名, "5f5ffc") },
                { 1, 大臣.职务 + 大臣.爵位 + UI相关.颜色代码(大臣.姓 + 大臣.名, "5f5ffc") },
                { 2, 野生大臣啊.职务 + 野生大臣啊.爵位 + UI相关.颜色代码(野生大臣啊.姓 + 野生大臣啊.名, "5f5ffc") 
                }}));

            大臣.记事.Add(new 记事(记事类型.大臣记事, 2, 1, new Dictionary<int, string>{
                { 0, 野生大臣.姓 + 野生大臣.名 },
                { 1, 野生大臣啊.姓 + 野生大臣啊.名 }}));

            野生大臣.记事.Add(new 记事(记事类型.大臣记事, 2, 1, new Dictionary<int, string>{
                { 0, 大臣.姓 + 大臣.名 },
                { 1, 野生大臣啊.姓 + 野生大臣啊.名 }}));

            野生大臣啊.记事.Add(new 记事(记事类型.大臣记事, 2, 1, new Dictionary<int, string>{
                { 0, 大臣.姓 + 大臣.名 },
                { 1, 野生大臣.姓 + 野生大臣.名 }}));
        }
    }
    private void 大臣社交记事三()
    {
        List<大臣> 随机大臣列表 = new List<大臣>();
        for (int i = 0; i < NPCManager.Instance.大臣列表.Count; i++)
        {
            大臣 kk = (大臣)NPCManager.Instance.所有人物[NPCManager.Instance.大臣列表[i]];
            if (kk.死亡判断 == false && kk.性别 == "男" && kk.年龄 >= 14)
            {
                随机大臣列表.Add(kk);
            }
        }
        if (随机大臣列表.Count <= 0) return;
        大臣 大臣 = 随机大臣列表[UnityEngine.Random.Range(0, 随机大臣列表.Count)];

        随机大臣列表 = new List<大臣>();
        for (int i = 0; i < NPCManager.Instance.大臣列表.Count; i++)
        {
            大臣 kk = (大臣)NPCManager.Instance.所有人物[NPCManager.Instance.大臣列表[i]];
            if (kk.死亡判断 == false && kk.编号 != 大臣.编号 && kk.性别 == "男" && kk.丧妻对象恩爱值 >= 80 && kk.性取向 == 1 && kk.伴侣 == -1)
            {
                if (kk.年龄 >= 大臣.年龄 - 5 && kk.年龄 <= 大臣.年龄 + 5)
                {
                    随机大臣列表.Add(kk);
                }
            }
        }
        if (随机大臣列表.Count <= 0) return;
        大臣 野生大臣 = 随机大臣列表[UnityEngine.Random.Range(0, 随机大臣列表.Count)];

        if (野生大臣 != null && 大臣 != null)
        {
            大臣大事.Add(new 记事(记事类型.大臣记事, 3, 0, new Dictionary<int, string>{
                { 0, 野生大臣.职务 + 野生大臣.爵位 + UI相关.颜色代码(野生大臣.姓 + 野生大臣.名, "5f5ffc") },
                { 1, 大臣.职务 + 大臣.爵位 + UI相关.颜色代码(大臣.姓 + 大臣.名, "5f5ffc") },
                { 2, 野生大臣.姓+野生大臣.名 },
                { 3, 野生大臣.丧妻对象 + UI相关.颜色代码(野生大臣.丧妻对象, "ff0000") }
            }));

            大臣.记事.Add(new 记事(记事类型.大臣记事, 3, 1, new Dictionary<int, string>{
                { 0, 野生大臣.姓 + 野生大臣.名 },
                { 1, 野生大臣.丧妻对象 }
            }));

            野生大臣.记事.Add(new 记事(记事类型.大臣记事, 3, 2, new Dictionary<int, string>{
                { 0, 大臣.姓 + 大臣.名 },
                { 1, 野生大臣.丧妻对象 }
            }));
        }
    }
    private void 大臣社交记事四()
    {
        List<大臣> 随机大臣列表 = new List<大臣>();
        for (int i = 0; i < NPCManager.Instance.大臣列表.Count; i++)
        {
            大臣 kk = (大臣)NPCManager.Instance.所有人物[NPCManager.Instance.大臣列表[i]];
            if (kk.死亡判断 == false && kk.年龄 >= 14 && kk.来源 == "科举" && kk.入仕时长 < 5 && kk.诗 >= 80)
            {
                随机大臣列表.Add(kk);
            }
        }
        if (随机大臣列表.Count <= 0) return;
        大臣 大臣 = 随机大臣列表[UnityEngine.Random.Range(0, 随机大臣列表.Count)];

        随机大臣列表 = new List<大臣>();
        for (int i = 0; i < NPCManager.Instance.大臣列表.Count; i++)
        {
            大臣 kk = (大臣)NPCManager.Instance.所有人物[NPCManager.Instance.大臣列表[i]];
            if (kk.死亡判断 == false && kk.清廉 < 50 && kk.所属党派 != 大臣.所属党派 && kk.编号 != 大臣.编号)
            {
                随机大臣列表.Add(kk);
            }
        }
        if (随机大臣列表.Count <= 0) return;
        大臣 野生大臣 = 随机大臣列表[UnityEngine.Random.Range(0, 随机大臣列表.Count)];

        if (野生大臣 != null && 大臣 != null)
        {
            大臣大事.Add(new 记事(记事类型.大臣记事, 4, 0, new Dictionary<int, string>{
                { 0, 野生大臣.职务 + 野生大臣.爵位 + UI相关.颜色代码(野生大臣.姓 + 野生大臣.名, "5f5ffc") },
                { 1, 大臣.职务 + 大臣.爵位 + UI相关.颜色代码(大臣.姓 + 大臣.名, "5f5ffc") }
            }));

            大臣.记事.Add(new 记事(记事类型.大臣记事, 4, 1, new Dictionary<int, string>{}));

            野生大臣.记事.Add(new 记事(记事类型.大臣记事, 4, 2, new Dictionary<int, string>{
                { 0, 大臣.职务 + 大臣.爵位 + 大臣.姓 + 大臣.名 }
            }));
        }
    }
    private void 大臣社交记事五()
    {
        List<大臣> 随机大臣列表 = new List<大臣>();
        for (int i = 0; i < NPCManager.Instance.大臣列表.Count; i++)
        {
            大臣 kk = (大臣)NPCManager.Instance.所有人物[NPCManager.Instance.大臣列表[i]];
            if (kk.死亡判断 == false  && kk.年龄 >= 14 && kk.功勋 < 2500 && kk.金钱 > 1000 && kk.城市 == 游戏设定.Instance.都城 && kk.职务 == "" && (kk.清廉 < 70 || kk.野心 >= 50))
            {
                随机大臣列表.Add(kk);
            }
        }
        if (随机大臣列表.Count <= 0) return;
        大臣 大臣 = 随机大臣列表[UnityEngine.Random.Range(0, 随机大臣列表.Count)];
        随机大臣列表 = new List<大臣>();
        for (int i = 0; i < NPCManager.Instance.大臣列表.Count; i++)
        {
            大臣 kk = (大臣)NPCManager.Instance.所有人物[NPCManager.Instance.大臣列表[i]];
            if (kk.死亡判断 == false && (kk.职务 == "吏部尚书" || kk.职务 == "丞相") && kk.清廉 <= 50 && kk.生日 == 时间体系.Instance.月 && kk.编号 != 大臣.编号)
            {
                随机大臣列表.Add(kk);
            }
        }
        if (随机大臣列表.Count <= 0) return;
        大臣 野生大臣 = 随机大臣列表[UnityEngine.Random.Range(0, 随机大臣列表.Count)];
        if (野生大臣 != null && 大臣 != null)
        {
            夫妻购物(野生大臣, 大臣, "求官");
        }
    }
    private void 夫妻购物(NPC 对象,NPC 大臣,string 特殊标记,NPC 野生对象 = null)
    {

    }
    public async Task 大臣社交记事()
    {
        Debug.Log("大臣社交记事开始");
        if (UnityEngine.Random.Range(0,5) == 0)
        {
            大臣社交记事一();
        }
        if(UnityEngine.Random.Range(0,50)==0)
        {
            大臣社交记事二();
        }
        if (UnityEngine.Random.Range(0,50)==0)
        {
            大臣社交记事三();
        }
        if(UnityEngine.Random.Range(0,50)==0)   大臣社交记事四();

        if (UnityEngine.Random.Range(0,50)==0)
        {
            大臣社交记事五();//疑似有bug。职务部分难以确定
        }
        await Task.Delay(1);
        Debug.Log("大臣社交记事结束");
    }
    #endregion
    public async Task 大臣个人的记事()
    {
        await Task.Delay(1);
    }

    public async Task 女大臣记事()
    {
        await Task.Delay(1);
    }
}