using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class katamuki_test : MonoBehaviour
{
    private Vector3 angle;
    // Start is called before the first frame update
    void Start()
    {
        angle = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            angle.x -= Time.deltaTime;
            transform.eulerAngles = new Vector3(angle.x, transform.root.eulerAngles.y, 0);

            // 角度に制限を加える。
            //if (angle.x < 70) { angle.x = 70; }
        }
        if (Input.GetKey(KeyCode.O))
        {
            angle.x += Time.deltaTime;
            transform.eulerAngles = new Vector3(angle.x, transform.root.eulerAngles.y, 0);

            // 角度に制限を加える。
            //if (angle.x < 70) { angle.x = 70; }
        }
    }
}
