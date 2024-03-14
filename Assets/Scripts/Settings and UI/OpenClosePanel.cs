using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class OpenClosePanel : MonoBehaviour
{
    //Lets people navigate the pause menus competently with a keyboard or controller
    //Just highlights whatever you've put into firstButton when this panel gets loaded
    //Oh yeah you'd better attach this to a UI panel or smthn

    public GameObject firstButton;
    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(firstButton);
    }
}
