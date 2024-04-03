using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject tutDialog;
    private bool tutorialPlayed = false;

    void Start(){
        mainMenu.SetActive(true);
        tutDialog.SetActive(false);
    }
    public void PlayGame()
    {
        // tutorialPlayed = PlayerPrefs.GetInt("TutorialPlayed", 0) == 1;
        tutorialPlayed = LevelManager.Instance.getTutorialDone();

        if (tutorialPlayed){
            SceneManager.LoadScene("LevelSelector");

        }
        else {
            mainMenu.SetActive(false);
            tutDialog.SetActive(true);
        }
    }

    public void closeDialog() {
        tutDialog.SetActive(false);
        mainMenu.SetActive(true);
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
