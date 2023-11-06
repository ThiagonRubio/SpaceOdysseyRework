using System;
using Unity.VisualScripting;
using UnityEngine;

public class CanvasSwitch : MonoBehaviour, IListener
{
    public bool IsHidden
    {
        get => isHidden;
        set => isHidden = value;
    }

    //private GameObject canvas;
    private CanvasGroup canvasGroup;

    [SerializeField] private bool isHidden;

    [SerializeField] private float fadeInSpeed = 0.25f;
    [SerializeField] private float fadeOutSpeed = 0.5f;
    
    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        
        EventManager.Instance.AddListener(EventConstants.Won, this);
        EventManager.Instance.AddListener(EventConstants.Lost, this);
        
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    private void Update()
    {
        if (!isHidden)
        {
            FadeIn();
        }

        if (isHidden)
        {
            FadeOut();
        }
    }

    private void FadeIn()
    {
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        if (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += fadeInSpeed * Time.deltaTime;
        }
    }

    private void FadeOut()
    {
        canvasGroup.alpha -= fadeOutSpeed * Time.deltaTime;
        if (canvasGroup.alpha <= 0)
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }
        
        
    public void OnEventDispatch(string invokedEvent)
    {
        isHidden = !isHidden;
    }
}
