using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAnimationEvents : MonoBehaviour
{
    public void OnExplosionEnded()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }
}
