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
        // ȷ������Ϸ��ʼʱ������ȷ��״̬
        UpdateButton();
        // ����toggle�ı仯
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    private void OnToggleValueChanged(bool isToggled)
    {
        // ��toggle��ֵ�ı�ʱ���ô˷���
        UpdateButton();
    }

    private void UpdateButton()
    {
        // ���toggle�Ƿ񱻼����ֵΪtrue��
        bool Buttonsprite = toggle.isOn;
        // ����toggle��״̬����panel�ļ���״̬
        if(Buttonsprite) image.sprite = sprites[0];
        else image.sprite = sprites[1];
    }
}
