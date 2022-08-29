using UnityEngine;

public class GameExit : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ÉQÅ[ÉÄèIóπ");
            Application.Quit();
        }
    }
}
