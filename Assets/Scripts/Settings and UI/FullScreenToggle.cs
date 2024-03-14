using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullScreenToggle : MonoBehaviour
{
    //Script for toggling fullscreen on and off!
    //Straightforward - just attach it to the fullscreen slider

    Toggle thisToggle;
    void Start()
    {
        thisToggle = GetComponent<Toggle>();

        int currentToggle = PlayerPrefs.GetInt("FullScreen", 1);
        if (currentToggle == 0)
        {
            thisToggle.isOn = false;
        }
        else
        {
            thisToggle.isOn = true;
        }
    }

    public void toggleFullScreen(bool morb)
    {
        if (morb)
        {
            PlayerPrefs.SetInt("FullScreen", 1);
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        }
        else
        {
            PlayerPrefs.SetInt("FullScreen", 0);
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }

    }
}