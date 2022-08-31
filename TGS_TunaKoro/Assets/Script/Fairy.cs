using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy : MonoBehaviour
{
    public GameObject crystal;
    //クリスタルオブジェクトを格納

    Vector3 target;
    //Vector3の名前

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
        //クリスタルの位置へ向かう

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, crystal.transform.position, step);
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("line"))
        {
            //スコアが上がる
            score_test.instance.score -= 200;
            Destroy(this.gameObject);

            //Debug.Log("line");

        }
        if (other.CompareTag("crystal"))
        {
            //スコアが上がる
            score_test.instance.score += 500;
            Destroy(this.gameObject);
        }
    }
}
