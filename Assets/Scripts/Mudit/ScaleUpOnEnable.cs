using System.Collections;
using UnityEngine;

public class ScaleUpOnEnable : MonoBehaviour
{
    public float duration = 0.5f; // Duration of the scale-up animation
    public Vector3 startScale = new Vector3(0.1f, 0.1f, 0.1f); // Starting scale (small)
    [SerializeField] private float startDelay = 0f; // Delay before setting to startSize and starting the animation

    private void OnEnable()
    {
        // Initially set scale to zero
        transform.localScale = Vector3.zero;

        // After the startDelay, start the scale-up animation
        StartCoroutine(StartScaleUpCoroutine());
    }

    IEnumerator StartScaleUpCoroutine()
    {
        // Wait for the startDelay
        yield return new WaitForSeconds(startDelay);

        // Instantly set the GameObject to the startSize
        transform.localScale = startScale;

        // Interpolate the scale from startScale to Vector3.one over the duration
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            transform.localScale = Vector3.Lerp(startScale, Vector3.one, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final scale is exactly Vector3.one
        transform.localScale = Vector3.one;
    }
}
