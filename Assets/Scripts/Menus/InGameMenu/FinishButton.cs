using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishButton : MonoBehaviour
{
    [SerializeField] PlayerDamageableComponent player;
    [SerializeField] PauseFacade facade;

    public void FinishLevel()
    {
        facade.ContinueGame();
        player.Die();
    }
}
