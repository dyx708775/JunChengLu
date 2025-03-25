using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.UIElements;
using TMPro;

public class PromptPanel : MonoBehaviour
{
    public float fadeDuration = 2f;
    public float displayDuration = 2f;
    public CanvasGroup canvasGroup;
    public TextMeshProUGUI TextComponent;
    public string texts;

    void Start()
    {
        canvasGroup.alpha = 0.0f;
        TextComponent.text = texts; 
        //canvasGroup = GetComponent<CanvasGroup>();
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