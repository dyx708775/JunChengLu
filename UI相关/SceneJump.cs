using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneJump : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadTargetScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void 宫殿拜访(int type)
    {
        宫殿管理.Instance.打开宫殿界面(type, "拜访");
    }
}
