using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoneyController))]
public class ScoreCounter : MonoBehaviour, IListener
{
    private float _score;
    private float _coinMultiplier;
    private MoneyController _moneyController;

    private const float NUKE_SCORE = 200;
    
    void Start()
    {
        _moneyController = GetComponent<MoneyController>();
        // _coinMultiplier = SaveSystem.LoadPlayerStats().UpgradedCoinMultiplier;
        
        EventManager.Instance.AddListener(EventConstants.NukeEffect, this);
        ActionsManager.SubscribeToAction(EventConstants.EnemyDeath, EnemyScoreSelection);
        ActionsManager.SubscribeToAction(EventConstants.BossDeath, EnemyScoreSelection);
        
        EventManager.Instance.AddListener(EventConstants.Lost, this);
        EventManager.Instance.AddListener(EventConstants.Won, this);
    }
    
    private void AddScore(float addedScore)
    {
        _score += addedScore;
    }
    
    private int ScoreToCoinConversion(float score, float coinMultiplier)
    {
        int money = Mathf.RoundToInt(score * coinMultiplier);
        Debug.Log(money);
        return money;
    }
    
    public void EnemyScoreSelection(Transform deadEnemy)
    {
        AddScore(deadEnemy.GetComponent<Enemy>().ScoreGiven);
    }
    
    public void OnEventDispatch(string invokedEvent)
    {
        switch (invokedEvent)
        {
            case EventConstants.NukeEffect:
            {
                AddScore(NUKE_SCORE);
                break;
            }
            case EventConstants.Lost:
            {
                _moneyController.AddMoney(ScoreToCoinConversion(_score, _coinMultiplier));
                break;
            }
            case EventConstants.Won:
            {
                _moneyController.AddMoney(ScoreToCoinConversion(_score, _coinMultiplier));
                break;
            }
        }
    }
}
