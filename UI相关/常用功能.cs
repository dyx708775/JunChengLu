using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 常用功能
{

    // Start is called before the first frame update
    #region 单例模式
    public static 常用功能 instance;
    public static 常用功能 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new 常用功能();
            }
            return instance;
        }
    }
    #endregion

    public void 打开大臣属性列表(string 参数)
    {
        GameObject instance = UI相关.实例化(Resources.Load<GameObject>("预制体/场景预制体/属性列表/大臣属性列表"));
        信息列表UI管理 UI = instance.GetComponent<信息列表UI管理>();
        UI.npcsid = NPCManager.Instance.大臣列表;
        UI.参数 = 参数;
        UI.type = "大臣";
        UI.刷新npcs();
        UI.列表展示();
    }

    public void 科举处理()
    {

    }

    public void 祭祀活动举行()
    {

    }

    public void 打开妃嫔属性列表(string 参数)
    {
        GameObject instance = UI相关.实例化(Resources.Load<GameObject>("预制体/场景预制体/属性列表/妃子列表"));
        信息列表UI管理 UI = instance.GetComponent<信息列表UI管理>();
        if (参数 == "安排宫殿"||参数=="妃嫔晋位") UI.npcsid = NPCManager.Instance.妃子列表.GetRange(1, NPCManager.Instance.妃子列表.Count-1);
        else  UI.npcsid = NPCManager.Instance.妃子列表;
        UI.参数 = 参数;
        UI.type = "妃子";
        UI.刷新npcs();
        UI.列表展示();
    }

    public void 打开孩子属性列表()
    {

    }

    public void 存档功能()
    {
        GameObject instance = UI相关.实例化(Resources.Load<GameObject>("预制体/UI预制体/存读档界面/存档界面"));
        存档界面UI管理 UI = instance.GetComponent<存档界面UI管理>();
        UI.参数 = "游戏存档";
    }

    public void 读档功能()
    {
        GameObject instance = UI相关.实例化(Resources.Load<GameObject>("预制体/UI预制体/存读档界面/读档界面"));
        存档界面UI管理 UI = instance.GetComponent<存档界面UI管理>();
        UI.参数 = "游戏存档";
    }
}
