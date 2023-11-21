using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUI : MonoBehaviour
{
    [SerializeField] private PlayerSavedStats playerSavedStats;
    private Animator _animator;
    [SerializeField] private ParticleSystem _skillParticles;
    [SerializeField] private float timeReducedFromParticleDuration;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void StartFacade()
    {
        var main = _skillParticles.main;
        main.duration = playerSavedStats.SkillDuration - timeReducedFromParticleDuration;
    }

    public void ResetAnimatorBooleans()
    {
        _animator.SetBool(AnimationConstants.SkillActive, false);
        _animator.SetBool(AnimationConstants.SkillAvailable, false);
        _animator.SetBool(AnimationConstants.SkillInCooldown, false);
    }
    
    public void ChangeSkillUIState(string state)
    {
        switch (state)
        {
            case AnimationConstants.SkillActive:
                if (!_skillParticles.isPlaying)
                {
                    _skillParticles.Play();
                }
                if (_animator.GetBool(state) == false)
                {
                    _animator.SetBool(state, true);
                }
                break;
            case AnimationConstants.SkillAvailable:
                if (_animator.GetBool(state) == false)
                {
                    _animator.SetBool(state, true);
                }
                break;
            case AnimationConstants.SkillInCooldown:
                if (_animator.GetBool(state) == false)
                {
                    _animator.SetBool(state, true);
                }
                break;
        }
    }
}

