using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; } // Singleton instance

    private bool tutorialPlayed = false;
    
    public string ButtonPrefix;
    public string ScenePrefix;

    void Start()
    {
        // PlayerPrefs.SetInt("TutorialPlayed", 0);
        tutorialPlayed = false;
        // tutorialPlayed = PlayerPrefs.GetInt("TutorialPlayed", 0) == 1;
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("LevelSelector"))
        {
            AssignOnClickHandlers();
        }

    }

    void AssignOnClickHandlers()
    {
        Button[] buttons = FindObjectsOfType<Button>(); // Find all buttons in the scene

        foreach (Button button in buttons)
        {
            if (button.name.StartsWith(ButtonPrefix))
            {
                // Extract the level index from the button name
                int levelIndex;
                if (int.TryParse(button.name.Substring(ButtonPrefix.Length), out levelIndex))
                {
                    button.onClick.AddListener(() => LoadLevel(levelIndex));
                    button.onClick.AddListener(() => AnalyticsManager.Instance.ResetAnalyticsOnSceneLoad());
                }
            }
        }
    }

    public void LoadLevel(int levelIndex)
    {

        SceneManager.LoadScene(ScenePrefix + levelIndex);


    }

    void Awake()
    {
        tutorialPlayed = PlayerPrefs.GetInt("TutorialPlayed", 0) == 1;
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

        // Implementing the singleton pattern
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("LevelSelector"))
        {
            AssignOnClickHandlers();
        }


    }

    public bool getTutorialDone(){
        return tutorialPlayed;
    }

    public void TutorialDone()
    {
        tutorialPlayed = true;
        PlayerPrefs.SetInt("TutorialPlayed", 1);
        Debug.Log("Tutorial Done");
    }
}
