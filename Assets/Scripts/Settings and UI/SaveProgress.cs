using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveProgress : MonoBehaviour
{
    // Part of the primitive progress saving system
    //I normally just enable the saveOnLoad thing so that as soon as you enter a scene, it gets "saved"

    public int progress;
    public bool saveOnLoad = false;
    void Start()
    {
        if(saveOnLoad)
            SaveProgressNow();
    }

    // Update is called once per frame
    public void SaveProgressNow()
    {
        PlayerPrefs.SetInt("Progress", progress);
    }
}
