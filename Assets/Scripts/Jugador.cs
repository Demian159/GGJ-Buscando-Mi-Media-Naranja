using System;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float velocidadCorrer = 5f;
    [SerializeField] private float velocidadSalto = 5f;
    [SerializeField] private float velocidadSubirEscaleras = 5f;
    //[SerializeField] private float velocidadProyectil = 10f;
    [SerializeField] private int danioRecibido = 20;
    //[SerializeField] private int danioAtaque = 1;
    private float escalagravedadAlInicio;
    [SerializeField] private AudioClip clipAudioSalto;

    [Header("States")]
    private bool estaVivo = true;

    [Header("Referencias a componentes")]
    private Rigidbody2D rb;
    Animator animator;
    private CapsuleCollider2D colliderPersonaje;
    private BoxCollider2D piesPersonaje;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        colliderPersonaje = GetComponent<CapsuleCollider2D>();
        piesPersonaje = GetComponent<BoxCollider2D>();
        escalagravedadAlInicio = rb.gravityScale;
    }

    void Update()
    {
        if (!estaVivo)
        {
            return;
        }
        Correr();
        SubirEscalera();
        Saltar();
        DarVueltaSprite();
    }

    private void Correr()
    {
        float controlThrow = Input.GetAxis("Horizontal");
        Vector2 velocidadJugador = new Vector2(controlThrow * velocidadCorrer, rb.velocity.y);
        rb.velocity = velocidadJugador;

        bool jugadorTieneMovimientoHorizontal = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        animator.SetBool("running", jugadorTieneMovimientoHorizontal);
    }

    private void SubirEscalera()
    {
        if (!piesPersonaje.IsTouchingLayers(LayerMask.GetMask("Trepar")))
        {
            //animator.SetBool("climbing", false);
            rb.gravityScale = escalagravedadAlInicio;
            return;
        }

        float inputControles = Input.GetAxis("Vertical");
        Vector2 velocidadTrepando = new Vector2(rb.velocity.x, inputControles * velocidadSubirEscaleras);
        rb.velocity = velocidadTrepando;
        rb.gravityScale = 0f;

        bool jugadorTieneMovimientoHorizontal = Mathf.Abs(rb.velocity.y) > Mathf.Epsilon;
        //animator.SetBool("climbing", playerHasVerticalSpeed);

    }

    private void Saltar()
    {
        if (!piesPersonaje.IsTouchingLayers(LayerMask.GetMask("Suelo")))
        {
            animator.SetBool("running", false);
            animator.SetBool("jumping", true);
            return;
        }
        else
        {
            animator.SetBool("jumping", false);
        }
        if (Input.GetButtonDown("Jump"))
        {
            
            FindObjectOfType<Sfx>().DispararSonido(clipAudioSalto);
            Vector2 sumaDeVelocidadEnSalto = new Vector2(0f, velocidadSalto);
            rb.velocity += sumaDeVelocidadEnSalto;
        }
        //bool jugadorTieneMovimientoVertical = Mathf.Abs(rb.velocity.y) > Mathf.Epsilon;
        
    }

    public void Morir()
    {
        estaVivo = false;
        //animator.SetTrigger("die");
            
        FindObjectOfType<Controlador>().ProcesarMuerte();
        estaVivo = true;
    }

    private void DarVueltaSprite()
    {
        bool jugadorTieneMovimientoHorizontal = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;

        if (jugadorTieneMovimientoHorizontal)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1);
        }
    }
}