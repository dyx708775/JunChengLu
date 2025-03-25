using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using UnityEngine.UI;

public class 妃子位分界面UI管理 : MonoBehaviour
{
    public GameObject 妃子位分界面;
    public UnityEngine.UI.Button 加位分, 减位分, 存储模板, 读取模板;
    public GameObject 按钮预制体;
    public UnityEngine.UI.Toggle 小位分添加, 位分名修改;
    public GameObject 位分界面;
    public GridLayoutGroup 网格;
    public int 小位分所属的大位分 = -1;
    public List<位分> 所有位分 = new List<位分>();
    public List<string> 小位分列表 = new List<string>();
    public GameObject 被修改按钮;
    public string 参数 = "修改大位分";
    public Action MyAction=null;
    void Start()
    {
        网格 = 位分界面.GetComponent<GridLayoutGroup>();
        if (参数 == "修改大位分")
        {
            小位分添加.GetComponent<CanvasGroup>().alpha = 1;
            小位分添加.GetComponent<CanvasGroup>().interactable = true;
            位分名修改.GetComponent<CanvasGroup>().interactable = true;
            位分名修改.GetComponent<CanvasGroup>().alpha = 1;
            存储模板.GetComponent<CanvasGroup>().alpha = 1;
            存储模板.GetComponent<CanvasGroup>().interactable = true;
            读取模板.GetComponent<CanvasGroup>().alpha = 1;
            读取模板.GetComponent<CanvasGroup>().interactable = true;
            刷新网格宽(所有位分.Count);
            刷新按钮文本();
        }
        else if (参数 == "修改小位分")
        {
            小位分添加.GetComponent<CanvasGroup>().alpha = 0;
            小位分添加.GetComponent<CanvasGroup>().interactable = false;
            位分名修改.GetComponent<CanvasGroup>().interactable = false;
            位分名修改.GetComponent<CanvasGroup>().alpha = 0;
            存储模板.GetComponent<CanvasGroup>().alpha = 0;
            存储模板.GetComponent<CanvasGroup>().interactable = false;
            读取模板.GetComponent<CanvasGroup>().alpha = 0;
            读取模板.GetComponent<CanvasGroup>().interactable = false;
            刷新网格宽(小位分列表.Count);
            刷新按钮文本();
        }
        else if (参数 == "册封大位分" || 参数 == "册封小位分" || 参数 == "妃嫔晋位" || 参数 == "妃嫔降位" || 参数 == "选秀")
        {
            小位分添加.GetComponent<CanvasGroup>().alpha = 0;
            小位分添加.GetComponent<CanvasGroup>().interactable = false;
            位分名修改.GetComponent<CanvasGroup>().interactable = false;
            位分名修改.GetComponent<CanvasGroup>().alpha = 0;
            存储模板.GetComponent<CanvasGroup>().alpha = 0;
            存储模板.GetComponent<CanvasGroup>().interactable = false;
            读取模板.GetComponent<CanvasGroup>().alpha = 0;
            读取模板.GetComponent<CanvasGroup>().interactable = false;
            加位分.GetComponent<CanvasGroup>().alpha = 0;
            加位分.GetComponent<CanvasGroup>().interactable = false;
            减位分.GetComponent<CanvasGroup>().alpha = 0;
            减位分.GetComponent<CanvasGroup>().interactable = false;
            if (参数 == "册封大位分" || 参数 == "妃嫔晋位" || 参数 == "妃嫔降位" || 参数 == "选秀") 刷新网格宽(所有位分.Count);
            else if (参数 == "册封小位分") 刷新网格宽(小位分列表.Count);
            刷新按钮文本();
        }
        else if (参数 == "妻妾等级修改" || 参数 == "公主等级修改" || 参数 == "皇子等级修改" || 参数 == "大臣爵位修改" || 参数 == "皇子妻妾等级修改" || 参数 == "太子妻妾等级修改")
        {
            小位分添加.GetComponent<CanvasGroup>().alpha = 0;
            小位分添加.GetComponent<CanvasGroup>().interactable = false;
            位分名修改.GetComponent<CanvasGroup>().interactable = true;
            位分名修改.GetComponent<CanvasGroup>().alpha = 1;
            存储模板.GetComponent<CanvasGroup>().alpha = 1;
            存储模板.GetComponent<CanvasGroup>().interactable = true;
            读取模板.GetComponent<CanvasGroup>().alpha = 1;
            读取模板.GetComponent<CanvasGroup>().interactable = true;
            刷新网格宽(小位分列表.Count);
            刷新按钮文本();
        }
        else if (参数 == "妻妾等级册封" || 参数 == "公主等级册封" || 参数 == "皇子等级册封" || 参数 == "大臣爵位册封" || 参数 == "皇子妻妾等级册封" || 参数 == "太子妻妾等级册封")
        {
            小位分添加.GetComponent<CanvasGroup>().alpha = 0;
            小位分添加.GetComponent<CanvasGroup>().interactable = false;
            位分名修改.GetComponent<CanvasGroup>().interactable = false;
            位分名修改.GetComponent<CanvasGroup>().alpha = 0;
            存储模板.GetComponent<CanvasGroup>().alpha = 0;
            存储模板.GetComponent<CanvasGroup>().interactable = false;
            读取模板.GetComponent<CanvasGroup>().alpha = 0;
            读取模板.GetComponent<CanvasGroup>().interactable = false;
            加位分.GetComponent<CanvasGroup>().alpha = 0;
            加位分.GetComponent<CanvasGroup>().interactable = false;
            减位分.GetComponent<CanvasGroup>().alpha = 0;
            减位分.GetComponent<CanvasGroup>().interactable = false;
            刷新网格宽(小位分列表.Count);
            刷新按钮文本();
        }
    }

