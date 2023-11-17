using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{

    [SerializeField] ProgressBarFacade _progressBarFacade;
    private void Start()
    {
        _progressBarFacade.ProgressBarStart();
    }
}
