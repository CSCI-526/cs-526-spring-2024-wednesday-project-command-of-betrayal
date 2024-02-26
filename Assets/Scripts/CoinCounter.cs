using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class CoinCounter : MonoBehaviour
{
    public int currentCoins = 0;
    public TMP_Text coinText;

    // Start is called before the first frame update
    void Start()
    {
        coinText.text = "COINS:" + currentCoins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseCoins(int v)
    {
        currentCoins += v;
        coinText.text = "COINS:" + currentCoins.ToString();
    }
}
