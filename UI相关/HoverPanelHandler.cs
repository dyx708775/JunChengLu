using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverPanelHandler : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    public GameObject HoverPanel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void OnPointerEnter(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        //Debug.Log("111");
        HoverPanel.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        HoverPanel.SetActive(false);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        // 当鼠标在按钮上按下时调用
        Debug.Log("Button is pressed down.");
    }
}
