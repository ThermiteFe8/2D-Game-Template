using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSceneOnTouch : MonoBehaviour
{
    // Take the GameController and load the next scene when you touch this object
    
    public GameController Controller;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Controller.NextLevel();
    }
}
