using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class 皇帝初始化UI管理 : MonoBehaviour
{
    public GameObject instance;
    public TMP_InputField 姓, 名, 年号;
    public Image image;
    public GameObject 界面;

    void Start()
    {
        更换立绘();   
    }
    public void 更换立绘()
    {
        主控.Instance.随机立绘();
        image.sprite = 主控.Instance.立绘;
    }

    public void 下一步()
    {
        主控.Instance.姓 = 姓.text;
        主控.Instance.名 = 名.text;
        主控.Instance.年龄 = 18;
        游戏设定.Instance.年号 = 年号.text;
        NPC 先皇 = NPCManager.Instance.创建随机人物("先皇", "男");
        主控.Instance.父亲 = 先皇.编号;
        先皇.姓 = 主控.Instance.姓;
        先皇.年龄 = Random.Range(40, 50);
        UI相关.销毁场景(instance);
        GameObject 位份修改界面 = UI相关.实例化(Resources.Load<GameObject>("预制体/信息展示预制体/妃子位分界面"));
        妃子位分界面UI管理 UI = 位份修改界面.GetComponent<妃子位分界面UI管理>();
        UI.参数 = "修改大位分";
        UI.所有位分 = 数据库.所有位分;
        UI.MyAction = () => { UI相关.实例化(界面); };
    }
}
