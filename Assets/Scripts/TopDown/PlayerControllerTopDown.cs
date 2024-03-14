using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTopDown : MonoBehaviour
{
    // PlayerController for top down gaming
    //It's pretty much just movement - interact doesn't do anything on here
    //I do have simple animation logic so that's neat
    public UserInput userInput;
    Rigidbody2D rb;
    public AreaChecker floorChecker;
    public Animator playerAnimator;
    public SpriteRenderer playerSprite;


    public float walkSpeed;
   
    public bool isMoving;
    public bool facingUp;
    public bool justHit;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        MovementHandler();
  
        AnimHandler();

        if(justHit)
        {
            justHit = false;
        }

        
    }

    void MovementHandler()
    {
        float xSpeed = userInput.MoveInput.x;
        float ySpeed = userInput.MoveInput.y;
        
        xSpeed = xSpeed * walkSpeed;
        ySpeed = ySpeed * walkSpeed;

        //Flip Sprite if the player's going left
        if(xSpeed > 0.01f)
        {
            playerSprite.flipX = false;
        }
        else if(xSpeed < -0.01f)
        {
            playerSprite.flipX = true;
        }
        //Toggle facingUp based on Y movement so we can have the funny back facing sprites
        if(ySpeed > 0.01f)
        {
            facingUp = true;
        }
        else if(ySpeed < -0.01f)
        {
            facingUp = false;
        }

        isMoving = false;
        if (Mathf.Abs(xSpeed) + Mathf.Abs(ySpeed) > 0)
            isMoving = true;

        rb.velocity = new Vector2(xSpeed, ySpeed);
    }


    void AnimHandler()
    {
        //playerAnimator.SetBool("IsGrounded", floorChecker.isTouching);
        playerAnimator.SetBool("IsMoving", isMoving);
        playerAnimator.SetBool("FacingUp", facingUp);
    }
}
