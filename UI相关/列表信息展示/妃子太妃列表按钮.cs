using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class 妃子太妃列表按钮 : MonoBehaviour
{
    //public Image hoverImage;
    //public GameObject instance;
    //public Sprite 原始图,悬浮图;
    //private Image ButtonImage;
    //private 妃子太妃列表UI管理 UI;
    //private int index;
    //private List<NPC> npcs;
    //public int id;
    //void Start()
    //{
    //    UI = instance.GetComponent<妃子太妃列表UI管理>();
    //    index = UI.index;
    //    hoverImage.gameObject.SetActive(false);
    //    ButtonImage = GetComponent<Image>();
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
    //public void OnPointerEnter(PointerEventData eventData)
    //{
    //    ButtonImage.sprite = 悬浮图;
    //    //Debug.Log("haha");
    //    npcs = UI.npcs;
    //    index = UI.index;
    //    if ((index - 1) * 10 + id < npcs.Count && hoverImage != null)
    //    {
    //        // 显示图片
    //        hoverImage.gameObject.SetActive(true);
    //        hoverImage.sprite = npcs[(index - 1) * 10 + id].立绘;
    //    }
    //    else
    //        hoverImage.gameObject.SetActive(false);
    //}

    //// 鼠标离开按钮时调用
    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    ButtonImage.sprite = 原始图;
    //    if (hoverImage != null)
    //    {
    //        // 隐藏图片
    //        hoverImage.gameObject.SetActive(false);
    //    }
    //}
    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    npcs = UI.npcs;
    //    if ((index - 1) * 10 + id < npcs.Count)
    //        npcs[(index - 1) * 10 + id].打开人物信息面板();
    //}
}