    public void 点击存储模板()
    {
        GameObject instance = UI相关.实例化(Resources.Load<GameObject>("预制体/UI预制体/存读档界面/存档界面"));
        存档界面UI管理 UI = instance.GetComponent<存档界面UI管理>();
        if (参数 == "妻妾等级修改") UI.参数 = "妻妾等级存档";
        else if (参数 == "公主等级修改") UI.参数 = "公主等级存档";
        else if (参数 == "皇子等级修改") UI.参数 = "皇子等级存档";
        else if (参数 == "大臣爵位修改") UI.参数 = "大臣爵位存档";
        else if (参数 == "皇子妻妾等级修改") UI.参数 = "皇子妻妾等级存档";
        else if (参数 == "太子妻妾等级修改") UI.参数 = "太子妻妾等级存档";
        else UI.参数 = "位分存档";
    }

    public void 点击读取模板()
    {
        数据库.所有位分 = this.所有位分;
        GameObject instance = UI相关.实例化(Resources.Load<GameObject>("预制体/UI预制体/存读档界面/读档界面"));
        存档界面UI管理 UI = instance.GetComponent<存档界面UI管理>();
        UI.参数 = "位分存档";
    }
    public void 刷新网格宽(int len)
    {
        if (len < 9) 网格.constraintCount = 1;
        else if (len < 18) 网格.constraintCount = 2;
        else 网格.constraintCount = 3;
    }
    public void 刷新按钮文本()
    {
        int len = 0;
        int 已有选项数量 = 位分界面.transform.childCount;
        if (参数 == "修改大位分" || 参数 == "册封大位分" || 参数 == "妃嫔晋位" || 参数 == "妃嫔降位" || 参数 == "选秀") len = 所有位分.Count;
        else if (参数 == "修改小位分" || 参数 == "册封小位分") len = 小位分列表.Count;
        for (int i = 0; i < len; i++)
        {
            int index = i;
            GameObject instance;
            if (i >= 已有选项数量)
                instance = Instantiate(按钮预制体, 位分界面.transform);
            else
                instance = 位分界面.transform.GetChild(i).gameObject;
            UnityEngine.UI.Button button = instance.GetComponentInChildren<UnityEngine.UI.Button>();
            if (参数 == "妃嫔晋位" || 参数 == "妃嫔降位")
            {
                妃子 妃子 = 中间变量.Instance.册封妃子;
                if ((参数 == "妃嫔晋位" && i >= 妃子.妃子品阶) || (参数 == "妃嫔降位" && i <= 妃子.妃子品阶))
                {
                    instance.GetComponent<CanvasGroup>().alpha = 0;
                    instance.GetComponent<CanvasGroup>().interactable = false;
                }
                else
                {
                    instance.GetComponent<CanvasGroup>().alpha = 1;
                    instance.GetComponent<CanvasGroup>().interactable = true;
                    if (所有位分[i].上限人数 >= 100) instance.GetComponentsInChildren<TMP_Text>()[1].text = "已有" + 所有位分[i].已有人数 + "人,无上限";
                    else instance.GetComponentsInChildren<TMP_Text>()[1].text = "已有" + 所有位分[i].已有人数 + "人,上限" + 所有位分[i].上限人数 + "人";
                    button.GetComponentInChildren<TMP_Text>().text = 所有位分[i].大位分名称;
                }

            }
            else if (参数 == "修改大位分" || 参数 == "册封大位分" || 参数 == "选秀")
            {
                if (所有位分[i].上限人数 >= 100) instance.GetComponentsInChildren<TMP_Text>()[1].text = "已有" + 所有位分[i].已有人数 + "人,无上限";
                else instance.GetComponentsInChildren<TMP_Text>()[1].text = "已有" + 所有位分[i].已有人数 + "人,上限" + 所有位分[i].上限人数 + "人";
                button.GetComponentInChildren<TMP_Text>().text = 所有位分[i].大位分名称;
            }
            else if (参数 == "修改小位分" || 参数 == "册封小位分")
            {
                Debug.Log(小位分列表[i]);
                button.GetComponentInChildren<TMP_Text>().text = 小位分列表[i];
                instance.GetComponentsInChildren<TMP_Text>()[1].text = "";
            }
            button.onClick.RemoveAllListeners();
            if (参数 == "修改大位分" || 参数 == "修改小位分")
                button.onClick.AddListener(() => 按下按钮(index));
            else if (参数 == "册封大位分" || 参数 == "册封小位分" || 参数 == "妃嫔晋位" || 参数 == "妃嫔降位" || 参数 == "选秀")
                button.onClick.AddListener(() => 册封按钮(index));
        }
        for (int i = len; i < 已有选项数量; i++)
        {
            Destroy(位分界面.transform.GetChild(i).gameObject);
        }
    }

