using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncAudioSource : MonoBehaviour
{
    private void Awake()
    {
        gameObject.GetComponent<AudioSource>().volume = GameObject.FindObjectOfType<SettingsMenu>().gameSettings.volume;
    }
}
