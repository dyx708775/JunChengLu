using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;
using System;
using Newtonsoft.Json;
using static UnityEngine.EventSystems.EventTrigger;
using NodeCanvas.Tasks.Actions;

[System.Serializable]
public class GameData
{
    public string 存档名;
    public NPCManager NPCManager;
    public 主控 主控;
    public 国家 国家;
    public 时间体系 时间体系;
    public 宫殿管理 宫殿管理;
    public 家族管理 家族管理;
    public 物品管理 物品管理;
    public 游戏设定 游戏设定;
    public List<位分> 所有位分;
}

public class 位分存储
{
    public string 存档名;
    public List<位分> 所有位分;
    public 位分存储(string 存档名, List<位分> 所有位分)
    {
        this.存档名 = 存档名;
        this.所有位分 = 所有位分;
    }
}
public class 存读系统
{ 
    public static 存读系统 instance;
    public static 存读系统 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new 存读系统();
            }
            return instance;
        }
    }
    public GameData 存档准备(GameData data)
    {
        data.NPCManager = NPCManager.instance;
        data.主控 = 主控.instance;
        data.宫殿管理 = 宫殿管理.instance;
        data.家族管理 = 家族管理.instance;
        data.国家 = 国家.instance;
        data.时间体系 = 时间体系.instance;
        data.所有位分 = 数据库.所有位分;
        data.物品管理 = 物品管理.instance;
        data.游戏设定 = 游戏设定.Instance;
        return data;
    }
    public void 存档(int index,string 参数,string 存档名)
    {
        string jsonStr="";
        string filePath = Path.Combine(Application.persistentDataPath, 参数 + index + ".json"); ;
        //Debug.Log(filePath);
        if(参数=="游戏存档")
        {
            GameData data = new GameData();
            data = 存档准备(data);
            data.存档名 = 存档名;
            jsonStr = JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });
            //Debug.Log(jsonStr);
        }
        else if(参数=="位分存档")
        {
            jsonStr = JsonConvert.SerializeObject(new 位分存储(存档名,数据库.所有位分), Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });
        }
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.Write(jsonStr);
        }
    }


    public void 读档(string filePath,string 参数)
    {
        string jsonStr = File.ReadAllText(filePath);
        if(参数=="位分存档")
        {
            位分存储 妃子位分= JsonConvert.DeserializeObject<位分存储>(jsonStr, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            数据库.所有位分 = 妃子位分.所有位分;
            妃子位分界面UI管理 UI = UnityEngine.Object.FindObjectOfType<妃子位分界面UI管理>();
            UI.所有位分 = 数据库.所有位分;
            UI.刷新网格宽(数据库.所有位分.Count);
            UI.刷新按钮文本();

        }
        else if(参数=="游戏存档")
        {
            GameData Data = JsonConvert.DeserializeObject<GameData>(jsonStr, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            Canvas[] all_canvas = UnityEngine.Object.FindObjectsOfType<Canvas>();
            for (int i = 0; i < all_canvas.Length; i++)
            {
                // 销毁找到的Canvas
                Canvas canvas = all_canvas[i];
                UI相关.销毁场景(canvas.gameObject);
            }
            NPCManager.instance = Data.NPCManager;
            宫殿管理.instance = Data.宫殿管理;
            家族管理.instance = Data.家族管理;
            主控.instance = Data.主控;
            国家.instance = Data.国家;
            时间体系.instance = Data.时间体系;
            数据库.所有位分 = Data.所有位分;
            物品管理.instance = Data.物品管理;
            游戏设定.instance= Data.游戏设定;
            Debug.Log(游戏设定.Instance.年号);
            for (int i = 0; i < NPCManager.Instance.所有人物.Count; i++)
            {
                NPCManager.Instance.所有人物[i].加载立绘();
            }

            for (int i = 0; i < NPCManager.Instance.妃子列表.Count; i++)
            {
                妃子 妃子 = (妃子)NPCManager.Instance.所有人物[NPCManager.Instance.妃子列表[i]];
                Debug.Log(妃子 == null);
                妃子.加载宫殿图();
            }
            for (int i = 0; i < 2; i++)
                foreach (宫殿 宫殿 in 宫殿管理.Instance.未建宫殿[i])
                    宫殿.加载宫殿图();
            for (int i = 0; i < 2; i++)
                foreach (宫殿 宫殿 in 宫殿管理.Instance.已建宫殿[i])
                    宫殿.加载宫殿图();
            UI相关.实例化(Resources.Load<GameObject>("预制体/场景预制体/宫殿大地图"));
            UnityEngine.Object.Instantiate(Resources.Load("预制体/UI预制体/信息面板"));
        }
    }

}

