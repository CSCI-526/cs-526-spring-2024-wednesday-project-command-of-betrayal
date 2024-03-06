using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bordercheck : MonoBehaviour
{
    public GameObject playerObject; 
    public string wallTag = "wall"; 
    public KeyCode turnOffCollisionKey = KeyCode.T;
    public float collisionDisableDuration = 3f;

    private bool collisionDisabled = false;
    private float collisionDisableEndTime;
    private bool collisionActivated = false;
    private bool collisionActivationRequested = false;

    private void Update()
    {
       
        if (Input.GetKeyDown(turnOffCollisionKey) && !collisionActivated && !collisionActivationRequested)
        {
            ActivateCollisionDisable();
            collisionActivationRequested = true; 
        }

        
        if (collisionDisabled && Time.time >= collisionDisableEndTime)
        {
            EnableCollision();
        }
    }

    private void ActivateCollisionDisable()
    {
        collisionActivated = true;
        AnalyticsManager.Instance.UsedGhostMode();
        DisableCollisionForDuration();
    }

    private void DisableCollisionForDuration()
    {
        collisionDisabled = true;
        collisionDisableEndTime = Time.time + collisionDisableDuration;

        
        Collider2D[] playerColliders = playerObject.GetComponentsInChildren<Collider2D>();
        GameObject[] wallObjects = GameObject.FindGameObjectsWithTag(wallTag);
        foreach (GameObject wallObject in wallObjects)
        {
            Collider2D[] wallColliders = wallObject.GetComponentsInChildren<Collider2D>();
            foreach (Collider2D playerCollider in playerColliders)
            {
                foreach (Collider2D wallCollider in wallColliders)
                {
                    Physics2D.IgnoreCollision(playerCollider, wallCollider, true);
                }
            }
        }
    }

    private void EnableCollision()
    {
        
        Collider2D[] playerColliders = playerObject.GetComponentsInChildren<Collider2D>();
        GameObject[] wallObjects = GameObject.FindGameObjectsWithTag(wallTag);
        foreach (GameObject wallObject in wallObjects)
        {
            Collider2D[] wallColliders = wallObject.GetComponentsInChildren<Collider2D>();
            foreach (Collider2D playerCollider in playerColliders)
            {
                foreach (Collider2D wallCollider in wallColliders)
                {
                    Physics2D.IgnoreCollision(playerCollider, wallCollider, false);
                }
            }
        }

        
        collisionActivated = false;
        collisionDisabled = false;
    }
}
