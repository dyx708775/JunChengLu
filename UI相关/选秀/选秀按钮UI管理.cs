using JetBrains.Annotations;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class 选秀按钮UI管理 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public int index=0;
    public GameObject infoPanel;
    public GameObject 选秀界面;
    private string 参数 = "";
    private 选秀界面UI管理 UI;
    private RectTransform imageRectTransform;
    private string infoText = ""; 
    private CanvasGroup canvasGroup;
    private TMP_Text panelText;
    private RectTransform panelRectTransform;

    void Start()
    {
        canvasGroup = infoPanel.GetComponent<CanvasGroup>();
        panelText = infoPanel.GetComponentInChildren<TMP_Text>();
        imageRectTransform = GetComponent<RectTransform>();
        panelRectTransform = infoPanel.GetComponent<RectTransform>();
        UI = 选秀界面.GetComponent<选秀界面UI管理>();
        参数 = UI.参数;
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        infoText = 获取人物介绍();
        panelText.text = infoText;
        SetPanelPosition();
    }

    public string 获取人物介绍()
    {
        StringBuilder str = new StringBuilder();
        NPC npc = UI.npcs[index];
        str.Append(npc.姓 + npc.名 + "   " + npc.年龄.ToString() + "岁\n");
        str.Append(npc.籍贯+"  魅力:"+npc.魅力.ToString()+"\n");
        str.Append("守宫砂:" + (npc.经验 == 0 ? "有" : "无")+"\n");
        if (npc.父亲 != -1 && NPCManager.Instance.所有人物[npc.父亲].类型 =="大臣")
        {
            大臣 父亲 = (大臣)NPCManager.Instance.所有人物[npc.父亲];
            str.Append(数据库.所有官员品阶[父亲.官职.品阶] + 父亲.官职.官职名称 + 父亲.姓 + 父亲.名 + npc.嫡庶 + npc.性别 + "\n");
        }
        else if (npc.父亲 != -1 && NPCManager.Instance.所有人物[npc.父亲].父亲!=-1)
        {
            int 祖父编号 = NPCManager.Instance.所有人物[npc.父亲].父亲;
            if (NPCManager.Instance.所有人物[祖父编号].类型=="大臣")
            {
                大臣 祖父 = (大臣)NPCManager.Instance.所有人物[祖父编号];
                str.Append(数据库.所有官员品阶[祖父.官职.品阶] + 祖父.官职.官职名称 + 祖父.姓 + 祖父.名 + npc.嫡庶 + "孙"+npc.性别 + "\n");
            }
        }
        return str.ToString();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
    private void SetPanelPosition()
    {
        panelRectTransform.anchoredPosition = imageRectTransform.anchoredPosition;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(UI.npcs[index].选秀标记==0&&参数=="妃嫔选秀")
        {
            UI.npcs[index].打开选秀介绍面板();
        }
    }
}