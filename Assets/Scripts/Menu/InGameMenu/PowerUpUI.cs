using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpUI : MonoBehaviour
{
    private float powerUpWeaponDuration;
    private float timer;
    private Image image;
    private ParticleSystem particles;

    private void Start()
    {
        image = GetComponent<Image>();
        particles = GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            ImageFillCalculation();
        }
        else
        {
            ResetPowerUpUI();
            gameObject.SetActive(false);
        }
    }

    private void ImageFillCalculation()
    {
        image.fillAmount = timer/powerUpWeaponDuration;
    }

    public void ResetPowerUpUI()
    {
        timer = powerUpWeaponDuration;
    }

    public void ParticlePlay()
    {
        particles.Play();
    }

    public void ChangeDuration(float duration)
    {
        powerUpWeaponDuration = duration;
    }
}
