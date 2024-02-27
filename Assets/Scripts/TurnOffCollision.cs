////using UnityEngine;

////public class TurnOffCollision : MonoBehaviour
////{
////    // The key to trigger turning off collision
////    public KeyCode turnOffCollisionKey = KeyCode.T;

////    // Reference to the player's collider
////    public Collider2D playerCollider;

////    // Boolean to track if collision is turned off
////    private bool collisionTurnedOff = false;

////    void Update()
////    {
////        if (Input.GetKeyDown(turnOffCollisionKey))
////        {
////            // Toggle collision state
////            collisionTurnedOff = !collisionTurnedOff;

////            // Turn off or on collision for the player based on the state
////            SetCollisionState(collisionTurnedOff);
////        }
////    }

////    private void SetCollisionState(bool state)
////    {
////        // If the player's collider is provided, disable/enable it
////        if (playerCollider != null)
////        {
////            playerCollider.enabled = !state;
////        }
////        else
////        {
////            Debug.LogWarning("Player collider is not assigned.");
////        }
////    }
////}

//using System.Collections;
//using UnityEngine;

//public class TurnOffCollision : MonoBehaviour
//{
//    // The key to trigger turning off collision
//    public KeyCode turnOffCollisionKey = KeyCode.T;

//    // Reference to the player's collider
//    public Collider2D playerCollider;

//    // Boolean to track if collision is turned off
//    private bool collisionTurnedOff = false;

//    void Update()
//    {
//        if (Input.GetKeyDown(turnOffCollisionKey) && !collisionTurnedOff)
//        {
//            // Turn off collision for the player
//            SetCollisionState(true);

//            // Start coroutine to revert back to original state after 3 seconds
//            StartCoroutine(RevertCollisionStateAfterDelay(3f));
//        }
//    }

//    private void SetCollisionState(bool state)
//    {
//        // If the player's collider is provided, disable/enable it
//        if (playerCollider != null)
//        {
//            playerCollider.enabled = !state;
//            collisionTurnedOff = state;
//        }
//        else
//        {
//            Debug.LogWarning("Player collider is not assigned.");
//        }
//    }

//    private IEnumerator RevertCollisionStateAfterDelay(float delay)
//    {
//        yield return new WaitForSeconds(delay);

//        // Revert collision state for the player
//        SetCollisionState(false);
//    }
//}

using System.Collections;
using UnityEngine;

public class TurnOffCollision : MonoBehaviour
{
    // The key to trigger turning off collision
    public KeyCode turnOffCollisionKey = KeyCode.T;

    // Reference to the player's collider
    public Collider2D playerCollider;

    // Boolean to track if collision is turned off
    private bool collisionTurnedOff = false;

    // Boolean to track if the feature has been activated
    private bool featureActivated = false;

    void Update()
    {
        // Check if the feature has not been activated yet
        if (!featureActivated && Input.GetKeyDown(turnOffCollisionKey))
        {
            // Activate the feature
            ActivateFeature();
        }
    }

    private void ActivateFeature()
    {
        // Turn off collision for the player
        SetCollisionState(true);

        // Start coroutine to revert back to original state after 3 seconds
        StartCoroutine(RevertCollisionStateAfterDelay(3f));

        // Mark the feature as activated
        featureActivated = true;
    }

    private void SetCollisionState(bool state)
    {
        // If the player's collider is provided, disable/enable it
        if (playerCollider != null)
        {
            playerCollider.enabled = !state;
            collisionTurnedOff = state;
        }
        else
        {
            Debug.LogWarning("Player collider is not assigned.");
        }
    }

    private IEnumerator RevertCollisionStateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Revert collision state for the player
        SetCollisionState(false);
    }
}
