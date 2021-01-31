using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculos : MonoBehaviour
{
    [SerializeField] private int danioACausar = 0;
    private BoxCollider2D boxCol;
    [SerializeField] private AudioClip clipsAudioSonido;

    private void Start()
    {
        boxCol = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<Sfx>().DispararSonido(clipsAudioSonido);
            other.GetComponent<Vida>().PerderLimpieza(danioACausar);
        }
    }
}
