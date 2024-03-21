using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameend : MonoBehaviour
{
    public void Start()
    {
        
    }
    public void Update()
    {
        
    }
    public void ResetScene()
    {
        
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 1f;
        AnalyticsManager.Instance.ResetAnalyticsOnSceneLoad();
        TutorialManager.Instance.ReloadSingleton();
        SceneManager.LoadScene(currentSceneIndex);
    }
}
