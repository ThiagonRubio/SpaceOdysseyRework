using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdMove : ICommand
{
    private Rigidbody2D entityRb;
    private Vector2 moveDirection;
    private float moveSpeed;

    public enum MoveType
    {
        AddForce,
        Translate
    }
    private MoveType moveType;

    //----CONSTRUCTOR----
    public CmdMove(Rigidbody2D entityRb, Vector2 moveDirection, float moveSpeed, MoveType moveType)
    {
        this.entityRb = entityRb;
        this.moveDirection = moveDirection;
        this.moveSpeed = moveSpeed;
        this.moveType = moveType;
    }

    //----ICOMMAND IMP.----
    public void Execute()
    {
        if (moveType == MoveType.AddForce)
        {
            entityRb.AddForce(moveDirection * moveSpeed * Time.deltaTime);
        }
        else if (moveType == MoveType.Translate)
        {
            entityRb.transform.position += (Vector3)moveDirection * moveSpeed * Time.deltaTime;
        }
    }
}
