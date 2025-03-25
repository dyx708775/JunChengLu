using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 提示框面板UI管理 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject 提示框面板;
    public string 参数;
    public string 提示语;
    public int 编号;
    public GameObject instance;
    public TMP_Text Text;
    void Start()
    {
        if(提示语!=null)
        {
            Text.text = 提示语;
        }
    }

    public void 取消()
    {
        Destroy(提示框面板);
    }

    public void 确定()
    {
        Destroy(提示框面板);
        if (参数 == "删除人物")
        {
            NPCManager.Instance.删除人物(编号);
            UI相关.销毁场景(instance);
        }
        else if(参数=="退朝")
        {
            UI相关.销毁场景(instance);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
