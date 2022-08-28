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

    } 

    void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Gray"))
        {
            Debug.Log("ぐれいに当たった");

            audioSource.clip = kettei;
            audioSource.Play();

            StartOn.SetActive(true);

            Fead_Anten_Canvas.SetActive(true);
            Invoke("nextscene", 3);
        }
    }

    void nextscene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}