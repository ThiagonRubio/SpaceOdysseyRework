using System;
using TMPro;
using UnityEngine;

public class FinalCanvasTextChange : MonoBehaviour, IListener
{
    [SerializeField] private TextMeshProUGUI text;

    private void Start()
    {
        EventManager.Instance.AddListener(EventConstants.Won,this);
        EventManager.Instance.AddListener(EventConstants.Lost,this);
    }


    public void OnEventDispatch(string invokedEvent)
    {
        if (invokedEvent == EventConstants.Won)
        {
            text.text = "YOU\nWon";
        }
        if (invokedEvent == EventConstants.Lost)
        {
            text.text = "GAME\nOVER";
        }
    }
}
