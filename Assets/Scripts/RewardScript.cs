using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardScript : MonoBehaviour
{
    public Sprite[] sprites;
    public int value;

    void Start()
    {

    }

   
    void Update()
    {
        transform.Rotate(0, 0, 0.05f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Playermovement.instance.IncreaseCoins(value); 
        }
    }
}
