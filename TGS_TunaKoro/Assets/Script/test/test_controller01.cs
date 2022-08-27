using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_controller01 : MonoBehaviour
{
    [SerializeField]
    float angularSpeed = 1f;
    public float inputX;
    public float inputY;

    void Update()
    {
        if (Input.GetKey(KeyCode.A) || inputX == 1)
        {
            this.transform.Rotate(angularSpeed * -1.0f * Time.deltaTime, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.D) || inputX == -1)
        {
            this.transform.Rotate(angularSpeed* Time.deltaTime, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.S) || inputY == 1)
        {
            this.transform.Rotate(0.0f, 0.0f, angularSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W) || inputY == -1)
        {
            this.transform.Rotate(0.0f, 0.0f, angularSpeed * -1.0f * Time.deltaTime);
        }

        //コントローラー操作
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            inputX = -1;
        }
        else if (0 < Input.GetAxisRaw("Vertical"))
        {
            inputX = 1;
        }
        else
        {
            inputX = 0;
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            inputY = -1;
        }
        else if (0 < Input.GetAxisRaw("Horizontal"))
        {
            inputY = 1;
        }
        else
            inputY = 0;
    }
}
