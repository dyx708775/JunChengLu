using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class 翻页版记事一览UI管理 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject 记事框;
    public GameObject prefab;
    public int index = 1;
    public List<记事> 所有记事;
    void Start()
    {
        记事展示();
    }
    public void 记事展示()
    {
        StringBuilder text = new StringBuilder();
        int start = (index-1)*10;//已经展现过的
        for (int i = 所有记事.Count-start-1;i>=0&&i> 所有记事.Count-start-1-10;i--)
        {
            text.Append(所有记事[i].记事生成());
            text.Append("\n");
        }
        TMP_Text Text = 记事框.GetComponent<TMP_Text>();
        if (Text == null) Debug.Log("找不到");
        else Text.text = text.ToString();
    }
    public void 上一页()
    {
        if(index>1)
        {
            index--;
            记事展示();
        }
    }
    public void 下一页()
    {
        if(index*10<所有记事.Count)
        {
            index++;
            记事展示();
        }
    }
    public void 增加记事()
    {
        所有记事.Add(new 记事(记事类型.妃子记事, 1, 0, new Dictionary<int, string> { { 1, "小雅馨" }, { 2, "大雅馨" } }));
        记事展示();
    }
    public void 离开()
    {
        UI相关.销毁场景(prefab);
    }
    public void 删除所有记事()
    {
        所有记事.Clear();
        index = 1;
        记事展示();
    }
}
