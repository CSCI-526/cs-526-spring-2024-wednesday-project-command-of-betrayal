using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUpdate : MonoBehaviour
{
    //public Text tutorialText;
    public GameObject player;

    private int step = 0;

    void Update()
    {
        switch (step)
        {
            case 0:
                //tutorialText.text = "Use the arrow keys to move left and right.";
                if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
                {
                    step++;
                }
                break;
            case 1:
                //tutorialText.text = "Press 'Space' to jump.";
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    step++;
                }
                break;
            case 2:
                //tutorialText.text = "Great! Now reach the end of the level to complete the tutorial.";
                break;
        }
    }
}

