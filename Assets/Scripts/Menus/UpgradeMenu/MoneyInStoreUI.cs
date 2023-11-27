using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyInStoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private UpgradeMenuController upgradeController;

    private void Start()
    {
        ChangeMoneyText();
    }

    public void ChangeMoneyText()
    {
        moneyText.text = upgradeController.CurrentLoadedSessionData.MoneyStored + " $";
    }
}
