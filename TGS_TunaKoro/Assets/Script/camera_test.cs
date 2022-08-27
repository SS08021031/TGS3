using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_test : MonoBehaviour
{
    private GameObject player;
    void Start()
    {
        player = GameObject.Find("A");
    }
    void Update()
    {
        transform.LookAt(player.transform);
    }
}
