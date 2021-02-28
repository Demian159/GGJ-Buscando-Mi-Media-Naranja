using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private Vida vidaJugador;

    public Renderer rend;

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

        GetComponent<SpriteRenderer>().color = Color.green;
    }

    public void CheckpointOff()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entra1");
        if (other.tag == "Player")
        {
            Debug.Log("Entra2");
            vidaJugador.SetearPuntoSpawn(new Vector3(transform.position.x, transform.position.y +2, transform.position.z));
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
