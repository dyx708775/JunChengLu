using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class 大臣初始化UI管理 : MonoBehaviour
{
    public TMP_InputField 大臣数量;
    public GameObject instance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void 跳转界面()
    {
        int num = 10;
        if (int.TryParse(大臣数量.text, out int number))
        {
            num = number;
        }
        NPCManager.Instance.初始大臣生成(num);
        UI相关.销毁场景(instance);
        GameObject 小桂子界面 = UI相关.实例化(Resources.Load<GameObject>("预制体/场景预制体/游戏开始场景/小桂子开始界面"));
        小桂子开始界面 小桂子 = 小桂子界面.GetComponent<小桂子开始界面>();
        小桂子.文本 = "主子好！\n 我是小桂子。您的贴身奴才\n 登基典礼一会就要开始了。\n 您准备好了吗？";
        小桂子.参数 = "大臣界面跳转";
    }
}
