using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class Audiomixerscript : MonoBehaviour
{
    // AudioMixing stuff - for separating SFX and Music into different categories and also having a master volume slider
    //You can attach this to the gamecontroller and than assign the appropriate methods to each Slider
    //Goes from -80 to like 5 or 10 because that's how audio sliders be

    //Assign the mixer groups
    public AudioMixerGroup master;
    public AudioMixerGroup SFX;
    public AudioMixerGroup music;

    // Assign the sliders
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider SFXSlider;

    private void Start()
    {
        float masterFloat = PlayerPrefs.GetFloat("Master Volume", -4f);
        float SFXFloat = PlayerPrefs.GetFloat("SFX Volume", -4f);
        float musicFloat = PlayerPrefs.GetFloat("Music Volume", -18f);

        masterSlider.value = masterFloat;
        musicSlider.value = musicFloat;
        SFXSlider.value = SFXFloat;

        master.audioMixer.SetFloat("Master Volume", masterFloat);
        master.audioMixer.SetFloat("SFX Volume", SFXFloat);
        master.audioMixer.SetFloat("Music Volume", musicFloat);
    }

    public void updateMasterVolume(float value)
    {
        master.audioMixer.SetFloat("Master Volume", value);
        PlayerPrefs.SetFloat("Master Volume", value);
    }

    public void updateSFXVolume(float value)
    {
        master.audioMixer.SetFloat("SFX Volume", value);
        PlayerPrefs.SetFloat("SFX Volume", value);
    }

    public void updateMusicVolume(float value)
    {
        master.audioMixer.SetFloat("Music Volume", value);
        PlayerPrefs.SetFloat("Music Volume", value);
    }
}