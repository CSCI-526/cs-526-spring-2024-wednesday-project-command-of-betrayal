using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWonAnalyticTrigger : MonoBehaviour
{
    private void OnEnable()
    {
        AnalyticsManager.Instance.WonGame();
    }
}
