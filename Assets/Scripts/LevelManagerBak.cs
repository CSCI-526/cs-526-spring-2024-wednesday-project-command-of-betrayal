using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManagerBak : MonoBehaviour
{
    public static LevelManagerBak Instance { get; private set; } // Singleton instance

    public string ButtonPrefix;
    public string ScenePrefix;
    public int totalLevels = 6; // Change this according to the total number of levels

    private bool tutorialPlayed = false;

    void Start()
    {
        PlayerPrefs.SetInt("TutorialPlayed", 0);
        tutorialPlayed = PlayerPrefs.GetInt("TutorialPlayed", 0) == 1;
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("LevelSelector"))
        {
            AssignOnClickHandlers();
            UpdateCompletedLevels(); // Update completed levels when the game starts
        }
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
            UpdateCompletedLevels(); // Update completed levels when the game starts
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
                }
            }
        }
    }

    void UpdateCompletedLevels()
    {
        // for (int i = 1; i <= totalLevels; i++)
        // {
        //     Debug.Log(PlayerPrefs.GetInt("Level_" + i.ToString(), 0));
        //     if (PlayerPrefs.GetInt("Level_" + i.ToString(), 0) == 1)
        //     {
        //         // If the level is completed, enable the button except for the first level
        //         if (i > 1)
        //         {
        //             GameObject.Find(ButtonPrefix + i.ToString()).GetComponent<Button>().interactable = true;
        //         }
        //     }
        //     else
        //     {
        //         if (i != 1)
        //         {
        //             GameObject.Find(ButtonPrefix + i.ToString()).GetComponent<Button>().interactable = false;

        //         }
        //     }
        // }
    }

    public void LoadLevel(int levelIndex)
    {
        if (levelIndex == 1 && tutorialPlayed)
        {
            SceneManager.LoadScene(ScenePrefix + levelIndex);
        }
        else if (levelIndex == 1 && !tutorialPlayed)
        {
            SceneManager.LoadScene("TutorialScene");
        }
        else
        {
            SceneManager.LoadScene(ScenePrefix + levelIndex);
        }

    }

    public void CompleteLevel(int levelIndex)
    {
        PlayerPrefs.SetInt("Level_" + levelIndex.ToString(), 1);
        // You can also add additional logic here such as unlocking the next level, displaying a completion message, etc.
    }

    public void TutorialDone()
    {
        AnalyticsManager.Instance.DestroyInstance();
        PlayerPrefs.SetInt("TutorialPlayed", 1);
        Debug.Log("Tutorial Done");
    }

    public void GoBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
