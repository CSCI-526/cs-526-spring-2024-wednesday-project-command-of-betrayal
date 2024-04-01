using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System;

public class TutorialManager : MonoBehaviour
{
    public GameObject instructionsCanvas;
    public TextMeshProUGUI instructionsText;

    public GameObject MovementStage;
    public GameObject DiamondStage;
    public GameObject GhostStage;
    public GameObject teleportsign;
    public GameObject DiamondStage2;
    public GameObject Stage5Instructions;
    public GameObject Stage6Instructions;
    public Button continueButton;
    public GameObject blurCamObj; 
    public GameObject labelUI; 

    public TextMeshProUGUI scoreObject;


    private bool isPaused = true;
    private bool inputReceived = false;
    private TutorialStage currentStage;

    private enum TutorialStage
    {
        Movement,
        CollectDiamond,
        GhostAbility,
        GhostAbility2,
        CollectDiamond2,
        Teleport,
        Finish
    }

    void Start()
    {
        PauseGameWithBlur();
        currentStage = TutorialStage.Movement;
        MovementStage.SetActive(true);
        continueButton.onClick.AddListener(ContinueGame);
    }

    void PauseGameWithBlur()
    {
        Time.timeScale = 0f; 
        blurCamObj.SetActive(true);
        labelUI.SetActive(false);
        isPaused = true;

    }

    void ContinueGame()
    {
        isPaused = false;
        instructionsCanvas.SetActive(false);
        Time.timeScale = 1f;
        blurCamObj.SetActive(false);
        labelUI.SetActive(true);
        inputReceived = false;

        switch (currentStage)
        {
            case TutorialStage.Movement:
                currentStage = TutorialStage.CollectDiamond;
                StartCoroutine(ShowInstructionsAfterDelay(MovementStage, DiamondStage, 1f));
                break;
            case TutorialStage.CollectDiamond:
                Debug.Log("CollectDiamond");
                stageDeactivate(DiamondStage);
                break;
            case TutorialStage.GhostAbility:
                Debug.Log("GhostAbility");
                currentStage = TutorialStage.GhostAbility2;
                StartCoroutine(ShowInstructionsAfterDelay(GhostStage, "Ghost ability can be used once for 3 seconds", 1f));
                break;
            case TutorialStage.GhostAbility2:
                currentStage = TutorialStage.CollectDiamond2;
                StartCoroutine(ShowInstructionsAfterDelay(GhostStage, DiamondStage2, 1f));
                break;

            case TutorialStage.Teleport:
                StartCoroutine(ShowInstructionsAfterDelay(teleportsign, "Teleport to another location", 1f));
                break;
            case TutorialStage.CollectDiamond2:
                stageDeactivate(DiamondStage2);
                break;

            case TutorialStage.Finish:
                // StartCoroutine(ShowInstructionsAfterDelay("Well Done! Now go to Exit", 2f));
                break;

        }
    }

    IEnumerator ShowInstructionsAfterDelay(GameObject lastStage, GameObject currentStage, float delay)
    {
        lastStage.SetActive(false);
        yield return new WaitForSeconds(delay);
        PauseGameWithBlur();
        currentStage.SetActive(true);
    }
    IEnumerator ShowInstructionsAfterDelay(GameObject lastStage, String text, float delay)
    {
        lastStage.SetActive(false);
        yield return new WaitForSeconds(delay);
        PauseGameWithBlur();
        SetInstructions(text);
    }

    void stageDeactivate(GameObject stage){
        stage.SetActive(false);
    }

    void SetInstructions(string message)
    {
        instructionsCanvas.SetActive(true);
        instructionsText.text = message;
    }

    void Update()
    {
        // Debug.Log("In Update");
        // Debug.Log("Is Paused:" + isPaused + "inputReceived+ " + inputReceived);

        if (isPaused && !inputReceived)
        {
            switch (currentStage)
            {
                case TutorialStage.Movement:
                case TutorialStage.CollectDiamond:
                case TutorialStage.CollectDiamond2:
                case TutorialStage.GhostAbility2:
                case TutorialStage.Finish:
                case TutorialStage.Teleport:
                    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) ||
                        Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) ||
                        Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) ||
                        Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        inputReceived = true;
                        ContinueGame();
                    }
                    break;

                case TutorialStage.GhostAbility:
                    if (Input.GetKeyDown(KeyCode.T))
                    {
                        inputReceived = true;
                        ContinueGame();
                    }
                    break;
            }
        }
        else
        {
        }
        // Debug.Log(currentStage == TutorialStage.CollectDiamond && scoreObject.text == "1");
        if (currentStage == TutorialStage.CollectDiamond && scoreObject.text == "1")
        {
            currentStage = TutorialStage.GhostAbility;
            StartCoroutine(ShowInstructionsAfterDelay(DiamondStage, GhostStage, 0.5f));
        }

        if (currentStage == TutorialStage.CollectDiamond2 && scoreObject.text == "2")
        {
            currentStage = TutorialStage.Finish;
            StartCoroutine(ShowInstructionsAfterDelay(DiamondStage2, "You can use teleport loop to escape", 0.5f));
        }
    }

}
