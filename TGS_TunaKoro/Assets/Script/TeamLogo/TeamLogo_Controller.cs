using UnityEngine;
using UnityEngine.SceneManagement;
public class TeamLogo_Controller : MonoBehaviour
{
    public AudioClip TeamLogoSound;
    AudioSource audioSource;

    public float Timer;

    void Start()
    {
        Audio_Manager.instance.StopMusic();

        audioSource = GetComponent<AudioSource>();

        Invoke("Sound", 1f);
    }

    void Update()
    {
            Invoke("Next", 6.5f);

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void Sound()
    {
        audioSource.clip = TeamLogoSound;
        audioSource.Play();
    }

    void Next()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
