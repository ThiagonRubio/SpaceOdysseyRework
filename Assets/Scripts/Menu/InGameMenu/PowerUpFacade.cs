using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFacade : MonoBehaviour, IListener
{
    [SerializeField] private PowerUpUI TripleShotUI;
    [SerializeField] private PowerUpUI DoubleTapUI;

    private void Start()
    {
        PlayerSavedStats stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSavedStats>();
        EventManager.Instance.AddListener(EventConstants.TripleShotEffect, this);
        EventManager.Instance.AddListener(EventConstants.DoubleTapEffect, this);

        TripleShotUI.ChangeDuration(stats.TripleShotDuration);
        DoubleTapUI.ChangeDuration(stats.DoubleTapDuration);

        DoubleTapUI.gameObject.SetActive(false);
        TripleShotUI.gameObject.SetActive(false);
    }

    public void OnEventDispatch(string invokedEvent)
    {
        switch (invokedEvent)
        {
            case EventConstants.TripleShotEffect:
                TripleShotUI.gameObject.SetActive(true);
                DoubleTapUI.gameObject.SetActive(false);
                TripleShotUI.ResetPowerUpUI();
                TripleShotUI.ParticlePlay();
                break;
            case EventConstants.DoubleTapEffect:
                DoubleTapUI.gameObject.SetActive(true);
                TripleShotUI.gameObject.SetActive(false);
                DoubleTapUI.ResetPowerUpUI();
                DoubleTapUI.ParticlePlay();
                break;
        }
    }
}
