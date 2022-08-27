using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scoreControl : MonoBehaviour
{
    public static scoreControl instance;
    public Text TextFrame;
    public int score;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        score = score_test.instance.score;
    }

    // Update is called once per frame
    void Update()
    {
        TextFrame.text = string.Format("{0}", score);

        if (Input.GetKeyDown("joystick button 1"))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
