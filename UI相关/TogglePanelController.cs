using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TogglePanelController : MonoBehaviour
{
    // Start is called before the first frame update
    public Toggle toggle;
    public GameObject panelAboveToggle;

    private void Start()
    {
        // 确保在游戏开始时设置正确的状态
        UpdatePanelVisibility();

        // 监听toggle的变化
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    private void OnToggleValueChanged(bool isToggled)
    {
        // 当toggle的值改变时调用此方法
        UpdatePanelVisibility();
    }

    private void UpdatePanelVisibility()
    {
        // 检查toggle是否被激活（即值为true）
        bool shouldShowPanel = toggle.isOn;
        // 根据toggle的状态设置panel的激活状态
        if(panelAboveToggle != null) 
        panelAboveToggle.SetActive(shouldShowPanel);
    }
}
