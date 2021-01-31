using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApuntarProyectil : MonoBehaviour
{
    [SerializeField] private GameObject proyectil;
    [SerializeField] private int danioAtaque = 1;
    [SerializeField] private float velocidadProyectil = 10f;
    [SerializeField] private float offset = -360;
    private float rotZ;
    private float timeBtwShots;
    [SerializeField] private float startTimeBtwShots;
    [SerializeField] private AudioClip clipsAudioSonido;

    //-----

    private Transform aimTransform;
    [SerializeField] private Transform shotPoint;

    private void Awake()
    {
        aimTransform = transform.Find("Aim");
    }
    private void Update()
    {
        HandleAiming();
        Disparar();
    }

    private void HandleAiming() 
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f,0f, rotZ + offset);
        
    }

    private void Disparar()
    {
        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                FindObjectOfType<Sfx>().DispararSonido(clipsAudioSonido);
                Instantiate(proyectil, shotPoint.position, transform.rotation);
                //GetComponent<Proyectil2>().danio = danioAtaque;
                timeBtwShots = startTimeBtwShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
       
    }
}
