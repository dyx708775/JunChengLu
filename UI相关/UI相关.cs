using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Drawing;
using UnityEngine.AdaptivePerformance.Provider;
using UnityEngine.SceneManagement;
using System.Threading;
using UnityEditor;
using System;

public class UI相关
{
    // Start is called before the first frame update
    public static 妃子 NPC宫殿拜访;
    public static int 宫殿场景ID = 2;
    public static UI相关 instance;
    public static int 是否初始化宫殿 = 0;
    public AsyncOperation asyncLoad;
    public static string 记事总览类型;
    public List<int> layersort = new List<int>();
    public int maxsortlayer = 0;

    public static UI相关 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new UI相关();
            }
            return instance;
        }
    }

    public static GameObject 实例化(GameObject 预制体)
    {
        GameObject instance = UnityEngine.Object.Instantiate(预制体);
        Canvas canvas = instance.GetComponentInChildren<Canvas>();
        if (canvas != null)
        {
            if (Instance.layersort.Count == 0)
                canvas.sortingOrder = 0;
            else canvas.sortingOrder = Instance.layersort[Instance.layersort.Count - 1] + 1;
            Instance.layersort.Add(canvas.sortingOrder);
        }
        return instance;
    }

    public static void 销毁场景(GameObject instance)
    {
        Canvas canvas = instance.GetComponentInChildren<Canvas>();
        if (canvas != null) Instance.layersort.Remove(canvas.sortingOrder);
        UnityEngine.Object.Destroy(instance);
    }

    public static Sprite 新后宫图形读取程序(int 编号, string 特殊)
    {
        string _loc4_ = "a0aPic_FeiZi/";
        if (特殊 == "男宠")
        {
            _loc4_ = "a0aPic_NanChong/";
        }
        else if (特殊 == "外域")
        {
            _loc4_ = "a0aPic_Wai/";
        }
        else if (特殊 == "青楼")
        {
            _loc4_ = "a0aPic_QingLou/";
        }
        else if (特殊 == "特殊")
        {
            _loc4_ = "a0aPic_TeShu/";
        }
        else if (特殊 == "戏子")
        {
            _loc4_ = "a0aPic_XiZi/";
        }
        else if (特殊 == "敌将")
        {
            _loc4_ = "a0aPic_DiJiang/";
        }
        else if (特殊 == "名臣")
        {
            _loc4_ = "a0aPic_MingChen/";
        }
        else if (特殊 == "名妃")
        {
            _loc4_ = "a0aPic_MingFei/";
        }
        else if (特殊 == "技术")
        {
            _loc4_ = "a0aPic_JiShu/";
        }
        else if (特殊 == "宫殿")
        {
            _loc4_ = "a0aPic_Placae/";
        }
        else if (特殊 == "皇子")
        {
            _loc4_ = "a0aPic_HuangZi/";
        }
        else if (特殊 == "公主")
        {
            _loc4_ = "a0aPic_HiMe/";
        }
        else if (特殊 == "剧情")
        {
            _loc4_ = "a0aPic_JuQing/";
        }
        else if (特殊 == "隐士")
        {
            _loc4_ = "a0aPic_YinZ/";
        }
        else if (特殊 == "血滴子")
        {
            _loc4_ = "a0aPic_XDZ/";
        }
        else if (特殊 == "太医")
        {
            _loc4_ = "a0aPic_YiSya/";
        }
        else if (特殊 == "驸马")
        {
            _loc4_ = "acbPic_FuMa/";
        }
        else if (特殊 == "名妓")
        {
            _loc4_ = "a0ePic_MingJi/";
        }
        else if (特殊 == "物品")
        {
            _loc4_ = "a0aPic_Icon/";
        }
        else if (特殊 == "背景")
        {
            _loc4_ = "a0aPic_BG/";
        }
        else if (特殊 == "伴读")
        {
            _loc4_ = "a0aPic_BanDu/";
        }
        else if (特殊 == "宫女")
        {
            _loc4_ = "a0aPic_Gongnv/";
        }
        return 加载本地图片(_loc4_ + "Tu_" + 编号 + ".jpg");
    }
    public static Sprite 加载本地图片(string loadPath)
    {
        loadPath = Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath)) + "\\" + loadPath;
        if (!File.Exists(loadPath))
        {
            return null;
        }
        byte[] fileData = File.ReadAllBytes(loadPath);
        Texture2D texture = new Texture2D(2,2); 
        texture.LoadImage(fileData);
        var rect = new Rect(0, 0, texture.width, texture.height);

        Vector2 pivot = new Vector2(0.5f, 0.5f);

        float pixelsPerUnit = 100.0f;
        // 创建Sprite
        Sprite sprite = Sprite.Create(texture, rect, pivot, pixelsPerUnit);
        return sprite;
    }
    public static string 颜色代码(string str,string color)
    {
        return $"<color=#{color}>{str}</color>";
    }
    public  static void 小提示(string str)
    {
        GameObject instance = 实例化(Resources.Load<GameObject>("预制体/UI预制体/小提示面板"));
        小提示面板UI管理 UI = instance.GetComponent<小提示面板UI管理>();
        UI.提示文本 = str;
    }
    public static 简易剧情 打开对话框()
    {
        GameObject instance = UI相关.实例化(Resources.Load<GameObject>("预制体/场景预制体/对话系统/简易对话"));
        简易剧情 UI = instance.GetComponent<简易剧情>();
        return UI;
    }
}
