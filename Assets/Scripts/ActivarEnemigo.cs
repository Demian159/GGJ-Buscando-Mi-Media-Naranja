using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarEnemigo : MonoBehaviour
{
    private enum TipoEnemigo {Tachuela,  Pelusa, Gusano, Rata, Perro, Polilla};
    [SerializeField] private TipoEnemigo enemigo;
    [SerializeField] private float distanciaActivacion = 2f;
    [SerializeField] private float velocidad = 1;
    [SerializeField] private float tiempoRenderizado = 1f;
    [SerializeField] private float distanciaAtaque = 0.1f;
    [SerializeField] private float limiteAltura = 1f;
    [SerializeField] private float velocidadGusano = 1f;
    [SerializeField] private float tiempoSalirGusano = 3f;
    [SerializeField] private int danioProyectil = 1;
    [SerializeField] private GameObject proyectil;
    [SerializeField] private float velocidadProyectil = 50f;
    Vector2 target;
    private bool activado = false;
    private float momentoActivacion;
    private bool estaActivo = false;
    private float distanciaRespectoJugador;
    private Jugador jugador;
    private Rigidbody2D rb;

    //Crear un script para que en el boss spawneen enemigos a lo tonto
    


    private void Start()
    {
        jugador = FindObjectOfType<Jugador>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ProcesarDistanciaJugador();
        //target = FindObjectOfType<Jugador>().transform.position;
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
            case TipoEnemigo.Gusano:
                ComportamientoGusano();
                break;
            case TipoEnemigo.Rata:
                ComportamientoRata();
                break;
            case TipoEnemigo.Perro:
                ComportamientoPerro();
                break;
            case TipoEnemigo.Polilla:
                ComportamientoPolilla();
                break;
            default:
                break;
        }
    }

    public void Atacar()
    {
        switch (enemigo)
        {
            case TipoEnemigo.Gusano:
                AtacarGusano();
                break;
            case TipoEnemigo.Rata:
                AtacarRata();
                break;
            case TipoEnemigo.Polilla:
                ComportamientoPolilla();
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

    private void ComportamientoPerro()
    {
        //Esto para perro
        //Charlar con equipo para diseñar comportamientos del Prro
        //Aparece pata, araña, se va
        //Aparece cabeza, muerde, c va
        //aparece siempre en posicion relativa al jugador, pero saliendo de un costado
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
        DarVueltaSprite();
        if (distanciaRespectoJugador != 0)
        {
            if (jugador.transform.position.x < transform.position.x)
            {
                rb.velocity = new Vector2(-1f * velocidad, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(+1f * velocidad, rb.velocity.y);
            }
        }  
    }

    private void ComportamientoPolilla()
    {
        if (distanciaRespectoJugador != 0)
        {
            if (jugador.transform.position.x < transform.position.x)
            {
                rb.velocity = new Vector2(-1f * velocidad, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(+1f * velocidad, rb.velocity.y);
            }
            if (jugador.transform.position.y < transform.position.y)
            {
                rb.velocity = new Vector2(rb.velocity.x, -1f * velocidad);
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, +1f * velocidad);
            }
        }
    }

    private void ComportamientoGusano()
    {
        //Esto para manzana
        //Animacion de que sale gusanito
        //Animación de disparo
        //Spawnear proyectil con animation event (ver si hace falta cooldown)
        //repetir
        momentoActivacion = Time.time;
        //activado = true;
        if (!activado)
        {
            StartCoroutine(AtacarGusano());
        }

        float posicionActual = transform.position.y;
    
    }

    private IEnumerator AtacarGusano()
    {
        activado = true;
        while (true)
        {
            target = FindObjectOfType<Jugador>().transform.position;
            rb.velocity = new Vector2(rb.velocity.x, 1f * velocidadGusano);
            yield return new WaitForSeconds(tiempoSalirGusano);
            rb.velocity = new Vector2(0, 0);
            //Disparar
            Debug.Log("Bang!");
            GameObject go = Instantiate(proyectil, this.transform.position, Quaternion.identity);
            go.GetComponent<Proyectil>().danio = danioProyectil;
            go.GetComponent<Proyectil>().esEnemigo = true;
            go.GetComponent<Proyectil>().target = target;
            go.GetComponent<Proyectil>().step = velocidadProyectil * Time.deltaTime;
            //go.GetComponent<Rigidbody2D>().AddForce(new Vector2(target.x, target.y) * velocidadProyectil);
            //go.transform.position = Vector2.MoveTowards(transform.position, target, velocidadProyectil * Time.deltaTime);
            //go.transform.Translate(target * velocidadProyectil);
            rb.velocity = new Vector2(rb.velocity.x, -1f * velocidadGusano);
            yield return new WaitForSeconds(tiempoSalirGusano);
            
        }
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

    private void DarVueltaSprite()
    {
        bool jugadorTieneMovimientoHorizontal = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;

        if (jugadorTieneMovimientoHorizontal)
        {
            transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)), transform.localScale.y);
        }
    }

}
