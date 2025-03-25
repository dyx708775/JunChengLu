using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class 列表按钮UI管理 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    // Start is called before the first frame update
    public Image hoverImage;
    public GameObject instance;
    private 信息列表UI管理 UI;
    private int index;
    private string 参数;
    private int buttonslen;
    private List<NPC> npcs;
    public int id;
    void Start()
    {
        UI = instance.GetComponent<信息列表UI管理>();
        npcs = UI.npcs;
        hoverImage.gameObject.SetActive(false);
        参数 = UI.参数;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        npcs = UI.npcs;
        index = UI.index;
        buttonslen = UI.buttonslen;
        if ((index - 1) * buttonslen + id < npcs.Count && hoverImage != null)
        {
            //Debug.Log("已进入");
            // 显示图片
            hoverImage.gameObject.SetActive(true);
            hoverImage.sprite = npcs[(index - 1) * 10 + id].立绘;
        }
        else
            hoverImage.gameObject.SetActive(false);
    }

    // 鼠标离开按钮时调用
    public void OnPointerExit(PointerEventData eventData)
    {
        if (hoverImage != null)
        {
            // 隐藏图片
            hoverImage.gameObject.SetActive(false);
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        参数 = UI.参数;
        npcs = UI.npcs;
        index = UI.index;
        buttonslen = UI.buttonslen;
        if ((index - 1) * buttonslen + id >= npcs.Count) return;
        string type = npcs[(index - 1) * buttonslen + id].类型;
        if (参数==""||参数=="人物列表展示")
        {
            //Debug.Log(type);
            if ((index - 1) * buttonslen + id < npcs.Count)
            {
                if (type == "妃子")
                {
                    妃子 npc = (妃子)npcs[(index - 1) * buttonslen + id];
                    //Debug.Log("hahha");
                    npc.打开人物信息面板();
                }
                else if (type == "大臣")
                {
                    大臣 npc = (大臣)npcs[(index - 1) * buttonslen + id];
                    npc.打开人物信息面板();
                }
                else if (type == "太妃")
                {
                    太妃 npc = (太妃)npcs[(index - 1) * buttonslen + id];
                    npc.打开人物信息面板();
                }
            }
        }
        else if(参数=="安排宫殿")
        {
            中间变量.Instance.被安排宫殿妃子 = (妃子)npcs[(index - 1) * buttonslen + id];
            宫殿管理.Instance.打开宫殿界面(0, "安排宫殿");
        }
        else if(参数=="初始化妃子")
        {
            妃子 npc = (妃子)npcs[(index - 1) * buttonslen + id];
            //Debug.Log("hahha");
            npc.初始化妃子信息面板();
            中间变量.Instance.UI = UI;
        }
        else if(参数=="初始化太妃")
        {
           太妃 npc = (太妃)npcs[(index - 1) * buttonslen + id];
            npc.打开人物信息面板();
            中间变量.Instance.UI = UI;
        }
        else if(参数=="妃嫔晋位"||参数=="妃嫔降位")
        {
            妃子 npc = (妃子)npcs[(index - 1) * buttonslen + id];
            npc.册封(参数,null);
            中间变量.Instance.UI = UI;
        }
    }
}
