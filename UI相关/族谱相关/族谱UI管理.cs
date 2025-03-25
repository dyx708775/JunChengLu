using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class 族谱UI管理 : MonoBehaviour
{
    public string 家族名;
    public GameObject 族谱界面;
    public GameObject 人物预制体;
    public RectTransform 族谱面板;
    public GameObject 连接线;
    private RectTransform 人物;
    public float scaleSpeed = 0.3f;
    private int 代间距 = 100;
    private int 行间距 = 30;
    private int 房间距 = 300;
    private int 夫妻间距 = 5;
    private Vector2 右移速度 = new Vector2(-500, 0);
    private Vector2 左移速度 = new Vector2(500, 0);
    private Vector2 上移速度 = new Vector2(0, -500);
    private Vector2 下移速度 = new Vector2(0, 500);
    private float dragSpeed = 1f;
    private Vector2 lastMousePosition;
    private bool isDragging = false;

    // Start is called before the first frame update
    void Start()
    {
        人物 = 人物预制体.GetComponent<RectTransform>();
        族谱展示();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            移动面板(右移速度 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            移动面板(左移速度 * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.UpArrow))
        {
            移动面板(上移速度*Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            移动面板(下移速度*Time.deltaTime);
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0)
        {
            族谱面板.localScale = 族谱面板.localScale + Vector3.one * scroll * scaleSpeed;
        }
        if(Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            lastMousePosition = Input.mousePosition;
        }
        if(Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
        if(isDragging)
        {
            Vector2 currentMousePosition = Input.mousePosition;
            Vector2 delta = (currentMousePosition - lastMousePosition) * dragSpeed;
            族谱面板.anchoredPosition += new Vector2(delta.x, delta.y);
            lastMousePosition = currentMousePosition;
        }
    }

    void 族谱展示()
    {
        if (!家族管理.Instance.所有家族.ContainsKey(家族名))
        {
            Debug.Log("不包含家族");
            return;
        }
        float 左距离 = 0;
        for(int i = 0; i < 家族管理.Instance.所有家族[家族名].根成员.Count;i++)
        {
            int id = 家族管理.Instance.所有家族[家族名].根成员[i];
            NPC npc = NPCManager.Instance.所有人物[id];
            float 中点;
            (左距离,中点)=人物展示(npc, 1,左距离);
            左距离 += 房间距;
        }
    }

    (float,float) 人物展示(NPC npc, int 代,float 距离)//第一个float是右边界，第二个float是当前节点的中点
    {
        //Debug.Log(距离);
        List<float> 所有孩子中点 = new List<float>();
        float 代高度 = -1 * (人物.rect.height * (代 - 1) + 代间距 * (代 - 1));
        float 开始距离 = 距离,中点=0;
        float 线段起点=0, 线段终点=0;
        bool flag = true;
        if (npc.性别 == "女") flag = false;
        if (flag&&npc.孩子.Count > 0) {
            for (int i = 0; i < npc.孩子.Count; i++)
            {
                //Debug.Log(npc.姓 + npc.名 + "的孩子是: " + NPCManager.Instance.所有人物[npc.孩子[i]].姓 + NPCManager.Instance.所有人物[npc.孩子[i]].名);
                (距离, 中点) = 人物展示(NPCManager.Instance.所有人物[npc.孩子[i]], 代 + 1, 距离);
                距离 += 行间距;
                所有孩子中点.Add(中点);
                if (i == 0) 线段起点 = 中点;
                if (i == npc.孩子.Count - 1) 线段终点 = 中点;
            }
            距离 -= 行间距;
            中点 = (线段起点+线段终点) / 2;
            GameObject instance = Instantiate(人物预制体, new Vector2(中点, 代高度), Quaternion.identity);
            instance.GetComponentInChildren<TextMeshProUGUI>().text = npc.姓 + npc.名;
            instance.transform.SetParent(族谱面板, false);
            instance.name = npc.姓 + npc.名;
            if (npc.孩子.Count > 1)
            {
                连接线段(new Vector2(线段起点, 代高度-代间距/2), new Vector2(线段终点,代高度-代间距/2),false);
            }
            连接线段(new Vector2(中点, 代高度), new Vector2(中点, 代高度 - 代间距 / 2),true);
            for (int i = 0; i < 所有孩子中点.Count; i++)
            {
                连接线段(new Vector2(所有孩子中点[i], 代高度 - 代间距 / 2), new Vector2(所有孩子中点[i], 代高度 - 代间距),true);
            }
            if(npc.伴侣!=-1)
            {
                NPC npc2 = NPCManager.Instance.所有人物[npc.伴侣];
                instance = Instantiate(人物预制体, new Vector2(中点+夫妻间距+人物.rect.width, 代高度), Quaternion.identity);
                instance.GetComponentInChildren<TextMeshProUGUI>().text = npc2.姓 + npc2.名;
                instance.transform.SetParent(族谱面板, false);
                instance.name = npc2.姓 + npc2.名;
                距离 = Mathf.Max(距离,中点+人物.rect.width+人物.rect.width/2+夫妻间距);
            }
        }
        else if (!flag||npc.孩子.Count == 0)
        {
            if(npc.伴侣==-1)
            {
                GameObject instance = Instantiate(人物预制体, new Vector2(距离 + 人物.rect.width / 2, 代高度), Quaternion.identity);
                instance.GetComponentInChildren<TextMeshProUGUI>().text = npc.姓 + npc.名;
                instance.transform.SetParent(族谱面板, false);
                instance.name = npc.姓 + npc.名;
                距离 += 人物.rect.width;
                中点 = 距离 - 人物.rect.width / 2;
            }
            else
            {
                GameObject instance = Instantiate(人物预制体, new Vector2(距离 + 人物.rect.width / 2, 代高度), Quaternion.identity);
                instance.GetComponentInChildren<TextMeshProUGUI>().text = npc.姓 + npc.名;
                instance.transform.SetParent(族谱面板, false);
                instance.name = npc.姓 + npc.名;

                NPC npc2 = NPCManager.Instance.所有人物[npc.伴侣];
                instance = Instantiate(人物预制体, new Vector2(距离 + 人物.rect.width / 2+人物.rect.width+夫妻间距, 代高度), Quaternion.identity);
                instance.GetComponentInChildren<TextMeshProUGUI>().text = npc2.姓 + npc2.名;
                instance.transform.SetParent(族谱面板, false);
                instance.name = npc2.姓 + npc2.名;
                距离 += 人物.rect.width * 2 + 夫妻间距;
                中点 = 距离 - 人物.rect.width/2-人物.rect.width;
            }
        }
        return (距离,中点);
    }

    void 寻找人物(string 人物名)
    {
        GameObject targetPrefab = GameObject.Find(人物名);
        if (targetPrefab == null)
        {
            Debug.LogError("找不到指定人物: " + 人物名);
            return;
        }

        RectTransform targetRect = targetPrefab.GetComponent<RectTransform>();
        族谱面板.anchoredPosition = -1 * targetRect.anchoredPosition;
    }

    void 实例化人物(Vector2 position, string name)
    {
        GameObject instance = Instantiate(人物预制体, position, Quaternion.identity);
        instance.transform.SetParent(族谱面板, false);
        instance.name = name;
    }

    void 移动面板(Vector2 deltaPosition)
    {
        族谱面板.anchoredPosition += deltaPosition; 
    }

    void 连接线段(Vector2 点1, Vector2 点2,bool type)
    {
        //Debug.Log(点1);
        //Debug.Log(点2);
        GameObject lineInstance = Instantiate(连接线, 点1, Quaternion.identity);
        lineInstance.transform.SetParent(族谱面板, false);
        lineInstance.GetComponent<RectTransform>().anchoredPosition = (点1 + 点2) / 2;
        if(type==false)
            lineInstance.GetComponent<RectTransform>().sizeDelta = new Vector2(Vector2.Distance(点1, 点2), 5);
        else
            lineInstance.GetComponent<RectTransform>().sizeDelta = new Vector2(5,Vector2.Distance(点1, 点2));
    }
}
