using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patas : MonoBehaviour
{
    [SerializeField] private GameObject vidaPerro;
    //[SerializeField] private GameObject pataPerro;
    //[SerializeField] private Transform[] spawns;
    [SerializeField] private float tiempoSpawn;
    //[Tooltip("Si el jugador está a la izquierda, setear esto en -1, si está a la derecha, setearlo en 1")]
    //[SerializeField] [Range(-1, 1)] private int direccionMovimiento;
    private bool puedeSpawnear = true;
    private Animator animator;
    [SerializeField] private AudioClip clipsAudioSonido;

    private void Start()
    {
        animator = GetComponent<Animator>();
        //pataPerro.SetActive(false);
    }

    private void Update()
    {
        if (puedeSpawnear)
        {
            StartCoroutine(Espera());
        }
    }
    private IEnumerator Espera()
    {
        animator.SetBool("atacando", false);
        yield return new WaitForSeconds(tiempoSpawn);
        //pataPerro.SetActive(true);
        StartCoroutine(SpawnearEnemigo());
        yield return new WaitForSeconds(tiempoSpawn);
        //pataPerro.SetActive(false);
    }

    private IEnumerator SpawnearEnemigo()
    {
        puedeSpawnear = false;
        yield return new WaitForSeconds(tiempoSpawn);
        
        animator.SetBool("atacando", true);

        yield return new WaitForSeconds(tiempoSpawn);
        puedeSpawnear = true;
        //StartCoroutine(Reposicionar());
    }

    private void Reposicionar()
    {
        //yield return new WaitForSeconds(tiempoSpawn * 2);
        /*Transform nextSpawn = spawns[UnityEngine.Random.Range(1, 4)];
        this.transform.position = new Vector3(nextSpawn.position.x, nextSpawn.position.y, nextSpawn.position.z);
        this.transform.localScale = nextSpawn.localScale;*/
        FindObjectOfType<Reposicionar>().Reposicion();
    }

    /*private void DesactivarAnimacion()
    {
        animator.SetBool("atacando", false);
    }*/
}
