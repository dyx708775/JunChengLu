using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class 对话
{
    public string 对话内容;
    public Sprite 人物图片;
    public 对话(string 对话内容, Sprite 人物图片)
    {
        this.对话内容 = 对话内容;
        this.人物图片 = 人物图片;
    }
    public 对话(){}
}
public class 简易剧情 : MonoBehaviour
{
    public List<对话> 剧情对话 = new List<对话>();
    [SerializeField]
    public Transform DialogueBackground;
    public Transform dialogueBoxText;
    public Transform choiceBox;
    public Transform characterBox;
    public Transform choiceButton;
    public GameObject instance;
    public int finalchoice;
    public int index = 0;
    private bool type = true;
    public bool finished = false;
    [Range(0.01f, 0.1f)] public float speed = 0.5f;
    private Coroutine typingCoroutine;
    private TMP_Text m_text;
    private List<Sprite> 人物立绘 = new List<Sprite>();
    private List<Transform> characterImages = new List<Transform>();
    private List<int> choices = new List<int>();
    public delegate void StoryCallback(List<int> storyData);
    private StoryCallback callback;
    private Action action;


    private void Awake()
    {
        m_text = dialogueBoxText.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    public void StartStory(List<对话>剧情对话,bool type,System.Action action)
    {
        this.剧情对话 = 剧情对话;
        index = 0;
        this.type = type;
        finished = false;
        this.action = action;
        ContinueStory();
    }

    //public IEnumerator 剧情是否播放完成(Action oncomplete)
    //{
    //    Debug.Log(finished);
    //    while (!finished)
    //        yield return null;
    //    oncomplete?.Invoke();
    //}


    public Button[] 出现按钮(List<string>choices)
    {
        choiceBox.gameObject.SetActive(true);
        Button[] buttons = new Button[choices.Count];
        while (choices.Count > choiceBox.childCount)
        {
            //Debug.Log(choiceBox.childCount);
            Transform newButton = Instantiate(choiceButton, choiceBox);
        }
        for (int i = 0; i < choiceBox.childCount; i++)
        {
            if (i < (choices.Count))
            {
                choiceBox.GetChild(i).gameObject.SetActive(true);
                choiceBox.GetChild(i).GetComponent<Button>().onClick.RemoveAllListeners();
                //choiceBox.GetChild(i).GetComponent<Button>().onClick.AddListener(delegate { OnClickChoiceButton(choice); });
                choiceBox.GetChild(i).GetChild(0).GetComponent<TMP_Text>().text = choices[i];
                buttons[i] = choiceBox.GetChild(i).GetComponent<Button>();
            }
            else
            {
                choiceBox.GetChild(i).gameObject.SetActive(false);
            }
        }
        return buttons;
    }

    public void 对话结束()
    {
        UI相关.销毁场景(instance);
    }
    public void ContinueStory()
    {
        //Debug.Log("wuwu");
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            m_text.maxVisibleCharacters = m_text.textInfo.characterCount;
            typingCoroutine = null;
        }
        else
        {
            if (index<剧情对话.Count)
            {
                choiceBox.gameObject.SetActive(false);
                string text = 剧情对话[index].对话内容;
                Sprite sprite = 剧情对话[index].人物图片;
                index++;
                PrintContent(text, sprite);
            }
            else
            {
                //Debug.Log(index);
                finished = true;
                action?.Invoke();
                if (type) UI相关.销毁场景(instance);
            }
        }
    }
    public void PrintContent(string content,Sprite sprite)
    {
        Sprite characterImage = sprite;
        //改变角色立绘
        if (sprite != null)
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
        //Debug.Log(content);
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
            if (current > total)
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
    public void 更新背景图片(string path)
    {
        Debug.Log("更新背景图片");
        Sprite sprite = null;
        sprite = UI相关.加载本地图片(path);
        DialogueBackground.GetComponent<Image>().sprite = sprite;
    }

    public void 更新背景图片2(Sprite sprite)
    {
        Debug.Log("haha");
        DialogueBackground.GetComponent<Image>().sprite = sprite;   
    }
}
