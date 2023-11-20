using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillFacade : MonoBehaviour
{
    [SerializeField] private SkillUI skillUIFacade;

    void Start()
    {
        skillUIFacade.StartFacade();
    }

    public void UpdateSkillUI(string state)
    {
        skillUIFacade.ResetAnimatorBooleans();
        skillUIFacade.ChangeSkillUIState(state);
    }
}