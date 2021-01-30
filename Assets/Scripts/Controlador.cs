﻿using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Controlador : MonoBehaviour
{
    [SerializeField] private int vidas = 3;
    [SerializeField] private TextMeshProUGUI textoVidas;
    [SerializeField] private TextMeshProUGUI textoLimpieza;

    private void Awake()
    {
        int numeroDeControladores = FindObjectsOfType<Controlador>().Length;
        if (numeroDeControladores > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        UpdateUI();
    }

    private void Update()
    {
        
    }

    public void UpdateUI()
    {
        textoVidas.text = "Vidas: " + vidas.ToString();
        textoLimpieza.text = "Limpieza: " + FindObjectOfType<Vida>().limpieza.ToString();
    }

    public void ProcesarMuerte()
    {
        if (vidas > 1)
        {
            PerderVida();
        }
        else
        {
            ResetearSesionJuego();
        }
    }

    private void PerderVida()
    {
        vidas--;
        int indiceEscenaActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(indiceEscenaActual);
        UpdateUI();
    }

    private void ResetearSesionJuego()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
