using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUIFacade : MonoBehaviour
{
    public PlayerSavedStats playerSavedStats;
    public PlayerController playerController;
    [SerializeField] GameObject player;
    public Animator animator;
    public ParticleSystem skillParticles;

    public void StartFacade()
    {
        var main = skillParticles.main;
        main.duration = playerSavedStats.SkillDuration - (playerSavedStats.SkillDuration * 0.3f);
    }

    public void UpdateFacade()
    {
        animator.SetBool("active", false);
        animator.SetBool("available", false);
        animator.SetBool("cooldown", false);

        if (playerController.IsSkillActive == true)
        {
            if (!skillParticles.isPlaying)
            {
                skillParticles.Play();
                Debug.Log("particles playing");
            }
            if (animator.GetBool("active") == false)
            {
                animator.SetBool("active", true);
            }
        }

        if (playerController.IsSkillInCooldown == false)
        {
            if (animator.GetBool("available") == false)
            {
                animator.SetBool("available", true);
            }
        }

        if (playerController.IsSkillInCooldown == true)
        {
            if (animator.GetBool("cooldown") == false)
            {
                animator.SetBool("cooldown", true);
            }
        }
    }
}

