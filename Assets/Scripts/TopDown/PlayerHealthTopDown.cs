using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthTopDown : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    public GameController gameController;
    public PlayerControllerTopDown playerControllerTopDown;
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
        isInvincible = false;
        hurtAudio = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        playerControllerTopDown.justHit = areaChecker.justTouched;
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
        hurtAudio.Play();
        gameController.shake(0.2f, 1.0f, Vector2.right);
        if(health <= 0 )
        {
            gameController.GameOver();
        }
        else
        {
            playerControllerTopDown.justHit = true;
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
