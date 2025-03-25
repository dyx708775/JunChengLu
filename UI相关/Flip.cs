using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject targetObject;
    private Listscripts ListScripts;
    private int now_page = 1;
    private List<List<string>> buttontexts = new List<List<string>>();
    Listscripts script_List;
    void Start()
    {
        now_page = 1;
        Button[] buttons = GetComponentsInChildren<Button>(true);
        for (int i = 0; i < 40; i++)
        {
            List<string> texts = new List<string>(new string[7]);
            for (int j = 0; j < 7; j++)
            {
                texts[j] = "ÎÄ±¾" + i + "_" + j;
            }
            buttontexts.Add(texts);
        }
        if (targetObject != null)
        {
            script_List = targetObject.GetComponent<Listscripts>();
            if (script_List != null)
            {
                script_List.update_list(buttontexts,now_page);
            }
        }
    }

    public void pre_page()
    {
        now_page--;
        if (now_page <= 0) now_page = 1;
        script_List.update_list(buttontexts, now_page);
    }

    public void next_page()
    {
        if(now_page*10 < buttontexts.Count)
        {
            now_page++;
        }
        script_List.update_list(buttontexts, now_page);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
