using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curacion : MonoBehaviour
{
    [SerializeField] private int limpiezaACurar = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Vida>().AgregarLimpieza(limpiezaACurar);
        }
    }
}
