using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{

    // public GameObject enemy;
    public List<GameObject> enemys = new List<GameObject>();

    public GameObject impact;

    public GameObject targetObject;

    public LayerMask whatGround;

    void Start()
    {
        targetObject = GameObject.Find("Crystal_Point");
    }

    void Update()
    {
        this.transform.LookAt(targetObject.transform);
        Vector3 location = Vector3.zero;
        Vector3 origin = transform.position;
        Vector3 direction = new Vector3(0, -3, 0);
        Ray ray = new Ray(origin, direction);
        Debug.DrawRay(ray.origin, ray.direction * 1f, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, whatGround))
        {
            transform.position = new Vector3(transform.position.x, hit.point.y + 0.1f, transform.position.z);
        }
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

