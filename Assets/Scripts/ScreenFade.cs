using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFade : MonoBehaviour
{
    public Image fadeImage; // A Imagem no Canvas usada para o fade
    public float fadeDuration = 1.5f;

    void Start()
    {
        // Começa transparente
        SetAlpha(0);
    }

    public void FadeToBlack()
    {
        StartCoroutine(Fade(1)); // Fica preto
    }

    public void FadeToClear()
    {
        StartCoroutine(Fade(0)); // Volta a ser transparente
    }

    private IEnumerator Fade(float targetAlpha)
    {
        float startAlpha = fadeImage.color.a;
        float time = 0;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, time / fadeDuration);
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        SetAlpha(targetAlpha);
    }

    private void SetAlpha(float alpha)
    {
        fadeImage.color = new Color(0, 0, 0, alpha);
    }
}


