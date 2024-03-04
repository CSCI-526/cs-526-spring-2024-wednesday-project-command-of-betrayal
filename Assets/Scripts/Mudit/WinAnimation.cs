using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinAnimation : MonoBehaviour
{
    public TMP_Text winTextComponent;
    public Button continueButton;

    private string winText = "<align=center>\n" +
                             "<color=#00ff00>C</color><color=#ffff00>o</color><color=#00ff00>n</color><color=#ffff00>g</color><color=#00ff00>r</color><color=#ffff00>a</color><color=#00ff00>t</color><color=#ffff00>u</color><color=#00ff00>l</color><color=#ffff00>a</color><color=#00ff00>t</color><color=#ffff00>i</color><color=#00ff00>o</color><color=#ffff00>n</color><color=#00ff00>s</color>!\n" +
                             "<color=#00ff00>Y</color><color=#ffff00>o</color><color=#00ff00>u</color> <color=#ffff00>W</color><color=#00ff00>o</color><color=#ffff00>n</color><color=#00ff00>!!!</color>\n" +
                             "<line-height=0.6em><color=#00ff00>..........................................</color><line-height=1em></align>";

    void Start()
    {
        winTextComponent.text = ""; // Initialize the text to be empty
        StartCoroutine(AnimateWinText());
    }

    IEnumerator AnimateWinText()
    {
        yield return TypeText(winText); // Animate the win message
        StartCoroutine(AnimateButton(continueButton)); // After the message, animate the button
    }

    IEnumerator TypeText(string textToType)
    {
        string currentText = "";
        bool isTag = false;
        foreach (char c in textToType)
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
                winTextComponent.text = currentText;
                yield return new WaitForSeconds(0.05f); // Delay for the typewriter effect
            }
        }
    }

    IEnumerator AnimateButton(Button button)
    {
        Vector3 originalScale = button.transform.localScale;
        Vector3 destinationScale = originalScale * 1.1f; // Scale up the button to 110% of its original size

        while (true) // Loop indefinitely
        {
            // Scale up
            while (button.transform.localScale != destinationScale)
            {
                button.transform.localScale = Vector3.MoveTowards(button.transform.localScale, destinationScale, Time.deltaTime * 2);
                yield return null;
            }

            // Scale down
            while (button.transform.localScale != originalScale)
            {
                button.transform.localScale = Vector3.MoveTowards(button.transform.localScale, originalScale, Time.deltaTime * 2);
                yield return null;
            }
        }
    }
}
