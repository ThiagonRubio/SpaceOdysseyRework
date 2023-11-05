using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDropper : MonoBehaviour, IListener //Lo deberían tener los enemy
{
    void Start()
    {
        EventManager.Instance.AddListener(EventConstants.EnemyDeath, this);
    }
   
    public void OnEventDispatch(string invokedEvent)
    {
        //Random para saber si droppea
        //Random para saber qué droppea
        //Instanciar elemento a droppear
    }
}
