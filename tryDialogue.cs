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
        npcs.Add(����.Instance);
        npcs.Add(NPCManager.Instance.�����������("����","Ů"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //public void StoryBegin()
    ////{
    ////    string FilePath ="��������/��Ů����1";
    ////    TextAsset inkJSONAsset =Resources.Load<TextAsset>(FilePath);
    ////    Dialogue.StartStory(OnStoryFinished,inkJSONAsset, npcs);
    //}

    private void OnStoryFinished(List<int> storyData)
    {
        // �����ﴦ���ص��б�����
        foreach (var line in storyData)
        {
            Debug.Log(line);
        }
        // ������������...
    }
    public void printMessage()
    {
        Debug.Log("��ť�Ѿ��������");
    }
}