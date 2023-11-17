using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MoneyController : MonoBehaviour
{
    [SerializeField] private float _money;
    
    // Start is called before the first frame update
    void Start()
    {
        if (SaveSystem.LoadMoney() != null)
        {
            MoneyController var = SaveSystem.LoadMoney();
            _money = var._money;
        }
        else
        {
            SaveSystem.SaveMoney(this);
        }
    }

    public void AddMoney(float addedMoney)
    {
        _money += addedMoney;
        SaveSystem.SaveMoney(this);
    }

    public void SubtractMoney(float subtractedMoney)
    {
        _money -= subtractedMoney;
        SaveSystem.SaveMoney(this);
    }
}
