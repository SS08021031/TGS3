using UnityEngine;
using UnityEngine.SceneManagement;

public class title_Controller_End : MonoBehaviour
{
    public GameObject EndOn;
    public GameObject EndOff;

    public AudioClip kettei;
    AudioSource audioSource;

    BoxCollider boxCollider;

    void Start()
    {
        EndOn.SetActive(false);
        audioSource = GetComponent<AudioSource>();

        Audio_Manager.instance.PlayTitleMusic();

        boxCollider = GetComponent<BoxCollider>();
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Gray"))
        {
            Debug.Log("‚®‚ê‚¢‚É“–‚½‚Á‚½");

            audioSource.clip = kettei;
            audioSource.Play();

            EndOn.SetActive(true);
            exitscene();
        }
    }

    void exitscene()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
