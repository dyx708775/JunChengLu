using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;
using System.Text;
using System;
using UnityEngine.UIElements;
using Unity.Properties;
[Serializable]
public class  位分
{
    public string 大位分名称;
    public string 品阶="从九品";
    public List<string>所有小位分 = new List<string>();
    public int 上限人数 = 99999;
    public int 已有人数 = 0;
    public 位分(string 大位分名称, string 品阶, List<string> 所有小位分, int 上限人数)
    {
        this.大位分名称 = 大位分名称;
        this.所有小位分 = 所有小位分;
        this.上限人数 = 上限人数;
        this.品阶 = 品阶;
    }

    public 位分() { }
}
public class 妃子 : NPC
{
    public string 宫斗罪名 = "";
    public int 任性 = 0;
    public int 朝廷势力 = 0;
    public int 欲望 = 5;
    public int 生育 = 0;
    public bool 疯癫 = false;
    public int 妃子品阶=-1;
    public int 小位分 = 0;
    public int 宫殿编号=-1;
    public int 宫殿类型=-1;
    public int 房间编号=-1;
    [NonSerialized]public Sprite 房间图;
    public string 房间图地址;
    public string 位分;
    //public string 封号;
    public int 宠 = 0;
    public int 爱 = 0;
    public int 入宫时长 = 0;
    public int 禁足=0;
    public int 省亲 = 0;
    public string 自称1 = "臣妾";
    public int 主子啊 = -1;
    public int 罚俸 = 0;
    public int 临幸 = 0;
    public int 经验啊 = 0;
    public int 太后好感度=0;
    public int 避 = 0;
    public int 孕啊 = 0;//偷情怀孕用
    public int 天降 = 0;
    public List<int> 宫女列表 = new List<int>();
    public override void Initialize(string 类型, string type, int id)
    {
        base.Initialize(类型,type,id);
        年龄 = UnityEngine.Random.Range(游戏设定.Instance.最小选秀年龄, 游戏设定.Instance.最大选秀年龄+1);
        随机立绘();
        房间图地址 = "azcPic_Gong_Li\\" + UnityEngine.Random.Range(1,33)+".jpg";
        房间图 = UI相关.加载本地图片(房间图地址);
        宠 = UnityEngine.Random.Range(40,100);
        经验 = 宠 / (UnityEngine.Random.Range(10, 20));
        爱 = 宠;
        //位份 = 数据库.所有位分[UnityEngine.Random.Range(1, 数据库.所有位分.Count)].所有小位分[0];
        封号 = 姓;
        int 随机 = UnityEngine.Random.Range(0, 100);
        if (随机 > 90)
        {
            //状态 = "孕";
            孕 = 1;
        }
        else
        {
            //状态 = "正常";
            孕 = 0;
        }
        太后好感度 = UnityEngine.Random.Range(0, 100);
    }

    public void 妃子入掖庭()
    {

    }
    public void 打入冷宫去吧()
    {

    }

