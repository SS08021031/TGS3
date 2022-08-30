using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_test9 : MonoBehaviour
{
    /// <summary>
    /// プレイヤーオブジェクト
    /// </summary>
    [SerializeField] GameObject Player;
    /// <summary>
    /// (中央)クリスタルオブジェクト
    /// </summary>
    [SerializeField] GameObject Crystal;

    /// <summary>
    /// カメラからプレイヤーとの距離
    /// </summary>
    [SerializeField] Vector2 cameraDistance;

    /// <summary>
    /// 最大カメラ回転角度
    /// </summary>
    [SerializeField] float cameraRotate;
    /// <summary>
    /// カメラ回転速度
    /// </summary>
    [SerializeField] float cameraAngleSpeed;

    /// <summary>
    /// 離れられる最大距離
    /// </summary>
    [SerializeField] Vector2 MaxDistance;
    /// <summary>
    /// 縮められる最小距離
    /// </summary>
    [SerializeField] Vector2 MinDistance;
    /// <summary>
    /// 距離変動速度
    /// </summary>
    [SerializeField] Vector2 cameraMoveSpeed;

    private float rotate;
    private float moveX;
    private float moveY;

    private float inputX;
    private float inputY;
    void Start()
    {
        moveX = cameraDistance.x;
        moveY = cameraDistance.y;
    }


    void Update()
    {
        // カメラ座標変数（プレイヤー座標を代入）
        Vector3 cameraPos = Player.transform.position;

        // 右スティック上下操作でカメラの距離を動かす
        inputY = Input.GetAxis("Horizontal2");
        // float変数誤差調整用
        if (inputY < 0.001f && inputY > -0.001f) inputY = 0;
        if (Input.GetKey(KeyCode.I))
        {
            inputY = 1;
        }
        else if (Input.GetKey(KeyCode.K))
        {
            inputY = -1;
        }
        else
        {
            inputY = 0;
        }
        if (moveX <= MaxDistance.x && moveX >= MinDistance.x)
        {
            moveX += cameraMoveSpeed.x * -inputY * Time.deltaTime;
        }
        else if (moveX > MaxDistance.x) moveX = MaxDistance.x;
        else if (moveX < MinDistance.x) moveX = MinDistance.x;

        if (moveY <= MaxDistance.y && moveY >= MinDistance.y)
        {
            moveY += cameraMoveSpeed.y * -inputY * Time.deltaTime;
        }
        else if (moveY > MaxDistance.y) moveY = MaxDistance.y;
        else if (moveY < MinDistance.y) moveY = MinDistance.y;

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            moveX = cameraDistance.x;
            moveY = cameraDistance.y;
        }

        // プレイヤー→クリスタルの方向ベクトル
        Vector3 ToCrystalVector = (Crystal.transform.position - Player.transform.position).normalized;
        // ↑のベクトルの逆方向にカメラ座標を配置
        cameraPos -= ToCrystalVector * moveX;
        // カメラを上にずらす
        cameraPos += new Vector3(0, moveY, 0);

        // カメラのpositionに座標変数を代入
        transform.position = cameraPos;

        // カメラの方向をクリスタルへ向かせる
        transform.LookAt(Crystal.transform);

        // 右スティック左右操作でカメラを左右へ動かす
        inputX = Input.GetAxis("Vertical2");
        // float変数誤差調整用
        if (inputX < 0.001f && inputX > -0.001f) inputX = 0;
        if (Input.GetKey(KeyCode.J))
        {
            inputX = 1;
        }
        else if (Input.GetKey(KeyCode.L))
        {
            inputX = -1;
        }
        else
        {
            inputX = 0;
        }

        if (inputX == 0 && rotate > 1)
        {
            rotate -= cameraAngleSpeed * Time.deltaTime;
        }
        else if (inputX == 0 && rotate < -1 || inputX == 0 && Input.GetKey(KeyCode.L) && rotate < -1)
        {
            rotate += cameraAngleSpeed * Time.deltaTime;
        }
        else if (inputX == 0)
        {
            rotate = 0;
        }
        else if (rotate < cameraRotate && rotate > -cameraRotate)
        {
            rotate += cameraAngleSpeed * -inputX * Time.deltaTime;
        }
        transform.Rotate(0, rotate, 0);
    }
}
