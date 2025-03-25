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
        // ȷ������Ϸ��ʼʱ������ȷ��״̬
        UpdatePanelVisibility();

        // ����toggle�ı仯
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    private void OnToggleValueChanged(bool isToggled)
    {
        // ��toggle��ֵ�ı�ʱ���ô˷���
        UpdatePanelVisibility();
    }

    private void UpdatePanelVisibility()
    {
        // ���toggle�Ƿ񱻼����ֵΪtrue��
        bool shouldShowPanel = toggle.isOn;
        // ����toggle��״̬����panel�ļ���״̬
        if(panelAboveToggle != null) 
        panelAboveToggle.SetActive(shouldShowPanel);
    }
}