    public override void 怀孕判定()
    {
        base.怀孕判定();
        int 高位 = 游戏设定.Instance.高位妃;
        if (UnityEngine.Random.Range(0, 5) == 0 &&夫妻恩爱值 >= 60 && 性别 == "女" && 临幸 != 0 && 疯癫 != true)
        {
            承宠记事();
        }
        if (UnityEngine.Random.Range(0, 15) == 0 && 临幸 != 0 && 疯癫 != true && 房中术 <= 25)
        {
            int 随机 = UnityEngine.Random.Range(0, 2);
            记事.Add(new 记事(记事类型.妃子记事, 10, 随机, null));
            记事管理.Instance.后宫大事.Add(new 记事(记事类型.妃子记事, 10, 2, new Dictionary<int, string> { { 1, UI相关.颜色代码(封号 + 位分, "5f5ffc") + UI相关.颜色代码(姓 + 名, "ff0000") } }));
            宠 -= 1;
        }
        else if (UnityEngine.Random.Range(0, 15) == 0 && 房中术 > 25 && 房中术 < 50 && 临幸 != 0 && 疯癫 != true)
        {
            if (UnityEngine.Random.Range(0, 10) == 0)
            {
                记事管理.Instance.后宫大事.Add(new 记事(记事类型.妃子记事, 10, 3, new Dictionary<int, string> { { 1, UI相关.颜色代码(封号 + 位分, "5f5ffc") + UI相关.颜色代码(姓 + 名, "ff0000") } }));
                记事.Add(new 记事(记事类型.妃子记事, 10, 4, null));
                宠 += 2;
                金钱 += 100;
            }
            else
            {
                记事管理.Instance.后宫大事.Add(new 记事(记事类型.妃子记事, 10, 2, new Dictionary<int, string> { { 1, UI相关.颜色代码(封号 + 位分, "5f5ffc") + UI相关.颜色代码(姓 + 名, "ff0000") } }));
                记事.Add(new 记事(记事类型.妃子记事, 10, 5, null));
                宠 -= 1;
            }
        }
        else if (UnityEngine.Random.Range(0, 15) == 0 && 房中术 >= 50 && 临幸 != 0 && 疯癫 != true)
        {
            记事管理.Instance.后宫大事.Add(new 记事(记事类型.妃子记事, 10, 6, new Dictionary<int, string> { { 1, UI相关.颜色代码(封号 + 位分, "5f5ffc") + UI相关.颜色代码(姓 + 名, "ff0000") } }));
            宠 += 4;
            金钱 += 300;
            int 随机 = UnityEngine.Random.Range(0, 2);
            if (随机 == 0) 记事.Add(new 记事(记事类型.妃子记事, 10, 7, null));
            else 记事.Add(new 记事(记事类型.妃子记事, 10, 8, null));
        }
        if (宫殿类型 != -1 && 宫殿编号 != -1) 避 = 宫殿管理.Instance.已建宫殿[宫殿类型][宫殿编号].避孕;
        if (游戏设定.Instance.宠爱判定 == 1)
        {
            宠 += 游戏设定.Instance.宠爱判定 + UnityEngine.Random.Range(0, 5);
            for (int i = 0; i < NPCManager.Instance.妃子列表.Count; i++)
            {
                int 妃子编号 = NPCManager.Instance.妃子列表[i];
                妃子 妃子 = (妃子)NPCManager.Instance.所有人物[妃子编号];
                if (妃子编号 != this.编号 && 妃子.孕 == 0) 妃子.宠 -= (1 + UnityEngine.Random.Range(0, 2));
            }
        }
        float _loc9_ = 0.5f;
        int _loc3_ = 0;
        float 武力 = 0.5f;
        临幸 += 1; 经验 += 1;
        if (夫妻恩爱值 < 100 && 夫妻恩爱值 >= 50) _loc9_ = 0.8f;
        else if (夫妻恩爱值 > 100) _loc9_ = 1f;
        if (this.武力 >= 40 && this.武力 <= 80) 武力 = 0.8f;
        else if (this.武力 > 80) 武力 = 1f;
        if(孕==0&&病==0)
        {
            记事.Add(new 记事(记事类型.妃子记事, 10, 9, null));
            if(宫殿类型!=-1&&宫殿编号!=-1&&房间编号!=-1)
            记事管理.Instance.后宫大事.Add(new 记事(记事类型.妃子记事, 10, 10, new Dictionary<int, string> { {1,主控.Instance.姓+主控.Instance.名 },{ 2, 宫殿管理.Instance.已建宫殿[宫殿类型][宫殿编号].房间名[房间编号]+UI相关.颜色代码(封号 + 位分, "5f5ffc") + UI相关.颜色代码(姓 + 名, "ff0000") } }));
            经验啊 += 1;
            _loc3_ = Mathf.RoundToInt(_loc9_ * 武力 * 主控.Instance.生育能力 / 10 * 孕率 * ((100 - 年龄) / 100) * ((100 - 年龄) / 100));
        }
        if(主控.Instance.孩子.Count<350&&主控.Instance.性别=="女"&&生育能力>0&&主控.Instance.孕==0)
        {
            float 概率 = Mathf.Round(主控.Instance.孕率 * 生育能力 * 0.1f * ((100f - 年龄 / 2) / 100f) * ((100f - 年龄 / 2) / 100f));
            int 随机 = UnityEngine.Random.Range(0, 250);
            if (概率 > 随机)
            {
                主控.Instance.孕 = 10;
                主控.Instance.孩子父亲 = 编号;
                string _loc8_ = "恭喜陛下，您有喜了。";
                //太监报告所有事件.push([_loc8_, "快乐", 5, 26, 0]);
                
            }
        }
        else if(主控.Instance.性别=="男")
        {
            int 会不会怀孕 = 0;
            #region 太后送避孕药
            List<太妃> 随机太后列表 = new List<太妃>();
            for (int i = 0; i < NPCManager.Instance.太妃列表.Count; i++)
            {
                int 太后编号 = NPCManager.Instance.太妃列表[0];
                太妃 太后 = (太妃)NPCManager.Instance.所有人物[太后编号];
                if (太后.妃子品阶 == 0)
                    随机太后列表.Add(太后);
            }
            if (随机太后列表.Count > 0 && 剧情管理.Instance.太后诏书 != -1)
            {
                妃子 皇后 = (妃子)NPCManager.Instance.所有人物[剧情管理.Instance.太后诏书];
                太妃 太后 = 随机太后列表[UnityEngine.Random.Range(0,随机太后列表.Count)];
                if (孕 == 0 && 性别 == "女" && 妃子品阶 != 0 && 编号!=剧情管理.Instance.太后诏书)
                {
                    记事.Add(new 记事(记事类型.妃子记事, 10, 11, new Dictionary<int, string> { { 1,太后.封号+太后.位分+太后.名称} }));
                    if(夫妻恩爱值 - 太后好感度 < 10)
                    {
                        记事.Add(new 记事(记事类型.妃子记事, 10, 12,null));
                        避 = 1;
                    }
                    else
                    {
                        记事.Add(new 记事(记事类型.妃子记事, 10, 13, null));
                    }
                }
            }
            #endregion
            if (孕啊 >= 8 && 孕啊 <= 10 && 性别 == "女" && 孩子父亲 != 主控.Instance.编号 && 病 == 0 && 孕 == 0)
            {
                孕 = 10;
                记事.Add(new 记事(记事类型.妃子记事, 10, 14, null));
                if(游戏设定.Instance.宠爱判定==1)
                {
                    宠 += 游戏设定.Instance.恩宠设定 * 2 + UnityEngine.Random.Range(0, 5);
                }
            }
            else if (UnityEngine.Random.Range(0, 500) == 0 && 避 == 0 && 称呼 != "张贵妃" && 孩子父亲 == -1 && 称呼 != "曹皇后" && 主控.Instance.名称 != "赵祯" && 孕啊 == 0 && 孕 == 0 && 病 == 0 && 儿子数量 <= 0 && 性别 == "女" && (清廉 < 50 && 野心 >= 50))
            {
                孕 = 10;
                孩子父亲 = -1;
                记事.Add(new 记事(记事类型.妃子记事, 10, 15, null));
                if (游戏设定.Instance.宠爱判定 == 1) 宠 += 游戏设定.Instance.恩宠设定 * 2 + UnityEngine.Random.Range(0, 5);
            }
            else if(年龄>13&&孕==0)
            {
                会不会怀孕 = 0;
                if(性别=="女")
                {
                    if (孕率 == 0 || 疯癫 == true) 会不会怀孕 = 1;
                    妃子 妃子 = 剧情总览.Instance.避子汤判断(this);
                    if(妃子!=null)
                    {
                        会不会怀孕 = 0;
                        if (妃子.宫女列表.Count > 0)
                        {
                            int 随机 = UnityEngine.Random.Range(0, 4);
                            记事.Add(new 记事(记事类型.妃子记事, 10, 16 + 随机, new Dictionary<int, string> { { 1, 妃子.封号 + 妃子.位分 + 妃子.名称 }, { 2, NPCManager.Instance.所有人物[妃子.宫女列表[0]].名称 } }));
                        }
                        else
                        {
                            int 随机 = UnityEngine.Random.Range(0, 4);
                            记事.Add(new 记事(记事类型.妃子记事, 10, 20 + 随机, new Dictionary<int, string> { { 1, 妃子.封号 + 妃子.位分 + 妃子.名称 } }));
                        }
                    }
                    else if (UnityEngine.Random.Range(0,5)==0&&夫妻恩爱值<30&&性取向==1)
                    {
                        会不会怀孕 = 0;
                        记事.Add(new 记事(记事类型.妃子记事,10,24,null));
                       
                    }
                    else if(UnityEngine.Random.Range(0,10)==0&&夫妻恩爱值<30&&性取向==0)
                    {
                        会不会怀孕 = 0;
                        记事.Add(new 记事(记事类型.妃子记事, 10, 24, null));
                    }
                    else { 会不会怀孕 =  UnityEngine.Random.Range(0,_loc3_);}
                }
                else if(性别=="男")
                {
                    if (年龄 < 50 && 避 != 1 && 孕 == 0 && 病 == 0 && 游戏设定.Instance._con_tianjiang >= 1)
                    {
                        游戏设定.Instance._con_tianjiang = 0;
                        孕 = 10;
                        天降 = 1;
                        孩子父亲 = 主控.Instance.编号;
                        主控.Instance.妃子怀孕 = 1;
                        剧情总览.Instance.男宠腹中有胎像(this);
                        记事.Add(new 记事(记事类型.妃子记事, 10, 25, null));
                        if (游戏设定.Instance.宠爱判定 == 1)
                        {
                            宠 += 游戏设定.Instance.恩宠设定 * 2 + UnityEngine.Random.Range(0, 5);
                        }
                    }
                    else if (年龄 < 50 && 孕率 > 0 && 年龄 > 13 && 病 == 0 && 疯癫 != true && 避 != 1 && 孕 == 0)
                    {
                        if(_loc3_>UnityEngine.Random.Range(0,100))
                        {
                            孕 = 10;
                            仙 = 0;
                            孩子父亲 = 主控.Instance.编号;
                            记事.Add(new 记事(记事类型.妃子记事, 10, 25, null));
                            if (游戏设定.Instance.宠爱判定 == 1) 宠 += 游戏设定.Instance.宠爱判定 * 2 + UnityEngine.Random.Range(0, 5);
                        }
                    }
                    else
                    {
                        会不会怀孕 = 0;
                    }
                }
            }
            else
            {
                会不会怀孕 = 100;
            }
            if (数据库.所有技术[20].开启==1&&孕==0)
            {
                int 结果 = UnityEngine.Random.Range(0, 70);
                if(游戏设定.Instance.宋仁宗模式==1&&主控.Instance.名称=="赵祯")
                {
                    结果 = 剧情总览.Instance.宋仁宗怀孕判断(this,结果);
                }
                if(避==0&&会不会怀孕>结果)
                {
                    主控.Instance.妃子怀孕 = 1;
                    if (年龄 < 50 && 性别 == "女" && 年龄 > 13 && 疯癫 != true && 孕 == 0 && 病 == 0 && 孕 == 0)
                    {
                        孕 = 10;
                        仙 = 0;
                        孩子父亲 = 主控.Instance.编号;
                        记事.Add(new 记事(记事类型.妃子记事, 10, 25, null));
                        if (游戏设定.Instance.宠爱判定 == 1) 宠 += 游戏设定.Instance.宠爱判定 * 2 + UnityEngine.Random.Range(0, 5); 
                    }
                    else if (年龄 < 50 && 性别 == "男" && 年龄 > 13 && 孕率 > 0 && 疯癫 != true && 孕 == 0 && 避 == 0 && 病 == 0) 
                    {
                        孕 = 10;
                        孩子父亲 = 主控.Instance.编号;
                        记事.Add(new 记事(记事类型.妃子记事, 10, 25, null));
                        if (游戏设定.Instance.宠爱判定 == 1) 宠 += 游戏设定.Instance.宠爱判定 * 2 + UnityEngine.Random.Range(0, 5);
                    }
                }
            }
            else if(孕==0&&病==0)
            {
                int 结果 = UnityEngine.Random.Range(0, 150);
                if(游戏设定.Instance.宋仁宗模式==1&&主控.Instance.名称=="赵祯")
                {
                    结果 = 剧情总览.Instance.宋仁宗怀孕判断(this, 结果);
                }
                if(会不会怀孕>结果&&避==0)
                {
                    主控.Instance.妃子怀孕 = 1;
                    if (年龄 < 50 && 性别 == "女" && 年龄 > 13 && 疯癫 != true && 孕 == 0 && 病 == 0 && 孕 == 0)
                    {
                        孕 = 10;
                        仙 = 0;
                        孩子父亲 = 主控.Instance.编号;
                        记事.Add(new 记事(记事类型.妃子记事, 10, 25, null));
                        if (游戏设定.Instance.宠爱判定 == 1) 宠 += 游戏设定.Instance.宠爱判定 * 2 + UnityEngine.Random.Range(0, 5);
                    }
                    else if (年龄 < 50 && 性别 == "男" && 年龄 > 13 && 孕率 > 0 && 疯癫 != true && 孕 == 0 && 避 == 0 && 病 == 0)
                    {
                        孕 = 10;
                        孩子父亲 = 主控.Instance.编号;
                        记事.Add(new 记事(记事类型.妃子记事, 10, 25, null));
                        if (游戏设定.Instance.宠爱判定 == 1) 宠 += 游戏设定.Instance.宠爱判定 * 2 + UnityEngine.Random.Range(0, 5);
                    }
                }
            }
        }
        #region 侍寝后其他妃子反应
        List<妃子> 随机妃子列表 = new List<妃子>();
        for (int i = 0; i < NPCManager.Instance.妃子列表.Count; i++)
        {
            int 妃子编号 = NPCManager.Instance.妃子列表[i];
            妃子 妃子 = (妃子)NPCManager.Instance.所有人物[妃子编号];
            if (妃子.编号 != 编号 && 妃子.省亲 == 0) 随机妃子列表.Add(妃子);
        }
        if(随机妃子列表.Count>0&&主控.Instance.性别=="男")
        {
            妃子 妃子 = 随机妃子列表[UnityEngine.Random.Range(0, 随机妃子列表.Count)];
            int 随机 = UnityEngine.Random.Range(0, 20);
            if (随机 == 0 && 妃子.夫妻恩爱值 >= 30) 妃子.记事.Add(new 记事(记事类型.妃子记事, 11, 0, new Dictionary<int, string> { { 1, 封号 + 位分 + 名称 } }));
            else if(随机==1&&妃子.清廉>=80) 妃子.记事.Add(new 记事(记事类型.妃子记事, 11, 1, new Dictionary<int, string> { { 1, 封号 + 位分 + 名称 } }));
            else if (随机 == 2 && 妃子.智力 >= 70 && 妃子.房间编号 != -1 && 妃子.宫殿类型 != -1 && 妃子.宫殿编号 != -1)
            {
                妃子.记事.Add(new 记事(记事类型.妃子记事, 11, 2, new Dictionary<int, string> { { 1, 封号 + 位分 + 名称 },{ 2, 宫殿管理.Instance.已建宫殿[妃子.宫殿类型][妃子.宫殿编号].房间名[妃子.房间编号] } }));
            }
            else if(随机==3&&妃子.夫妻恩爱值>=50&&妃子.清廉>=50&&妃子.经验啊>10&&妃子.入宫时长>1)
            {
                妃子.记事.Add(new 记事(记事类型.妃子记事, 11, 3, new Dictionary<int, string> { { 1, 封号 + 位分 + 名称 } }));
            }
            else if(随机==4&&妃子.性情编号!=0&&妃子.夫妻恩爱值>50&&妃子.清廉<50&&妃子.妃子品阶<妃子品阶&&妃子.后宫派系!=后宫派系)
            {
                妃子.记事.Add(new 记事(记事类型.妃子记事, 11, 4, new Dictionary<int, string> { { 1, 封号 + 位分 + 名称 }, { 2, 宫殿管理.Instance.已建宫殿[妃子.宫殿类型][妃子.宫殿编号].房间名[妃子.房间编号] } }));
                if (妃子.宫女列表.Count > 0)
                {
                    NPC 宫女 = NPCManager.Instance.所有人物[UnityEngine.Random.Range(0,妃子.宫女列表.Count)];
                    宫女.记事.Add(new 记事(记事类型.妃子记事,11,5,new Dictionary<int, string>() { { 1, 封号 + 位分 + 名称 },{ 2, 妃子.封号 + 妃子.位分 + 妃子.名称 } }));
                }
            }
            else if (随机 == 5 && 妃子.夫妻恩爱值 >= 50 && (妃子.性情编号 == 1 || 妃子.性情编号 == 3 || 妃子.性情编号 == 4))
            {
                妃子.记事.Add(new 记事(记事类型.妃子记事, 11, 6, new Dictionary<int, string> { { 1, 封号 + 位分 + 名称 } }));
            }
            else if (随机 == 6 && 妃子.后宫派系 == 后宫派系 && (妃子.性情编号 == 0 || 妃子.性情编号 == 2 || 妃子.性情编号 == 4 || 妃子.性情编号 == 5))
            {
                string 小吃名称 = 数据库.小吃[UnityEngine.Random.Range(0, 数据库.小吃.Length)];
                妃子.记事.Add(new 记事(记事类型.妃子记事, 11, 7, new Dictionary<int, string> { { 1, 封号 + 位分 + 名称 }, { 2, 小吃名称 } }));
                if (妃子.宫女列表.Count > 0)
                {
                    NPC 宫女 = NPCManager.Instance.所有人物[UnityEngine.Random.Range(0, 妃子.宫女列表.Count)];
                    宫女.记事.Add(new 记事(记事类型.妃子记事, 11, 8, new Dictionary<int, string> { { 1, 封号 + 位分 + 名称 }, { 2, 妃子.封号 + 妃子.位分 + 妃子.名称 } }));
                }
                妃子.体重 += UnityEngine.Random.Range(0, 3);
            }
            else if (随机 == 7 && 妃子.夫妻恩爱值 < 70 && (妃子.性情编号 == 0 || 妃子.性情编号 == 1 || 妃子.性情编号 == 3 || 妃子.性情编号 == 4))
            {
                妃子.记事.Add(new 记事(记事类型.妃子记事, 11, 9, new Dictionary<int, string> { { 1, 封号 + 位分 + 名称 } }));
            }
            else if (随机 == 8 && 妃子.夫妻恩爱值 < 30)
            {
                妃子.记事.Add(new 记事(记事类型.妃子记事, 11, 10, new Dictionary<int, string> { { 1, 封号 + 位分 + 名称 } }));
            }
            else if (随机 == 9 && 妃子.夫妻恩爱值 > 90)
            {
                妃子.记事.Add(new 记事(记事类型.妃子记事, 11, 11, new Dictionary<int, string> { { 1, 封号 + 位分 + 名称 } }));
                if (妃子.宫女列表.Count > 0)
                {
                    NPC 宫女 = NPCManager.Instance.所有人物[UnityEngine.Random.Range(0, 妃子.宫女列表.Count)];
                    宫女.记事.Add(new 记事(记事类型.妃子记事, 11, 12, new Dictionary<int, string> { { 1, 封号 + 位分 + 名称 }, { 2, 妃子.封号 + 妃子.位分 + 妃子.名称 } }));
                }
            }
            else if (随机 == 9 && 妃子.夫妻恩爱值 < 60)
            {
                妃子.记事.Add(new 记事(记事类型.妃子记事, 11, 13, new Dictionary<int, string> { { 1, 封号 + 位分 + 名称 } }));
            }
            else if (随机 == 10 && 妃子.孕 == 0 && 妃子.欲望 >= 7)
            {
                妃子.记事.Add(new 记事(记事类型.妃子记事, 11, 14, new Dictionary<int, string>()));
            }
            else if (随机 == 11 && 妃子.孕 > 0)
            {
                妃子.记事.Add(new 记事(记事类型.妃子记事, 11, 15, new Dictionary<int, string> { { 1, 封号 + 位分 + 名称 } }));
            }
            else if (随机 == 12 && 妃子.宫女列表.Count>0)
            {
                NPC 宫女 = new 宫女();
                if (妃子.宫女列表.Count > 0)
                {
                    宫女 = NPCManager.Instance.所有人物[UnityEngine.Random.Range(0, 妃子.宫女列表.Count)];
                    宫女.记事.Add(new 记事(记事类型.妃子记事, 11, 17, new Dictionary<int, string> { { 1, 封号 + 位分 + 名称 }, { 2, 妃子.封号 + 妃子.位分 + 妃子.名称 } }));
                }
                妃子.记事.Add(new 记事(记事类型.妃子记事, 11, 16, new Dictionary<int, string> { { 1, 封号 + 位分 + 名称 }, { 2, 宫女.名称 } }));
            }
            else if (随机 == 13 && 妃子.宫女列表.Count>0 && 妃子.夫妻恩爱值 >= 50 && 妃子.性情编号 != 5)
            {
                NPC 宫女 = new 宫女();
                if (妃子.宫女列表.Count > 0)
                {
                    宫女 = NPCManager.Instance.所有人物[UnityEngine.Random.Range(0, 妃子.宫女列表.Count)];
                    宫女.记事.Add(new 记事(记事类型.妃子记事, 11, 17, new Dictionary<int, string> { { 1, 封号 + 位分 + 名称 }, { 2, 妃子.封号 + 妃子.位分 + 妃子.名称 } }));
                }
                妃子.记事.Add(new 记事(记事类型.妃子记事, 11, 18, new Dictionary<int, string> { { 1, 封号 + 位分 + 名称 }, { 2, 宫女.名称 } }));
            }
            else if (随机 == 14 && 妃子.夫妻恩爱值 < 50 && 妃子.性情编号 != 5)
            {
                妃子.记事.Add(new 记事(记事类型.妃子记事, 11, 20, new Dictionary<int, string> { { 1, 封号 + 位分 + 名称 } }));
            }
            else if (随机 == 15 && 妃子.夫妻恩爱值 > 30 && 妃子.夫妻恩爱值 < 100)
            {
                妃子.记事.Add(new 记事(记事类型.妃子记事, 11, 21, new Dictionary<int, string> { { 1, 封号 + 位分 + 名称 } }));
            }
            else if (随机 == 16 && 妃子.心!= -1 && 妃子.心 != 主控.Instance.编号)
            {
                妃子.记事.Add(new 记事(记事类型.妃子记事, 11, 22, new Dictionary<int, string> { { 1, 封号 + 位分 + 名称 }, { 2, NPCManager.Instance.所有人物[妃子.心].名称 } }));
            }
        }
        if (宠 > 100) 宠 = 100;
        #endregion
        Debug.Log("完成怀孕判定");
    }

