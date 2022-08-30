using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal_effect : MonoBehaviour
{
    public GameObject Damage;
    public GameObject point;
    GameObject obj;
    GameObject crystal;

    void Start()
    {
        crystal = GameObject.Find("crystal_effect");    
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            obj = (GameObject)Instantiate(Damage, this.transform.position, Quaternion.identity);
            obj.transform.parent = crystal.transform;
        }

        if (other.CompareTag("fairy"))
        {
            obj = (GameObject)Instantiate(point, this.transform.position, Quaternion.identity);
            obj.transform.parent = crystal.transform;
        }
    }
}
