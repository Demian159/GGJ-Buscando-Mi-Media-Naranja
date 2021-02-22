using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemigo;
    [SerializeField] private float tiempoSpawn;
    [Tooltip("Si el jugador está a la izquierda, setear esto en -1, si está a la derecha, setearlo en 1")]
    [SerializeField] [Range(-1, 1)] private int direccionMovimiento;
    private enum TipoEnemigo { Tachuela, Pelusa, Gusano, Rata, Perro, Polilla };
    [SerializeField] private TipoEnemigo tipoEnemigo;
    [SerializeField] private float velocidadEnemigo;
    [SerializeField] private float radioDeActivacion = 40f;
    private bool puedeSpawnear = true;

    private void Update()
    {
        if (puedeSpawnear)
        {
            StartCoroutine(SpawnearEnemigo());
        }
        
    }

    private IEnumerator SpawnearEnemigo()
    {
        puedeSpawnear = false;
        yield return new WaitForSeconds(tiempoSpawn);
        GameObject go = EnemyInstance();
        SetInstanceParams(go);
        yield return new WaitForSeconds(tiempoSpawn);
        puedeSpawnear = true;
    }

    private void SetInstanceParams(GameObject go)
    {
        go.GetComponent<ActivarEnemigo>().velocidad = velocidadEnemigo;
        go.GetComponent<ActivarEnemigo>().distanciaActivacion = radioDeActivacion;
    }

    private GameObject EnemyInstance()
    {
        GameObject go = Instantiate(enemigo, this.transform.position, Quaternion.identity);
        if (tipoEnemigo == TipoEnemigo.Pelusa)
        {
            go.GetComponent<ActivarEnemigo>().direccionMovimiento = direccionMovimiento;
        }
        if (tipoEnemigo == TipoEnemigo.Gusano)
        {
            go.GetComponent<ActivarEnemigo>().vieneDeSpawner = true;
        }

        return go;
    }
}