    public void 册封按钮(int index)
    {
        if (中间变量.Instance.册封妃子 == null) return;
        妃子 妃子 = 中间变量.Instance.册封妃子;
        if (参数 == "册封大位分" || 参数 == "妃嫔晋位" || 参数 == "妃嫔降位" || 参数 == "选秀")
        {
            if (所有位分[index].已有人数 >= 所有位分[index].上限人数)
            {
                UI相关.小提示("该位分人数已达上限");
                return;
            }
            if (index == 0) 游戏设定.Instance.皇后 = 妃子.编号;
            if (妃子.妃子品阶 >= 0 && 妃子.妃子品阶 < 所有位分.Count)
            {
                if (妃子.妃子品阶 == 0) 游戏设定.Instance.皇后 = -1;
                所有位分[妃子.妃子品阶].已有人数--;
                if (所有位分[妃子.妃子品阶].上限人数 > 100) 位分界面.transform.GetChild(妃子.妃子品阶).gameObject.GetComponentsInChildren<TMP_Text>()[1].text = "已有" + 所有位分[妃子.妃子品阶].已有人数 + "人,无上限";
                else 位分界面.transform.GetChild(妃子.妃子品阶).gameObject.GetComponentsInChildren<TMP_Text>()[1].text = "已有" + 所有位分[妃子.妃子品阶].已有人数 + "人,上限" + 所有位分[妃子.妃子品阶].上限人数 + "人";
                if (家族管理.Instance.所有家族.ContainsKey(妃子.家族))
                {
                    家族管理.Instance.所有家族[妃子.家族].后宫势力-=派系管理.获取妃子势力值(妃子);
                }
            }
            妃子.妃子品阶 = index;
            所有位分[index].已有人数++;
            if (所有位分[index].上限人数 > 100) 位分界面.transform.GetChild(index).gameObject.GetComponentsInChildren<TMP_Text>()[1].text = "已有" + 所有位分[index].已有人数 + "人,无上限";
            else 位分界面.transform.GetChild(index).gameObject.GetComponentsInChildren<TMP_Text>()[1].text = "已有" + 所有位分[index].已有人数 + "人,上限" + 所有位分[index].上限人数 + "人";
            if (家族管理.Instance.所有家族.ContainsKey(妃子.家族))
            {
                家族管理.Instance.所有家族[妃子.家族].后宫势力 += 派系管理.获取妃子势力值(妃子);
                家族管理.Instance.所有家族[妃子.家族].总势力值 = 家族管理.Instance.所有家族[妃子.家族].后宫势力 + 家族管理.Instance.所有家族[妃子.家族].朝廷势力;
            }
            if (所有位分[index].所有小位分.Count <= 1)
            {
                妃子.位分 = 所有位分[index].大位分名称;
            }
            else
            {
                GameObject instance = UI相关.实例化(Resources.Load<GameObject>("预制体/信息展示预制体/妃子位分界面"));
                妃子位分界面UI管理 UI = instance.GetComponent<妃子位分界面UI管理>();
                UI.参数 = "册封小位分";
                UI.小位分列表 = 所有位分[index].所有小位分;
                妃子.位分 = 所有位分[index].所有小位分[0];
            }
        }
        else if (参数 == "册封小位分")
        {
            妃子.位分 = 小位分列表[index];
            UI相关.销毁场景(妃子位分界面);
        }
    }

