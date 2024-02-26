using System.Collections;
using UnityEngine;

public class FOVEnemyRotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 1f;
    Quaternion originalRotation;

    void Start()
    {
        originalRotation = transform.rotation;
        StartCoroutine(RotateAndBack());
    }

    IEnumerator RotateAndBack()
    {
        while (true)
        {
            Quaternion targetRotation = originalRotation * Quaternion.Euler(0, 0, 90); // Rotate 90 degrees
            Quaternion originalRotationInverse = Quaternion.Inverse(originalRotation);

            // Rotate to targetRotation
            while (Quaternion.Angle(transform.rotation, targetRotation) > 0.1f)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                yield return null;
            }

            yield return new WaitForSeconds(0.5f); // Wait for a brief moment

            // Rotate back to original rotation
            while (Quaternion.Angle(transform.rotation, originalRotation) > 0.1f)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, originalRotation, rotationSpeed * Time.deltaTime);
                yield return null;
            }

            yield return new WaitForSeconds(0.5f); // Wait for a brief moment
        }
    }
}
