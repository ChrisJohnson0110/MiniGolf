using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingPowerController : MonoBehaviour
{
    public float minPower = 5f;
    public float maxPower = 30f;
    public float powerStep = 0.5f;
    public float CurrentPower { get; private set; }

    void Start()
    {
        CurrentPower = minPower;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            CurrentPower = Mathf.Min(CurrentPower + powerStep * Time.deltaTime, maxPower);

        if (Input.GetKey(KeyCode.S))
            CurrentPower = Mathf.Max(CurrentPower - powerStep * Time.deltaTime, minPower);
    }
}