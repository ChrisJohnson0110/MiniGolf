using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBarUI : MonoBehaviour
{
    public SwingPowerController powerController;
    public Slider powerSlider;

    void Start()
    {
        powerSlider.minValue = powerController.minPower;
        powerSlider.maxValue = powerController.maxPower;
    }

    void Update()
    {
        powerSlider.value = powerController.CurrentPower;
    }
}