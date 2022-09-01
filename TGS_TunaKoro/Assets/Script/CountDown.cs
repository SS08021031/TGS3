using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour
{
    public float time;
    public Text TimerText;
    public GameObject Fade_Anten_Canvas;
    void Start()
    {
        Fade_Anten_Canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Ingame_controll.instance.ingamecontroll == true)
        {
            if (0 < time)
            {
                time -= Time.deltaTime;
                TimerText.text = time.ToString("F0");
            }
            else if (time < 0)
            {
                Fade_Anten_Canvas.SetActive(true);

                Invoke("nextscene", 3);

            }
        }
        
    }

    void nextscene()
    {
        SceneManager.LoadScene("Resullt");
    }
    
}
