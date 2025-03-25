using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 存读档界面命名UI管理 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject instance;
    public string 提示词;
    public TMP_Text 文本;
    public TMP_InputField 输入框;
    public string 参数;
    public int index;

    public void Start()
    {
        输入框.text = 提示词;
    }
    public void 确认()
    {
        文本.text = 输入框.text;
        存读系统.Instance.存档(index, 参数, 文本.text);
        UI相关.销毁场景(instance);
    }
}
