using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Controlador : MonoBehaviour
{
    [SerializeField] private int vidas = 3;
    [SerializeField] private int limpieza = 20;
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

    private void UpdateUI()
    {
        textoVidas.text = "Vidas: " + vidas.ToString();
        textoLimpieza.text = "Limpieza: " + limpieza.ToString();
    }

    public void AgregarPuntaje(int puntosLimpieza)
    {
        limpieza += puntosLimpieza;
        UpdateUI();
    }

    public void ProcesarMuerte(int danioRecibido)
    {
        //if (limpieza <= 0)
       //{
            if (vidas > 1)
            {
                PerderVida();
            }
            else
            {
                ResetearSesionJuego();
            }
        //}
        //else
        //{
        //    limpieza -= danioRecibido;
        //}
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