    public void 承宠记事()
    {

    }
    public override void 随机立绘()
    {
        立绘编号 = UnityEngine.Random.Range(0, 2000);
        立绘地址 = "a0aPic_FeiZi\\Tu_" + 立绘编号 + ".jpg";
        立绘 = UI相关.加载本地图片(立绘地址);
    }
    public void 加载宫殿图()
    {
        房间图 = UI相关.加载本地图片(房间图地址);
    }
    public override void 打开人物信息面板()
    {
        base.打开人物信息面板();
        string[] 功能按钮名称 = { "", "", "", "", "", "", "", "删除人物", "修改", "下一页" };
        string[] 查看信息按钮名称 = { "职务", "记事", "家眷" };
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
        buttons[7].onClick.AddListener(() =>删除人物(instance));
        查看信息按钮[1].onClick.AddListener(() => 查看记事());
        查看信息按钮[2].onClick.AddListener(() => 打开家眷面板());
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
        if(家族管理.Instance.所有家族.ContainsKey(家族))
        {
            家族 家族 = 家族管理.Instance.所有家族[this.家族];
            str.Append("\n家族总势力:" + 家族.总势力值.ToString("F1") + "  后宫势力" + 家族.后宫势力.ToString("F1") + "  朝廷势力:" + 家族.朝廷势力.ToString("F1"));
        }
        return str;
    }
    public void 初始化妃子信息面板()
    {
        string[] 功能按钮名称 = { "更换宫殿", "册封位分", "删除人物", "生成家族", "", "", "", "", "", "" };
        string[] 查看信息按钮名称 = { "职务", "记事", "家眷" };
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
        #region 添加按钮点击事件
        buttons[0].onClick.AddListener(() => 更换宫殿());
        buttons[1].onClick.AddListener(() => 册封("册封大位分",null));
        buttons[2].onClick.AddListener(() => 删除人物(instance));
        buttons[3].onClick.AddListener(() => 生成家族());
        查看信息按钮[1].onClick.AddListener(() => 查看记事());
        查看信息按钮[2].onClick.AddListener(() => 打开家眷面板());
        #endregion
    }

