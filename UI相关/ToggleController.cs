using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleController : MonoBehaviour
{
    // Start is called before the first frame update
    public Toggle toggle;
    public Sprite ѡ��, ��ѡ��;
    private Image image;
    void Start()
    {
        image = toggle.GetComponentInChildren<Image>();
        if (toggle.isOn) image.sprite = ѡ��;
        else image.sprite = ��ѡ��;
    }

    public void ����ͼƬ()
    {
        if (toggle.isOn) image.sprite = ѡ��;
        else image.sprite = ��ѡ��;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
