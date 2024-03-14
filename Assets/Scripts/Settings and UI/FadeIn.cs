using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    // I only use this in the gameover scene, but you could use it for any other scene that you wanna fade into probably
    

    public Image screenTransition;
    public float gameOverFadeDuration;
    void Start()
    {
        StartCoroutine(UnFadeToBlack());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator UnFadeToBlack()
    {
        // Fade from transparent to black
        float elapsedTime = 0f;
        Color startColor = screenTransition.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 0f); // Set alpha to 1 for black
        while (elapsedTime < gameOverFadeDuration)
        {
            screenTransition.color = Color.Lerp(startColor, targetColor, elapsedTime / gameOverFadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        screenTransition.color = targetColor;
        screenTransition.gameObject.SetActive(false);// Ensure final color is set correctly
    }
}
