using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_LoadingShade : MonoBehaviour
{
    [SerializeField] private CanvasGroup loadingGroup;
    [SerializeField] TextMeshProUGUI loadingText;
    
    private float duration;
    private float elapsed;
    private float startingAlpha;
    private float targetAlpha;

    private bool isFading;

    public void SetLoadingShade(float alpha)
    {
        alpha = Mathf.Clamp01(alpha);
        loadingGroup.alpha = alpha;
    }

    public void FadeIn(float duration, bool includeLoadingText = true)
    {
        gameObject.SetActive(true);
        loadingText.gameObject.SetActive(includeLoadingText);
        StartFade(1f, 0f, duration);
    }

    public void FadeOut(float duration, bool includeLoadingText = true)
    {
        gameObject.SetActive(true);
        loadingText.gameObject.SetActive(includeLoadingText);
        StartFade(0f, 1f, duration);
    }

    private void StartFade(float from, float to, float fadeDuration)
    {
        startingAlpha = from;
        targetAlpha = to;
        duration = Mathf.Max(0.01f, fadeDuration);
        elapsed = 0f;
        isFading = true;
        SetLoadingShade(startingAlpha);
    }

    private void Update()
    {
        if (!isFading) return;

        elapsed += Time.deltaTime;

        float t = Mathf.Clamp01(elapsed / duration);
        float currentAlpha = Mathf.Lerp(startingAlpha, targetAlpha, t);

        SetLoadingShade(currentAlpha);

        if (t >= 1f)
        {
            SetLoadingShade(targetAlpha);
            isFading = false;
            gameObject.SetActive(currentAlpha > 0);
        }
    }
}