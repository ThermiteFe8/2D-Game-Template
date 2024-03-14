using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSide : MonoBehaviour
{
    // Player Health for sidescroller
    // Stores health, has function for hit invincibility, as well as the invincibility flashing
    //Calls gameController's gameOver when it hits 0 HP
    //Also triggers screenshake just to show off how it works

    public int health;
    public GameController gameController;
    public PlayerControllerSide playerControllerSide;
    public SpriteRenderer playerRenderer;
    AreaChecker areaChecker;
    public bool isInvincible;
    public float invinTimer;
    public float hurtInvinTimeGoal;
    public float flashSpeed;
    public float invinOpacity1;
    public float invinOpacity2;

    private AudioSource hurtAudio;

    private void Start()
    {
        areaChecker = GetComponent<AreaChecker>();
        hurtAudio = GetComponent<AudioSource>();
        isInvincible = false;
    }
    // Update is called once per frame
    void Update()
    {
        playerControllerSide.justHit = areaChecker.justTouched; //Activate the getting hit when you collide with something
        if(areaChecker.justTouched &&!isInvincible)
        {
            takeDamage();
        }

        if (invinTimer < hurtInvinTimeGoal)
        {
            invinTimer += Time.deltaTime;
            if (invinTimer > hurtInvinTimeGoal)
            {
                isInvincible = false;
            }
        }

    }

    void takeDamage()
    {
        health--;
        gameController.shake(0.2f, 1.0f, Vector2.right);
        hurtAudio.Play();
        if (health <= 0 )
        {
            gameController.GameOver();
        }
        else
        {
            playerControllerSide.justHit = true;
            StartCoroutine(StartInvincibility());
        }
    }

    IEnumerator StartInvincibility()
    {
        isInvincible = true;
        invinTimer = 0;

        // Set up a loop for changing opacity periodically
        while (isInvincible)
        {
            // Toggle the visibility by changing the alpha value
            playerRenderer.color = new Color(1f, 1f, 1f, invinOpacity1); // Fully transparent
            yield return new WaitForSeconds(flashSpeed);

            playerRenderer.color = new Color(1f, 1f, 1f, invinOpacity2); // Fully opaque
            yield return new WaitForSeconds(flashSpeed);
        }

        // Reset the sprite opacity when invincibility ends
        playerRenderer.color = new Color(1f, 1f, 1f, 1f); // Fully opaque
    }


}
