using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class 妃子拜访界面UI管理 : MonoBehaviour
{
    // Start is called before the first frame update
    public Image 妃子图片;
    public Image background;
    public GameObject 缓动黑幕界面;
    public GameObject 黑幕instance;
    public Toggle 信息按钮,闲聊按钮,临幸按钮;
    private 妃子 拜访妃子;
    void Start()
    {
        //宫殿管理.Instance.加载场景("宫殿大地图");
        拜访妃子 = UI相关.NPC宫殿拜访;
        if (拜访妃子 != null)
        {
            妃子图片.sprite = 拜访妃子.立绘;
            background.sprite = 拜访妃子.房间图;
        }
        UI相关.实例化(缓动黑幕界面);
    }
    public GameObject 妃子拜访界面;
    public void 离开()
    {
        UI相关.销毁场景(妃子拜访界面);
    }

    public void 临幸()
    {
        if (临幸按钮.isOn)
        {
            拜访妃子.临幸 = 1;
            拜访妃子.怀孕判定();
            临幸按钮.isOn = false;
        }
        
    }

    public void 打开信息面板()
    {
        bool 是否打开记事面板 = 信息按钮.isOn;
        if(是否打开记事面板)
        {
            拜访妃子.打开人物信息面板();
            信息按钮.isOn = false;
        }
    }

    public void 闲聊()
    {
        bool 是否闲聊 = 闲聊按钮.isOn;
        if (是否闲聊)
        {
            闲聊对话();
        }
    }
    public void 闲聊对话()
    {
        int 娃 = -1;
        string 皇帝名称 = 主控.Instance.姓 + 主控.Instance.名;
        string 拜访妃子名 = 拜访妃子.姓 + 拜访妃子.名;
        if (拜访妃子.孩子.Count>0) 娃 = 拜访妃子.孩子[Random.Range(0,拜访妃子.孩子.Count)];
        if(拜访妃子.宠<40 && 拜访妃子.入宫时长>2 && Random.Range(0, 5) == 0)
        {

            GameObject 对话框 = UI相关.实例化(Resources.Load<GameObject>("预制体/场景预制体/对话系统/简易对话")); 
            简易剧情 UI = 对话框.GetComponent<简易剧情>();
            UI.更新背景图片2(拜访妃子.房间图);
            List<对话> 剧情 = new List<对话>() {
                new 对话(皇帝名称+":爱妃这么晚了，为何还未歇息？",主控.Instance.立绘),
                new 对话(拜访妃子名+":"+拜访妃子.自称1+"不敢。皇上贵为天子，天子又怎会有错。"+皇帝名称+"......（拂袖离去）",拜访妃子.立绘)
            };
            UI.StartStory(剧情, true,null);
            拜访妃子.宠 -= 10;
            拜访妃子.爱 -= 10;
            拜访妃子.记事.Add(new 记事(记事类型.妃子记事,1,0,new Dictionary<int,string>()));
        }
        else if (娃 != -1 && Random.Range(0, 5) == 0)
        {
            GameObject 对话框 = UI相关.实例化(Resources.Load<GameObject>("预制体/场景预制体/对话系统/简易对话"));
            简易剧情 UI = 对话框.GetComponent<简易剧情>();
            string 娃名 = NPCManager.Instance.所有人物[娃].姓 + NPCManager.Instance.所有人物[娃].名;
            UI.更新背景图片2(拜访妃子.房间图);
            List<对话> 剧情 = new List<对话>() {
                new 对话(拜访妃子名+":"+娃名+"这孩子，每日天不亮就起来温书，如此勤奋，定是随了皇上。若是"+拜访妃子.自称1+"，是断断起不来这么早的",拜访妃子.立绘),
                new 对话(皇帝名称+"：爱妃此言差矣。朕每日事情繁多，顾不了孩子，皇儿勤奋好学，是爱妃教得好。",主控.Instance.立绘),
                new 对话(拜访妃子名+"：“为人母，理应如此。",拜访妃子.立绘)
            };
            UI.StartStory(剧情, true, null);
            拜访妃子.记事.Add(new 记事(记事类型.妃子记事,2,0,new Dictionary<int, string>() { { 1, 娃名 } }));
            拜访妃子.宠 += 10;
            拜访妃子.爱 += 10;
        }
        else
        {
            GameObject 对话框 = UI相关.实例化(Resources.Load<GameObject>("预制体/场景预制体/对话系统/简易对话"));
            简易剧情 UI = 对话框.GetComponent<简易剧情>();
            UI.更新背景图片2(拜访妃子.房间图);
            List<对话> 剧情 = new List<对话>()
            {
                new 对话(拜访妃子名+":"+拜访妃子.自称1+"听闻，近几日京中多了些外邦来的新鲜玩意儿，倒是新奇得很。",拜访妃子.立绘),
                new 对话(皇帝名称+"：不过是些小玩意儿。你若是喜欢，朕哪日给你带些回来。",主控.Instance.立绘),
                new 对话(拜访妃子名+"：皇上此话当真？"+拜访妃子.自称1+"记住了，皇上君无戏言，可不许赖账。",拜访妃子.立绘),
            };
            UI.StartStory(剧情, true, null);
            拜访妃子.记事.Add(new 记事(记事类型.妃子记事, 3, 0, new Dictionary<int, string>()));
            拜访妃子.宠 += 10;
            拜访妃子.爱 += 10;
        }
    }
}
