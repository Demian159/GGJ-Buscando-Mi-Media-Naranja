using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransicionNiveles : MonoBehaviour
{
    [SerializeField] private bool llevaABoss = false;
    [SerializeField] private GameObject persistentes;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {       
            if (llevaABoss)
            {
                //Destruir music player
                Destroy(GameObject.Find("MusicPlayer"));
            }
            other.GetComponent<Jugador>().panelPausa.SetActive(true);
            int indiceEscenaActual = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(indiceEscenaActual + 1);
        }
    }

    public void BossMurio()
    {
        if (FindObjectOfType<Vida>().limpieza <= 100)
        {
            int indiceEscenaActual = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(indiceEscenaActual + 2); //bad ending
        }
        else
        {
            int indiceEscenaActual = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(indiceEscenaActual + 1); //good ending
        } 
    }

    public void ExitGame()
    {
        Debug.Log("FuncionaListener");
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        Destroy(FindObjectOfType<Controlador>().gameObject);
    }
}
