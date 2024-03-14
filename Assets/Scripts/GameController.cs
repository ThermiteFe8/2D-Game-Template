using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //GameController! Controls the...game. Handles stuff like ScreenShake and fading.
    //They also handle pausing. Also disables the player input.
    //If I've done it right, ther pause menu should also be a child of this?
    //If I've done it wrong, everything explodes, so that's not great


    public bool isPaused = false;
    public GameObject pauseMenu;
    public string GameOverScene;
    public string nextScene;
    public GameObject MainCamera; //The Camera GameObject
    private Transform cameraItself; //Transform of the camera
    public Image screenTransition;
    public float fadeDuration;
    PlayerInput input;
    

    public float globalShakeIntensity = 1.0f;
    public Vector3 originalPosition = new Vector3(0, 0, 0); //Original position of the camera to fix screensahke shenanigans


    public bool lockPause = false;


    void Start()
    {
        input = GetComponent<PlayerInput>(); //There should be a PlayerInput 
        float storedShake = PlayerPrefs.GetFloat("ScreenShakeAmount", 1.0f); //Load the stored screenshake intensity
        globalShakeIntensity = storedShake; 
        cameraItself = MainCamera.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            togglePause();
        }

        if(lockPause) //This stuff's almost exclusively for the settings scene tbh
        {
            isPaused = true;
            Time.timeScale = 0.0f;
            input.enabled = false;

        }
    }


    //The idea's that you can call this method from any other script. The player can do it when they get hit, for example
    public void shake(float shakeDuration, float shakeMagnitude, Vector3 shakeDirection)
    {
        StartCoroutine(ShakeCoroutine(shakeDuration, shakeMagnitude, shakeDirection));
    }

    public IEnumerator ShakeCoroutine(float shakeDuration, float shakeMagnitude, Vector3 shakeDirection)
    {
        float elapsedTime = 0f;
        //shakeDirection = Vector3.up;
        // Shake the camera for the specified duration
        while (elapsedTime < shakeDuration)
        {
            // Calculate a random position offset within the shake magnitude along the specified direction
            Vector3 randomOffset = Random.insideUnitSphere * shakeMagnitude * globalShakeIntensity;

            // Apply the offset to the camera's position
            cameraItself.localPosition = originalPosition + Vector3.Scale(shakeDirection.normalized, randomOffset);
            ;

            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // Reset the camera position after shaking
        cameraItself.localPosition = originalPosition;
        //Debug.Log("Reset Position");
    }


    //There was probably a less stupid way to code this, but this works.
    public void togglePause()
    {
        isPaused = !isPaused;
        pauseMenu.SetActive(isPaused);

        if(isPaused)
        {
            Time.timeScale = 0.0f;
            input.enabled = false;
        }
        else
        {
            Time.timeScale = 1.0f;
            input.enabled = true;
        }


    }

    
    public void GameOver()
    {
        StartCoroutine(FadeToBlack(GameOverScene));
    }

    public void NextLevel()
    {
        StartCoroutine(FadeToBlack(nextScene));
    }

    IEnumerator FadeToBlack(string sceneName)
    {
        screenTransition.gameObject.SetActive(true);
        // Fade from transparent to black
        Time.timeScale = 1f;
        float elapsedTime = 0f;
        Color startColor = screenTransition.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 1f); // Set alpha to 1 for black
        while (elapsedTime < fadeDuration)
        {
            screenTransition.color = Color.Lerp(startColor, targetColor, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        screenTransition.color = targetColor;
        // screenTransition.gameObject.SetActive(false);// Ensure final color is set correctly
        SceneManager.LoadScene(sceneName);
    }

}
