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

    public void ����ݷ�(int type)
    {
        �������.Instance.�򿪹������(type, "�ݷ�");
    }
}
