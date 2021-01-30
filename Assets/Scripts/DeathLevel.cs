using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Jugador>().Morir();
        }
    }
}
