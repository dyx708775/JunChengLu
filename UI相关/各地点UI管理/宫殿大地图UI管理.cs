using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 宫殿大地图UI管理 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void 打开界面(GameObject prefab)
    {
        UI相关.实例化(prefab);
    }

    public void 打开后宫(int type)
    {
        宫殿管理.Instance.打开宫殿界面(type,"拜访");
    }

    public void 打开长乐宫()
    {
        人物选择界面.Instance.npcsid = NPCManager.Instance.太妃列表;
        人物选择界面.Instance.打开人物拜访界面();
    }
}
