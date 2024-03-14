using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerSide : MonoBehaviour
{
    // PlayerController for SideScroller
    //Uses the UserInput thing as well as a rigidbody for all these shenanigans.
    //Also has variable jump height just because that felt like a good thing to have
    public UserInput userInput;
    Rigidbody2D rb;
    public AreaChecker floorChecker;
    public Animator playerAnimator;
    public SpriteRenderer playerSprite;


    public float walkSpeed;
    public float jumpForce;
    public float jumpHoldTimer;
    public float jumpHoldTimeMax;
    public float jumpHoldForce;

    public float knockbackForce;
    public float knockbackLockMax;
    public float knockbackLockTimer;

    public bool isJumping;
    public bool isMoving;
    public bool justHit;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpHoldTimer = 0f;
        knockbackLockTimer = knockbackLockMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (knockbackLockTimer < knockbackLockMax) //Lock the player's horizontal movement while the player's getting knocked back
        {
            knockbackLockTimer += Time.deltaTime; 
        }
        else
        {
            MovementHandler();
        }
        

        if(userInput.InteractJustPressed) 
        {
            JumpHandler();
        }
        if ((isJumping && userInput.InteractHeld))
        {
            JumpHoldHandler();
        }
        else
        {
            isJumping = false;
        }

        AnimHandler();//Does stuff with the animation controller

        if(justHit)//Handles the player getting hit
        {
            justHit = false;
            Knockback();
        }

        
    }

    void MovementHandler()
    {
        float xSpeed = userInput.MoveInput.x;
        
        xSpeed = xSpeed * walkSpeed;

        //Flip the sprite if the player's going to the left
        if(xSpeed > 0.01f)
        {
            playerSprite.flipX = false;
        }
        else if(xSpeed < -0.01f)
        {
            playerSprite.flipX = true;
        }

        isMoving = false;

        if (Mathf.Abs(xSpeed) > 0)
            isMoving = true;
        //Apply the speed to the rigidbody
        rb.velocity = new Vector2(xSpeed, rb.velocity.y);
    }

    void JumpHandler()
    {
        if(floorChecker.isTouching)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = true;
            jumpHoldTimer = 0f;
        }
    }

    void JumpHoldHandler()
    {
        if (jumpHoldTimer < jumpHoldTimeMax) // Limit the maximum jump duration
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHoldForce);
            jumpHoldTimer += Time.deltaTime;
        }
        else
        {
            isJumping = false;
        }
    }

    void AnimHandler()
    {
        //Set the bools properly for the Animation Controller
        playerAnimator.SetBool("IsGrounded", floorChecker.isTouching);
        playerAnimator.SetBool("IsMoving", isMoving);
        playerAnimator.SetBool("IsJumping", isJumping);
    }

    void Knockback()
    {
        float knockbackForceX = knockbackForce;
        if(!playerSprite.flipX)
        {
            knockbackForceX = knockbackForceX * -1;
        }
        rb.velocity = new Vector2(knockbackForceX, knockbackForce);
        knockbackLockTimer = 0f;
    }

}
