using UnityEngine;

using DG.Tweening;

public class PanelUI : MonoBehaviour
{

    [Header("Shake Settings")]
    public float shakeDuration = 0.5f;   // How long it shakes
    public float shakeStrength = 0.3f;   // How much it distorts the scale
    public int vibrato = 10;             // Number of shakes per second
    public float randomness = 90f;       // Randomness angle

    private Vector3 originalScale;

    private void Awake()
    {
        originalScale = transform.localScale;
        transform.localScale = Vector3.zero;
    }

    public void Enable(bool enable)
    {
        transform.DOScale(enable ? Vector3.one : Vector3.zero, 1.0f).OnComplete(() =>
        {
            transform.DOShakeScale(shakeDuration, shakeStrength, vibrato, randomness, false)
               .OnComplete(() => transform.localScale = originalScale); // Ensure it resets
        });
    }
}
