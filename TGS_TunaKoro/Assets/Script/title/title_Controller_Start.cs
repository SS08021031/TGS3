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

    public GameObject Fead_Anten_Canvas;

    public float PVcount;
    void Start()
    {
        StartOn.SetActive(false);
        audioSource = GetComponent<AudioSource>();

        Audio_Manager.instance.PlayTitleMusic();

        boxCollider = GetComponent<BoxCollider>();

        Fead_Anten_Canvas.SetActive(false);
    }


    void Update()
    {
        PVcount -= Time.deltaTime;
        if (PVcount <= 0)
        {
            Fead_Anten_Canvas.SetActive(true);
            Invoke("moviescene", 3);
            
        }

    } 

    void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Gray"))
        {
            Debug.Log("‚®‚ê‚¢‚É“–‚½‚Á‚½");

            audioSource.clip = kettei;
            audioSource.Play();

            StartOn.SetActive(true);

            Fead_Anten_Canvas.SetActive(true);
            Invoke("nextscene", 3);
        }
    }

    void nextscene()
    {
        SceneManager.LoadScene("IngamePV");
    }

    void moviescene()
    {
        SceneManager.LoadScene("3Dmovie");
    }
}