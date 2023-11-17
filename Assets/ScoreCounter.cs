using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoneyController))]
public class ScoreCounter : MonoBehaviour, IListener
{
    [SerializeField] private float _score;
    [SerializeField] private float _coinMultiplier;
    private MoneyController _moneyController;

    [SerializeField] private ScoreStats scoreStats;
    
    void Start()
    {
        _moneyController = GetComponent<MoneyController>();
        _coinMultiplier = SaveSystem.LoadPlayerStats().UpgradedCoinMultiplier;
        
        EventManager.Instance.AddListener(EventConstants.NukeEffect, this);
        ActionsManager.SubscribeToAction(EventConstants.EnemyDeath, EnemyScoreSelection);
        EventManager.Instance.AddListener(EventConstants.BossDeath, this);
        
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
        Debug.Log("Registro que murió alguien");
        switch (deadEnemy.name)
        {
            case "Asteroid":
            {
                Debug.Log("Fue un asteroide");
                AddScore(scoreStats.AsteroidScore);
                break;
            }
            case "RedShip":
            {
                
                Debug.Log("Fue una nave roja");
                AddScore(scoreStats.RedShipScore);
                break;
            }
            case "PurpleShip":
            {
                AddScore(scoreStats.PurpleShipScore);
                break;
            }
            case "YellowShip":
            {
                AddScore(scoreStats.YellowShipScore);
                break;
            }
        }
    }
    
    public void OnEventDispatch(string invokedEvent)
    {
        switch (invokedEvent)
        {
            case EventConstants.NukeEffect:
            {
                AddScore(scoreStats.NukeScore);
                break;
            }
            case EventConstants.BossDeath:
            {
                AddScore(scoreStats.RedBosscore);
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
