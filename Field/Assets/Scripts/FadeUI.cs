using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class FadeUI : MonoBehaviour
{
    [Range(0f, 2f)]
    [SerializeField] float fadeDuration = 1f;   // Time for each fade step
    private Image fadeImage;

    void Awake()
    {
        fadeImage = GetComponent<Image>();
    }

    void Start()
    {
        // Optional: Start with a fade-in effect on game start
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeOut()
    {
        float time = 0f;
        Color c = fadeImage.color;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            c.a = Mathf.Lerp(0f, 1f, time / fadeDuration);
            fadeImage.color = c;
            yield return null;
        }
    }

    public IEnumerator FadeIn()
    {
        float time = 0f;
        Color c = fadeImage.color;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            c.a = Mathf.Lerp(1f, 0f, time / fadeDuration);
            fadeImage.color = c;
            yield return null;
        }
    }

    public IEnumerator FadeOutIn(float holdTime = 0.5f)
    {
        // Fade out
        yield return StartCoroutine(FadeOut());

        // Optional pause (e.g. during scene loading)
        yield return new WaitForSeconds(holdTime);

        // Fade in
        yield return StartCoroutine(FadeIn());
    }
}
