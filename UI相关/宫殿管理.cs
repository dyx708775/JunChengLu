using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEditor;
using Unity.VisualScripting;

[System.Serializable]
public class 宫殿
{
    public string 宫殿名;
    [NonSerialized]public Sprite 宫殿外图;
    [NonSerialized]public Sprite 宫殿内图;
    public string 宫殿外图地址;
    public string 宫殿内图地址;
    public string[] 房间名 = new string[5];
    public bool[] 是否有人居住 = new bool[5];
    public int[] 居住人 = new int[5];
    public int 怀孕人数 = 0;
    public int 宫殿等级 = 0;
    public int 生病人数 = 0;
    public int 最高位分 = 数据库.所有位分.Count;
    public int 避孕 = 0;
    public 宫殿(){}
    public 宫殿(List<string> 宫殿房间名,string 外图地址,string 内图地址)
    {
        宫殿名 = 宫殿房间名[0];
        for (int i = 1; i <= 5; i++)
        {
            房间名[i - 1] = 宫殿房间名[i];
        }
        for (int i = 0; i < 5; i++)
        {
            是否有人居住[i] = false;
        }
        宫殿外图地址 = 外图地址;
        宫殿内图地址 = 内图地址;
        加载宫殿图();
        怀孕人数 = 0;
        生病人数 = 0;
    }
    public void 加载宫殿图()
    {
        宫殿外图 = UI相关.加载本地图片(宫殿外图地址);
        宫殿内图 = UI相关.加载本地图片(宫殿内图地址);
    }
}

