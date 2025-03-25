using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 缓动黑幕UI管理 : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator fadeAnimator;
    public GameObject instance;
    void Start()
    {
        StartCoroutine(WaitForAnimation());
    }
    IEnumerator WaitForAnimation()
    {
        // 获取当前动画的时长
        float animationLength = fadeAnimator.GetCurrentAnimatorStateInfo(0).length;

        // 等待动画播放完成
        yield return new WaitForSeconds(animationLength);

        // 动画结束后销毁场景
        UI相关.销毁场景(instance);
    }


}
