using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    [SerializeField] public int limpieza = 20;
    private RespawnManager respawnManager;
    public int maxLimpieza = 20;

    //[SerializeField] private Vector2 deathKick = new Vector2(25f, 25f);

    public float tiempoInvencibilidad;
    public float contadorInvencibilidad;

    public SpriteRenderer playerRenderer;
    [HideInInspector]
    public float contadorFlash;
    public float tiempoFlash = 0.1f;

    void Start()
    {
        respawnManager = FindObjectOfType<RespawnManager>();
        FindObjectOfType<Controlador>().UpdateUI();
        limpieza = maxLimpieza;
    }


    void Update()
    {
        InvencibilidadHandler();
    }

    public void PerderLimpieza(int danioRecibido)
    {
        if (contadorInvencibilidad <= 0)
        {
            limpieza = Mathf.Max(limpieza - danioRecibido, 0);
            contadorInvencibilidad = tiempoInvencibilidad;
            //limpieza.playerRenderer.enabled = false; //Arreglar
            contadorFlash = tiempoFlash;
            if (limpieza <= 0)
            {
                GetComponent<Jugador>().Morir();
                //GetComponent<Rigidbody2D>().velocity = deathKick;
            }
            FindObjectOfType<Controlador>().UpdateUI();
        }
    }

    public void AgregarLimpieza(int puntosLimpieza)
    {
        if (limpieza >= maxLimpieza)
        {
            return;
        }
        limpieza += puntosLimpieza;
        FindObjectOfType<Controlador>().UpdateUI();
    }

    public void SetearPuntoSpawn(Vector3 nuevaPosicion)
    {
        respawnManager.puntoRespawn = nuevaPosicion;
    }

    public void InvencibilidadHandler()
    {
        if (contadorInvencibilidad > 0)
        {
            contadorInvencibilidad -= Time.deltaTime;

            contadorFlash -= Time.deltaTime;
            if (contadorFlash <= 0)
            {
                playerRenderer.enabled = !playerRenderer.enabled;
                contadorFlash = tiempoFlash;
            }

            if (contadorInvencibilidad <= 0)
            {
                playerRenderer.enabled = true;
            }
        }
    }
}
