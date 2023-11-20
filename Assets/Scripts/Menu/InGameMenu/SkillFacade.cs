using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillFacade : MonoBehaviour
{
    [SerializeField] private SkillUI _skillUIFacade;

    void Start()
    {
        _skillUIFacade.StartFacade();
    }

    void Update()
    {
        _skillUIFacade.UpdateFacade();
    }
}