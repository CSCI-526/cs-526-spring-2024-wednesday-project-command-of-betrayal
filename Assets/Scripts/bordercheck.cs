using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bordercheck : MonoBehaviour
{
    public GameObject playerObject; // Reference to the player object
    public string wallTag = "wall"; // Tag for the walls
    public KeyCode turnOffCollisionKey = KeyCode.T;
    public float collisionDisableDuration = 3f;

    private bool collisionDisabled = false;
    private float collisionDisableEndTime;
    private bool collisionActivated = false;
    private bool collisionActivationRequested = false; // Flag to track if collision activation has been requested

    private void Update()
    {
        // Check if T key is pressed and collision can be activated
        if (Input.GetKeyDown(turnOffCollisionKey) && !collisionActivated && !collisionActivationRequested)
        {
            ActivateCollisionDisable();
            collisionActivationRequested = true; // Mark collision activation as requested
        }

        // Check if collision disable duration has elapsed
        if (collisionDisabled && Time.time >= collisionDisableEndTime)
        {
            EnableCollision();
        }
    }

    private void ActivateCollisionDisable()
    {
        collisionActivated = true;
        DisableCollisionForDuration();
    }

    private void DisableCollisionForDuration()
    {
        collisionDisabled = true;
        collisionDisableEndTime = Time.time + collisionDisableDuration;

        // Disable collision between player and all objects with the "Wall" tag
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
        // Enable collision between player and all objects with the "Wall" tag
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

        // Reset flags
        collisionActivated = false;
        collisionDisabled = false;
    }
}
