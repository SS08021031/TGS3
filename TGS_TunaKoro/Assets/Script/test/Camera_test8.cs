using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_test8 : MonoBehaviour
{
    public Transform target;
    public float smoothing = 0.0f;
    private Vector3 offset;
    //public float rotationSpeed = 60.0f;
    [SerializeField]
    float angularSpeed = 1f;
    public float inputX;
    //public float inputY;
    public float speedX;
    public float speedY;

    /// <summary>
    /// プレイヤーオブジェクト
    /// </summary>
    [SerializeField] GameObject Player;
    /// <summary>
    /// (中央)クリスタルオブジェクト
    /// </summary>
    [SerializeField] GameObject Crystal;

    /// <summary>
    /// カメラからプレイヤーとの距離-上下
    /// </summary>
    [SerializeField] float cameraUp;
    /// <summary>
    /// カメラからプレイヤーとの距離-前後
    /// </summary>
    [SerializeField] float cameraDistance;
    /// <summary>
    /// 前後傾き時のカメラ調整用（0.0～1.0）
    /// </summary>
    [SerializeField] float y; 
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

        // カメラ座標変数（プレイヤー座標を代入）
        Vector3 cameraPos = Player.transform.position;
        // 前後傾き時の角度調整（傾きが把握できるように）
        cameraPos = new Vector3(cameraPos.x, cameraPos.y * y, cameraPos.z);

        // プレイヤー→クリスタルの方向ベクトル
        Vector3 ToCrystalVector = (Crystal.transform.position - Player.transform.position).normalized;
        // ↑のベクトルの逆方向にカメラ座標を配置
        cameraPos -= ToCrystalVector * cameraDistance;
        // カメラを上にずらす
        cameraPos += new Vector3(0, cameraUp, 0);

        // カメラのpositionに座標変数を代入
        //transform.position = cameraPos;

        // カメラの方向をクリスタルへ向かせる
        transform.LookAt(Crystal.transform);

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
        //if (Input.GetKey(KeyCode.K) || inputY == 1)
        {
            //this.transform.Rotate(0.0f, 0.0f, Time.deltaTime * speedY);
        }
        // 下に視点移動
        //if (Input.GetKey(KeyCode.I) || inputY == -1)
        {
            //this.transform.Rotate(0.0f, 0.0f, Time.deltaTime * -1.0f * speedY);
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
           // inputY = -1;
        }
        else if (0 < Input.GetAxisRaw("Horizontal2"))
        {
           // inputY = 1;
        }
        else
        {
            //inputY = 0;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
