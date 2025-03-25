using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 圣旨界面UI管理 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject instance;
    void Start()
    {
        
    }
    public void 跳转界面()
    {
        for (int i = 0; i < NPCManager.Instance.所有人物.Count; i++)
        {
            NPC npc = NPCManager.Instance.所有人物[i];
            npc.名称 = npc.姓 + npc.名;
        }
        UI相关.销毁场景(instance);
        GameObject 小桂子界面 = UI相关.实例化(Resources.Load<GameObject>("预制体/场景预制体/游戏开始场景/小桂子开始界面"));
        小桂子开始界面 小桂子 = 小桂子界面.GetComponent<小桂子开始界面>();
        小桂子.文本 = "接着举行皇后册立大典。\n将原太子妃册立为皇后。\n一切礼仪都在大臣的安排下顺利完成。";
        小桂子.参数 = "圣旨界面跳转";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
