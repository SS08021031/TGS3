using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall2 : MonoBehaviour
{
    public GameObject target;
    [SerializeField]
    float speed;
    void Start()
    {
        target = GameObject.Find("crystal");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
    }
    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("crystal"))
        {

           Destroy(this.gameObject);

            //ÉXÉRÉAÇ™å∏ÇÈ
            score_test.instance.score -= 200;

            //Debug.Log("line");

        }
    }
}
