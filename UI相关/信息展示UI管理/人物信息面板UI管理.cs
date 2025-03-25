using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 人物信息面板UI管理 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject instance;

    public void 离开()
    {
        UI相关.销毁场景(instance);
    }
}
