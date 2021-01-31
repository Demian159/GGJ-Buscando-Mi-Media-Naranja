using System;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float velocidadCorrer = 5f;
    [SerializeField] private float velocidadSalto = 5f;
    [SerializeField] private float velocidadSubirEscaleras = 5f;
    [SerializeField] private float velocidadProyectil = 10f;
    [SerializeField] private int danioRecibido = 20;
    [SerializeField] private int danioAtaque = 1;
    [SerializeField] private GameObject proyectil;
    private float escalagravedadAlInicio;

    [Header("States")]
    private bool estaVivo = true;

    [Header("Referencias a componentes")]
    private Rigidbody2D rb;
    //Animator animator;
    private CapsuleCollider2D colliderPersonaje;
    private BoxCollider2D piesPersonaje;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
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
        //Morir();
        DarVueltaSprite();
        Disparar();
    }


    private void Disparar()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject go = Instantiate(proyectil, this.transform.position, Quaternion.identity);
            go.GetComponent<Proyectil>().danio = danioAtaque;
            go.GetComponent<Rigidbody2D>().AddForce(new Vector2(this.transform.localScale.x * velocidadProyectil, 0f));
            //go.GetComponent<Rigidbody2D>().AddForce();
            //Rigidbody2D rigidbody = go.GetComponent<Rigidbody2D>();
            //rigidbody.velocity = rigidbody.f * velocidadProyectil;
        }
    }


    private void Correr()
    {
        float controlThrow = Input.GetAxis("Horizontal");
        Vector2 velocidadJugador = new Vector2(controlThrow * velocidadCorrer, rb.velocity.y);
        rb.velocity = velocidadJugador;

        bool jugadorTieneMovimientoHorizontal = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        //animator.SetBool("running", jugadorTieneMovimientoHorizontal);
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
            return;
        }
        if (Input.GetButtonDown("Jump"))
        {
            Vector2 sumaDeVelocidadEnSalto = new Vector2(0f, velocidadSalto);
            rb.velocity += sumaDeVelocidadEnSalto;
        }
    }

    public void Morir()
    {
        //if (colliderPersonaje.IsTouchingLayers(LayerMask.GetMask("Enemigo", "Obstaculo")))
        //{
            estaVivo = false;
            //animator.SetTrigger("die");
            
            FindObjectOfType<Controlador>().ProcesarMuerte();
        estaVivo = true;
        //}
    }

    private void DarVueltaSprite()
    {
        bool jugadorTieneMovimientoHorizontal = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;

        if (jugadorTieneMovimientoHorizontal)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1);
        }
    }

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemigo")
        {
            other.GetComponent<ActivarEnemigo>().Activar();
        }
    }*/
}