using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NebulaActivation : MonoBehaviour
{
    private void OnBecameVisible()
    {
        EventManager.Instance.DispatchSimpleEvent(EventConstants.NebulaActivation);
    }
}
