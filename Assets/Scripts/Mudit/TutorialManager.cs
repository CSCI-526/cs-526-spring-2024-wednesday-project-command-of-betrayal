using System.Collections;
using TMPro;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager Instance { get; private set; }
    public float delayInSeconds = 2f;
    public GameObject textBoxparent;
    public GameObject[] textArrayGameobject;
    public bool tKeyPressed = true;
    private bool arrowKeyPressed = false;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If another instance already exists, destroy this one
            Destroy(gameObject);
        }
    }
    // Method to destroy and reload the singleton
    public void ReloadSingleton()
    {
        // Destroy the current instance of the singleton
        Destroy(gameObject);

        // Instantiate a new instance of the singleton in the new scene
        GameObject newSingleton = Instantiate(this.gameObject);
        Instance = newSingleton.GetComponent<TutorialManager>();
        DontDestroyOnLoad(newSingleton);
    }
    // Start is called before the first frame update
    void Start()
    {
        textBoxparent.SetActive(false);
        EnableTextOne();
    }

    void Update()
    {
        // Check if any arrow key is pressed
        if (!arrowKeyPressed && (Input.GetKeyDown(KeyCode.UpArrow) ||
            Input.GetKeyDown(KeyCode.DownArrow) ||
            Input.GetKeyDown(KeyCode.LeftArrow) ||
            Input.GetKeyDown(KeyCode.RightArrow)))
        {
            arrowKeyPressed = true;
            // Start the coroutine to disable the object after a delay
            StartCoroutine(DisableObjectWithDelay(textBoxparent));
            StartCoroutine(EnableTextTwoWithDelay());
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (tKeyPressed)
            {
                EnableTextThree();
                tKeyPressed = false;
                Time.timeScale = 1f;
            }
            else
            {
                EnableTextFour();
                StartCoroutine(DisableObjectWithDelay(textBoxparent));
            }
        }
    }

    public void EnableTextOne()
    {
        textBoxparent.SetActive(true);
        textArrayGameobject[0].SetActive(true);
        textArrayGameobject[1].SetActive(false);
        textArrayGameobject[2].SetActive(false);
        textArrayGameobject[3].SetActive(false);
        textArrayGameobject[4].SetActive(false);
    }
    public void EnableTextTwo()
    {
        textBoxparent.SetActive(true);
        textArrayGameobject[0].SetActive(false);
        textArrayGameobject[1].SetActive(true);
        textArrayGameobject[2].SetActive(false);
        textArrayGameobject[3].SetActive(false);
        textArrayGameobject[4].SetActive(false);
    }
    public void EnableTextThree()
    {
        textBoxparent.SetActive(true);
        textArrayGameobject[0].SetActive(false);
        textArrayGameobject[1].SetActive(false);
        textArrayGameobject[2].SetActive(true);
        textArrayGameobject[3].SetActive(false);
        textArrayGameobject[4].SetActive(false);
        Time.timeScale = 0.3f;
    }
    public void EnableTextFour()
    {
        textBoxparent.SetActive(true);
        textArrayGameobject[0].SetActive(false);
        textArrayGameobject[1].SetActive(false);
        textArrayGameobject[2].SetActive(false);
        textArrayGameobject[3].SetActive(true);
        textArrayGameobject[4].SetActive(false);
    }
    public void EnableTextFive()
    {
        textBoxparent.SetActive(true);
        textArrayGameobject[0].SetActive(false);
        textArrayGameobject[1].SetActive(false);
        textArrayGameobject[2].SetActive(false);
        textArrayGameobject[3].SetActive(false);
        textArrayGameobject[4].SetActive(true);
    }
    public void EnableTextSix()
    {
        textBoxparent.SetActive(true);
        textArrayGameobject[0].SetActive(false);
        textArrayGameobject[1].SetActive(false);
        textArrayGameobject[2].SetActive(false);
        textArrayGameobject[3].SetActive(false);
        textArrayGameobject[4].SetActive(false);
        textArrayGameobject[5].SetActive(true);
    }

    IEnumerator DisableObjectWithDelay(GameObject obj)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delayInSeconds);

        // Disable the object
        if (obj != null)
        {
            obj.SetActive(false);
        }
    }
    IEnumerator EnableTextTwoWithDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(3f);
        EnableTextTwo();
    }
}
