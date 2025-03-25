using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPanelController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel;

    private void Start()
    {
        
    }
    public void SetPanelVisibility(bool active)
    {
        if (panel != null)
        {
            panel.SetActive(active);
        }
    }
}
