using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_test6 : MonoBehaviour
{
    public Transform target;
    public float smoothing = 0.0f;
    private Vector3 offset;
    //public float rotationSpeed = 60.0f;
    [SerializeField]
    float angularSpeed = 1f;
    public float inputX;
    public float inputY;
    public float speedX;
    public float speedY;

    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(
            transform.position,
            targetCamPos,
            Time.deltaTime * smoothing
        );

        if (Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            //this.transform.Rotate();
            gameObject.transform.rotation = Quaternion.identity;
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            this.transform.Rotate(0.0f, -180.0f, 0.0f);
        }

        if (Input.GetKeyUp(KeyCode.Joystick1Button5))
        {
            this.transform.Rotate(0.0f, 180.0f, 0.0f);
        }

        // 左に視点移動
        if (Input.GetKey(KeyCode.J) || inputX == -1)
        {
            this.transform.Rotate(0.0f, speedX * Time.deltaTime, 0.0f);
        }
        // 右に視点移動
        if (Input.GetKey(KeyCode.L) || inputX == 1)
        {
            this.transform.Rotate(0.0f, speedX * -1.0f * Time.deltaTime, 0.0f);
        }
        // 上に視点移動
        if (Input.GetKey(KeyCode.K) || inputY == 1)
        {
            this.transform.Rotate(0.0f, 0.0f, Time.deltaTime  * speedY);
        }
        // 下に視点移動
        if (Input.GetKey(KeyCode.I) || inputY == -1)
        {
            this.transform.Rotate(0.0f, 0.0f, Time.deltaTime * -1.0f * speedY);
        }

        //float rotation = inputX * rotationSpeed;
        //rotation *= Time.deltaTime;
        //transform.Rotate(0, rotation, 0);

        //コントローラー操作
        if (Input.GetAxisRaw("Vertical2") < 0)
        {
            inputX = -1;
        }
        else if (0 < Input.GetAxisRaw("Vertical2"))
        {
            inputX = 1;
        }
        else
        {
            inputX = 0;
        }

        if (Input.GetAxisRaw("Horizontal2") < 0)
        {
            inputY = -1;
        }
        else if (0 < Input.GetAxisRaw("Horizontal2"))
        {
            inputY = 1;
        }
        else
		{
            inputY = 0;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
