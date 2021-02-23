using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarEnemigo : MonoBehaviour
{
    public enum TipoEnemigo {Tachuela,  Pelusa, Gusano, Rata, Perro, Polilla};
    public TipoEnemigo enemigo;
    public float distanciaActivacion = 0f;
    public float velocidad = 0;
    [SerializeField] private float tiempoRenderizado = 1f;
    [SerializeField] private float distanciaAtaque = 0.1f;
    [SerializeField] private float limiteAltura = 1f;
    [SerializeField] private float velocidadGusano = 1f;
    [SerializeField] private float tiempoSalirGusano = 3f;
    [SerializeField] private int danioProyectil = 1;
    [SerializeField] private GameObject proyectil;
    [SerializeField] private float velocidadProyectil = 50f;
    [Tooltip("Si el jugador está a la izquierda, setear esto en -1, si está a la derecha, setearlo en 1")]
    [Range(-1, 1)] public int direccionMovimiento = -1;
    bool isDirectionSet = false;
    Vector2 target;
    private bool activado = false;
    private float momentoActivacion;
    private bool estaActivo = false;
    private float distanciaRespectoJugador;
    private Jugador jugador;
    private Rigidbody2D rb;
    [HideInInspector] public bool vieneDeSpawner = false;
    [SerializeField] private AudioClip clipsAudioSonido;

    private void Start()
    {
        jugador = FindObjectOfType<Jugador>();
        rb = GetComponent<Rigidbody2D>();
        /*if (vieneDeSpawner && enemigo == TipoEnemigo.Gusano)
        {
            Destroy(gameObject, 6f);
        }*/
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
                break;
            case TipoEnemigo.Polilla:
                ComportamientoPolilla();
                break;
            case TipoEnemigo.Perro:
                break;
            default:
                break;
        }
    }

    private void ComportamientoRata()
    {
        if (!activado)
        {
            activado = true;
            GetComponent<Animator>().SetTrigger("caminar");
        }     
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
        else if (distanciaRespectoJugador == 0) //esto para que la rata no te empuje. TODO ver si no da problemas
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
    }

    private void ComportamientoPolilla()
    {
        if (!activado)
        {
            activado = true;
            GetComponent<Animator>().SetTrigger("volar");
        }
        FindObjectOfType<Sfx>().DispararSonido(clipsAudioSonido);
        DarVueltaSprite(); //TODO ver si funciona correctamente o al revés como con la rata. En ese caso, habrá que ver de pasarle un param para ajustar ese error
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
        else if (distanciaRespectoJugador == 0) //esto para que la polilla no te empuje. TODO ver si no da problemas
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
    }

    private void ComportamientoGusano()
    {
        momentoActivacion = Time.time;
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
            GetComponent<Animator>().SetTrigger("atacar");
            yield return new WaitForSeconds(tiempoSalirGusano);

        }
    }

    public void DispararGusano()
    {
        GameObject go = Instantiate(proyectil, this.transform.position, Quaternion.identity);
        go.GetComponent<Proyectil>().danio = danioProyectil;
        go.GetComponent<Proyectil>().esEnemigo = true;
        go.GetComponent<Proyectil>().target = target;
        go.GetComponent<Proyectil>().step = velocidadProyectil * Time.deltaTime;
        rb.velocity = new Vector2(rb.velocity.x, -1f * velocidadGusano);
    }

    private void ComportamientoPelusa()
    {

        if (jugador.transform.position.x < transform.position.x && isDirectionSet == false)
        {
            direccionMovimiento = -1;
            Debug.Log("Dir -1");
            isDirectionSet = true;
        }
        else if (jugador.transform.position.x > transform.position.x && isDirectionSet == false)
        {
            direccionMovimiento = 1;
            Debug.Log("Dir 1");
            isDirectionSet = true;
        }
        GetComponent<Animator>().SetBool("activada", true);
        rb.velocity = new Vector2(direccionMovimiento * velocidad,0);
        momentoActivacion = Time.time;
        Destroy(gameObject, momentoActivacion + tiempoRenderizado);
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
