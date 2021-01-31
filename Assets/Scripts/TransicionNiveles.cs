using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransicionNiveles : MonoBehaviour
{
    [SerializeField] private bool llevaABoss = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {       
            if (llevaABoss)
            {
                //Destruir music player
                Destroy(GameObject.Find("MusicPlayer"));
            }
            int indiceEscenaActual = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(indiceEscenaActual + 1);
        }
    }
}
