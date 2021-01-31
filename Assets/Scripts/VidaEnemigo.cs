using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    [SerializeField] private int vida = 5;
    [SerializeField] private bool esBoss = false;
    [SerializeField] private AudioClip clipsAudioMuerte;
    [SerializeField] private AudioClip clipsAudioAtaque;
    [SerializeField] private AudioClip clipsAudioSonido;
    public enum TipoEnemigo { Tachuela, Pelusa, Gusano, Rata, Perro, Polilla };
    public TipoEnemigo enemigo;

    void Update()
    {
        if (vida <= 0)
        {
            if (esBoss)
            {
                FindObjectOfType<TransicionNiveles>().BossMurio();
            }
            RuidoMuerte();
            Destroy(gameObject);
        }
    }

    private void RuidoMuerte()
    {
        FindObjectOfType<Sfx>().DispararSonido(clipsAudioMuerte);
    }

    public void PerderVida(int danio)
    {
        vida -= danio;
    }

    
}
