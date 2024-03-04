using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLostAnalyticTrigger : MonoBehaviour
{
    private void OnEnable()
    {
        AnalyticsManager.Instance.LostGame();
    }
}
