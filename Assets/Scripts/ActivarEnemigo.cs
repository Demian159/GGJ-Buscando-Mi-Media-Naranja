using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarEnemigo : MonoBehaviour
{
    private enum TipoEnemigo {Tachuela,  Pelusa, Manzana, Rata, Perro};
    [SerializeField] private TipoEnemigo enemigo;
    [SerializeField] private float distanciaActivacion = 2f;
    private bool estaActivo = false;
    private float distanciaRespectoJugador;
    private Jugador jugador;

    private void Start()
    {
        jugador = FindObjectOfType<Jugador>();
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
        Debug.Log("Me muevo!");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 0, 255f, 0.5f);
        Gizmos.DrawWireSphere(transform.position, distanciaActivacion);
    }
}
