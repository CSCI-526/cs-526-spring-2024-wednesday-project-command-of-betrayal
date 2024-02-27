using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chec : MonoBehaviour
{
    public GameObject objectToEnable;
    public GameObject objectToEnableonlose;

    CoinCounter c;

    private void Start()
    {
        c = FindObjectOfType<CoinCounter>();
        if (c == null)
        {
            Debug.LogWarning("CoinCounter script not found in the scene.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Square"))
        {
            Debug.Log("Destroying other object");
            //Destroy(other.gameObject);
            if (c != null)
            {
                Debug.Log(c.coin);
                if (c.coin == 2)
                {
                    objectToEnable.SetActive(true);
                    GameObject[] enemies = GameObject.FindGameObjectsWithTag("police");
                    for (int i = 0; i < Mathf.Min(2, enemies.Length); i++)
                    {
                        Destroy(enemies[i]);
                    }

                    GameObject[] enemies2 = GameObject.FindGameObjectsWithTag("police2");
                    for (int i = 0; i < Mathf.Min(2, enemies.Length); i++)
                    {
                        Destroy(enemies2[i]);
                    }
                }
                else
                {
                    objectToEnableonlose.SetActive(true);
                    GameObject[] enemies = GameObject.FindGameObjectsWithTag("police");
                    for (int i = 0; i < Mathf.Min(2, enemies.Length); i++)
                    {
                        Destroy(enemies[i]);
                    }

                    GameObject[] enemies2 = GameObject.FindGameObjectsWithTag("police2");
                    for (int i = 0; i < Mathf.Min(2, enemies.Length); i++)
                    {
                        Destroy(enemies2[i]);
                    }
                }
            }
            else
            {
                Debug.LogWarning("CoinCounter script is not assigned.");
            }
        }
    }
}
