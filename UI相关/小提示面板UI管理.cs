using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 小提示面板UI管理 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject instance;
    public TMP_Text Text;
    public string 提示文本="";
    private float fadeDuration = 2f;
    private float displayDuration = 2f;
    public CanvasGroup canvasGroup;
    void Start()
    {
        Text.text = 提示文本;
        canvasGroup.alpha = 0.0f;
        StartFadeOut();
    }

    public IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        UI相关.销毁场景(instance);
    }

    public IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }
        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }
    private IEnumerator DisplayThenFadeOutCoroutine()
    {
        // 等待displayDuration秒
        yield return new WaitForSeconds(displayDuration);
        // 开始淡出
        StartCoroutine(FadeOut());
    }
    public void StartFadeOut()
    {
        canvasGroup.alpha = 1f;
        StartCoroutine(DisplayThenFadeOutCoroutine());
    }
}
