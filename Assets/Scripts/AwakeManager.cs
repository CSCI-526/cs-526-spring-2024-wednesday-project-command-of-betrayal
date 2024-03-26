using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;

public class AwakeManager : MonoBehaviour
{
public static AwakeManager Instance { get; private set; } 
void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }
}