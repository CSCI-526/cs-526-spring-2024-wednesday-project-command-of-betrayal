using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Playermovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;
    void Start()
    {

    } 
    void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector2 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * speed * Time.deltaTime);
        }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Reward"))
        {
            Destroy(collision.gameObject);
            //score = score + 1;
            //scoreText.text = score.ToString();
        }
    }
}


