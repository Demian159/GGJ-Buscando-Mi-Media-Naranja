using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    [SerializeField] private int vida = 5;
    [SerializeField] private bool esBoss = false;
    /*[SerializeField] private AudioClip clipMuertePolilla;
    public enum TipoEnemigo { Tachuela, Pelusa, Gusano, Rata, Perro, Polilla };
    public TipoEnemigo enemigo;*/

    void Update()
    {
        if (vida <= 0)
        {
            if (esBoss)
            {
                FindObjectOfType<TransicionNiveles>().BossMurio();
            }
            //RuidoMuerte();
            Destroy(gameObject);
        }
    }

    /*private void RuidoMuerte()
    {
        AudioClip audioASonar = null;
        switch (enemigo)
        {
            case TipoEnemigo.Tachuela:
                break;
            case TipoEnemigo.Pelusa:
                audioASonar = clipMuertePolilla;
                    break;
            case TipoEnemigo.Gusano:
                break;
            case TipoEnemigo.Rata:
                break;
            case TipoEnemigo.Perro:
                break;
            case TipoEnemigo.Polilla:
                break;
            default:
                break;
        }
        FindObjectOfType<Sfx>().DispararSonido(audioASonar);
    }*/

    public void PerderVida(int danio)
    {
        vida -= danio;
        Debug.Log("OlaQhacePruebaOqHace");
    }

    
}
