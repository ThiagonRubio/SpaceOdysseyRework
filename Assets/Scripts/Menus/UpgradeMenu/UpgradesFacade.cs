using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesFacade : MonoBehaviour
{
    [SerializeField] private UpgradesUI HpButton;
    [SerializeField] private UpgradesUI AtkButton;
    [SerializeField] private UpgradesUI SpdButton;
    [SerializeField] private UpgradesUI SkDurButton;
    [SerializeField] private UpgradesUI SkCoolButton;
    [SerializeField] private UpgradesUI BFRButton;
    [SerializeField] private UpgradesUI DTButton;
    [SerializeField] private UpgradesUI TSButton;
    [SerializeField] private UpgradesUI CMButton;
    [SerializeField] private MoneyInStoreUI moneyUI;
    
    public void HpButtonPressed()
    {
        HpButton.ChangeTexts();
        moneyUI.ChangeMoneyText();
    }
    
    public void AtkButtonPressed()
    {
        AtkButton.ChangeTexts();
        moneyUI.ChangeMoneyText();
    }
    public void SpdButtonPressed()
    {
        SpdButton.ChangeTexts();
        moneyUI.ChangeMoneyText();
    }
    public void SkDurButtonPressed()
    {
        SkDurButton.ChangeTexts();
        moneyUI.ChangeMoneyText();
    }
    public void SkCoolButtonPressed()
    {
        SkCoolButton.ChangeTexts();
        moneyUI.ChangeMoneyText();
    }
    public void BFRButtonPressed()
    {
        BFRButton.ChangeTexts();
        moneyUI.ChangeMoneyText();
    }
    public void DTButtonPressed()
    {
        DTButton.ChangeTexts();
        moneyUI.ChangeMoneyText();
    }
    public void TSButtonPressed()
    {
        TSButton.ChangeTexts();
        moneyUI.ChangeMoneyText();
    }
    public void CMButtonPressed()
    {
        CMButton.ChangeTexts();
        moneyUI.ChangeMoneyText();
    }
}
