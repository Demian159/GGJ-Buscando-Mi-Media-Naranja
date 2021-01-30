﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculos : MonoBehaviour
{
    [SerializeField] private int danioACausar = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Vida>().PerderLimpieza(danioACausar);
        }
    }
}
