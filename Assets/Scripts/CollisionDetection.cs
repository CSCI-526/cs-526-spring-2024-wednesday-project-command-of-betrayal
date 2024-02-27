using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Square"))
        {
            Debug.Log("Destroying other object");
            Destroy(other.gameObject); // Destroy the other object
        }
    }
}
