using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 简易剧情阐释 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void 打开避子汤事件()
    {
        Debug.Log("haha");
        剧情总览.Instance.避子汤判断(null);
    }
    public void 开始剧情()
    {
        List<对话> 剧情1 = new List<对话>();
        GameObject instance = UI相关.实例化(Resources.Load<GameObject>("预制体/场景预制体/对话系统/简易对话"));
        简易剧情 UI = instance.GetComponent<简易剧情>();
        剧情1.Add(new 对话("我想吃汉堡", UI相关.加载本地图片("a0aPic_FeiZi\\Tu_13.jpg")));
        剧情1.Add(new 对话("不，你只能吃薯条", UI相关.加载本地图片("a0aPic_FeiZi\\Tu_15.jpg")));
        UI.StartStory(剧情1, false, () => {
            Debug.Log("haha");
            Button[] buttons = UI.出现按钮(new List<string> { "嘿嘿", "哈哈" });
            buttons[0].onClick.AddListener(() =>
            {
                剧情1 = new List<对话>();
                剧情1.Add(new 对话("嘿嘿", null));
                UI.StartStory(剧情1, true, null);
            });
            buttons[1].onClick.AddListener(() =>
            {
                剧情1 = new List<对话>();
                剧情1.Add(new 对话("哈哈", null));
                UI.StartStory(剧情1, true, null);
            });
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
