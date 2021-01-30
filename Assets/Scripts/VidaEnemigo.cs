using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    [SerializeField] private int vida = 5;

    void Update()
    {
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void PerderVida(int danio)
    {
        vida -= danio;
    }
}