    public void 按下按钮(int index)
    {
        Debug.Log(index);
        if (参数 == "修改大位分")
        {
            if (位分名修改.isOn)
            {
                被修改按钮 = 位分界面.transform.GetChild(index).gameObject;
                打开位分修改界面(index);
            }
            else if (小位分添加.isOn&&index!=0)
            {
                GameObject instance = UI相关.实例化(Resources.Load<GameObject>("预制体/信息展示预制体/妃子位分界面"));
                妃子位分界面UI管理 UI = instance.GetComponent<妃子位分界面UI管理>();
                UI.参数 = "修改小位分";
                UI.小位分列表 = 所有位分[index].所有小位分;
                Debug.Log(UI.小位分列表.Count);
            }
            else if(小位分添加.isOn&&index==0)
            {
                UI相关.小提示("最高位分无法添加小位分！！");
            }
        }
        else if (参数 == "修改小位分")
        {
            被修改按钮 = 位分界面.transform.GetChild(index).gameObject;
            打开位分修改界面(index);
        }
    }

    public void 打开位分修改界面(int index)
    {
        Debug.Log(index);
        GameObject instance = UI相关.实例化(Resources.Load<GameObject>("预制体/信息展示预制体/妃子位分修改界面"));
        位分修改界面UI管理 UI = instance.GetComponent<位分修改界面UI管理>();
        UI.index = index;
        UI.UI = this;
    }

    public void 添加位分()
    {
        GameObject instance = Instantiate(按钮预制体, 位分界面.transform);
        UnityEngine.UI.Button button = instance.GetComponentInChildren<UnityEngine.UI.Button>();
        button.onClick.RemoveAllListeners();
        被修改按钮 = instance;
        if (参数 == "修改大位分")
        {
            所有位分.Add(new 位分("侍御", "从九品", new List<string>() { "侍御" }, 99999));
            int index = 所有位分.Count - 1;
            button.onClick.AddListener(() => 按下按钮(index));
            打开位分修改界面(所有位分.Count - 1);
            刷新网格宽(所有位分.Count);
        }
        else if (参数 == "修改小位分")
        {
            小位分列表.Add("");
            int index = 小位分列表.Count - 1;
            button.onClick.AddListener(() => 按下按钮(index));
            打开位分修改界面(小位分列表.Count - 1);
            刷新网格宽(所有位分.Count);
        }
    }
    public void 减少位分()
    {
        if (参数 == "修改大位分" && 所有位分.Count > 5)
        {
            所有位分.RemoveAt(所有位分.Count - 1);
            Destroy(位分界面.transform.GetChild(位分界面.transform.childCount - 1).gameObject);
            刷新网格宽(所有位分.Count);
        }
        else if (参数 == "修改小位分" && 小位分列表.Count > 0)
        {
            小位分列表.RemoveAt(小位分列表.Count - 1);
            Destroy(位分界面.transform.GetChild(位分界面.transform.childCount - 1).gameObject);
            刷新网格宽(小位分列表.Count);
        }
    }

    public void 离开()
    {
        UI相关.销毁场景(妃子位分界面);
        if (MyAction != null) MyAction.Invoke();
        if (参数 == "修改大位分")
        {
            游戏设定.Instance.高位妃 = 所有位分.Count / 3;
            游戏设定.Instance.中位妃 = 所有位分.Count / 3 * 2;
            数据库.所有位分 = 所有位分;
        }
        if (参数 == "册封大位分" || 参数 == "妃嫔晋位" || 参数 == "妃嫔降位")
        {
            if (中间变量.Instance.UI != null)
            {
                中间变量.Instance.UI.列表展示();
            }
        }
        if (参数 == "选秀")
        {
            妃子 妃子 = 中间变量.Instance.册封妃子;
            妃子.赐封号("选秀");
        }
    }
}
