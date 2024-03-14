using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    // Title Screen stuff
    // Also some primitive logic for loading saved progress using this stupid array
    //Also fades to black because I thought it'd be neat

    public string initialScene;
    //Put the scenes in the order you'd like them to be loaded
    public string[] continueScenes;
    public string settingsScene;
    public float fadeDuration;
    public Image screenTransition;

    public AudioSource audioSource;


    void Start()
    {
        //Guarantee that the saved fullscreen settings are reloaded as soon as the game starts
        int currentToggle = PlayerPrefs.GetInt("FullScreen", 1);
        if (currentToggle == 0)
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        }
    }

    public void startGame()
    {
        StartCoroutine(FadeToBlack(initialScene));
    }

    public void continueGame()
    {
        //Get the progress integer and clamp it between 0 and the size of the array in case something's gone wrong

        string continueString = continueScenes[Mathf.Clamp(PlayerPrefs.GetInt("Progress", 0), 0, continueScenes.Length)];
        
        StartCoroutine(FadeToBlack(continueString));

    }

    public void loadSettingsScene()
    {
        StartCoroutine (FadeToBlack(settingsScene));    
    }

    public void exitGame()
    {
        Application.Quit();
    }

    IEnumerator FadeToBlack(string sceneName)
    {
        audioSource.Play();
        screenTransition.gameObject.SetActive(true);
        // Fade from transparent to black
        Time.timeScale = 1f;
        float elapsedTime = 0f;
        Debug.Log(elapsedTime);
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
