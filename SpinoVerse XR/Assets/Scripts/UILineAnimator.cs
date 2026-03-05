using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UILineAnimator : MonoBehaviour
{
    public float targetWidth = 300f;   // Final width
    public float duration = 1f;        // Animation time

    private RectTransform rect;

    void Awake()
    {
        rect = GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(0, rect.sizeDelta.y);
    }

    public void AnimateLine()
    {
        StartCoroutine(AnimateWidth());
    }

    IEnumerator AnimateWidth()
    {
        float time = 0f;
        float startWidth = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            float width = Mathf.Lerp(startWidth, targetWidth, time / duration);
            rect.sizeDelta = new Vector2(width, rect.sizeDelta.y);
            yield return null;
        }

        rect.sizeDelta = new Vector2(targetWidth, rect.sizeDelta.y);
    }
}