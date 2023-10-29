using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Asteroid : Enemy
{
    private int _rotationSpeed;
    [SerializeField] private int rotationSpeedMin;
    [SerializeField] private int rotationSpeedMax;
    
    protected override void Start()
    {
        base.Start();
        DefineRotation();
    }

    private void Update()
    {
        Move();
        Rotate();
    }

    private void DefineRotation()
    {
        _rotationSpeed = Random.Range(rotationSpeedMin, rotationSpeedMax);
    }
    
    public override void Move()
    {
        EntityCommandEventQueue.AddCommandToQueue(CmdMoveLeft, CommandEventQueue.UpdateFilter.Fixed);
    }

    private void Rotate()
    {
        gameObject.transform.Rotate(0, 0, _rotationSpeed * Time.deltaTime);
    }
}
