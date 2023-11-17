using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MoneyController : MonoBehaviour
{
    [SerializeField] private float _money;
    private GameData data;
    void Start()
    {
        if (SaveSystem.LoadFromJson() != null)
        {
            data = SaveSystem.LoadFromJson();
            _money = data.MoneyStored;
        }
        else
        {
            data = new GameData();
            SaveSystem.SaveToJson(data);
        }
    }

    public void AddMoney(float addedMoney)
    {
        _money += addedMoney;
        SaveCurrentMoneyStored();
    }

    public void SubtractMoney(float subtractedMoney)
    {
        _money -= subtractedMoney;
        SaveCurrentMoneyStored();
    }

    public void SaveCurrentMoneyStored()
    {
        data = SaveSystem.LoadFromJson();
        data.MoneyStored = _money;
        SaveSystem.SaveToJson(data);
    }
}
