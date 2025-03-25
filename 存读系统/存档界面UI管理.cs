using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class 存档界面UI管理 : MonoBehaviour
{
    public Transform 存档界面;
    public GameObject instance;
    public string 参数 = "";
    private Transform[] savePanels = new Transform[6];

    // 存储每个Panel下的Button和Text
    private Button[] saveButtons = new Button[6];
    private TMP_Text[] saveTexts = new TMP_Text[6];

    private int currentPage = 0; // 当前页数
    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            savePanels[i] = 存档界面.GetChild(i); // 假设6个Panel是存档界面的直接子对象
            saveButtons[i] = savePanels[i].GetComponentInChildren<Button>();
            saveTexts[i] = savePanels[i].GetChild(1).GetComponent<TMP_Text>();
        }

        // 初始化界面
        UpdateSaveSlots();
    }
    void UpdateSaveSlots()
    {
        for (int i = 0; i < 6; i++)
        {
            int saveSlot = currentPage * 6 + i + 1; // 计算当前存档编号
            saveButtons[i].GetComponentInChildren<TMP_Text>().text = $"存档 {saveSlot}"; // 更新Text显示
            string filePath = Path.Combine(Application.persistentDataPath, 参数 + saveSlot + ".json");
            if (File.Exists(filePath))
            {
                string jsonStr = File.ReadAllText(filePath);
                if(参数==""||参数=="游戏存档")
                {
                    GameData Data = JsonConvert.DeserializeObject<GameData>(jsonStr);
                    saveTexts[i].text = Data.存档名;
                }
                else if(参数=="位分存档")
                {
                    位分存储 Data = JsonConvert.DeserializeObject<位分存储>(jsonStr);
                    saveTexts[i].text = Data.存档名;
                }
            }
            else
            {
                saveTexts[i].text = "暂无存档";
            }

        }
    }
    public void 上一页()
    {
        if (currentPage == 0) return;
        currentPage--;
        UpdateSaveSlots();
    }

    public void 下一页()
    {
        currentPage++;
        UpdateSaveSlots();
    }

    public void 存档按钮点击(int id)
    {
        int index = currentPage * 6 + id + 1;
        string 存档名 = "";
        if (参数 == "" || 参数 == "游戏存档") 存档名 = 游戏设定.Instance.年号 + " " + 时间体系.Instance.年 + "年" + 时间体系.Instance.月 + "月  " + 主控.Instance.姓 + 主控.Instance.名;
        else if (参数 == "位分存档") 存档名 = "妃子位分模板" + index.ToString();
        GameObject 修改名字界面 = UI相关.实例化(Resources.Load<GameObject>("预制体/UI预制体/存读档界面/存读档界面命名"));
        存读档界面命名UI管理 UI = 修改名字界面.GetComponent<存读档界面命名UI管理>();
        UI.文本 = saveTexts[id];
        UI.提示词 = 存档名;
        UI.参数 = 参数;
        UI.index = index;
        UpdateSaveSlots();
    }

    public void 删除按钮点击(int id)
    {
        int index = currentPage * 6 + id + 1;
        string filePath = Path.Combine(Application.persistentDataPath, 参数 + index + ".json");
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            UpdateSaveSlots();
        }
    }
    public void 离开()
    {
        UI相关.销毁场景(instance);
    }
    public void 读档按钮点击(int id)
    {
        int saveSlot = currentPage * 6 + id + 1;
        string filePath = Path.Combine(Application.persistentDataPath, 参数 + saveSlot + ".json");
        if (File.Exists(filePath))
        {
            存读系统.Instance.读档(filePath,参数);
            UI相关.销毁场景(instance);
        }
        else
        {
            Debug.Log("暂无存档");
        }
    }
}
