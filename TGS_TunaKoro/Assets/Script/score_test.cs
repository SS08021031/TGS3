using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class score_test : MonoBehaviour
{
    public static score_test instance;
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
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TextFrame.text = string.Format("{0}", score);

        
    }
}
