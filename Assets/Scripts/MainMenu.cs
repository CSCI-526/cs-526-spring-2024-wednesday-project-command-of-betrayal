using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("LevelSelector");
    }

    public void OpenOptions()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
