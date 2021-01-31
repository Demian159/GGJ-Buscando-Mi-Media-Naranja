using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMusicPlayer : MonoBehaviour
{
    void Start()
    {
        if (GameObject.Find("MusicPlayer"))
        {
            Destroy(GameObject.Find("MusicPlayer"));
        }
        FindObjectOfType<RespawnManager>().esBossFight = true;
    }
}
