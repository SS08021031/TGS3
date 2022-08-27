using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy : MonoBehaviour
{
    public GameObject crystal;
    //�N���X�^���I�u�W�F�N�g���i�[

    Vector3 target;
    //Vector3�̖��O

    public float speed = 3.0f;


    // Start is called before the first frame update
    void Start()
    {
        crystal = GameObject.Find("crystal");
    }

    // Update is called once per frame
    void Update()
    {

        new Vector3(transform.position.x, transform.position.y, transform.position.z);
        //�N���X�^���̈ʒu�֌�����

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, crystal.transform.position, step);
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("line"))
        {

            Destroy(this.gameObject);

            //Debug.Log("line");

        }
    }
}