public class 宫殿管理
{
    // Start is called before the first frame update
    public List<宫殿>[]未建宫殿 = new List<宫殿>[] { new List<宫殿>(),new List<宫殿>()};
    public List<宫殿>[]已建宫殿 = new List<宫殿>[] { new List<宫殿>(), new List<宫殿>() };
    [NonSerialized]public Sprite[]宫殿等级图 = new Sprite[3];
    private int LocationId = 0;
    private GameObject 宫殿选择界面 = Resources.Load<GameObject>("预制体/场景预制体/宫殿选择界面");
    private GameObject 房间选择界面 = Resources.Load<GameObject>("预制体/场景预制体/房间选择界面");
    private GameObject 妃子拜访界面 = Resources.Load<GameObject>("预制体/场景预制体/妃子拜访界面");
    #region 单例模式
    public static 宫殿管理 instance;
    public static 宫殿管理 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new 宫殿管理();
            }
            return instance;
        }
    }
    #endregion
    public string 安排宫殿(妃子 妃子,int type)
    {
        妃子.住所 = "";
        for(int i = 0; i < 已建宫殿[type].Count&&妃子.住所=="";i++)
        {
            if(妃子.妃子品阶 <=16)
            {
                if (已建宫殿[type][i].是否有人居住[0]==false)
                {
                    已建宫殿[type][i].是否有人居住[0] = true;
                    已建宫殿[type][i].居住人[0] = 妃子.编号;
                    已建宫殿[type][i].最高位分 = Math.Min(已建宫殿[type][i].最高位分, 妃子.妃子品阶);
                    妃子.住所 = 已建宫殿[type][i].宫殿名;
                    妃子.宫殿编号 = i;
                    妃子.宫殿类型 = type;
                    妃子.房间编号 = 0;
                }
            }
            else
            {
                for(int j=1;j<5;j++)
                {
                    if (已建宫殿[type][i].是否有人居住[j]==false)
                    {
                        已建宫殿[type][i].是否有人居住[(int)j] = true;
                        //Debug.Log(已建宫殿[type][i].是否有人居住[j]);
                        已建宫殿[type][i].居住人[j] = 妃子.编号;
                        已建宫殿[type][i].最高位分 = Math.Min(已建宫殿[type][i].最高位分, 妃子.妃子品阶);
                        妃子.住所 = 已建宫殿[type][i].宫殿名;
                        妃子.宫殿编号 = i;
                        妃子.宫殿类型 = type;
                        妃子.房间编号 = j;
                        break;
                    }
                }
            }
        }
        return 妃子.住所;
    }
    public void Init()
    {
        for (int i = 0; i < 2; i++)
        {
            未建宫殿[i] = new List<宫殿>();
            已建宫殿[i] = new List<宫殿>();
        }
        for (int i=0;i<数据库.所有宫殿.Count;i++)
        {
            if (i >= 数据库.所有宫殿.Count / 2)
                添加宫殿(i, 1);
            else 添加宫殿(i, 0);
        }
        for(int i=0;i<5;i++)
        {
            建立宫殿(0);
            建立宫殿(1);
        }

    }
    #region 宫殿操作
    public void 添加宫殿(int i,int type)
    {
        宫殿 宫殿 = new 宫殿(数据库.所有宫殿[i], "a0aPic_Placae\\Tu_"+(i+1)+".jpg", "azcPic_Gong_Biao\\"+(i+1)+".jpg");
        未建宫殿[(int)type].Add(宫殿);  
    }

    public void 建立宫殿(int type)
    {
        if(未建宫殿[type].Count>0&& type<2)
        {
            已建宫殿[type].Add(未建宫殿[type][0]);
            未建宫殿[type].RemoveAt(0);
        }
    }
    #endregion
    #region 宫殿UI
    private void output(int type)
    {
        Debug.Log(type);
        if (已建宫殿[type] == null) Debug.Log("Uwuwuw");
        for(int i = 0; i < 已建宫殿[type].Count;i++)
        {
            Debug.Log(已建宫殿[type][i].宫殿名);
        }
    }
    public void 打开宫殿界面(int type,string 参数)
    {
        GameObject instance = UI相关.实例化(宫殿选择界面);
        LocationId = 0;
        if (instance != null)
        {
            //output(type);
            更新拜访信息(instance, LocationId, type, 参数);
            Transform previousButton = instance.transform.Find("宫殿选择").Find("上");
            Transform nextButton = instance.transform.Find("宫殿选择").Find("下");
            Transform exitButton = instance.transform.Find("宫殿选择").Find("离开按钮");
            Transform 更换宫殿按钮 = instance.transform.Find("宫殿选择").Find("换宫殿");
            Button 上 = previousButton.GetComponent<Button>();
            Button 下 = nextButton.GetComponent<Button>();
            Button 离开 = exitButton.GetComponent<Button>();
            Button 更换宫殿 = 更换宫殿按钮.GetComponent<Button>();    
            if(参数=="拜访")
            {
                CanvasGroup canvasGroup = 更换宫殿.GetComponent<CanvasGroup>();
                canvasGroup.alpha = 0;
                canvasGroup.interactable = false;
            }
            else if(参数=="安排宫殿"||参数=="初始化安排宫殿")
            {
                CanvasGroup canvasGroup = 更换宫殿.GetComponent<CanvasGroup>();
                canvasGroup.alpha = 1;
                canvasGroup.interactable = true;
                更换宫殿.onClick.AddListener(() =>
                {
                    LocationId = 0;
                    if(type==0)
                        更新拜访信息(instance, LocationId, 1, 参数);
                    else
                        更新拜访信息(instance, LocationId, 0, 参数);
                });
            }
            上.onClick.AddListener(() =>
            {
                //Debug.Log("点击上按钮");
                LocationId--;
                更新拜访信息(instance, LocationId, type,参数);
            });
            下.onClick.AddListener(() =>
            {
                //Debug.Log("点击下按钮");
                LocationId++;
                更新拜访信息(instance, LocationId, type, 参数);
            });
            离开.onClick.AddListener(() =>
            {
                if (instance != null)
                {
                    if (参数 == "初始化安排宫殿" && 中间变量.Instance.UI != null)
                        中间变量.Instance.UI.列表展示();
                    UI相关.销毁场景(instance);
                }
            });
        }
        else
        {
            Debug.Log("无法将拜访面板实例化");
        }
    }

    public void 更新拜访信息(GameObject instance,int id,int type,string 参数)
    {
        string panelName = "拜访面板";
        if (id < 0 || id*5 >= 已建宫殿[type].Count) return;
        Transform 拜访面板 = instance.transform.Find("宫殿选择").Find(panelName);
        if(拜访面板!=null)
        {
            Button[] buttons = 拜访面板.GetComponentsInChildren<Button>(true);
            for(int i=0;i<5; i++)
            {
                CanvasGroup canvasGroup = buttons[i].GetComponent<CanvasGroup>();
                if (id * 5 + i < 已建宫殿[type].Count)
                {
                    canvasGroup.alpha = 1;
                    canvasGroup.interactable = true;
                    Image[] images = buttons[i].GetComponentsInChildren<Image>(true);
                    TMP_Text text = buttons[i].GetComponentInChildren<TMP_Text>();    
                    images[1].sprite = 已建宫殿[type][id*5+i].宫殿外图;
                    text.text = 已建宫殿[type][id * 5 + i].宫殿名;
                    int index = id * 5 + i;
                    buttons[i].onClick.AddListener(() => {
                        打开房间选择面板(instance,index, type,参数);
                    });
                }
                else
                {
                    canvasGroup.alpha = 0;
                    canvasGroup.interactable = false;
                }
            }
        }
    }

    public void 打开房间选择面板(GameObject parentinstance,int id, int type, string 参数)
    {
        GameObject instance = UI相关.实例化(房间选择界面);
        Transform 宫殿房间面板 = instance.transform.Find("房间选择").Find("房间按钮总览");
        Button[]buttons = 宫殿房间面板.GetComponentsInChildren<Button>();
        for (int i = 0; i < buttons.Length; i++)
        {
            //Debug.Log(id);
            TMP_Text[] text = buttons[i].GetComponentsInChildren<TMP_Text>();
            text[0].text = 已建宫殿[type][id].房间名[i];
            if (已建宫殿[type][id].是否有人居住[i] == false) text[1].text = null;
            else
            {
                妃子 妃子 = (妃子)NPCManager.Instance.所有人物[已建宫殿[type][id].居住人[i]];
                text[1].text = "["+妃子.封号+妃子.位分+"]"+妃子.姓+妃子.名;
            }
            int index = i;
            buttons[i].onClick.RemoveAllListeners();
            Debug.Log(参数);
            buttons[i].onClick.AddListener(() => {
                Debug.Log("确认按钮已点击");
                if (参数 == "拜访")
                {
                    if(已建宫殿[type][id].是否有人居住[index] == true)
                    {
                        妃子 妃子 = (妃子)NPCManager.Instance.所有人物[已建宫殿[type][id].居住人[index]];
                        UI相关.NPC宫殿拜访 = 妃子;
                        UI相关.实例化(妃子拜访界面);
                    }
                }
                else if (参数 == "安排宫殿"||参数=="初始化安排宫殿")
                {
                    妃子 妃子 = 中间变量.Instance.被安排宫殿妃子;
                    if (已建宫殿[type][id].是否有人居住[index] == true)
                    {
                        Debug.Log("该位置已有人居住");
                    }
                    else if (index == 0 && 妃子.妃子品阶 >= 已建宫殿[type][id].最高位分)
                    {
                        Debug.Log("一宫正殿应由最高位妃子居住");
                    }
                    else
                    {
                        if (妃子.宫殿编号 != -1 && 妃子.宫殿类型 != -1 && 妃子.房间编号 != -1)
                        {
                            已建宫殿[妃子.宫殿类型][妃子.宫殿编号].是否有人居住[妃子.房间编号] = false;
                            已建宫殿[妃子.宫殿类型][妃子.宫殿编号].居住人[妃子.房间编号] = -1;
                            if (妃子.妃子品阶 == 已建宫殿[妃子.宫殿类型][妃子.宫殿编号].最高位分)
                            {
                                int 最高位分 = 数据库.所有位分.Count;

                                for (int kk=0;kk<5;kk++)
                                {
                                    if (已建宫殿[妃子.宫殿类型][妃子.宫殿编号].是否有人居住[kk]==true)
                                    {
                                        妃子 妃子2 = (妃子)NPCManager.Instance.所有人物[已建宫殿[妃子.宫殿类型][妃子.宫殿编号].居住人[kk]];
                                        最高位分 = Math.Min(最高位分, 妃子2.妃子品阶);
                                    }
                                }
                                已建宫殿[妃子.宫殿类型][妃子.宫殿编号].最高位分 = 最高位分;
                            }
                            if (妃子.宫殿编号 == id)
                            {
                                TMP_Text[] text = buttons[妃子.房间编号].GetComponentsInChildren<TMP_Text>();
                                text[1].text = "";
                            }
                        }
                        妃子.宫殿类型 = type;
                        妃子.宫殿编号 = id;
                        妃子.房间编号 = index;
                        妃子.住所 = 已建宫殿[type][id].宫殿名;
                        已建宫殿[type][id].最高位分 = Math.Min(已建宫殿[type][id].最高位分, 妃子.妃子品阶);
                        已建宫殿[type][id].是否有人居住[index] = true;
                        已建宫殿[type][id].居住人[index] = 妃子.编号;
                        text[1].text = "[" + 妃子.封号 + 妃子.位分 + "]" + 妃子.姓 + 妃子.名;
                    }
                }
            });
        }
        Transform 背景图片 = instance.transform.Find("房间选择").Find("背景图片");
        Image image = 背景图片.GetComponent<Image>();
        image.sprite = 已建宫殿[type][id].宫殿内图;

        Transform exitButton = instance.transform.Find("房间选择").Find("离开按钮");
        Button 离开 = exitButton.GetComponent<Button>();
        离开.onClick.AddListener(() =>
        {
            if (instance != null)
            {
                UI相关.销毁场景(instance);
            }
        });
    }
    #endregion
}
