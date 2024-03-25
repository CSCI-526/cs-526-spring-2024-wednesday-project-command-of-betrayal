using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;

public class AwakeManager : MonoBehaviour
{
public static AwakeManager Instance { get; private set; } // Singleton instance
void Awake()
    {
        // Implementing the singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }
}