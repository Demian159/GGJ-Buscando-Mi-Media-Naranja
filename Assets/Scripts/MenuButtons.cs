using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] GameObject CreditsPanel;
    [SerializeField] GameObject SettingPanel;

    public void StartGame()
    {        

    }
    public void Credits()
    {

    }
    public void Setting()
    {

    }
    public void ClosePanel(GameObject objToClose)
    {
        objToClose.SetActive(false);
    }
    
    public void Exit()
    {
        Application.Quit();
    }
}
