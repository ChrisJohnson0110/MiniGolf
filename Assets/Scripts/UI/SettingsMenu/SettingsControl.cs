using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// script to navigate the settings menus
/// </summary>
public class SettingsControl : MonoBehaviour
{
    [Header("Settings menus")]
    [SerializeField] private List<GameObject> settingsMenus;
    [SerializeField] private GameObject defultMenu;
    [SerializeField] private GameObject settingsMenuContainer;
    [Header("Home menus")]
    [SerializeField] private GameObject homeMenuContainer;
    [SerializeField] private GameObject homeMenu;
    private int currentIndex = -1;

    private void Awake()
    {
        if (settingsMenus.Count == 0)
        {
            Debug.Log("No setting menus given");
        }

        defultMenu.SetActive(true);

        //get the index of the defult menu

        int indexCount = 0;

        foreach (GameObject settingsMenu in settingsMenus)
        {
            if (defultMenu == settingsMenu)
            {
                currentIndex = indexCount;
            }
            indexCount++;
        }

        //check we found an index

        if (currentIndex == -1)
        {
            Debug.Log("Defult menu cannot be found within menus");
        }
    }

    private void OnEnable()
    {
        //defultMenu.SetActive(true);

        ////get the index of the defult menu

        //int indexCount = 0;

        //foreach (GameObject settingsMenu in settingsMenus)
        //{
        //    if (defultMenu == settingsMenu)
        //    {
        //        currentIndex = indexCount;
        //    }
        //    indexCount++;
        //}
        
        ////check we found an index

        //if (currentIndex == -1)
        //{
        //    Debug.Log("Defult menu cannot be found within menus");
        //}
    }

    public void NextMenu()
    {
        settingsMenus[currentIndex].SetActive(false);
        currentIndex = (currentIndex + 1) % settingsMenus.Count;
        settingsMenus[currentIndex].SetActive(true);
    }

    public void PreviousMenu()
    {
        settingsMenus[currentIndex].SetActive(false);
        currentIndex = (currentIndex - 1 + settingsMenus.Count) % settingsMenus.Count;
        settingsMenus[currentIndex].SetActive(true);
    }



    public void CloseMenus()
    {
        settingsMenuContainer.SetActive(false);
        if (homeMenuContainer.activeSelf == true)
        {
            homeMenu.SetActive(true);
        }
    }

}
