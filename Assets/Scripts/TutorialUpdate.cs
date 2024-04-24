using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUpdate : MonoBehaviour
{
    public GameObject player;
    public GameObject collectibleItem;
    public Animator textAnimator;

    private int step = 0;
    private bool itemCollected = false;

    void Start()
    {

        //tutorialText.text = "Welcome to the tutorial! Let's learn the basics.";
        if (textAnimator != null)
        {
            textAnimator.SetTrigger("Highlight");
        }
    }

    void Update()
    {
        switch (step)
        {
            case 0:
                //tutorialText.text = "Use the arrow keys to move left and right.";
                if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
                {
                    NextStep();
                }
                break;
            case 1:
                //tutorialText.text = "Press 'Space' to jump.";
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    NextStep();
                }
                break;
            case 2:
                //tutorialText.text = "Now, collect the item by touching it.";
                if (itemCollected)
                {
                    NextStep();
                }
                break;
            case 3:
                //tutorialText.text = "Great! Now reach the end of the level to complete the tutorial.";

                break;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == collectibleItem)
        {
            itemCollected = true;
            Destroy(collectibleItem);
        }
    }

    private void NextStep()
    {
        step++;
        if (textAnimator != null)
        {
            textAnimator.SetTrigger("Highlight");
        }
    }
}