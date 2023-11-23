using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeEffect : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;

    private bool fadeIn = false;
    private bool fadeOut = false;

    public void ShowUI()
    {
        fadeIn = true;
        fadeOut = false;
    }

    public void HideUI()
    {
        fadeOut = true;
        fadeIn = false;
    }

    public void AutomaticallyShowUI()
    {
        fadeIn = false;
        fadeOut = false;
        canvasGroup.alpha = 1;
    }
    
    public void AutomaticallyHideUI()
    {
        fadeIn = false;
        fadeOut = false;
        canvasGroup.alpha = 0;
    }

    private void Start()
    {
        canvasGroup.alpha = 0;
        fadeIn = true;
    }

    private void Update()
    {
        if (fadeIn)
        {
            if (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += 0.25f * Time.deltaTime;
                if (canvasGroup.alpha >= 1)
                {
                    fadeIn = false;
                }
            }
        }

        if (fadeOut)
        {
            if (canvasGroup.alpha >= 0)
            {
                canvasGroup.alpha -= 0.25f * Time.deltaTime;
                if (canvasGroup.alpha == 0)
                {
                    fadeOut = false;
                }
            }
        }
    }
}
