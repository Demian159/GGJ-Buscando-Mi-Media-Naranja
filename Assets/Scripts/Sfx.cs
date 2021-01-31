using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sfx : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void DispararSonido(AudioClip audioToShoot)
    {
            audioSource.PlayOneShot(audioToShoot);
    }
}
