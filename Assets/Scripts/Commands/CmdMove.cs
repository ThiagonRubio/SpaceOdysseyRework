using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdMove : ICommand
{
    private Rigidbody2D entityRb;
    private Vector2 moveDirection;
    private float moveSpeed;

    //----CONSTRUCTOR----
    public CmdMove(Rigidbody2D entityRb, Vector2 moveDirection, float moveSpeed)
    {
        this.entityRb = entityRb;
        this.moveDirection = moveDirection;
        this.moveSpeed = moveSpeed;
    }

    //----ICOMMAND IMP.----
    public void Do()
    {
        entityRb.AddForce(moveDirection * moveSpeed * Time.deltaTime);
    }
}
