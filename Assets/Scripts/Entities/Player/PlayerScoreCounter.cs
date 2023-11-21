using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreCounter : MonoBehaviour, IListener
{
    [SerializeField] ScoreFacade scoreFacade;
    public float Score => _score;
    
    private float _score;
    private float _coinMultiplier;

    private const float NUKE_SCORE = 200;
    
    private void Start()
    {
        _coinMultiplier = GetComponent<PlayerSavedStats>().UpgradedCoinMultiplier;
        
        EventManager.Instance.AddListener(EventConstants.NukeEffect, this);
        ActionsManager.SubscribeToAction(EventConstants.EnemyDeath, EnemyScoreSelection);
        ActionsManager.SubscribeToAction(EventConstants.BossDeath, EnemyScoreSelection);
        
        EventManager.Instance.AddListener(EventConstants.Lost, this);
        EventManager.Instance.AddListener(EventConstants.Won, this);
    }
    private void OnDisable()
    {
        ActionsManager.UnsubscribeToAction(EventConstants.EnemyDeath, EnemyScoreSelection);
        ActionsManager.UnsubscribeToAction(EventConstants.BossDeath, EnemyScoreSelection);
        EventManager.Instance.RemoveListener(EventConstants.NukeEffect, this);
        EventManager.Instance.RemoveListener(EventConstants.Lost, this);
        EventManager.Instance.RemoveListener(EventConstants.Won, this);
    }

    private void AddScore(float addedScore)
    {
        _score += addedScore;
        scoreFacade.UpdateScoreUI(_score);
    }
    
    private int ScoreToCoinConversion(float score, float coinMultiplier)
    {
        int money = Mathf.RoundToInt(score * coinMultiplier);
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
                AddMoney(ScoreToCoinConversion(_score, _coinMultiplier));
                break;
            }
            case EventConstants.Won:
            {
                AddMoney(ScoreToCoinConversion(_score, _coinMultiplier));
                break;
            }
        }
    }

    private void AddMoney(float addedMoney)
    {
        GetComponent<PlayerSavedStats>().SaveMoneyData(addedMoney);
    }
}
