using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using System.Linq;

public class 皇后初始化UI管理 : MonoBehaviour
{
    public GameObject instance;
    public TMP_InputField 姓, 名;
    public Image image;
    public GameObject 跳转界面;
    private 妃子 皇后;
    bool 初始化完成 = false;
    bool 初始化开始 = false;

    public void Start()
    {
        皇后 = NPCManager.Instance.创建随机人物("妃子", "女") as 妃子;
        皇后.妃子品阶 = 0;
        皇后.位分 = 数据库.所有位分[皇后.妃子品阶].所有小位分[0];
        数据库.所有位分[皇后.妃子品阶].已有人数++;
        皇后.住所 = "椒房殿";
        image.sprite = 皇后.立绘;
    }
    public void Update()
    {
        if (!初始化开始)
        {
            StartCoroutine(初始化());
        }        
    }

    public void 更换立绘()
    {
        皇后.随机立绘();
        image.sprite = 皇后.立绘;
    }

    public void 下一步()
    {
        皇后.姓 = 姓.text;
        皇后.名 = 名.text;
        皇后.籍贯 = 数据库.籍贯[Random.Range(0, 数据库.籍贯.Length)];
        皇后.家族 = 皇后.籍贯 + 皇后.姓 + "氏";
        StartCoroutine(跳转协程());
    }
    IEnumerator 跳转协程()
    {
        while (!初始化完成) yield return null;
        UI相关.销毁场景(instance);
        UI相关.实例化(跳转界面);
    }
    IEnumerator 初始化()
    {
        初始化开始 = true;
        宫殿管理.Instance.Init();
        NPCManager.Instance.初始化妃子太妃();
        初始化完成 = true;
        yield return null;
    }

}
