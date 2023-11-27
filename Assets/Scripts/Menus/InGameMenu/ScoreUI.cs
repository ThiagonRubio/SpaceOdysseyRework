using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    private float score;

    public void UpdateScore(float newScore)
    {
        score = newScore;
        textMeshProUGUI.text = score.ToString();
    }
}
