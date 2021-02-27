using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] private bool isSfx = false;
    [SerializeField] private bool isDelayed = false;
    [SerializeField] private float delayTime = 5f;

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

        if (isDelayed)
        {
            audioSource.playOnAwake = false;
            StartCoroutine(DelayedAudio());
        }
    }

    private IEnumerator DelayedAudio()
    {
        yield return new WaitForSeconds(delayTime);
        audioSource.loop = true;
        audioSource.Play();
    }

    public void SetVolume(float volume)
    {
        Debug.Log("Llamado");
        audioSource.volume = volume;
    }
}
