using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class 时间体系尝试 : MonoBehaviour
{
    // Start is called before the first frame update
    private int count = 0;
    private Task currentTask;
    private bool isTaskRunning = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void 时间推进()
    {
        if (isTaskRunning)
        {
            等待进程完成().ContinueWith(_ => {
                Debug.Log("haha");
                新进程();
            });
        }
        else
        {
            Debug.Log("haha");
            新进程();
        }
    }

    private async void 新进程()
    {
        count++;
        Debug.Log("新进程开始" + count);
        isTaskRunning = true;
        currentTask = MyAsyncTask();
        await currentTask;
        isTaskRunning = false;
        Debug.Log("（我是新进程中的函数）进程完成啦，无需等待");
    }

    private async Task MyAsyncTask()
    {
        Debug.Log("等待开始………………");
        await Task.Delay(3000);
        Debug.Log("等待结束………………");
    }


    private async Task 等待进程完成()
    {
        Debug.Log("开始等待进程完成");
        if (currentTask != null) await currentTask;
        Debug.Log("（我是等待进程完成中的函数）进程完成啦");
    }
}
