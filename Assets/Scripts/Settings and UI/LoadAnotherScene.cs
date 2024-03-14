using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAnotherScene : MonoBehaviour
{
    //Load another scene - I think I just attach these to buttons
    public string nextScene;
    public void LoadTheScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
