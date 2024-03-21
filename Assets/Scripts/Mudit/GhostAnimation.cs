using UnityEngine;

public class GhostAnimation : MonoBehaviour
{
    public float animationDuration = 3f; // Duration of the ghost animation
    public float breathingScaleUpSize = 1.1f; // Target scale for scaling up
    public float breathingScaleDownSize = 1.0f; // Target scale for scaling down
    public float breathingDuration = 1f; // Duration of each scale animation
    public Color[] rainbowColors; // Array of colors for rainbow effect
    public float rainbowSpeed = 2f; // Speed of rainbow color change
    public float maxTransparency = 0.5f; // Maximum transparency value
    public int pressLimit = 1; // How many times "T" can be pressed

    private SpriteRenderer spriteRenderer;
    private Vector3 originalScale;
    private Color originalColor;
    private float animationStartTime;
    private bool animationStarted;
    private int pressCount;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalScale = transform.localScale;
        originalColor = spriteRenderer.color;
    }

    void Update()
    {
        // Check if the ghost animation is active and has not ended yet
        if (animationStarted && Time.time - animationStartTime < animationDuration)
        {
            // Calculate the progress of the animation
            float animationProgress = (Time.time - animationStartTime) / animationDuration;

            // Apply breathing animation
            ApplyBreathingAnimation(animationProgress);

            // Apply rainbow color change
            ApplyRainbowColorChange(animationProgress);

            // Apply transparency change
            ApplyTransparency(animationProgress);
        }
        else if (animationStarted && Time.time - animationStartTime >= animationDuration)
        {
            // Animation duration has passed, reset the animation
            animationStarted = false;
            transform.localScale = originalScale;
            spriteRenderer.color = originalColor;

            // Increment the press count
            pressCount++;
        }

        // Check if the press count exceeds the press limit
        if (Input.GetKeyDown(KeyCode.T) && pressCount < pressLimit)
        {
            StartGhostAnimation();
        }
    }

    void ApplyBreathingAnimation(float progress)
    {
        // Calculate the scale for breathing animation
        float breathingScale = Mathf.Lerp(breathingScaleDownSize, breathingScaleUpSize, Mathf.PingPong(progress * breathingDuration, 1f));

        // Apply the scale to the sprite
        transform.localScale = originalScale * breathingScale;
    }

    void ApplyRainbowColorChange(float progress)
    {
        // Calculate the index of the rainbow color based on progress
        int colorIndex = Mathf.FloorToInt(progress * rainbowSpeed) % rainbowColors.Length;

        // Apply the rainbow color to the sprite
        spriteRenderer.color = rainbowColors[colorIndex];
    }

    void ApplyTransparency(float progress)
    {
        // Calculate the transparency based on progress
        float transparency = Mathf.Lerp(0f, maxTransparency, Mathf.PingPong(progress * 2f, 1f));

        // Apply the transparency to the sprite color
        Color newColor = spriteRenderer.color;
        newColor.a = transparency;
        spriteRenderer.color = newColor;
    }

    public void StartGhostAnimation()
    {
        // Start the ghost animation and set the start time
        animationStarted = true;
        animationStartTime = Time.time;
    }
}
