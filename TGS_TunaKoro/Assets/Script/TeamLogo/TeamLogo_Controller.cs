using UnityEngine;
using UnityEngine.SceneManagement;
public class TeamLogo_Controller : MonoBehaviour
{
    public AudioClip TeamLogoSound;
    AudioSource audioSource;

    public float Timer;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        Invoke("Sound", 1f);
    }

    void Update()
    {
            Invoke("Next", 6.5f);
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
