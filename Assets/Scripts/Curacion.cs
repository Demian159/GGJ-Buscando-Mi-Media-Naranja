using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curacion : MonoBehaviour
{
    [SerializeField] private int limpiezaACurar = 0;
    [SerializeField] private AudioClip clipsAudioSonido;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<Sfx>().DispararSonido(clipsAudioSonido);
            other.GetComponent<Vida>().AgregarLimpieza(limpiezaACurar);
            Destroy(gameObject);
        }
    }
}
