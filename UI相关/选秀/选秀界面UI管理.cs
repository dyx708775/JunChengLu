using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class 选秀界面UI管理 : MonoBehaviour
{
    public GameObject 选秀界面;
    public GameObject 选秀面板;
    public string 参数 = "妃嫔选秀";
    public List<NPC> npcs = new List<NPC>();
    void Start()
    {
        Button[] buttons = 选秀面板.GetComponentsInChildren<Button>();
        if(参数=="妃嫔选秀")
        {
            for (int i = 0; i < NPCManager.Instance.所有人物.Count && npcs.Count < buttons.Length; i++)
            {
                NPC npc = NPCManager.Instance.所有人物[i];
                if (npc.年龄 >= 游戏设定.Instance.最小选秀年龄 && npc.年龄 <= 游戏设定.Instance.最大选秀年龄 && npc.性别 == "女" && npc.伴侣 == -1&&npc.类型=="家眷")
                {
                    npcs.Add(npc);
                }
            }
            while (npcs.Count < buttons.Length)
            {
                npcs.Add(NPCManager.Instance.创建临时人物("妃子", "女"));
            }
        }
        Debug.Log(buttons.Length);
        for(int i=0;i<buttons.Length;i++)
        {
            Button btn = buttons[i];
            Image image = btn.GetComponentInChildren<Image>();
            Debug.Log(image);
            Debug.Log(npcs[i].立绘);
            image.sprite = npcs[i].立绘;
        }
    }
    public void 离开()
    {
        UI相关.销毁场景(选秀界面);
    }    
}
