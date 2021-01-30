using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public bool esEnemigo = false;
    public int danio; //se le pone desde el que lo instancia
    [SerializeField] private float tiempoDestruccion = 3f;
    public Vector2 target;
    public float step;

    void Start()
    {
        Destroy(gameObject, tiempoDestruccion);
        if (esEnemigo)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }


    void Update()
    {
        if (esEnemigo)
        {
            DisparoAJugador();
        }
    }

    private void DisparoAJugador()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, step);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (esEnemigo)
        {
            if (other.tag == "Player")
            {
                Destroy(gameObject);
                other.GetComponent<Vida>().PerderLimpieza(danio);
            }
        }
        else
        {
            if (other.tag == "Enemigo")
            {
                Destroy(gameObject);
                other.GetComponent<VidaEnemigo>().PerderVida(danio);
            }
        }
    }
}
