using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsHandler : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.7f;

    [SerializeField] Slider sfxSlider;
    [SerializeField] float defaultDifficulty = 0.5f;
    [SerializeField] MusicPlayer musicPlayer;
    [SerializeField] MusicPlayer sfxPlayer;

    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        sfxSlider.value = PlayerPrefsController.GetSfxVolume();
        if (!musicPlayer)
        {
            var bossMusicPlayer = GameObject.Find("BossMusicPlayer");
            musicPlayer = bossMusicPlayer.GetComponent<MusicPlayer>();
        }
    }

    void Update()
    {
        //MusicPlayer musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            var bossMusicPlayer = GameObject.Find("BossMusicPlayer");
            musicPlayer = bossMusicPlayer.GetComponent<MusicPlayer>();
            musicPlayer.SetVolume(volumeSlider.value);
        }
        if (sfxPlayer)
        {
            sfxPlayer.SetVolume(sfxSlider.value);
        }
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetSfxVolume(sfxSlider.value);
    }

    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
        sfxSlider.value = defaultDifficulty;
    }
}
