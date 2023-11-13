using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NebulaDeactivation : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        EventManager.Instance.DispatchSimpleEvent(EventConstants.NebulaDeactivation);
    }
}
