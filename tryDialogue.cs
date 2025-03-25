using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class tryDialogue : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dialoguePrefab;
    public List<NPC> npcs;
    void Start()
    {
        npcs = new List<NPC>();
        npcs.Add(主控.Instance);
        npcs.Add(NPCManager.Instance.创建随机人物("妃子","女"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //public void StoryBegin()
    ////{
    ////    string FilePath ="剧情总览/宫女侍寝1";
    ////    TextAsset inkJSONAsset =Resources.Load<TextAsset>(FilePath);
    ////    Dialogue.StartStory(OnStoryFinished,inkJSONAsset, npcs);
    //}

    private void OnStoryFinished(List<int> storyData)
    {
        // 在这里处理返回的列表数据
        foreach (var line in storyData)
        {
            Debug.Log(line);
        }
        // 继续其他操作...
    }
    public void printMessage()
    {
        Debug.Log("按钮已经被点击啦");
    }
}