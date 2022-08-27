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
    //ゲームシーンに移行
    public void NewGame()
    {
        SceneManager.LoadScene(newGameScene);
    }
    //ゲーム終了の処理
    public void QuitGame()
    {
        Application.Quit();
    }
}
