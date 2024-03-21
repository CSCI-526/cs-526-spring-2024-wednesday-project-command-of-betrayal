using System.Collections;
using UnityEngine;

public class ButtonBreathing : MonoBehaviour
{
    public float scaleUpSize = 1.1f; // Target scale for scaling up
    public float scaleDownSize = 1.0f; // Target scale for scaling down (usually the original scale)
    public float duration = 0.5f; // Duration of each scale animation
    [SerializeField] private float startDelay = 0f; // Delay before the breathing animation starts

    private Vector3 originalScale; // Original scale of the object

    private void Start()
    {
        originalScale = transform.localScale; // Store the original scale of the object

        // Start the breathing effect with a delay
        Invoke(nameof(StartBreathing), startDelay);
    }

    void StartBreathing()
    {
        StartCoroutine(BreathingCoroutine());
    }

    IEnumerator BreathingCoroutine()
    {
        while (true)
        {
            yield return ScaleCoroutine(scaleUpSize, duration);
            yield return ScaleCoroutine(scaleDownSize, duration);
        }
    }

    IEnumerator ScaleCoroutine(float targetScale, float duration)
    {
        float elapsedTime = 0f;
        Vector3 startScale = transform.localScale;
        Vector3 endScale = originalScale * targetScale;

        while (elapsedTime < duration)
        {
            transform.localScale = Vector3.Lerp(startScale, endScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = endScale;
    }
}
