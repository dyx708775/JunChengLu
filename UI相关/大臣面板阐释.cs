using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class 大臣面板阐释 : MonoBehaviour
{
    // Start is called before the first frame update
    public Image image;
    void Start()
    {
        
    }

    public void 更改中间变量UI()
    {

    }
    public void 添加人物()
    {
        for (int i = 0; i < 16; i++)
        {
            NPCManager.Instance.创建随机人物("大臣", "男");
        }
    }

    public void 打开妃嫔品阶面板()
    {
        GameObject instance = UI相关.实例化(Resources.Load<GameObject>("预制体/信息展示预制体/妃子位分界面"));
        妃子位分界面UI管理 UI = instance.GetComponent<妃子位分界面UI管理>();
        UI.参数 = "修改大位分";
        UI.所有位分 = 数据库.所有位分;
    }
    public void 拜访大臣面板()
    {
        人物选择界面.Instance.npcsid = NPCManager.Instance.大臣列表;
        人物选择界面.Instance.打开人物拜访界面();
    }
    public void 创建族谱人物()
    {
        for (int i = 0; i < 3; i++)
        {
            NPC npc = NPCManager.Instance.创建随机人物("家族人物", "男");
            if (家族管理.Instance.所有家族.ContainsKey(npc.籍贯))
            {
                家族管理.Instance.所有家族[npc.籍贯].根成员.Add(npc.编号);
            }
        }
    }
    public void 族谱尝试()
    {
        if (家族管理.Instance.所有家族.ContainsKey("弘农杨氏"))
        {
            家族管理.Instance.所有家族["弘农杨氏"].打开族谱界面();
        }
    }

    public void 图片()
    {
        string Filepath = "a0aPic_FeiZi\\1.jpg";
        image.sprite = UI相关.加载本地图片(Filepath);
    }

    public void 图片2()
    {
        string Filepath = "a0aPic_FeiZi\\Tu_1.jpg";
        image.sprite = UI相关.加载本地图片(Filepath);
    }
    public void 存档()
    {
        //存读系统.Instance.存档();
    }
    public void 读档()
    {
        //存读系统.Instance.读档();
    }
    public void 宫女侍寝剧情()
    {
        //剧情文件加载
        GameObject instance = UI相关.实例化(Resources.Load<GameObject>("预制体/场景预制体/对话系统/对话系统"));
        Dialogue dialogue = instance.GetComponent<Dialogue>();
        //获取发生事件的人物
        List<NPC> npcs = new List<NPC>();
        npcs.Add(主控.Instance);
        npcs.Add(NPCManager.Instance.创建随机人物("妃子", "女"));
        //开始事件
        string FilePath = "剧情总览/宫女侍寝1";
        TextAsset inkJSONAsset = Resources.Load<TextAsset>(FilePath);
        dialogue.StartStory(OnStoryFinished, inkJSONAsset, npcs);
        //后续事件
    }
    private void OnStoryFinished(List<int> storyData)
    {
        // 在这里处理返回的列表数据
        foreach (var line in storyData)
        {
            Debug.Log(line);
        }
        // 继续其他操作...
    }
}
