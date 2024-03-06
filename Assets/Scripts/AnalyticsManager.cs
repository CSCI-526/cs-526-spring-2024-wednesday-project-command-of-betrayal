using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class AnalyticsManager : MonoBehaviour
{
    public static AnalyticsManager Instance { get; private set; } 

   
    private const string formURL = "https://docs.google.com/forms/d/e/1FAIpQLScFhWT_BFBHzBmJufmesR7FrUbq2D7bttCGJB0hdYKIOZXr9A/formResponse";
    private const string sessionIDFieldName = "entry.1425437715";
    private const string sessionStartFieldName = "entry.1537180872";
    private const string diamondOneCollectedFieldName = "entry.1666743395";
    private const string diamondTwoCollectedFieldName = "entry.1627429180";
    private const string gameLostFieldName = "entry.654633359";
    private const string gameWonFieldName = "entry.1719582203";
    private const string usedGhostModeFIeldName = "entry.1781204333";

    private string sessionID;
    private bool diamondOneCollected = false;
    private bool diamondTwoCollected = false;
    private bool gameWon = false;
    private bool gameLost = false;
    private bool usedGhostMode = false;

    private int diamondsCollected = 0; 
    void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
        sessionID = System.Guid.NewGuid().ToString();
        Debug.Log(sessionID);
    }
    
    public void ResetAnalyticsOnSceneLoad()
    {
        
        diamondOneCollected = false;
        diamondTwoCollected = false;
        gameWon = false;
        gameLost = false;
        usedGhostMode = false;
        diamondsCollected = 0;

        
        sessionID = System.Guid.NewGuid().ToString();
    }
    public void UsedGhostMode()
    {
        usedGhostMode = true;
    }
    public void DiamondCollected()
    {
        diamondsCollected++;

        if (diamondsCollected == 1)
        {
            
            CollectFirstDiamond();
            Debug.Log("Diamond 1 Collected!");
        }
        else if (diamondsCollected == 2)
        {
            
            CollectSecondDiamond();
            Debug.Log("Diamond 2 Collected!");
        }
    }

    public void WonGame()
    {
        gameWon = true;
        SendEndAnalyticsData();
    }

    public void LostGame()
    {
        gameLost = true;
        SendEndAnalyticsData();
    }
  
    private void CollectFirstDiamond()
    {
        diamondOneCollected = true;
    }

    private void CollectSecondDiamond()
    {
        diamondTwoCollected = true;
    }
    private void SendEndAnalyticsData()
    {
        StartCoroutine(PostEndGameData());
    }

    IEnumerator PostEndGameData()
    {
        WWWForm form = new WWWForm();
        form.AddField(sessionIDFieldName, sessionID);
        form.AddField(sessionStartFieldName, "1"); // Assuming session start is always 1
        form.AddField(diamondOneCollectedFieldName, diamondOneCollected ? "1" : "0");
        form.AddField(diamondTwoCollectedFieldName, diamondTwoCollected ? "1" : "0");
        form.AddField(gameWonFieldName, gameWon ? "1" : "0");
        form.AddField(gameLostFieldName, gameLost ? "1" : "0");
        form.AddField(usedGhostModeFIeldName, usedGhostMode ? "1" : "0");

        using (UnityWebRequest www = UnityWebRequest.Post(formURL, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error sending analytics data: " + www.error);
            }
            else
            {
                Debug.Log("Analytics data sent successfully!");
            }
        }
    }
}
