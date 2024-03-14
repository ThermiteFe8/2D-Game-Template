using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenShakeController : MonoBehaviour
{
    //Controls screenshake intensity
    //I wasn't gonna have this but having players throw up from too much screenshake's no good
    GameController gameController;
    Slider slider;
    void Start()
    {
        //Set the shakeintensity stored in the GameController and then apply it to the slider to avoid jamk
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        slider = GetComponent<Slider>();
        float storedSlow = PlayerPrefs.GetFloat("ScreenShakeAmount");
        if (storedSlow > 0)
        {
            slider.value = storedSlow;
            gameController.globalShakeIntensity = storedSlow;
        }
        else
        {
            slider.value = 1.0f;
            gameController.globalShakeIntensity = 1.0f;
        }
    }

    public void updateShake(float value)
    {
        PlayerPrefs.SetFloat("ScreenShakeAmount", value);
        gameController.globalShakeIntensity = value;
    }
}