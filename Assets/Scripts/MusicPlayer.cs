using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] private bool isSfx = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (isSfx)
        {
            audioSource.volume = PlayerPrefsController.GetSfxVolume();
        }
        else
        {
            audioSource.volume = PlayerPrefsController.GetMasterVolume();
        }   
    }

    public void SetVolume(float volume)
    {
        Debug.Log("Llamado");
        audioSource.volume = volume;
    }
}
