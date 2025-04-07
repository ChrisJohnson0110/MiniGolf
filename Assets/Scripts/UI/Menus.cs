using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    [SerializeField] public GameObject HomeMenuContainer;
    [SerializeField] public List<GameObject> menus;
    [SerializeField] private GameObject defaultMenu;
    [SerializeField] private GameObject homeMenu;
    [SerializeField] private GameObject settingsMenu;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            HomeMenuContainer.SetActive(true);
        }
        else
        {
            HomeMenuContainer.SetActive(false);
        }

        HideAllMenus();

        defaultMenu.SetActive(true);
    }

    public void SettingsButton()
    {
        if (settingsMenu.activeSelf == true)
        {
            settingsMenu.SetActive(false);
            homeMenu.SetActive(true);
        }
        else
        {
            HideAllMenus();
            settingsMenu.SetActive(true);
        }
    }

    public void HideAllMenus()
    {
        foreach (GameObject menu in menus)
        {
            menu.SetActive(false);
        }
    }

}
