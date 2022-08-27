using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{

    // public GameObject enemy;
    public List<GameObject> enemys = new List<GameObject>();

    public GameObject impact;

    public GameObject targetObject;

    void Start()
    {
        targetObject = GameObject.Find("Crystal_Point");
    }

    void Update()
    {
        this.transform.LookAt(targetObject.transform);
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "enemy")
        {
        enemys.Add(other.gameObject);
        }
    }



    void OnCollisionEnter(Collision collision)
    {
    
        if (collision.gameObject.tag == "crystal")
        {
            
            for(int i = 0; i < enemys.Count; i++)
            {
                
                Instantiate(impact, enemys[i].transform.position, Quaternion.identity);
                Destroy(enemys[i]);
            }
            enemys.Clear();
            

        }
    }
}

