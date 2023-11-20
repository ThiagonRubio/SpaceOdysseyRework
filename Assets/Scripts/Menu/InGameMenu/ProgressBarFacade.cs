using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProgressBarFacade : MonoBehaviour
{

    [SerializeField] ProgressBarUI _progressBarFacade;
    private void Start()
    {
        _progressBarFacade.ProgressBarStart();
    }
}
