using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenNewPanel : MonoBehaviour
{
    //Just used in the pause menu for opening other panels properly
    public GameObject nextPanel;
    public GameObject currentPanel;
    public  void OpenPanel()
    {
        nextPanel.SetActive(true);
        currentPanel.SetActive(false);
    }
}
