using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class 小桂子开始界面 : MonoBehaviour
{
    public GameObject instance;
    public string 参数;
    public string 文本;
    public TMP_Text 小桂子文本;

    private void Start()
    {
        小桂子文本.text = 文本;
    }

    public void 跳转页面()
    {
        UI相关.销毁场景(instance);
        if(参数=="大臣界面跳转")
            UI相关.实例化(Resources.Load<GameObject>("预制体/场景预制体/游戏开始场景/圣旨界面"));
        else if(参数=="圣旨界面跳转")
        {
            GameObject instance = UI相关.实例化(Resources.Load<GameObject>("预制体/场景预制体/游戏开始场景/小桂子开始界面"));
            小桂子开始界面 UI= instance.GetComponent<小桂子开始界面>();
            UI.参数 = "小桂子开始界面跳转";
            UI.文本 = "皇帝" + 主控.Instance.姓 + 主控.Instance.名 + "在文武大臣和全国百姓的期待下登上极位。\n宣布年号为" + 游戏设定.Instance.年号 + "。\n象征一个新的盛世即将展开。";
        }
        else if(参数=="小桂子开始界面跳转")
        {
            Instantiate(Resources.Load<GameObject>("预制体/UI预制体/信息面板"));
            UI相关.实例化(Resources.Load<GameObject>("预制体/场景预制体/宫殿大地图"));
        }
    }
}
