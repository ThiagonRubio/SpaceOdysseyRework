using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeEffect : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    public bool fadeIn = false;
    public bool fadeOut = false;

    public void showUI()
    {
        fadeIn = true;
    }

    public void hideUI()
    {
        fadeOut = true;
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
