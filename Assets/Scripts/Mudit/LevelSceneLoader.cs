using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSceneLoader : MonoBehaviour
{
    public int tutorialSceneNumber;
    public int levelOneSceneNumber;
    public int levelTwoSceneNumber;
    public int mainMenuSceneNumber;

    public void LoadTutorialScene()
    {
        SceneManager.LoadScene(tutorialSceneNumber);
    }

    public void LoadLevelOneScene()
    {
        SceneManager.LoadScene(levelOneSceneNumber);
    }

    public void LoadLevelTwoScene()
    {
        SceneManager.LoadScene(levelTwoSceneNumber);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneNumber);
    }
}
