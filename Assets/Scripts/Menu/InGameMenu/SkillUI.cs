using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUI : MonoBehaviour
{
    [SerializeField] private SkillUIFacade _skillUIFacade;

    void Start()
    {
        _skillUIFacade.StartFacade();
    }

    void Update()
    {
        _skillUIFacade.UpdateFacade();
    }
}
