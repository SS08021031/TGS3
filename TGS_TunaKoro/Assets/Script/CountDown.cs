using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour
{
    public float time;
    public Text TimerText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(0 < time)
        {
            time -= Time.deltaTime;
            TimerText.text = time.ToString("F0");
        }
        else if (time < 0)
        {
            SceneManager.LoadScene("Resullt");
        }
    }
    
}
