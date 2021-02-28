using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ExitGame : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(FindObjectOfType<TransicionNiveles>().ExitGame);
    }
}
