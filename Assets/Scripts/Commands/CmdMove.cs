using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdMove : ICommand
{
    private Rigidbody2D entityRb;
    private Vector2 moveDirection;
    private float moveSpeed;
    private float savedDeltaT;

    public enum MoveType
    {
        AddForce,
        Translate
    }
    private MoveType moveType;

    //----CONSTRUCTOR----
    public CmdMove(Rigidbody2D entityRb, Vector2 moveDirection, float moveSpeed, MoveType moveType, float savedDeltaT)
    {
        this.entityRb = entityRb;
        this.moveDirection = moveDirection;
        this.moveSpeed = moveSpeed;
        this.moveType = moveType;
        this.savedDeltaT = savedDeltaT;
    }

    //----ICOMMAND IMP.----
    public void Execute()
    {
        if (moveType == MoveType.AddForce)
        {
            entityRb.AddForce(moveDirection * moveSpeed * savedDeltaT);
        }
        else if (moveType == MoveType.Translate)
        {
            entityRb.transform.position += (Vector3)moveDirection * moveSpeed * savedDeltaT;
        }
    }
}
