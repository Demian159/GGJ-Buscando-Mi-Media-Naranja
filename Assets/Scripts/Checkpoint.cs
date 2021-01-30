using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private Vida vidaJugador;

    public Renderer rend;
    //public Material checkpointOff;
    //public Material checkpointOn;

    [SerializeField] private GameObject panelNotificacion;
    [SerializeField] private float tiempoNotificacion = 2f;

    void Start()
    {
        vidaJugador = FindObjectOfType<Vida>();
        panelNotificacion.SetActive(false);
    }

    public void CheckpointOn()
    {
        Debug.Log("Entra3");
        Checkpoint[] checkpoints = FindObjectsOfType<Checkpoint>();
        foreach (Checkpoint checkpoint in checkpoints)
        {
            Debug.Log("EntraForEach");
            checkpoint.CheckpointOff();
        }

        //rend.GetComponent<SpriteRenderer>().color = Color.green;
        GetComponent<SpriteRenderer>().color = Color.green;
    }

    public void CheckpointOff()
    {
        //rend.GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entra1");
        if (other.tag == "Player")
        {
            Debug.Log("Entra2");
            vidaJugador.SetearPuntoSpawn(transform.position);
            CheckpointOn();
            StartCoroutine(NotificarCheckPoint());
        }
    }

    private IEnumerator NotificarCheckPoint()
    {
        panelNotificacion.SetActive(true);
        yield return new WaitForSeconds(tiempoNotificacion);
        panelNotificacion.SetActive(false);
    }
}
