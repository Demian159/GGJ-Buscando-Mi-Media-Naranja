﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    [SerializeField] public int limpieza = 20;
    public int maxLimpieza = 20;

    void Start()
    {
        FindObjectOfType<Controlador>().UpdateUI();
        limpieza = maxLimpieza;
    }


    void Update()
    {
        
    }

    public void PerderLimpieza(int danioRecibido)
    {
        limpieza -= Mathf.Max(0, danioRecibido);
        if (limpieza <= 0)
        {
            GetComponent<Jugador>().Morir();
        }
        FindObjectOfType<Controlador>().UpdateUI();
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
}