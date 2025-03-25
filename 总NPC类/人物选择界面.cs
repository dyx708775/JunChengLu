using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 人物选择界面
{
    // Start is called before the first frame update
    private int LocationId = 0;
    public List<int> npcsid;
    public List<NPC> npcs = new List<NPC>();
    public static 人物选择界面 instance;
    public static 人物选择界面 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new 人物选择界面();
            }
            return instance;
        }
    }
    public void 打开人物拜访界面()
    {
        for (int i = 0; i < npcsid.Count; i++)
        {
            npcs.Add(NPCManager.Instance.所有人物[npcsid[i]]);
        }
        GameObject instance = UI相关.实例化(Resources.Load<GameObject>("预制体/场景预制体/人物选择界面")); 
        LocationId = 0;
        if (instance != null)
        {
            更新拜访信息(instance, LocationId);
            Transform previousButton = instance.transform.Find("人物选择").Find("上");
            Transform nextButton = instance.transform.Find("人物选择").Find("下");
            Transform exitButton = instance.transform.Find("人物选择").Find("离开按钮");
            Button 上 = previousButton.GetComponent<Button>();
            Button 下 = nextButton.GetComponent<Button>();
            Button 离开 = exitButton.GetComponent<Button>();
            上.onClick.AddListener(() =>
            {
                LocationId--;
                更新拜访信息(instance, LocationId);
            });
            下.onClick.AddListener(() =>
            {
                LocationId++;
                更新拜访信息(instance, LocationId);
            });
            离开.onClick.AddListener(() =>
            {
                if (instance != null)
                {
                    UI相关.销毁场景(instance);
                }
            });
        }
        else
        {
            Debug.Log("无法将拜访面板实例化");
        }
    }

    public void 更新拜访信息(GameObject instance, int id)
    {
        string panelName = "拜访面板";
        if (id < 0 || id * 5 >= npcs.Count) return;
        Transform 拜访面板 = instance.transform.Find("人物选择").Find(panelName);
        if (拜访面板 != null)
        {
            Button[] buttons = 拜访面板.GetComponentsInChildren<Button>(true);
            for (int i = 0; i < 5; i++)
            {
                CanvasGroup canvasGroup = buttons[i].GetComponent<CanvasGroup>();
                if (id * 5 + i < npcs.Count)
                {
                    canvasGroup.alpha = 1;
                    canvasGroup.interactable = true;
                    Image[] images = buttons[i].GetComponentsInChildren<Image>(true);
                    TMP_Text text = buttons[i].GetComponentInChildren<TMP_Text>();
                    images[1].sprite = npcs[id * 5 + i].立绘;
                    text.text = npcs[id * 5 + i].姓 + npcs[id * 5 + i].名;
                    int index = id * 5 + i;
                    buttons[i].onClick.AddListener(() => {
                        npcs[index].拜访();
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
}
