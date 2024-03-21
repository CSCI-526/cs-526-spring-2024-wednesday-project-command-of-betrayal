using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public int nextSceneNumber;

    public void ChangeToNextScene()
    {
        SceneManager.LoadScene(nextSceneNumber);
    }
}
