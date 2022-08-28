using UnityEngine;
using UnityEngine.SceneManagement;



public class Resullt_Controller : MonoBehaviour
{
    public GameObject StartOn;
    public GameObject EndOn;
    public GameObject StartOff;
    public GameObject EndOff;

    public int selCnt;
    private bool isSel;

    public AudioClip sentaku;
    public AudioClip kettei;
    AudioSource audioSource;

    public GameObject Fead_Canvas_Anten;

    private bool ActOk;
    void Start()
    {
        StartOn.SetActive(false);
        EndOn.SetActive(false);

        audioSource = GetComponent<AudioSource>();

        ActOk = true;

        Fead_Canvas_Anten.SetActive(false);
    }


    void Update()
    {
        if (ActOk == true)
        {
            float input = Input.GetAxis("Horizontal");

            if (input <= -0.5f && !isSel)
            {
                isSel = true;
                selCnt = 1;

                if (selCnt == 1)
                {
                    StartOn.SetActive(true);
                    EndOn.SetActive(false);

                    audioSource.clip = sentaku;
                    audioSource.Play();

                    NextBotton();
                }
            }

            if (input >= 0.5f && !isSel)
            {
                isSel = true;
                selCnt = 0;

                if (selCnt == 0)
                {
                    StartOn.SetActive(false);
                    EndOn.SetActive(true);

                    audioSource.clip = sentaku;
                    audioSource.Play();

                    ExitBotton();
                }
            }

            if (input >= -0.1f && input <= 0.1f)
            {
                isSel = false;
            }
        }

        if (Input.GetKeyDown("joystick button 0"))
        {
            if (selCnt == 1)
            {
                StartOn.SetActive(true);
                EndOn.SetActive(false);

                audioSource.clip = sentaku;
                audioSource.Play();

                NextBotton();
            }

            if (selCnt == 0)
            {
                StartOn.SetActive(false);
                EndOn.SetActive(true);

                audioSource.clip = sentaku;
                audioSource.Play();

                ExitBotton();
            }
        }
    }

    void NextBotton()
    {
        Debug.Log("ネクストボタン");

        if (Input.GetKeyDown("joystick button 0"))
        {
            Debug.Log("ボタン");

            ActOk = false;
            audioSource.clip = kettei;
            audioSource.Play();

            Debug.Log("next");

            Fead_Canvas_Anten.SetActive(true );

            Invoke("nextscene", 3);
        }
    }

    void ExitBotton()
    {
        Debug.Log("出口ボタン");

        if (Input.GetKeyDown("joystick button 0"))
        {
            Debug.Log("ボタン");

            ActOk = false;
            audioSource.clip = kettei;
            audioSource.Play();

            Debug.Log("exit");

            Fead_Canvas_Anten.SetActive(true);

            Invoke("exitscene", 3);
        }
    }
    void nextscene()
    {
        SceneManager.LoadScene("TeamLogo");
    }

    void exitscene()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
}
