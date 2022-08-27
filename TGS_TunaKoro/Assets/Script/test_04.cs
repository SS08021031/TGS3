using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_04 : MonoBehaviour
{
    [SerializeField]
    float angularSpeed = 1f;

    float xAngle = 0;

    float step;

    void Update()
    {
        step = angularSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
        {
            xAngle += 0.1f;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, xAngle),step);
            //transform.eulerAngles += angularSpeed * Time.deltaTime * Vector3.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            xAngle -= 0.1f;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, xAngle), step);
            //transform.eulerAngles -= angularSpeed * Time.deltaTime * Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            xAngle -= 0.1f;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(xAngle, 0, 0), step);
            //transform.eulerAngles += angularSpeed * Time.deltaTime * Vector3.left;
        }
        if (Input.GetKey(KeyCode.W))
        {
            xAngle += 0.1f;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(xAngle, 0, 0), step);
            //transform.eulerAngles -= angularSpeed * Time.deltaTime * Vector3.left;
        }
    }
}
