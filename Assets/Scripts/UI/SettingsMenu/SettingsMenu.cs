using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public GameSettings gameSettings = new GameSettings();
    public PlayerSettings playerSettings = new PlayerSettings();

    //UI elements reference

    //Audio
    [SerializeField] private Slider volumeSlider;

    //Graphics

    //Player
    [SerializeField] private TMP_InputField playerNameInput;

    #region Audio

    public void VolumeSlider()
    {
        gameSettings.volume = volumeSlider.value;
    }

    #endregion

    #region Graphics

    public void GraphicsLow()
    {
        gameSettings.graphics = GameSettings.GraphicsQuality.Low;
    }

    public void GraphicsMedium()
    {
        gameSettings.graphics = GameSettings.GraphicsQuality.Medium;
    }

    public void GraphicsHigh()
    {
        gameSettings.graphics = GameSettings.GraphicsQuality.High;
    }

    #endregion

    #region Player

    public void SetPlayerName()
    {
        playerSettings.playerName = playerNameInput.text;
    }

    #endregion


}
