using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport2way : MonoBehaviour
{
    public Transform destination;
    public float distance = 0.2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Square"))
        {
            if (Vector2.Distance(transform.position, collision.transform.position) > distance)
            {
                collision.transform.position = new Vector2(destination.position.x, destination.position.y);
                AnalyticsManager.Instance.UsedTeleport();
                
            }
        }
    }
}



