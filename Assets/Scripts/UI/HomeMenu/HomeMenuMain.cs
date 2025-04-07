using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeMenuMain : MonoBehaviour
{
    [SerializeField] private GameObject GameUI;
    [SerializeField] private Menus menuReference;

    public void SinglePlayer()
    {
        menuReference.HideAllMenus();
        menuReference.HomeMenuContainer.SetActive(false);
        //load game scene
        GameUI.SetActive(true);
    }

    public void MultiPlayer()
    {
        menuReference.HideAllMenus();
        menuReference.HomeMenuContainer.SetActive(false);
        //call lobby function
        GameUI.SetActive(true); //temp to see button works
    }

    public void ExitApplication()
    {
        Application.Quit();
        Debug.Log("Application.Quit()");
    }
}
