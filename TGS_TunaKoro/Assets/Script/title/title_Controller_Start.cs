using UnityEngine;
using UnityEngine.SceneManagement;

public class title_Controller_Start : MonoBehaviour
{
    public GameObject StartOn;
    public GameObject StartOff;

    public AudioClip sentaku;
    public AudioClip kettei;
    AudioSource audioSource;

    BoxCollider boxCollider;

    bool next;
    void Start()
    {
        StartOn.SetActive(false);
        audioSource = GetComponent<AudioSource>();

        Audio_Manager.instance.PlayTitleMusic();

        boxCollider = GetComponent<BoxCollider>();
    }


    void Update()
    {

    } 

    void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Gray"))
        {
            Debug.Log("‚®‚ê‚¢‚É“–‚½‚Á‚½");

            audioSource.clip = kettei;
            audioSource.Play();

            StartOn.SetActive(true);
            nextscene();
        }
    }

    void nextscene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}