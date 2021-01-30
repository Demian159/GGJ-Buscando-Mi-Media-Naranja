using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    [SerializeField] private bool esEnemigo = false;
    public int danio; //se le pone desde el que lo instancia
    [SerializeField] private float tiempoDestruccion = 3f;

    void Start()
    {
        Destroy(gameObject, tiempoDestruccion);
    }


    void Update()
    {
        
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
                //other.GetComponent<VidaEnemigo>().PerderVida(danio);
            }
        }
    }
}
