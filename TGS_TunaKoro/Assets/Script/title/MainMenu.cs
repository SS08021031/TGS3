using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string newGameScene;

    void Start()
    {
        Audio_Manager.instance.PlayTitleMusic();
    }
    //�Q�[���V�[���Ɉڍs
    public void NewGame()
    {
        SceneManager.LoadScene(newGameScene);
    }
    //�Q�[���I���̏���
    public void QuitGame()
    {
        Application.Quit();
    }
}
