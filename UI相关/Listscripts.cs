using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Listscripts: MonoBehaviour
{
    // Start is called before the first frame update
    public int attribute_num = 7;
    List<NPC> npcs;
    void Start()
    {
    }
    // Update is called once per frame
    public void update_list(List<List<string>>all_texts,int page)
    {
        
        int s = (page - 1) * 10, e = page * 10 - 1,len = all_texts.Count;
        Button[] buttons = GetComponentsInChildren<Button>(true);
        for(int i = 0; i < buttons.Length; i++)
        {
            Button button = buttons[i];
            TextMeshProUGUI[] textComponents = button.GetComponentsInChildren<TextMeshProUGUI>(true);
            if (s + i >= len)
            {
                button.interactable = false;
                for(int j = 0; j < attribute_num; j++)//容易出bug的地方
                {
                    textComponents[j].text = "";
                }
            }
            else
            {
                button.interactable = true;
                List<string> texts = all_texts[i + s];
                for (int j = 0; j < attribute_num; j++)
                    textComponents[j].text = texts[j];
            }
            
        }
    }
    void Update()
    {

    }
}
