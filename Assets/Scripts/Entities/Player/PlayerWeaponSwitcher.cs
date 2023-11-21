using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerSavedStats))]
public class PlayerWeaponSwitcher : MonoBehaviour, IListener
{
    [SerializeField] private Weapon defaultWeapon;
    [SerializeField] private Weapon doubleTapWeapon;
    [SerializeField] private Weapon tripleShotWeapon;

    private float powerUpWeaponDurationLeft = 0;

    //################ #################
    //----------UNITY EV FUNC-----------
    //################ #################

    private void Start()
    {
        EventManager.Instance.AddListener(EventConstants.TripleShotEffect, this);
        EventManager.Instance.AddListener(EventConstants.DoubleTapEffect, this);

        RevertToDefaultWeapon();
    }
    private void OnDisable()
    {
        EventManager.Instance.RemoveListener(EventConstants.TripleShotEffect, this);
        EventManager.Instance.RemoveListener(EventConstants.DoubleTapEffect, this);
    }

    private void Update()
    {
        if (powerUpWeaponDurationLeft > 0)
        {
            powerUpWeaponDurationLeft -= Time.deltaTime;
        }
        else if (defaultWeapon.gameObject.activeInHierarchy == false && powerUpWeaponDurationLeft <= 0)
        {
            RevertToDefaultWeapon();
        }
    }

    //################ #################
    //----------CLASS METHODS-----------
    //################ #################

    public void OnEventDispatch(string invokedEvent)
    {
        PlayerSavedStats stats = GetComponent<PlayerSavedStats>();

        switch (invokedEvent)
        {
            case EventConstants.TripleShotEffect:
                defaultWeapon.gameObject.SetActive(false);
                doubleTapWeapon.gameObject.SetActive(false);
                tripleShotWeapon.gameObject.SetActive(true);
                break; 
            case EventConstants.DoubleTapEffect:
                defaultWeapon.gameObject.SetActive(false);
                doubleTapWeapon.gameObject.SetActive(true);
                tripleShotWeapon.gameObject.SetActive(false);
                break;
        }

        powerUpWeaponDurationLeft = stats.TripleShotDuration;
    }
    private void RevertToDefaultWeapon()
    {
        defaultWeapon.gameObject.SetActive(true);
        doubleTapWeapon.gameObject.SetActive(false);
        tripleShotWeapon.gameObject.SetActive(false);
        powerUpWeaponDurationLeft = 0;
    }
}
