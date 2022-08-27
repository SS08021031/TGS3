using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    public static Audio_Manager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public AudioSource titleMusic, inGameMusic;
    public AudioSource[] SE;

    //BGMÇé~ÇﬂÇÈèàóù
    public void StopMusic()
    {
        titleMusic.Stop();
        
        inGameMusic.Stop();
    }
    //MainMenuÇÃBGMçƒê∂
    public void PlayTitleMusic()
    {
        StopMusic();
        titleMusic.Play();

    }
    
    //IngameÇÃBGMçƒê∂
    public void PlayinGameMusic()
    {
        StopMusic();
        inGameMusic.Play();
    }
    //SEÇÃçƒê∂
    public void PlaySE(int SEtoPlay)
    {
        SE[SEtoPlay].Stop();
        SE[SEtoPlay].Play();
    }
}