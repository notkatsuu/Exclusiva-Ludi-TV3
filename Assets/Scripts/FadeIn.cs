using System.Collections;
using UnityEngine;

public class SceneFadeIn : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float duration = 2f;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float startTime = Time.time;

        while (Time.time - startTime <= duration)
        {
            canvasGroup.alpha = 1 - ((Time.time - startTime) / duration);
            yield return null;
        }

        canvasGroup.alpha = 0;
    }
}

