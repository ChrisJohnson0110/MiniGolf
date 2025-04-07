using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Settings GameSettings = new Settings();

    //UI elements reference

    //Audio
    [SerializeField] private Slider volumeSlider;

    //Graphics


    //Audio

    public void VolumeSlider()
    {
        GameSettings.volume = volumeSlider.value;
    }

    //Graphics

    public void GraphicsLow()
    {
        GameSettings.graphics = Settings.GraphicsQuality.Low;
    }

    public void GraphicsMedium()
    {
        GameSettings.graphics = Settings.GraphicsQuality.Medium;
    }

    public void GraphicsHigh()
    {
        GameSettings.graphics = Settings.GraphicsQuality.High;
    }
}
