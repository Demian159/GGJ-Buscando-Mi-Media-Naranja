using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespawnManager : MonoBehaviour
{
    public bool esBossFight = false;
    public Jugador jugador;
    public Vida limpieza;

    private bool estaRespawnando;
    public Vector2 puntoRespawn;
    public float tiempoRespawn;

    //public GameObject efectoMuerte;
    public Image pantallaNegra;

    private bool enFadeToBlack;
    private bool enFadeFromBlack;
    public float velocidadFade;
    public float esperaFade;

    private void Start()
    {
        SeteoComponentes();
    }

    private void SeteoComponentes()
    {
        jugador = FindObjectOfType<Jugador>();
        limpieza = FindObjectOfType<Vida>();
        puntoRespawn = jugador.transform.position;
    }

    private void Update()
    {
        FadeBlack();
    }

    private void FadeBlack()
    {
        if (enFadeToBlack)
        {
            pantallaNegra.color = new Color(pantallaNegra.color.r, pantallaNegra.color.g, pantallaNegra.color.b, Mathf.MoveTowards(pantallaNegra.color.a, 1f, velocidadFade * Time.deltaTime));
            if (pantallaNegra.color.a == 1)
            {
                enFadeToBlack = false;
            }
        }

        if (enFadeFromBlack)
        {
            pantallaNegra.color = new Color(pantallaNegra.color.r, pantallaNegra.color.g, pantallaNegra.color.b, Mathf.MoveTowards(pantallaNegra.color.a, 0f, velocidadFade * Time.deltaTime));
            if (pantallaNegra.color.a == 0)
            {
                enFadeFromBlack = false;
            }
        }
    }

    public void Respawn()
    {
        if (!estaRespawnando)
        {
            StartCoroutine("RespawnCo");
        }
    }

    public IEnumerator RespawnCo()
    {
        estaRespawnando = true;
        jugador.gameObject.SetActive(false);
        //Instantiate(efectoMuerte, jugador.transform.position, jugador.transform.rotation);

        yield return new WaitForSeconds(tiempoRespawn);

        enFadeToBlack = true;

        yield return new WaitForSeconds(esperaFade);

        enFadeToBlack = false;
        enFadeFromBlack = true;

        estaRespawnando = false;

        if (esBossFight)
        {
            ActivarEnemigo[] enemigos = FindObjectsOfType<ActivarEnemigo>();
            foreach (ActivarEnemigo enemigo in enemigos)
            {
                Destroy(enemigo.gameObject);
            }
        }
        jugador.gameObject.SetActive(true);
        jugador.transform.position = puntoRespawn;
        limpieza.limpieza = limpieza.maxLimpieza;

        limpieza.contadorInvencibilidad = limpieza.tiempoInvencibilidad;
        limpieza.playerRenderer.enabled = false; //Arreglar
        limpieza.contadorFlash = limpieza.tiempoFlash;

        SeteoComponentes();
        GetComponent<Controlador>().UpdateUI();
    }
}
