using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 妃子太妃列表UI管理 : MonoBehaviour
{
    public GameObject instance;
    public Toggle 妃子按钮, 太妃按钮;
    private 信息列表UI管理 UI;
    void Start()
    {
        妃子按钮.onValueChanged.AddListener(delegate { OnToggleValueChanged(妃子按钮); });
        太妃按钮.onValueChanged.AddListener(delegate { OnToggleValueChanged(太妃按钮); });
        妃子按钮.isOn = true;
        太妃按钮.isOn = false;
        UI = instance.GetComponent<信息列表UI管理>();
        OnToggleValueChanged(妃子按钮);
    }

    public void 增加妃子()
    {
        if(妃子按钮.isOn)
        {
            //Debug.Log("hahah");
            NPCManager.Instance.创建随机人物("妃子", "女");
            int len = NPCManager.Instance.妃子列表.Count;
            妃子 孺子 = (妃子)NPCManager.Instance.所有人物[NPCManager.Instance.妃子列表[len - 1]];
            孺子.妃子品阶 = UnityEngine.Random.Range(数据库.所有位分.Count/5*4,数据库.所有位分.Count);
            孺子.位分 = 数据库.所有位分[孺子.妃子品阶].所有小位分[0];
            数据库.所有位分[孺子.妃子品阶].已有人数++;
            孺子.籍贯 = 数据库.籍贯[UnityEngine.Random.Range(0, 数据库.籍贯.Length)];
            孺子.家族 = 孺子.籍贯 + 孺子.姓 + "氏";
            孺子.住所 = 宫殿管理.Instance.安排宫殿(孺子, 0);
            OnToggleValueChanged(妃子按钮);
        }
        else
        {
            太妃 太妃 = (太妃)NPCManager.Instance.创建随机人物("太妃", "女");
            太妃.籍贯 = 数据库.籍贯[UnityEngine.Random.Range(0, 数据库.籍贯.Length)];
            太妃.家族 = 太妃.籍贯 + 太妃.姓 + "氏";
            太妃.增加孩子();
            OnToggleValueChanged(太妃按钮);
        }
            
    }

    void OnToggleValueChanged(Toggle toggle)
    {
        if(toggle==妃子按钮&& toggle.isOn)
        {
            UI.npcsid = NPCManager.Instance.妃子列表;
            UI.type = "妃子";
            UI.参数 = "初始化妃子";
            UI.index = 1;
            UI.刷新npcs();
            UI.列表展示();
        }
        else if(toggle==太妃按钮 && toggle.isOn)
        {
            UI.npcsid = NPCManager.Instance.太妃列表;
            UI.type = "太妃";
            UI.参数 = "初始化太妃";
            UI.index = 1;
            UI.刷新npcs();
            UI.列表展示();
        }
    }
    public void 离开(GameObject 跳转界面)
    {
        if (NPCManager.Instance.太妃列表.Count > 0)
        {
            太妃 太后 = (太妃)NPCManager.Instance.所有人物[NPCManager.Instance.太妃列表[0]];
            皇帝 皇帝 = (皇帝)NPCManager.Instance.所有人物[NPCManager.Instance.皇帝列表[0]];
            皇帝.孩子.Add(主控.Instance.编号);
            太后.孩子.Add(主控.Instance.编号);
            太后.伴侣 = 皇帝.编号;
            皇帝.孩子.Add(主控.Instance.编号);
            主控.Instance.母亲 = 太后.编号;
        }  
        UI.离开();
        UI相关.实例化(跳转界面);
    }
}
