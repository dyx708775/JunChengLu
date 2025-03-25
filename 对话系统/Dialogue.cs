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
    private List<Sprite> �������� = new List<Sprite>();
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
        //�����������Ը�ֵ
        List<string> npc�� = new List<string>();
        List<Sprite> npc���� = new List<Sprite>();
        for (int i = 0; i < npcs.Count; i++)
        {
            npc��.Add(npcs[i].��.ToString() + npcs[i].��.ToString());
            npc����.Add(npcs[i].����);
        }
        //Debug.Log("StartStory");
        //��ض���
        this.callback = callback;
        story = new Story(inkJSONAsset.text);
        story.BindExternalFunction("background", (string path) =>
        {
            ���±���ͼƬ(path);
        });
        ����������(npc��);
        �������� = npc����;
        //ink�Դ�api
        if (OnCreateStory != null) OnCreateStory(story);
        ContinueStory();
    }

    void ����������(List<string> npc��)
    {
        for (int i = 0; i < npc��.Count; i++)
        {
            string character = "CH" + i;
            story.variablesState[character] = npc��[i];
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
                //ɾ����β�Ŀո�
                // This removes any white space from the text.
                text = text.Trim();
                //�ҵ���һ�е�tags
                //Find the tags of this line
                List<string> tags = story.currentTags;//ink�Դ���api����ȡ���е�tags
                                                      // �����ִ�ӡ����
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
                UI���.���ٳ���(instance);
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
                characterImage = ��������[character];
                Debug.Log(character);
            }
            else if (tagSplit[0] == "POS")
            {
                characterPos = Int32.Parse(tagSplit[1]);
            }
        }
        //�ı��ɫ����
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
    //public void ���±���ͼƬ(Sprite sprite)
    //{
    //    DialogueBackground.GetComponent<Image>().sprite = sprite;
    //}
    public void ���±���ͼƬ(string path)
    {
        Debug.Log("���±���ͼƬ");
        Sprite sprite = null;
        sprite = UI���.���ر���ͼƬ(path);
        DialogueBackground.GetComponent<Image>().sprite = sprite;
    }
}
