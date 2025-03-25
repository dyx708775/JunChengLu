using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    public Toggle toggle;
    public Image image;
    public Sprite[] sprites;
    private void Start()
    {
        // 确保在游戏开始时设置正确的状态
        UpdateButton();
        // 监听toggle的变化
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    private void OnToggleValueChanged(bool isToggled)
    {
        // 当toggle的值改变时调用此方法
        UpdateButton();
    }

    private void UpdateButton()
    {
        // 检查toggle是否被激活（即值为true）
        bool Buttonsprite = toggle.isOn;
        // 根据toggle的状态设置panel的激活状态
        if(Buttonsprite) image.sprite = sprites[0];
        else image.sprite = sprites[1];
    }
}
