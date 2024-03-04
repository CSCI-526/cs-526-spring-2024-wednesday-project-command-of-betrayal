using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BustedAnimation : MonoBehaviour
{
    public TMP_Text welcomeText;
    public Button startButton;
    private string fullText = "<align=center>\n" +
                            "<color=#ff0000>B</color><color=#ffff00>u</color><color=#ff0000>s</color><color=#ffff00>t</color><color=#ff0000>e</color><color=#ffff00>d</color><color=#ff0000>!!!</color>\n" +
                            "<line-height=0.6em><color=#ff0000>• • • • • • • • • • • • • • • • • • • • •</color><line-height=1em></align>";

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
