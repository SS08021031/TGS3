using UnityEngine;

public class GameExit : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            Debug.Log("�Q�[���I��");
            Application.Quit();
        }
    }
}
