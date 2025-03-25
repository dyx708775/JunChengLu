using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class 信息列表UI管理 : MonoBehaviour
{
    // Start is called before the first frame update
    public List<int> npcsid;
    public List<string> 关系;
    public string type;
    public string 参数="";
    public List<NPC> npcs = new List<NPC>();
    public GameObject instance;
    public int buttonslen = 10;
    public int index = 1;
    private UnityEngine.UI.Button[] buttons;
    private string[] 大写数字 = { "一", "二", "三", "四", "五", "六", "七", "八", "九" };
    void Start()
    {
        UnityEngine.UI.Button[] buttons = instance.transform.Find("属性列表").GetComponents<UnityEngine.UI.Button>();
        buttonslen = buttons.Length;
        中间变量.Instance.dl += 刷新列表;
    }

    public void 刷新列表(int index)
    {
        Debug.Log(type);
        Debug.Log(index);
        Debug.Log(instance);
        if(参数=="家眷")
        {
            int i = npcsid.FindIndex(x=>x==index);
            npcsid.RemoveAt(i);
            关系.RemoveAt(i);
        }
        else
        {
            npcsid.RemoveAll(x => x == index);
        }
        刷新npcs();
        列表展示();
    }
    public void 刷新npcs()
    {
        npcs.Clear();
        for (int i = 0; i < npcsid.Count; i++)
        {
            npcs.Add(NPCManager.Instance.所有人物[npcsid[i]]);
        }
    }
    public void 列表展示()
    {
        //Debug.Log(type);
        //Debug.Log(instance);
        UnityEngine.UI.Button[] buttons = instance.transform.Find("属性列表").GetComponentsInChildren<UnityEngine.UI.Button>();
        buttonslen = buttons.Length;
        int s = (index - 1) * buttonslen, e = index * buttonslen - 1, len = npcs.Count;
        //Debug.Log(npcs.Count);
        for (int i = 0; i < buttonslen; i++)
        {
            UnityEngine.UI.Button button = buttons[i];
            int id = (index - 1) * buttonslen + i;
            TextMeshProUGUI[] textComponents = button.GetComponentsInChildren<TextMeshProUGUI>(true);
            if (s + i >= len)
            {
                button.interactable = false;
                button.GetComponent<CanvasGroup>().alpha = 0.0f;
            }
            else
            {
                button.interactable = true;
                button.GetComponent<CanvasGroup>().alpha = 1.0f;   
                if(type=="大臣")
                {
                    大臣 npc = (大臣)npcs[id];
                    npcs[id] = npcs[id];
                    button.GetComponent<CanvasGroup>().alpha = 1.0f;
                    button.interactable = true;
                    textComponents[0].text = npc.姓 + npc.名;
                    textComponents[1].text = npc.年龄.ToString();
                    textComponents[2].text = npc.统帅.ToString();
                    textComponents[3].text = npc.武力.ToString();
                    textComponents[4].text = npc.智力.ToString();
                    textComponents[5].text = npc.政治.ToString();
                    textComponents[6].text = npc.魅力.ToString();
                    textComponents[7].text = 数据库.所有官员品阶[npc.品阶]+" ";
                    if (npc.官职 != null)
                        textComponents[7].text += npc.官职.官职名称;
                    else if (npc.大臣类别 == "武")
                        textComponents[7].text += 数据库.武散官[npc.品阶];
                    else if (npc.大臣类别 == "文")
                        textComponents[7].text += 数据库.文散官[npc.品阶];
                    textComponents[8].text = npc.爵位;
                }
                else if(type=="妃子")
                {
                    妃子 npc = (妃子)npcs[id];
                    textComponents[0].text = npc.姓 + npc.名;
                    textComponents[1].text = npc.家族;
                    textComponents[2].text = npc.年龄.ToString();
                    textComponents[3].text = npc.位分;
                    textComponents[4].text = npc.住所;
                    textComponents[5].text = npc.孩子.Count.ToString();
                    textComponents[6].text = npc.经验.ToString();
                    textComponents[7].text = npc.宠.ToString();
                    textComponents[8].text = npc.孕 > 0 ? "孕" : "正常";
                }
                else if(type=="太妃")
                {
                    太妃 npc = (太妃)npcs[id];
                    textComponents[0].text = npc.姓 + npc.名;
                    textComponents[1].text = npc.家族;
                    textComponents[2].text = npc.年龄.ToString();
                    textComponents[3].text = npc.位分;
                    textComponents[4].text = npc.住所;
                    if (id == 0)
                        textComponents[5].text = (npc.孩子.Count + 1).ToString();
                    else textComponents[5].text = npc.孩子.Count.ToString();
                    textComponents[6].text = npc.经验.ToString();
                    textComponents[7].text = npc.宠爱.ToString();
                    textComponents[8].text = "正常";
                }
                else if(type=="家眷")
                {
                    NPC npc = npcs[id];
                    textComponents[0].text = npc.姓 + npc.名;
                    textComponents[1].text = npc.年龄.ToString();
                    textComponents[2].text = npc.统帅.ToString();
                    textComponents[3].text = npc.武力.ToString();
                    textComponents[4].text = npc.智力.ToString();
                    textComponents[5].text = npc.政治.ToString();
                    textComponents[6].text = npc.魅力.ToString();
                    textComponents[7].text = 关系[id];
                    textComponents[8].text = npc.孩子.Count.ToString();
                }
            }

        }
    }
    public void 上一页()
    {
        if (index > 1)
        {
            index--;
            列表展示();
        }
    }
    public void 下一页()
    {
        if(index*buttonslen<npcs.Count)
        {
            index++;
            列表展示();
        }
    }
    public void 离开()
    {
        中间变量.Instance.dl -= 刷新列表;
        UI相关.销毁场景(instance);
    }
}
