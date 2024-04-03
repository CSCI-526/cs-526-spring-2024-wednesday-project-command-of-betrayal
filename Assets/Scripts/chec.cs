using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chec : MonoBehaviour
{
    public GameObject objectToEnable;
    public GameObject objectToEnableonlose;
    public GameObject objectToDestroyOnCollision;
    public GameObject canvasToTurnOff;
    public GameObject canvasToTurnOff2;
    public GameObject canvasToTurnOff3;
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
            Destroy(objectToDestroyOnCollision); 

            if (c != null)
            {
                Debug.Log(c.coin);
                if (c.coin == 0)
                {
                    objectToEnable.SetActive(true);


                    canvasToTurnOff.SetActive(false);
                    canvasToTurnOff2.SetActive(false);
                    canvasToTurnOff3.SetActive(false);

                    AnalyticsManager.Instance.WonGame();
                    // LevelManager.Instance.CompleteLevel(1);
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
                else if (c.coin >0)
                {
                    objectToEnableonlose.SetActive(true);
                    canvasToTurnOff.SetActive(false);
                    canvasToTurnOff2.SetActive(false);
                    canvasToTurnOff3.SetActive(false);
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
                objectToEnableonlose.SetActive(true);
                Debug.LogWarning("CoinCounter script is not assigned.");
            }
        }
    }
}
