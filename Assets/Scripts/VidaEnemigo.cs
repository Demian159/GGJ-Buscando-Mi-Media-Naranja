using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    [SerializeField] private int vida = 5;
    [SerializeField] private bool esBoss = false;

    void Update()
    {
        if (vida <= 0)
        {
            if (esBoss)
            {
                FindObjectOfType<TransicionNiveles>().BossMurio();
            }
            Destroy(gameObject);
            
        }
    }

    public void PerderVida(int danio)
    {
        vida -= danio;
        Debug.Log("OlaQhacePruebaOqHace");
    }

    
}
