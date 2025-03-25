using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
using TMPro;
using System.IO;
using UnityEngine.TextCore.Text;
using UnityEditor;
using UnityEngine.U2D;

public enum effectType
{
    typewritter = 0,
}
public class Dialogue : MonoBehaviour
{
    // Start is called before the first frame update
    public static event Action<Story> OnCreateStory;
    public Story story;
    [SerializeField]
    public Transform DialogueBackground;
    public Transform dialogueBoxText;
    public Transform choiceBox;
    public Transform characterBox;
    public Transform choiceButton;
    public GameObject instance;
    public int finalchoice;
    [Range(0.01f, 0.1f)] public float speed = 0.5f;
    private Coroutine typingCoroutine;
    private TMP_Text m_text;
    private List<Sprite> 人物立绘 = new List<Sprite>();
    private List<Transform> characterImages = new List<Transform>();
    private List<int>choices = new List<int>();
    public delegate void StoryCallback(List<int> storyData);
    private StoryCallback callback;


    private void Awake()
    {
        m_text = dialogueBoxText.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    public void StartStory(StoryCallback callback,UnityEngine.TextAsset inkJSONAsset, List<NPC> npcs)
    {
        //剧情人物属性赋值
        List<string> npc名 = new List<string>();
        List<Sprite> npc立绘 = new List<Sprite>();
        for (int i = 0; i < npcs.Count; i++)
        {
            npc名.Add(npcs[i].姓.ToString() + npcs[i].名.ToString());
            npc立绘.Add(npcs[i].立绘);
        }
        //Debug.Log("StartStory");
        //相关定义
        this.callback = callback;
        story = new Story(inkJSONAsset.text);
        story.BindExternalFunction("background", (string path) =>
        {
            更新背景图片(path);
        });
        加载人物名(npc名);
        人物立绘 = npc立绘;
        //ink自带api
        if (OnCreateStory != null) OnCreateStory(story);
        ContinueStory();
    }

    void 加载人物名(List<string> npc名)
    {
        for (int i = 0; i < npc名.Count; i++)
        {
            string character = "CH" + i;
            story.variablesState[character] = npc名[i];
        }
    }

    public void ContinueStory()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            m_text.maxVisibleCharacters = m_text.textInfo.characterCount;
            typingCoroutine = null;
        }
        else
        {
            if (story.canContinue)
            {
                choiceBox.gameObject.SetActive(false);
                string text = story.Continue();
                //删除收尾的空格
                // This removes any white space from the text.
                text = text.Trim();
                //找到这一行的tags
                //Find the tags of this line
                List<string> tags = story.currentTags;//ink自带的api，获取所有的tags
                                                      // 将文字打印出来
                                                      // Display the text on screen!
                PrintContent(text, tags);
            }
            else if ((story.currentChoices.Count > 0))
            {
                choiceBox.gameObject.SetActive(true);
                while (story.currentChoices.Count > choiceBox.childCount)
                {
                    Transform newButton = Instantiate(choiceButton, choiceBox);
                }
                for (int i = 0; i < choiceBox.childCount; i++)
                {
                    if (i < (story.currentChoices.Count))
                    {
                        Choice choice = story.currentChoices[i];
                        choiceBox.GetChild(i).gameObject.SetActive(true);
                        choiceBox.GetChild(i).GetComponent<Button>().onClick.RemoveAllListeners();
                        choiceBox.GetChild(i).GetComponent<Button>().onClick.AddListener(delegate { OnClickChoiceButton(choice); });
                        choiceBox.GetChild(i).GetChild(0).GetComponent<TMP_Text>().text = choice.text.Trim();
                    }
                    else
                    {
                        choiceBox.GetChild(i).gameObject.SetActive(false);
                    }

                }
            }
            else
            {
                Debug.Log("story ends");
                if (callback != null) callback(choices);
                UI相关.销毁场景(instance);
            }
        }
    }
    public void PrintContent(string content, List<string> tags)
    {
        string[] tagSplit;
        Sprite characterImage = null;
        string characterName = "";
        int character;
        int characterPos = 2;
        for (int i = 0; i < tags.Count; i++)
        {
            if (!tags[i].Contains(":"))
            {
                continue;
            }

            tagSplit = tags[i].Trim().Split(":");
            //Character tag
            if (tagSplit[0] == "CH")
            {
                characterName = tagSplit[1].Trim();
                character = int.Parse(characterName);
                characterImage = 人物立绘[character];
                Debug.Log(character);
            }
            else if (tagSplit[0] == "POS")
            {
                characterPos = Int32.Parse(tagSplit[1]);
            }
        }
        //改变角色立绘
        if (characterImage != null)
        {
            characterBox.gameObject.SetActive(true);
            Image image = characterBox.GetComponent<Image>();
            image.sprite = characterImage;
        }
        else
        {
            characterBox.gameObject.SetActive(false);
        }
        m_text.text = content;
        typingCoroutine = StartCoroutine(TypeWritter());
        Debug.Log(content);
    }

    private IEnumerator TypeWritter()
    {
        m_text.ForceMeshUpdate();
        TMP_TextInfo textInfo = m_text.textInfo;
        int total = textInfo.characterCount;
        bool complete = false;
        int current = 0;
        while (!complete)
        {
            if(current>total)
            {
                current = total;
                complete = true;
            }
            m_text.maxVisibleCharacters = current; 
            current++;
            yield return new WaitForSecondsRealtime(speed);
        }
        typingCoroutine = null;
        yield return null;
    }


    void OnClickChoiceButton(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        choices.Add(choice.index);
        choiceBox.gameObject.SetActive(false);
        ContinueStory();
    }
    //public void 更新背景图片(Sprite sprite)
    //{
    //    DialogueBackground.GetComponent<Image>().sprite = sprite;
    //}
    public void 更新背景图片(string path)
    {
        Debug.Log("更新背景图片");
        Sprite sprite = null;
        sprite = UI相关.加载本地图片(path);
        DialogueBackground.GetComponent<Image>().sprite = sprite;
    }
}