    public override void 打开家眷面板()
    {
        base.打开家眷面板();
    }

    public void 生成家族()
    {
        家族 妃子家族;
        
        string[] 所有性别 = { "男", "女" };
        int 孩子数量 = UnityEngine.Random.Range(0, 5);
        int 妃子编号 = 编号;
        妃子 妃子 = (妃子)NPCManager.Instance.所有人物[妃子编号];
        if (妃子.父亲 != -1)
        {
            UI相关.小提示("妃子的家族只可以生成一次哦~");
            return;
        }
        if (妃子编号 == 中间变量.Instance.太后妃子家族统一) { UI相关.小提示("该妃子是太后族亲，已有初始家族"); return; }
        if (!家族管理.Instance.所有家族.ContainsKey(妃子.家族))
        {
            妃子家族 = new 家族(妃子.家族);
            家族管理.Instance.所有家族[妃子.家族] = 妃子家族;
        }   
        else 妃子家族 = 家族管理.Instance.所有家族[妃子.家族];

        大臣 爸爸 = (大臣)NPCManager.Instance.创建随机人物("大臣", "男");
        爸爸.名 = 取名字字库.Instance.获取名(2, "男");
        爸爸.姓 = 妃子.姓; 爸爸.籍贯 = 妃子.籍贯; 爸爸.家族 = 妃子.家族;
        爸爸.年龄 = 妃子.年龄 + UnityEngine.Random.Range(20, 40);
        爸爸.孩子.Add(妃子.编号);
        爸爸.女儿数量 = 1;
        if (妃子.妃子品阶 <= 数据库.所有位分.Count / 3)
            官职管理.Instance.初始官职生成(爸爸, 1, 5);
        else if (妃子.妃子品阶 <= 数据库.所有位分.Count / 3 * 2)
            官职管理.Instance.初始官职生成(爸爸, 6, 10);
        else 官职管理.Instance.初始官职生成(爸爸, 6, 10);

        if (妃子.名.Length >= 2)
            妃子家族.女字辈.Add(2, new 字辈(字辈类型.第一个字, 妃子.名.Substring(0, 1)));
        if (爸爸.名.Length >= 2)
            妃子家族.男字辈.Add(1, new 字辈(字辈类型.第一个字, 爸爸.名.Substring(0, 1)));
        妃子家族.家族成员.Add(妃子.编号);
        妃子家族.家族成员.Add(爸爸.编号);
        妃子家族.后宫成员.Add(妃子.编号);
        妃子家族.朝廷成员.Add(爸爸.编号);
        妃子家族.族长编号 = 爸爸.编号;
        妃子家族.家族名 = 妃子.家族;
        妃子家族.后宫势力 += 派系管理.获取妃子势力值(妃子);
        妃子家族.朝廷势力 += 派系管理.获取官员势力值(爸爸);
        妃子家族.总势力值 = 妃子家族.后宫势力 + 妃子家族.朝廷势力;
        if (爸爸.伴侣 == -1)
        {
            家眷 母亲 = (家眷)NPCManager.Instance.创建随机人物("家眷", "女");
            母亲.年龄 = 爸爸.年龄 - UnityEngine.Random.Range(0, 3);
            母亲.随机立绘();
            爸爸.伴侣 = 母亲.编号;
        }
        妃子.母亲 = 爸爸.伴侣;
        妃子.父亲 = 爸爸.编号;

        int 妾室数量 = UnityEngine.Random.Range(0, 3);
        for(int i=1;i<=妾室数量;i++)
        {
            家眷 妾室 = (家眷)NPCManager.Instance.创建随机人物("家眷","女");
            妾室.年龄 = 爸爸.年龄 + UnityEngine.Random.Range(-5, 5);
            爸爸.妾室.Add(妾室.编号);
        }

        孩子数量 = UnityEngine.Random.Range(0, 3);
        for (int j = 0; j < 孩子数量; j++)
        {
            string 性别 = 所有性别[UnityEngine.Random.Range(0, 2)];
            家眷 家眷 = (家眷)NPCManager.Instance.创建随机人物("家眷", 性别);
            家眷.年龄 = 妃子.年龄 + UnityEngine.Random.Range(-5, 5);
            家眷.随机立绘();
            家眷.姓 = 爸爸.姓;
            家眷.籍贯 = 爸爸.籍贯;
            家眷.家族 = 爸爸.家族;
            if(家眷.性别=="女"&&妃子.名.Length>=2)
            {
                if (家眷.名.Length >= 2) 家眷.名 = 妃子.名.Substring(0, 1) + 家眷.名.Substring(1);
                else 家眷.名 = 妃子.名.Substring(0, 1) + 家眷.名;
            }
            else if(家眷.性别=="男")
            {
                if(妃子家族.男字辈.ContainsKey(2)==false)
                {
                    if (家眷.名.Length < 2) 妃子家族.男字辈.Add(2, new 字辈(字辈类型.第一个字, 数据库.字辈[UnityEngine.Random.Range(0, 数据库.字辈.Length)]));
                    else 妃子家族.男字辈.Add(2,new 字辈(字辈类型.第一个字,家眷.名.Substring(0,1)));
                }
                if (家眷.名.Length >= 2) 家眷.名 = 妃子家族.男字辈[2].字 + 家眷.名.Substring(1);
                else 家眷.名 = 妃子家族.男字辈[2].字 + 家眷.名;
            }
            家眷.父亲 = 爸爸.编号;
            爸爸.孩子.Add(家眷.编号);
            if (爸爸.妾室.Count > 0 && UnityEngine.Random.Range(0, 100) > 60)
            {
                int 妾室编号 = 爸爸.妾室[UnityEngine.Random.Range(0, 爸爸.妾室.Count)];
                家眷.母亲 = 妾室编号;
                NPCManager.Instance.所有人物[妾室编号].孩子.Add(家眷.编号);
                家眷.嫡庶 = "庶";
            }
            else
            {
                家眷.母亲 = 爸爸.伴侣;
                NPCManager.Instance.所有人物[爸爸.伴侣].孩子.Add(家眷.编号);
            }
            if (家眷.性别 == "女")
            {
                爸爸.女儿数量++;
            }
            else if (家眷.性别 == "男")
            {
                爸爸.儿子数量++;
            }
            妃子家族.家族成员.Add(家眷.编号);
        }
    }

    public override void 删除人物(GameObject instance)
    {
        base.删除人物(instance);
    }


    public void 更换宫殿()
    {
        中间变量.Instance.被安排宫殿妃子 = this;
        宫殿管理.Instance.打开宫殿界面(0, "初始化安排宫殿");
    }
    public override void 查看记事()
    {
        base.查看记事();
    }
    public void 妃子列表展示()
    {
        List<int> 所有妃子信息 = NPCManager.Instance.妃子列表;
    }

    public void 册封(string 参数,Action MyAction)
    {
        GameObject instance = UI相关.实例化(Resources.Load<GameObject>("预制体/信息展示预制体/妃子位分界面"));
        妃子位分界面UI管理 UI = instance.GetComponent<妃子位分界面UI管理>();
        UI.MyAction = MyAction;
        UI.参数 = 参数;
        UI.所有位分 = 数据库.所有位分;
        中间变量.Instance.册封妃子 = this;
    }

    public void 赐封号(string 参数)
    {
        中间变量.Instance.赐封号妃子 = this;
        GameObject instance = UI相关.实例化(Resources.Load<GameObject>("预制体/UI预制体/选秀/妃子封号界面"));
        instance.GetComponent<妃子封号界面UI管理>().参数 = 参数;
    }
}
