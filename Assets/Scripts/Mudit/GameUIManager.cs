using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class GameUIManager : MonoBehaviour
{
    public TMP_Text welcomeText;
    public Button startButton;
    private string fullText = "<color=#008000>Welcome <color=#FFD700>thief</color>,</color>\n" +
                                  "* you need to <color=#FF4500>steal</color> the <color=#FFD700>diamonds ♦</color>\n" +
                                  "* Beware of the <color=#1E90FF>patrolling police</color>.\n" +
                                  "* If needed, use your <color=#9400D3>ghost ability</color> by \n  pressing <color=#FFA500>T</color> and it will be\n" +
                                  "  <color=#32CD32>enabled</color> for <color=#FF4500>3 seconds</color>.";

    private void OnEnable()
    {
        StartCoroutine(TypeText(fullText));
    }

    IEnumerator TypeText(string fullText)
    {
        string currentText = "";
        bool isTag = false;
        foreach (char c in fullText)
        {
            if (c == '<' || isTag)
            {
                isTag = true;
                currentText += c;
                if (c == '>')
                {
                    isTag = false;
                }
            }
            else
            {
                currentText += c;
                welcomeText.text = currentText;
                yield return new WaitForSeconds(0.05f); // Wait 0.05 seconds before adding next character
            }
        }
        StartCoroutine(AnimateButton());
    }


    IEnumerator AnimateButton()
    {
        Vector3 originalScale = startButton.transform.localScale;
        Vector3 destinationScale = originalScale * 1.1f; // 10% larger for the 'pulse' effect

        // Scale up
        while (startButton.transform.localScale != destinationScale)
        {
            startButton.transform.localScale = Vector3.MoveTowards(startButton.transform.localScale, destinationScale, Time.deltaTime * 2);
            yield return null;
        }

        // Scale down
        while (startButton.transform.localScale != originalScale)
        {
            startButton.transform.localScale = Vector3.MoveTowards(startButton.transform.localScale, originalScale, Time.deltaTime * 2);
            yield return null;
        }

        // Repeat the scale animation
        StartCoroutine(AnimateButton());
    }
}
