using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public Text tutorialText;
    public GameObject[] tutorialSteps;
    private int currentStep = 0;

    void Start()
    {
        InitializeTutorial();
    }

    void InitializeTutorial()
    {
        if (tutorialSteps.Length == 0) return;

        foreach (GameObject step in tutorialSteps)
        {
            step.SetActive(false);
        }

        ShowCurrentStep();
    }

    void ShowCurrentStep()
    {
        if (currentStep < tutorialSteps.Length)
        {
            tutorialSteps[currentStep].SetActive(true);
            tutorialText.text = "Step " + (currentStep + 1) + ": " + tutorialSteps[currentStep].name;
        }
    }

    public void NextStep()
    {
        if (currentStep < tutorialSteps.Length)
        {
            tutorialSteps[currentStep].SetActive(false);
            currentStep++;
            if (currentStep < tutorialSteps.Length)
            {
                ShowCurrentStep();
            }
            else
            {
                TutorialCompleted();
            }
        }
    }

    void TutorialCompleted()
    {
        tutorialText.text = "Tutorial Completed!";
        Debug.Log("Tutorial is now completed.");
    }

    public void SkipTutorial()
    {
        foreach (GameObject step in tutorialSteps)
        {
            step.SetActive(false);
        }
        currentStep = tutorialSteps.Length;
        TutorialCompleted();
    }
}