using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;

public class AnalyticsManager : MonoBehaviour
{
    public static AnalyticsManager Instance { get; private set; } 

    private const string formURL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLScFhWT_BFBHzBmJufmesR7FrUbq2D7bttCGJB0hdYKIOZXr9A/formResponse";
    // private const string formURL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLScIHVahCdPvuCaiNaUCMBBZ3irn0guQQZe4J-hhxoVl-xyGCQ/formResponse";
    private const string sessionIDFieldName = "entry.1425437715";
    private const string sessionStartFieldName = "entry.1537180872";
    private const string diamondOneCollectedFieldName = "entry.1666743395";
    private const string diamondTwoCollectedFieldName = "entry.1627429180";
    private const string gameLostFieldName = "entry.654633359";
    private const string gameWonFieldName = "entry.1719582203";
    private const string usedGhostModeFIeldName = "entry.1781204333";
    // private const string sessionIDFieldName = "entry.1528187168";
    // private const string sessionStartFieldName = "entry.1624323975";
    // private const string diamondOneCollectedFieldName = "entry.466139527";
    // private const string diamondTwoCollectedFieldName = "entry.2035539655";
    // private const string gameLostFieldName = "entry.880444437";
    // private const string gameWonFieldName = "entry.114316415";
    // private const string usedGhostModeFIeldName = "entry.2012665187";

    // private const string timeToWinFieldName = "entry.1915734830";
    // private const string timeToCollectFirstDiamondFieldName = "entry.632710935";
    // private const string timeToCollectSecondDiamondFieldName = "entry.662346092";
    // private const string timeBetweenDiamondsFieldName = "entry.24591028";

    private string sessionID;
    private bool diamondOneCollected = false;
    private bool diamondTwoCollected = false;
    private bool gameWon = false;
    private bool gameLost = false;
    private bool usedGhostMode = false;

    private int diamondsCollected = 0; 

    private DateTime startTime;
    private DateTime diamondOneTime;
    private DateTime diamondTwoTime;

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
        startTime = DateTime.Now;

    }
    public void ResetAnalyticsOnSceneLoad()
    {
        diamondOneCollected = false;
        diamondTwoCollected = false;
        gameWon = false;
        gameLost = false;
        usedGhostMode = false;
        diamondsCollected = 0;

        sessionID = Guid.NewGuid().ToString();
        startTime = DateTime.Now;
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
            diamondOneTime = DateTime.Now;
            CollectFirstDiamond();
            Debug.Log("Diamond 1 Collected!");
        }
        else if (diamondsCollected == 2)
        {
            diamondTwoTime = DateTime.Now;
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
        TimeSpan timeToWin = DateTime.Now - startTime;
        TimeSpan timeToCollectFirstDiamond = diamondOneTime - startTime;
        TimeSpan timeToCollectSecondDiamond = diamondTwoTime - diamondOneTime;
        TimeSpan timeBetweenDiamonds = diamondTwoTime - diamondOneTime;

        WWWForm form = new WWWForm();
        form.AddField(sessionIDFieldName, sessionID);
        form.AddField(sessionStartFieldName, "1"); 
        form.AddField(diamondOneCollectedFieldName, diamondOneCollected ? "1" : "0");
        form.AddField(diamondTwoCollectedFieldName, diamondTwoCollected ? "1" : "0");
        form.AddField(gameWonFieldName, gameWon ? "1" : "0");
        form.AddField(gameLostFieldName, gameLost ? "1" : "0");
        form.AddField(usedGhostModeFIeldName, usedGhostMode ? "1" : "0");

        // Add time measurements
        // form.AddField(timeToWinFieldName, (int)timeToWin.TotalSeconds);
        // form.AddField(timeToCollectFirstDiamondFieldName, (int)timeToCollectFirstDiamond.TotalSeconds);
        // form.AddField(timeToCollectSecondDiamondFieldName, (int)timeToCollectSecondDiamond.TotalSeconds);
        // form.AddField(timeBetweenDiamondsFieldName, (int)timeBetweenDiamonds.TotalSeconds);


        using (UnityWebRequest www = UnityWebRequest.Post(formURL, form))
        {
            yield return 0;

            if (www.result != 0)
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
