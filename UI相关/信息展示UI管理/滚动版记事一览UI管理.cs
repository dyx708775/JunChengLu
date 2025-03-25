using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TMPro;
using UnityEngine;

public class 滚动版记事一览UI管理 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject instance;
    public GameObject 记事框;
    public NPC npc;
    private void Start()
    {
        记事展示();
    }
    public void 记事展示()
    {
        StringBuilder text = new StringBuilder();
        for (int i = 0; i<npc.记事.Count;i++)
        {
            text.Append(npc.记事[i].记事生成());
            text.Append("\n");
        }
        TMP_Text Text = 记事框.GetComponent<TMP_Text>();
        if (Text == null) Debug.Log("找不到");
        else Text.text = text.ToString();
    }
    public void 增加记事()
    {
        npc.记事.Add(new 记事( 记事类型.妃子记事, 1, 0, new Dictionary<int, string> { { 1, "小雅馨" }, { 2, "大雅馨" } }));
        记事展示();
    }
    public void 离开()
    {
        UI相关.销毁场景(instance);
    }
    public void 删除所有记事()
    {
        npc.记事.Clear();
        记事展示();
    }
}
