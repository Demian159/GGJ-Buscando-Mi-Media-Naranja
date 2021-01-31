using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sfx : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    public void DispararSonido(AudioClip audioToShoot)
    {
            audioSource.PlayOneShot(audioToShoot);
    }
}
