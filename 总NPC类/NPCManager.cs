using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Xml;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class NPC
{
    // Start is called before the first frame update
    //NPC所需要的公共信息
    #region 基础属性
    public string 称呼 = "";
    public int 关系=50;
    public string 名称;
    public bool 死亡判断 = false;
    public string 类型;
    public string 姓;
    public string 名;
    public string 性别;
    public int 年龄;
    public string 家族;
    public string 籍贯="";
    public int 寿命;
    public int 所属国家;
    public int 智力;
    public int 武力;
    public int 魅力;
    public int 政治;
    public int 统帅;
    public int 清廉;
    public int 野心;
    public int 立绘编号;
    public int 孕=0;
    public int 属相;
    public int 生日;
    public int 性情编号;
    public string 性情;
    public List<string> 喜好 = new List<string>();
    public int 出身编号;
    public string 出身;
    public string 字;
    public string 号;
    public int 心 = -1;
    public int 后宫派系 = 0;
    public int 性取向;
    public int 孕率=-1;
    public int 生育能力=-1;
    public int 尺寸=-1;
    public int 胸围=-1;

    [NonSerialized]public Sprite 立绘;
    public string 立绘地址;
    public int 生父 = -1;
    public int 生母 = -1;
    public int 父亲=-1;
    public int 母亲=-1;
    public int 外祖父 = -1;
    public int 外祖母 = -1;
    public int 祖父 = -1;
    public int 祖母 = -1;
    public int 伴侣=-1;
    public int 夫妻恩爱值 = 50;
    public string 住所;
    public int 编号;
    public int 女儿数量=0;
    public int 儿子数量=0;
    public int 孙女数量=0;
    public int 孙子数量=0;
    public int 经验 = 0;
    public double 金钱 = 0;
    public string 封号 = "";
    public string 嫡庶 = "嫡";
    public List<int> 孩子 = new List<int>();
    public List<记事> 记事 = new List<记事>();
    public List<int> 妾室 = new List<int>();
    public int 选秀标记 = 0;
    public int 体重 = 89;
    public string 出身啊="";
    public string 昵称;
    public int 状态;
    public int 病 = 0;
    public int 孩子父亲 = -1;
    public int 房中术 = 50;
    public int 仙 = 0;
    public int 后宫归属感 = 0;
    public int 大臣归属感 = 0;
    public int 皇嗣归属感 = 0;
    public int 后宫相性 = 0;
    public int 朝廷相性 = 0;
    public int 所属党派 = -1;
    public int 丧妻对象恩爱值 = 0;
    public string 丧妻对象 = "";
    public int 诗 = 0;

    #endregion
    public virtual void 查看记事()
    {
        GameObject instance = UI相关.实例化(Resources.Load<GameObject>("预制体/信息展示预制体/记事一览滚动版"));
        instance.GetComponent<滚动版记事一览UI管理>().npc = this;
    }
    public virtual void 打开人物信息面板()
    {
    }
    public virtual void 随机立绘()
    {

    }
    public virtual void 打开家眷面板()
    {
        List<KeyValuePair<int, string>> 所有亲戚 = new List<KeyValuePair<int, string>>();
        Dictionary<int, string> 亲戚 = 获取亲戚();
        List<int> npcsid = new List<int>();
        List<string> 关系 = new List<string>();
        foreach (KeyValuePair<int, string> kv in 亲戚)
        {
            npcsid.Add(kv.Key);
            关系.Add(kv.Value);
        }
        信息列表UI管理 UI = UI相关.实例化(Resources.Load<GameObject>("预制体/场景预制体/属性列表/家眷列表/家眷关系列表")).GetComponent<信息列表UI管理>();
        //Debug.Log(所有亲戚.Count);
        UI.type = "家眷";
        UI.npcsid = npcsid;
        UI.关系 = 关系;
        UI.刷新npcs();
        UI.列表展示();
        //Debug.Log("打开家眷面板");
    }
    public void 加载立绘()
    {
        立绘 = UI相关.加载本地图片(立绘地址);
    }
    public virtual void Initialize(string 类型,string type,int id)
    {
        this.类型 = 类型;
        姓 = 取名字字库.Instance.获取姓();
        if (type == "男")
        {
            名 = 取名字字库.Instance.获取名(UnityEngine.Random.Range(1, 3), "男");
        }
        else if (type == "女")
        {
            名 = 取名字字库.Instance.获取名(UnityEngine.Random.Range(1, 3), "女");
        }
        昵称 = 名;
        寿命 = UnityEngine.Random.Range(20, 600);
        属相 = UnityEngine.Random.Range(1, 13);
        籍贯 = 数据库.籍贯[UnityEngine.Random.Range(0, 数据库.籍贯.Length)];
        家族 = 籍贯 + 姓 + "氏";
        性别 = type;
        生日 = UnityEngine.Random.Range(1, 13);
        if (性别 == "女")
        {
            性情编号 = UnityEngine.Random.Range(0, 数据库.女个性.Count);
            性情 = 数据库.女个性[性情编号][UnityEngine.Random.Range(0, 数据库.女个性[性情编号].Count)];
        }
        else if(性别=="男")
        {
            性情编号 = UnityEngine.Random.Range(0, 数据库.男个性.Count);
            性情 = 数据库.男个性[性情编号][UnityEngine.Random.Range(0, 数据库.男个性[性情编号].Count)];
        }
        记事 = new List<记事>();
        智力 = UnityEngine.Random.Range(0, 101);
        武力 = UnityEngine.Random.Range(0, 101);
        魅力 = UnityEngine.Random.Range(0, 101);
        统帅 = UnityEngine.Random.Range(0, 101);
        政治 = UnityEngine.Random.Range(0, 101);
        诗 = UnityEngine.Random.Range(0, 101);
        名称 = 姓 + 名;
        if (type == "女") 体重 = UnityEngine.Random.Range(80, 120);
        else 体重 = UnityEngine.Random.Range(120, 180);
        伴侣 = -1;
        编号 = id;
        孕 = 0;
        房中术 = UnityEngine.Random.Range(0, 100);
        if(性别=="男")
            喜好.Add(数据库.男爱好[性情编号][UnityEngine.Random.Range(0,数据库.男爱好[性情编号].Count)]);
        else if(性别=="女") 喜好.Add(数据库.男爱好[性情编号][UnityEngine.Random.Range(0, 数据库.男爱好[性情编号].Count)]);
        野心 = UnityEngine.Random.Range(50, 100);
    }
    public void 通用数据复制(NPC npc)
    {
        称呼 = npc.称呼;
        姓 = npc.姓;
        名 = npc.名;
        性别 = npc.性别;
        年龄 = npc.年龄;
        家族 = npc.家族;
        籍贯 = npc.籍贯;
        寿命 = npc.寿命;
        所属国家 = npc.所属国家;
        智力 = npc.智力;
        武力 = npc.武力;
        魅力 = npc.魅力;
        政治 = npc.政治;
        统帅 = npc.统帅;
        清廉 = npc.清廉;
        野心 = npc.野心;
        立绘编号 = npc.立绘编号;
        孕 = npc.孕;
        属相 = npc.属相;
        生日 = npc.生日;
        性情编号 = npc.性情编号;
        性情 = npc.性情;
        喜好 = npc.喜好;
        出身编号 = npc.出身编号;
        出身 = npc.出身;
        字 = npc.字;
        号 = npc.号;
        心 = npc.心;
        性取向 = npc.性取向;
        后宫派系 = npc.后宫派系 ;
        孕率 = npc.孕率;
        生育能力 = npc.生育能力;
        尺寸 = npc.尺寸;
        胸围 = npc.胸围;
        生父 = npc.生父;
        生母 = npc.生母;
        父亲 = npc.父亲;
        母亲 = npc.母亲;
        外祖父 = npc.外祖父;
        外祖母 = npc.外祖母;
        祖父 = npc.祖父;
        祖母 = npc.祖母;
        伴侣 = npc.伴侣;
        关系 = npc.关系;
        夫妻恩爱值 = npc.夫妻恩爱值;
        住所 = npc.住所;
        女儿数量 = npc.女儿数量;
        儿子数量 = npc.儿子数量;
        孙女数量 = npc.孙女数量;
        孙子数量 = npc.孙子数量;
        经验 = npc.经验;
        金钱 = npc.金钱;
        封号 = npc.封号;
        嫡庶 = npc.嫡庶;
        孩子 = npc.孩子;
        记事 = npc.记事;
        妾室 = npc.妾室;
        立绘 = npc.立绘;
        名称 = npc.名称;
        孩子父亲 = npc.孩子父亲;
        房中术 = npc.房中术;
        仙 = npc.仙;
    }

    public virtual void 怀孕判定()
    {

    }
    public void 打开选秀介绍面板()
    {
        string[] 功能按钮名称 = { "亲眷", "评价", "", "", "", "", "", "", "修改", "记事" };
        string[] 查看信息按钮名称 = { "婚配", "充为女官", "收入后宫" };
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
        buttons[0].onClick.AddListener(() => 打开家眷面板());
        //buttons[1].onClick.AddListener(() => 卸职());
        //buttons[2].onClick.AddListener(() => 增加奴婢());
        //buttons[3].onClick.AddListener(() => 查看党派());
        //buttons[7].onClick.AddListener(() => 策答());
        //buttons[8].onClick.AddListener(() => 修改());
        buttons[9].onClick.AddListener(() => 查看记事());
        查看信息按钮[0].onClick.AddListener(() => 婚配());
        查看信息按钮[1].onClick.AddListener(() => 充为女官());
        查看信息按钮[2].onClick.AddListener(() => 选秀(instance));
        #endregion
    }
    public void 充为女官()
    {
        Debug.Log("充为女官");
    }
    public void 婚配()
    {
        Debug.Log("婚配");
    }
    public void 选秀(GameObject instance)
    {
        UI相关.销毁场景(instance);
        妃子 妃子 = new 妃子();
        if (编号 == -1)
        {
            妃子 = (妃子)NPCManager.Instance.创建随机人物("妃子", "女");
        }
        else
        {
            妃子.Initialize("妃子", this.性别, this.编号);
            NPCManager.Instance.妃子列表.Add(妃子.编号);
        }
        妃子.妃子品阶 = 数据库.所有位分.Count;
        妃子.位分 = "秀女";
        妃子.通用数据复制(this);
        妃子.伴侣 = 主控.Instance.编号;
        妃子.类型 = "妃子";
        NPCManager.Instance.所有人物[妃子.编号] = 妃子;
        妃子.选秀标记 = 1;
        this.选秀标记 = 1;
        妃子.册封("选秀", null);
    }
    public virtual void 拜访()
    {

    }
    public virtual void 删除人物(GameObject instance)
    {
        GameObject 删除确认 = UnityEngine.Object.Instantiate(Resources.Load<GameObject>("预制体/UI预制体/提示框面板2"),instance.transform);
        提示框面板UI管理 UI = 删除确认.GetComponent<提示框面板UI管理>();
        UI.参数 = "删除人物";
        UI.instance = instance;
        UI.编号 = this.编号;
        UI.提示语 = "确认删除此人物吗？";
    }
    public virtual Dictionary<int,string> 获取亲戚()
    {
        Dictionary<int,string> 亲戚 = new Dictionary<int,string>();
        if(类型!="宗室"&&类型!="皇嗣"&&类型!="皇帝")
        {
            if (this.祖父 != -1) 递归获取亲戚(this.祖父, 亲戚, "祖父", 0);
            else if (this.父亲 != -1) 递归获取亲戚(this.父亲, 亲戚, "父亲", 1);
        }
        if (this.外祖父 != -1) 递归获取亲戚(this.外祖父, 亲戚, "外祖父", 0);
        else if (this.母亲 != -1) 递归获取亲戚(this.母亲, 亲戚, "母亲", 1);
        if (父亲 == -1 && 母亲 == -1)
            递归获取亲戚(this.编号, 亲戚, "自己", 2);
        return 亲戚;
    }
    private void 递归获取亲戚(int id, Dictionary<int,string>亲戚,string 关系,int depth)
    {
        //Debug.Log(NPCManager.Instance.所有人物[id] + "  " + 关系 + "  " + depth);
        if (id != this.编号 && NPCManager.Instance.所有人物[id].死亡判断==false)
            亲戚[id] = 关系;
        if (NPCManager.Instance.所有人物[id].类型 == "皇帝" || NPCManager.Instance.所有人物[id].类型 == "先皇") return;
        if (depth > 4) return;
        if (关系 == "祖父" && NPCManager.Instance.所有人物[id].伴侣 != -1) 亲戚[NPCManager.Instance.所有人物[id].伴侣] = "祖母";
        if (关系 == "外祖父" && NPCManager.Instance.所有人物[id].伴侣 != -1) 亲戚[NPCManager.Instance.所有人物[id].伴侣] = "外祖母";
        if(关系=="自己")
        {
            if (NPCManager.Instance.所有人物[id].伴侣 != -1 && NPCManager.Instance.所有人物[id].性别=="男") 亲戚[NPCManager.Instance.所有人物[id].伴侣] = "嫡妻";
            else if (NPCManager.Instance.所有人物[id].伴侣 != -1 && NPCManager.Instance.所有人物[id].性别=="女") 亲戚[NPCManager.Instance.所有人物[id].伴侣] = "夫婿";
            for (int i = 0; i < NPCManager.Instance.所有人物[id].妾室.Count; i++)
            {
                int 妾室编号 = NPCManager.Instance.所有人物[id].妾室[i];
                亲戚[妾室编号] = "妾室";
            }
        }
        else if(关系=="父亲")
        {
            for (int i = 0; i < NPCManager.Instance.所有人物[id].妾室.Count; i++)
            {
                int 妾室编号 = NPCManager.Instance.所有人物[id].妾室[i];
                亲戚[妾室编号] = "庶母";
            }
        }
        int 女儿计数 = 1, 儿子计数 = 1;
        //Debug.Log(NPCManager.Instance.所有人物[id].孩子.Count);
        if(关系=="自己")
        {
            NPCManager.Instance.所有人物[id].孩子.Sort((a, b) => NPCManager.Instance.所有人物[b].年龄.CompareTo(NPCManager.Instance.所有人物[a].年龄));
        }
        for (int i = 0; i <NPCManager.Instance.所有人物[id].孩子.Count; i++)
        {
            int cid = NPCManager.Instance.所有人物[id].孩子[i];
            //if (NPCManager.Instance.所有人物[cid].死亡判断 == true) continue;
            string 性别 = NPCManager.Instance.所有人物[cid].性别;
            int 年龄 = NPCManager.Instance.所有人物[cid].年龄;
            #region 关系判断
            if (cid == this.编号) 递归获取亲戚(cid,亲戚,"自己",depth+1);
            if (亲戚.ContainsKey(cid)) continue;
            if (关系 == "祖父")
            {
                int 父亲年龄 = NPCManager.Instance.所有人物[父亲].年龄;
                if (cid == this.父亲) 递归获取亲戚(cid,亲戚,"父亲",depth+1); 
                else if (性别 == "女") 递归获取亲戚(cid, 亲戚, "姑姑", depth + 1);
                else if (性别 == "男" && 年龄 < 父亲年龄) 递归获取亲戚(cid, 亲戚, "伯伯", depth + 1);
                else if (性别 == "男" && 年龄 >= 父亲年龄) 递归获取亲戚(cid, 亲戚, "叔叔", depth + 1);
            }
            else if(关系=="外祖父")
            {
                int 母亲年龄 = NPCManager.Instance.所有人物[母亲].年龄;
                if (cid == this.母亲) 亲戚[cid] = "母亲";
                else if (性别 == "女") 递归获取亲戚(cid, 亲戚, "姨妈", depth + 1);
                else if (性别 == "男") 递归获取亲戚(cid, 亲戚, "舅舅", depth + 1);
            }
            else if(关系=="父亲")
            {
                if (性别 == "女" && 年龄 > this.年龄) 递归获取亲戚(cid, 亲戚, "姐姐", depth + 1);
                else if (性别 == "女" && 年龄 <= this.年龄) 递归获取亲戚(cid, 亲戚, "妹妹", depth + 1);
                else if (性别 == "男" && 年龄 >=this.年龄) 递归获取亲戚(cid, 亲戚, "哥哥", depth + 1);
                else if (性别 == "男") 递归获取亲戚(cid, 亲戚, "弟弟", depth + 1);
            }
            else if(关系=="姑姑"||关系=="伯伯"||关系=="叔叔")
            {
                if (性别 == "女" && 年龄 > this.年龄) 递归获取亲戚(cid, 亲戚, "堂姐", depth + 1);
                else if (性别 == "女" && 年龄 <= this.年龄) 递归获取亲戚(cid, 亲戚, "堂妹", depth + 1);
                else if (性别 == "男" && 年龄 >= this.年龄) 递归获取亲戚(cid, 亲戚, "堂兄", depth + 1);
                else if (性别 == "男") 递归获取亲戚(cid, 亲戚, "堂弟", depth + 1);
            }
            else if(关系=="姨妈"||关系=="舅舅")
            {
                if (性别 == "女" && 年龄 > this.年龄) 递归获取亲戚(cid, 亲戚, "表姐", depth + 1);
                else if (性别 == "女" && 年龄 <= this.年龄) 递归获取亲戚(cid, 亲戚, "表妹", depth + 1);
                else if (性别 == "男" && 年龄 >= this.年龄) 递归获取亲戚(cid, 亲戚, "表哥", depth + 1);
                else if (性别 == "男") 递归获取亲戚(cid, 亲戚, "表弟", depth + 1);
            }
            else if (关系[0]=='堂')
            {
                if (性别 == "女") 递归获取亲戚(cid, 亲戚, "侄女", depth + 1);
                else 递归获取亲戚(cid, 亲戚, "侄子", depth + 1);
            }
            else if (关系[0]=='表')
            {
                if (性别 == "女") 递归获取亲戚(cid, 亲戚, "外甥", depth + 1);
                else 递归获取亲戚(cid, 亲戚, "外甥女", depth + 1);
            }
            else if(关系=="自己")
            {
                Debug.Log("哈哈哈");
                string str = "";
                str += NPCManager.Instance.所有人物[cid].嫡庶;
                if(性别=="女")
                {
                    if (女儿计数 == 1) str += "长";
                    else if (女儿计数 == 2) str += "次";
                    else str += 数据库.大写数字[女儿计数];
                    str += "女";
                    女儿计数++;
                }
                else if(性别=="男")
                {
                    if (儿子计数 == 1) str += "长";
                    else if (儿子计数 == 2) str += "次";
                    else str += 数据库.大写数字[儿子计数];
                    str += "子";
                    儿子计数++;
                }
                if (NPCManager.Instance.所有人物[cid].伴侣 != -1 && NPCManager.Instance.所有人物[cid].伴侣!=主控.Instance.编号)
                {
                    int 伴侣 = NPCManager.Instance.所有人物[cid].伴侣;
                    if (性别 == "女")
                    {
                        亲戚[伴侣] = "女婿";
                    }
                    else 亲戚[伴侣] = "儿媳";
                }
                递归获取亲戚(cid, 亲戚, str, depth + 1);
            }
            else if (关系[0] == '嫡' || 关系[0]=='庶')
            {
                string str = "";
                if (关系[2] == '女') str += "外";
                if (性别 == "女") str+= "孙女";
                else str+= "孙子";
                if (关系[2]=='子'&&NPCManager.Instance.所有人物[cid].伴侣!=-1)
                {
                    int 伴侣 = NPCManager.Instance.所有人物[cid].伴侣;
                    if (性别 == "男") 亲戚[伴侣] = "孙媳";
                    else 亲戚[伴侣] = "孙女婿";
                }
                亲戚[cid] = str;
            }
            #endregion
        }


    }

    public void 生子程序()
    {

    }
}
public class NPCManager
{
    #region 人物管理列表
    // Start is called before the first frame update
    public List<int> 妃子列表 = new List<int>();
    public List<int> 大臣列表 = new List<int>();
    public List<int> 太妃列表 = new List<int>();
    public List<int> 宗室列表 = new List<int>();
    public List<int> 皇嗣列表 = new List<int>();
    public Dictionary<int,NPC> 所有人物= new Dictionary<int,NPC>();
    //public List<NPC> 所有人物 = new List<NPC>();
    public List<int> 皇帝列表 = new List<int>();
    public List<int> 闲官列表 = new List<int>();
    public List<int> 宫女列表 = new List<int>(); 
    public int all_people_count = 0;
    #endregion
    #region 单例模式
    public static NPCManager instance;
    public static NPCManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new NPCManager();
            }
            return instance;
        }
    }
    #endregion
    public void 随机伴侣(NPC npc)
    {
        if (npc.伴侣 != -1||npc.年龄<18) return;
        string type = npc.性别 == "男" ? "女" : "男";
        家眷 伴侣 = (家眷)创建随机人物("家眷", type);
        伴侣.年龄 = Math.Max(npc.年龄 + UnityEngine.Random.Range(-10, 10),UnityEngine.Random.Range(16,20));
        伴侣.随机立绘();
        伴侣.伴侣 = npc.编号;
        npc.伴侣 = 伴侣.编号;
    }
    public void 随机孩子(NPC npc)
    {
        if (npc.年龄 < 18 || (npc.伴侣 == -1&&npc.妾室.Count==0)) return;
        家族 家族 = 家族管理.Instance.所有家族[npc.家族];
        int 孩子数量 = UnityEngine.Random.Range(0, 6);
        for(int i = 0; i < 孩子数量; i++)
        {
            家眷 孩子 = (家眷)NPCManager.Instance.创建随机人物("家眷",UnityEngine.Random.Range(0,2)==0?"男":"女");
            NPC 母亲 = new NPC();
            if (npc.伴侣 == -1) { 母亲 = NPCManager.Instance.所有人物[npc.妾室[UnityEngine.Random.Range(0, npc.妾室.Count)]]; 孩子.嫡庶 = "庶"; }
            else if (npc.妾室.Count <= 0) 母亲 = NPCManager.Instance.所有人物[npc.伴侣];
            else if (UnityEngine.Random.Range(0, 100) < 60) 母亲 = NPCManager.Instance.所有人物[npc.伴侣];
            else
            {
                母亲 = NPCManager.Instance.所有人物[npc.妾室[UnityEngine.Random.Range(0, npc.妾室.Count)]];
                孩子.嫡庶 = "庶";
            }
            孩子.年龄 = Math.Max(1, 母亲.年龄 - UnityEngine.Random.Range(18, 30));
            孩子.姓 = npc.姓;
            孩子.籍贯 = npc.籍贯;
            孩子.家族 = npc.家族;
            孩子.随机立绘();
            孩子.父亲 = npc.编号;
            孩子.母亲 = 母亲.编号;
            家族.家族成员.Add(孩子.编号);
            母亲.孩子.Add(孩子.编号);
            npc.孩子.Add(孩子.编号);
            if (孩子.性别 == "女") npc.女儿数量++;
            else npc.儿子数量++;

        }
    }
    public NPC 创建临时人物(string type, string 性别)
    {
        NPC npc = new NPC();
        if(type=="妃子")
        {
            npc = new 妃子();
        }
        else if(type=="大臣")
        {
            npc = new 大臣();
        }
        npc.Initialize(type, 性别, -1);
        return npc;
    }
    public NPC 创建随机人物(string type,string 性别)
    {
        NPC npc = new NPC();
        int id = all_people_count++;
        if (type == "妃子")
        {
            npc = new 妃子();
            npc.伴侣 = 主控.Instance.编号;
            妃子列表.Add(id);
        }
        else if(type=="家眷")
        {
            npc = new 家眷();
        }
        else if (type == "大臣")
        {
            npc = new 大臣();
            大臣列表.Add(id);
        }
        else if (type == "太妃")
        {
            npc = new 太妃();
            太妃列表.Add(id);
        }
        else if(type =="宗室")
        {
            npc = new 宗室();
            宗室列表.Add(id);
        }
        else if(type=="皇嗣")
        {
            npc = new 宗室();
            皇嗣列表.Add(id);
        }
        else if (type == "先皇")
        {
            npc = new 皇帝();
            皇帝列表.Add(id);
        }
        所有人物[id] = npc;
        npc.Initialize(type,性别,id);
        return npc;
    }
    public void 初始大臣生成(int num)
    {
        for(int i=0;i<num;i++)
        {
            大臣 大臣 = (大臣)创建随机人物("大臣", "男");
            官职管理.Instance.初始官职生成(大臣,2,12);
            家族 大臣家族;
            if (!家族管理.Instance.所有家族.ContainsKey(大臣.家族))
            {
                大臣家族 = new 家族(大臣.家族);
                大臣家族.族长编号 = 大臣.编号;
                家族管理.Instance.所有家族.Add(大臣.家族,大臣家族);
                //大臣家族.根成员.Add(大臣.编号);
            }
            else
            {
                大臣家族 = 家族管理.Instance.所有家族[大臣.家族];   
            }

            大臣家族.家族成员.Add(大臣.编号);
            大臣家族.朝廷势力 += 派系管理.获取官员势力值(大臣);
            int 妾室数量 = UnityEngine.Random.Range(0, 3);
            for(int j=1;j<=妾室数量;j++)
            {
                家眷 妾室 = (家眷)NPCManager.Instance.创建随机人物("家眷", "女");
                妾室.年龄 = 大臣.年龄 + UnityEngine.Random.Range(-5, 5);
                大臣.妾室.Add(妾室.编号);
            }
            int 随机 = UnityEngine.Random.Range(0, 10);
            if(随机<5)
            {
                NPCManager.Instance.随机伴侣(大臣);
                NPCManager.Instance.随机孩子(大臣);
            }
        }
    }
    public void 初始化妃子太妃()
    {
        for (int i = 0; i < 4; i++)
            NPCManager.Instance.创建随机人物("妃子", "女");
        int len = NPCManager.Instance.妃子列表.Count;
        妃子 侧妃 = (妃子)NPCManager.Instance.所有人物[NPCManager.Instance.妃子列表[len - 4]];
        侧妃.妃子品阶 = UnityEngine.Random.Range(1, 数据库.所有位分.Count/5*2);
        侧妃.小位分 = 0;
        侧妃.位分 = 数据库.所有位分[侧妃.妃子品阶].所有小位分[0];
        数据库.所有位分[侧妃.妃子品阶].已有人数++;
        int 侧妃家族 = UnityEngine.Random.Range(0, 数据库.氏族籍贯.Length / 3);
        侧妃.姓 = 数据库.氏族姓[侧妃家族];
        侧妃.籍贯 = 数据库.氏族籍贯[侧妃家族];
        侧妃.家族 = 侧妃.籍贯 + 侧妃.姓 + "氏";
        侧妃.住所 = 宫殿管理.Instance.安排宫殿(侧妃, 0);
        侧妃.伴侣 = 主控.Instance.编号;

        妃子 良娣 = (妃子)NPCManager.Instance.所有人物[NPCManager.Instance.妃子列表[len - 3]];
        良娣.妃子品阶 = UnityEngine.Random.Range(数据库.所有位分.Count/5*2,数据库.所有位分.Count/5*3);
        良娣.位分 = 数据库.所有位分[良娣.妃子品阶].所有小位分[0];
        数据库.所有位分[良娣.妃子品阶].已有人数++;
        int 良娣家族 = UnityEngine.Random.Range(数据库.氏族籍贯.Length / 3, 数据库.氏族籍贯.Length/3*2);
        良娣.姓 = 数据库.氏族姓[良娣家族];
        良娣.籍贯 = 数据库.氏族籍贯[良娣家族];
        良娣.家族 = 良娣.籍贯 + 良娣.姓 + "氏";
        良娣.住所 = 宫殿管理.Instance.安排宫殿(良娣, 0);
        良娣.伴侣 = 主控.Instance.编号;

        妃子 保林 = (妃子)NPCManager.Instance.所有人物[NPCManager.Instance.妃子列表[len - 2]];
        保林.妃子品阶 = UnityEngine.Random.Range(数据库.所有位分.Count/5*3, 数据库.所有位分.Count/5*4);
        保林.位分 = 数据库.所有位分[保林.妃子品阶].所有小位分[0];
        数据库.所有位分[保林.妃子品阶].已有人数++;
        int 保林家族 = UnityEngine.Random.Range(数据库.氏族籍贯.Length / 3 * 2, 数据库.氏族籍贯.Length);
        保林.姓 = 数据库.氏族姓[保林家族];
        保林.籍贯 = 数据库.氏族籍贯[保林家族];
        保林.家族 = 保林.籍贯 + 保林.姓 + "氏";
        保林.住所 = 宫殿管理.Instance.安排宫殿(保林, 0);
        保林.伴侣 = 主控.Instance.编号;

        妃子 孺子 = (妃子)NPCManager.Instance.所有人物[NPCManager.Instance.妃子列表[len - 1]];
        孺子.妃子品阶 = UnityEngine.Random.Range(数据库.所有位分.Count/5*4, 数据库.所有位分.Count);
        孺子.位分 = 数据库.所有位分[孺子.妃子品阶].所有小位分[0];
        数据库.所有位分[孺子.妃子品阶].已有人数++;
        孺子.籍贯 = 数据库.籍贯[UnityEngine.Random.Range(0, 数据库.籍贯.Length)];
        孺子.家族 = 孺子.籍贯 + 孺子.姓 + "氏";
        孺子.住所 = 宫殿管理.Instance.安排宫殿(孺子, 0);
        孺子.伴侣 = 主控.Instance.编号;

        int 太妃数量 = UnityEngine.Random.Range(0, 10);
        for (int i = 0; i <= 太妃数量; i++)
        {
            NPCManager.Instance.创建随机人物("太妃", "女");
            太妃 太妃 = (太妃)NPCManager.Instance.所有人物[NPCManager.Instance.太妃列表[i]];
            太妃.伴侣 = NPCManager.Instance.皇帝列表[0];
            if (i == 0)
            {
                太妃.年龄 = UnityEngine.Random.Range(35, 45);
                太妃.妃子品阶 = 0;
                太妃.位分 = 数据库.所有位分[0].所有小位分[0];
                int 随机 = UnityEngine.Random.Range(0, 100);
                if (随机 > 80)
                {
                    妃子 妃子 = (妃子)NPCManager.Instance.所有人物[NPCManager.Instance.妃子列表[UnityEngine.Random.Range(0, math.min(5, NPCManager.Instance.妃子列表.Count))]];
                    中间变量.Instance.太后妃子家族统一 = 妃子.编号;
                    太妃.籍贯 = 妃子.籍贯;
                    太妃.姓 = 妃子.姓;
                    太妃.家族 = 妃子.家族;
                    游戏设定.Instance.太后 = 太妃.编号;
                    太后族亲生成();
                }
            }
            太妃.增加孩子();
        }
    }
    public void 太后族亲生成()
    {
        int 太后编号 = NPCManager.Instance.太妃列表[0];
        int 妃子编号 = 中间变量.Instance.太后妃子家族统一;
        int 家族人数 = 4;
        if (NPCManager.Instance.所有人物.ContainsKey(妃子编号) == false) return;
        妃子 妃子 = (妃子)NPCManager.Instance.所有人物[妃子编号];
        太妃 太后 = (太妃)NPCManager.Instance.所有人物[太后编号];
        大臣 爷爷 = (大臣)NPCManager.Instance.创建随机人物("大臣", "男");
        大臣 爸爸 = (大臣)NPCManager.Instance.创建随机人物("大臣", "男");
        家族 太后家族;
        太后.姓 = 妃子.姓; 太后.家族 = 妃子.家族; 太后.籍贯 = 妃子.籍贯; 
        if (!家族管理.Instance.所有家族.ContainsKey(太后.家族)) 
        { 
            太后家族 = new 家族(太后.家族);
            家族管理.Instance.所有家族[太后.家族] = 太后家族;
        }
        else 太后家族 = 家族管理.Instance.所有家族[太后.家族];

        太后家族.族长编号 = 爷爷.编号;
        太后家族.家族名 = 太后.家族;
        太后家族.家族成员.Add(太后.编号);
        太后家族.家族成员.Add(爷爷.编号);
        太后家族.家族成员.Add(爸爸.编号);
        太后家族.家族成员.Add(妃子.编号);
        太后家族.后宫成员.Add(妃子.编号);
        太后家族.后宫成员.Add(太后.编号);
        太后家族.朝廷成员.Add(爸爸.编号);
        太后家族.朝廷成员.Add(爷爷.编号);
        爷爷.年龄 = 太后.年龄 + UnityEngine.Random.Range(18, 25);
        爸爸.年龄 = 太后.年龄 + UnityEngine.Random.Range(3, 5);
        爷爷.姓 = 太后.姓; 爷爷.籍贯 = 太后.籍贯; 爷爷.家族 = 太后.家族;
        爸爸.姓 = 太后.姓; 爸爸.籍贯 = 太后.籍贯; 爸爸.家族 = 太后.家族;

        if (爸爸.名.Length >= 2) 太后家族.男字辈.Add(1, new 字辈(字辈类型.第一个字,爸爸.名.Substring(0, 1)));
        if (太后.名.Length >= 2) 太后家族.女字辈.Add(1, new 字辈(字辈类型.第一个字, 太后.名.Substring(0, 1)));
        if (爷爷.名.Length >= 2) 太后家族.男字辈.Add(0, new 字辈(字辈类型.第一个字, 爷爷.名.Substring(0, 1)));
        if (妃子.名.Length >= 2) 太后家族.女字辈.Add(2, new 字辈(字辈类型.第一个字, 妃子.名.Substring(0, 1)));

        爷爷.女儿数量 = 1;
        爷爷.儿子数量 = 1;
        官职管理.Instance.初始官职生成(爷爷, 1, 5);
        官职管理.Instance.初始官职生成(爸爸, 3, 7);
        爷爷.孩子.Add(爸爸.编号);
        爷爷.孩子.Add(太后.编号);
        爸爸.孩子.Add(妃子.编号);
        爸爸.女儿数量 = 1;
        爸爸.父亲 = 爷爷.编号; 太后.父亲 = 爷爷.编号;
        妃子.父亲 = 爸爸.编号;
        妃子.祖父 = 爷爷.编号;
        妃子.祖母 = 爷爷.编号;
        if (爷爷.伴侣 == -1)
        {
            NPCManager.Instance.随机伴侣(爷爷);
            NPCManager.Instance.所有人物[爷爷.伴侣].孩子.Add(爸爸.编号);
            NPCManager.Instance.所有人物[爷爷.伴侣].孩子.Add(太后.编号);
        }
        if (爸爸.伴侣 == -1)
        {
            NPCManager.Instance.随机伴侣(爸爸);
            NPCManager.Instance.所有人物[爸爸.伴侣].孩子.Add(妃子.编号);
        }
        太后.母亲 = 爷爷.伴侣;
        爸爸.母亲 = 爷爷.伴侣;
        妃子.母亲 = 爸爸.伴侣;
        string[] 所有性别 = { "男", "女" };
        int 妾室数量 = UnityEngine.Random.Range(0, 3);
        for(int i=1;i<=妾室数量;i++)
        {
            家眷 妾室 = (家眷)NPCManager.Instance.创建随机人物("家眷", "女");
            妾室.年龄 = 爸爸.年龄 + UnityEngine.Random.Range(-5, 0);
            爸爸.妾室.Add(妾室.编号);
        }
        int 孩子数量 = UnityEngine.Random.Range(0, 5);
        for (int i = 0; i < 孩子数量; i++)
        {
            家族人数++;
            string 性别 = 所有性别[UnityEngine.Random.Range(0, 2)];
            家眷 家眷 = (家眷)NPCManager.Instance.创建随机人物("家眷", 性别);
            家眷.年龄 = 妃子.年龄 + UnityEngine.Random.Range(-5, 5);
            家眷.姓 = 爸爸.姓;
            if (家眷.性别 == "女" && 太后家族.女字辈.ContainsKey(2))
            {
                if (家眷.名.Length < 2) 家眷.名 = 太后家族.女字辈[2].字 + 家眷.名.Substring(0);
                else 家眷.名 = 太后家族.女字辈[2].字 + 家眷.名.Substring(1);
            }
            else if (家眷.性别 == "男" && 太后家族.男字辈.ContainsKey(2))
            {
                if (家眷.名.Length < 2) 家眷.名 = 太后家族.男字辈[2].字 + 家眷.名.Substring(0);
                else 家眷.名 = 太后家族.男字辈[2].字 + 家眷.名.Substring(1);
            }
            else if(家眷.性别=="男"&&!太后家族.男字辈.ContainsKey(2))
            {
                if (家眷.名.Length < 2)
                {
                    string 字 = 数据库.字辈[UnityEngine.Random.Range(0,数据库.字辈.Length)];
                    家眷.名 = 字 + 家眷.名;
                    太后家族.男字辈.Add(2, new 字辈(字辈类型.第一个字,字));
                }
                else 太后家族.男字辈.Add(2,new 字辈(字辈类型.第一个字,家眷.名.Substring(0,1)));
            }
            家眷.籍贯 = 爸爸.籍贯;
            家眷.家族 = 爸爸.家族;
            家眷.随机立绘();
            家眷.父亲 = 爸爸.编号;
            爸爸.孩子.Add(家眷.编号);
            家眷.祖父 = 爷爷.编号;
            家眷.祖母 = 爷爷.编号;
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
            太后家族.家族成员.Add(家眷.编号);

            爸爸.孩子.Add(家眷.编号);
            NPCManager.Instance.所有人物[爸爸.伴侣].孩子.Add(家眷.编号);
            if (家眷.性别 == "女")
            {
                爸爸.女儿数量++;
                爷爷.孙女数量++;
            }
            else if (家眷.性别 == "男")
            {
                爸爸.儿子数量++;
                爷爷.孙子数量++;
            }
        }
        太后家族.后宫势力 += 派系管理.获取妃子势力值(妃子);
        太后家族.后宫势力 += UnityEngine.Random.Range(50,80);//太后势力值
        太后家族.朝廷势力 += 派系管理.获取官员势力值(爸爸);
        太后家族.朝廷势力 += 派系管理.获取官员势力值(爷爷);
        太后家族.总势力值 += 太后家族.朝廷势力 + 太后家族.后宫势力;
    }
    #region 未实装
    public void 初始家族生成()
    {
        if (中间变量.Instance.太后妃子家族统一 != -1)
        {
            太后族亲生成();
        }
        #region 妃子家族生成
        for (int i = 0; i < 4; i++)
        {
            string[] 所有性别 = { "男", "女" };
            int 孩子数量 = UnityEngine.Random.Range(0, 5);
            int 妃子编号 = NPCManager.Instance.妃子列表[i];
            妃子 妃子 = (妃子)NPCManager.Instance.所有人物[妃子编号];
            if (妃子编号 == 中间变量.Instance.太后妃子家族统一) continue;

            大臣 爸爸 = (大臣)NPCManager.Instance.创建随机人物("大臣", "男");
            爸爸.姓 = 妃子.姓; 爸爸.籍贯 = 妃子.籍贯; 爸爸.家族 = 妃子.家族;
            爸爸.孩子.Add(妃子.编号);
            爸爸.女儿数量 = 1;
            官职管理.Instance.初始官职生成(爸爸, 1, 7);
            if (爸爸.伴侣 == -1)
            {
                家眷 母亲 = (家眷)NPCManager.Instance.创建随机人物("家眷", "女");
                母亲.年龄 = 爸爸.年龄 - UnityEngine.Random.Range(0, 3);
                母亲.随机立绘();
                爸爸.伴侣 = 母亲.编号;
            }
            妃子.母亲 = 爸爸.伴侣;
            妃子.父亲 = 爸爸.编号;
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
                家眷.父亲 = 爸爸.编号;
                家眷.母亲 = 爸爸.伴侣;
                爸爸.孩子.Add(家眷.编号);
                NPCManager.Instance.所有人物[爸爸.伴侣].孩子.Add(家眷.编号);
                if (家眷.性别 == "女")
                {
                    爸爸.女儿数量++;
                }
                else if (家眷.性别 == "男")
                {
                    爸爸.儿子数量++;
                }
            }
            if (!家族管理.Instance.所有家族.ContainsKey(妃子.家族))
            {
                家族 妃子家族 = new 家族(妃子.家族);
                妃子家族.根成员.Add(爸爸.编号);
                妃子家族.家族名 = 妃子.家族;
                家族管理.Instance.所有家族[妃子.家族] = 妃子家族;
            }
            #endregion
        }
    }

    #endregion
    public void 删除人物(int 编号)
    {
        if (编号 < 0 || 编号 > NPCManager.Instance.所有人物.Count) return;
        NPC npc = NPCManager.Instance.所有人物[编号];
        if (npc.类型 == "大臣") 大臣列表.RemoveAll(x => x == 编号);
        else if (npc.类型 == "妃子") {
            if (npc.编号 == 游戏设定.Instance.协理六宫啊) 游戏设定.Instance.协理六宫啊 = -1;
            妃子列表.RemoveAll(x => x == 编号);
        }
        else if (npc.类型 == "太妃") 太妃列表.RemoveAll(x => x == 编号);
        else if (npc.类型 == "宗室") 宗室列表.RemoveAll(x => x == 编号);
        if(npc.伴侣!=-1)
        {
            NPCManager.Instance.所有人物[npc.伴侣].伴侣 = -1;
        }
        if(npc.父亲!=-1)
        {
            NPCManager.Instance.所有人物[npc.父亲].孩子.RemoveAll(x => x == 编号);
            if (npc.性别 == "女") NPCManager.Instance.所有人物[npc.父亲].女儿数量--;
            else NPCManager.Instance.所有人物[npc.父亲].儿子数量--;
            if (NPCManager.Instance.所有人物[npc.父亲].父亲!=-1)
            {
                int 祖父编号 = NPCManager.Instance.所有人物[npc.父亲].父亲;
                if(npc.性别=="女") NPCManager.Instance.所有人物[祖父编号].孙女数量--;
                else if (npc.性别 == "男") NPCManager.Instance.所有人物[祖父编号].孙子数量--;
            }
        }
        if(npc.母亲!=-1)
        {
            NPCManager.Instance.所有人物[npc.母亲].孩子.RemoveAll(x => x == 编号);
            if (npc.性别 == "女") NPCManager.Instance.所有人物[npc.母亲].女儿数量--;
            else NPCManager.Instance.所有人物[npc.母亲].儿子数量--;
        }
        for(int i = 0; i < npc.孩子.Count; i++)
        {
            NPC 孩子 = NPCManager.Instance.所有人物[npc.孩子[i]];
            if (npc.性别 == "女") 孩子.母亲 = -1;
            else 孩子.父亲 = -1;
        }
        if (家族管理.Instance.所有家族.ContainsKey(npc.家族))
        {
            家族 家族 = 家族管理.Instance.所有家族[npc.家族];
            if(npc.类型=="大臣")
            {

            }
            else if(npc.类型=="太妃"||npc.类型=="妃子")
            {
                家族.后宫成员.Remove(npc.编号);
            }
            家族.家族成员.Remove(npc.编号);
        }
        if (编号 == 中间变量.Instance.太后妃子家族统一) 中间变量.Instance.太后妃子家族统一 = -1;
        if(编号 == 游戏设定.Instance.太后)  游戏设定.Instance.太后 = -1;
        所有人物.Remove(编号);
        中间变量.Instance.dl(npc.编号);
    }

    public void 孕期计算()
    {
        for (int i = 0; i < NPCManager.Instance.所有人物.Count; ++i)
        {
            NPC npc = NPCManager.Instance.所有人物[i];
            if (npc.死亡判断 == true) continue;
            if (npc.孕 > 1)
                npc.孕 -= 1;
            else if (npc.孕 == 1) npc.生子程序();
        }
    }
}
