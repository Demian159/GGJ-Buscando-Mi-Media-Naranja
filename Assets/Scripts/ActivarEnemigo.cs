using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarEnemigo : MonoBehaviour
{
    private enum TipoEnemigo {Tachuela,  Pelusa, Manzana, Rata, Perro};
    [SerializeField] private TipoEnemigo enemigo;
    [SerializeField] private float distanciaActivacion = 2f;
    [SerializeField] private float velocidad = 1;
    [SerializeField] private float tiempoRenderizado = 1f;
    [SerializeField] private float distanciaAtaque = 0.1f;
    private float momentoActivacion;
    private bool estaActivo = false;
    private float distanciaRespectoJugador;
    private Jugador jugador;
    private Rigidbody2D rb;

    //probando
    


    private void Start()
    {
        jugador = FindObjectOfType<Jugador>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ProcesarDistanciaJugador();
    }

    private void ProcesarDistanciaJugador()
    {
        distanciaRespectoJugador = Vector2.Distance(jugador.transform.position, transform.position);
        estaActivo = distanciaRespectoJugador < distanciaActivacion;
        if (distanciaRespectoJugador < distanciaActivacion)
        {
            Activar();
        }
        else if (distanciaRespectoJugador < distanciaAtaque)
        {
            Atacar();
        }
    }

    public void Activar()
    {
        switch (enemigo)
        {
            case TipoEnemigo.Tachuela:
                break;
            case TipoEnemigo.Pelusa:
                ComportamientoPelusa();
                break;
            case TipoEnemigo.Manzana:
                ComportamientoManzana();
                break;
            case TipoEnemigo.Rata:
                ComportamientoRata();
                break;
            case TipoEnemigo.Perro:
                ComportamientoPerro();
                break;
            default:
                break;
        }
    }
    public void Atacar()
    {
        switch (enemigo)
        {
            case TipoEnemigo.Manzana:
                AtacarManzana();
                break;
            case TipoEnemigo.Rata:
                AtacarRata();
                break;
            case TipoEnemigo.Perro:
                AtacarPerro();
                break;
            default:
                break;
        }
    }

    private void AtacarPerro()
    {
        throw new NotImplementedException();
    }

    private void AtacarRata()
    {
        throw new NotImplementedException();
    }

    private void AtacarManzana()
    {
        throw new NotImplementedException();
    }

    private void ComportamientoPerro()
    {
        //Esto para perro
        //Charlar con equipo para diseñar comportamientos del Prro
        throw new NotImplementedException();
    }

    private void ComportamientoRata()
    {
        //Esto para Rata
        //ir hacia el jugador
        //procesar cuando estás lo suficientemente cerca
        //atacar si estas en radio de ataque HASTA ACÁ ADRIAN
        //disparar metodo de player para recibir daño en base a un animation event
        //cooldown (puede que no sea necesario porque la animación en sí funciona como cooldown)
        //repetir
        if (distanciaRespectoJugador != 0)
        {
            if (jugador.transform.position.x < transform.position.x)
            {
                rb.velocity = new Vector2(-1f * velocidad, 0);
            }
            else
            {
                rb.velocity = new Vector2(+1f * velocidad, 0);
            }
        }  
    }

    private void ComportamientoManzana()
    {
        //Esto para manzana
        //Animacion de que sale gusanito
        //Animación de disparo
        //Spawnear proyectil con animation event (ver si hace falta cooldown)
        //repetir
    }

    private void ComportamientoPelusa()
    {
        //Esto para Pelusa
        //Ir hacia el jugador, pero pasar de largo
        //Autodestruirse cdo ya está fuera de visión (o después de cierto tiempo)
        rb.velocity = new Vector2(-1f * velocidad,0);
        momentoActivacion = Time.time;
        Destroy(gameObject, momentoActivacion + tiempoRenderizado);
        Debug.Log("Me muevo!");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 0, 255f, 0.5f);
        Gizmos.DrawWireSphere(transform.position, distanciaActivacion);
    }
}
