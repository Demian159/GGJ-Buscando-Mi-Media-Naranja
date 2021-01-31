using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] GameObject mainPanel;
    [SerializeField] private AudioClip clipsAudioSonido;

    public void StartGame()
    {
        SceneManager.LoadScene("Level-1");
    }
    public void StartIntro()
    {
        FindObjectOfType<Sfx>().DispararSonido(clipsAudioSonido);
        SceneManager.LoadScene("Intro");
    }
    public void OpenPanel(GameObject objToOpen)
    {
        FindObjectOfType<Sfx>().DispararSonido(clipsAudioSonido);
        objToOpen.SetActive(true);
        mainPanel.SetActive(false);
    }
    public void ClosePanel(GameObject objToClose)
    {
        objToClose.SetActive(false);
        mainPanel.SetActive(true);
    }
    
    public void Exit()
    {
        FindObjectOfType<Sfx>().DispararSonido(clipsAudioSonido);
        Application.Quit();
    }
}
