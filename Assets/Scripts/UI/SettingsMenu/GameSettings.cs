using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings
{
    public float volume;
    public GraphicsQuality graphics;

    public enum GraphicsQuality 
    { 
        Low,
        Medium,
        High
    }

}
