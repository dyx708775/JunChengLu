using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleController : MonoBehaviour
{
    // Start is called before the first frame update
    public Toggle toggle;
    public Sprite 选中, 不选中;
    private Image image;
    void Start()
    {
        image = toggle.GetComponentInChildren<Image>();
        if (toggle.isOn) image.sprite = 选中;
        else image.sprite = 不选中;
    }

    public void 更换图片()
    {
        if (toggle.isOn) image.sprite = 选中;
        else image.sprite = 不选中;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
