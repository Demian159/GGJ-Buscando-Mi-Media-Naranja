using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Controlador : MonoBehaviour
{
    public int vidas = 3;
    [SerializeField] private TextMeshProUGUI textoVidas;
    [SerializeField] private Slider barraLimpieza;

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
        barraLimpieza.maxValue = FindObjectOfType<Vida>().maxLimpieza;
    }

    private void Update()
    {
        
    }

    public void UpdateUI()
    {
        textoVidas.text = "Vidas: " + vidas.ToString();
        barraLimpieza.value = FindObjectOfType<Vida>().limpieza;
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
        
        //UpdateUI();
        GetComponent<RespawnManager>().Respawn();
    }

    private void ResetearSesionJuego()
    {
        int indiceEscenaActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(indiceEscenaActual);
        Destroy(gameObject);
    }
}
