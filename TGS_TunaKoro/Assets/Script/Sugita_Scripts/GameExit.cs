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
            Debug.Log("ÉQÅ[ÉÄèIóπ");
            Application.Quit();
        }
    }
}
