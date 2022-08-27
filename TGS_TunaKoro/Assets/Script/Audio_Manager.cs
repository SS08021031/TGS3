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

    //BGM���~�߂鏈��
    public void StopMusic()
    {
        titleMusic.Stop();
        
        inGameMusic.Stop();
    }
    //MainMenu��BGM�Đ�
    public void PlayTitleMusic()
    {
        StopMusic();
        titleMusic.Play();

    }
    
    //Ingame��BGM�Đ�
    public void PlayinGameMusic()
    {
        StopMusic();
        inGameMusic.Play();
    }
    //SE�̍Đ�
    public void PlaySE(int SEtoPlay)
    {
        SE[SEtoPlay].Stop();
        SE[SEtoPlay].Play();
    }
}