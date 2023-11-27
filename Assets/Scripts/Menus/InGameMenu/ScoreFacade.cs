using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreFacade : MonoBehaviour
{
    [SerializeField] ScoreUI scoreUI;

    public void UpdateScoreUI(float newScore)
    {
        scoreUI.UpdateScore(newScore);
    }
}
