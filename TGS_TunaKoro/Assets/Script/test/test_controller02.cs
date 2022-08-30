using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_controller02 : MonoBehaviour
{
    [SerializeField]
    float angularSpeed = 1f;
    public float inputX;
    public float inputY;

    /// <summary>
    /// プレイヤーオブジェクト
    /// </summary>
    [SerializeField] GameObject Player;
    /// <summary>
    /// (中央)クリスタルオブジェクト
    /// </summary>
    [SerializeField] GameObject Crystal;
    /// <summary>
    /// 傾けられる角度限界
    /// </summary>
    [SerializeField] float MaxAngle;

    void Start()
    {
        Audio_Manager.instance.PlayinGameMusic();
    }
    void Update()
    {
        //コントローラー操作
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        // 傾ける角度変数(angle)
        Vector3 angle = new Vector3(0, 0, 0);// プレイヤー→クリスタルの方向ベクトル
        Vector3 ToCrystalVector = (Crystal.transform.position - Player.transform.position).normalized;
        // angleに角度を設定（左方向　回転軸：プレイヤー→クリスタルの方向ベクトル）
        angle += Quaternion.AngleAxis(angularSpeed * -inputX * Time.deltaTime, ToCrystalVector).eulerAngles;
        // プレイヤー→クリスタルの方向ベクトルを90°回転
        Vector3 tcv = Quaternion.Euler(0, 90, 0) * ToCrystalVector;
        // angleに角度を設定（後方向　回転軸：90°回転させた方向ベクトル）
        angle += Quaternion.AngleAxis(angularSpeed * inputY * Time.deltaTime, tcv).eulerAngles;
        // angleで設定した分回転させる
        transform.Rotate(angle);

        //if(transform.rotation.eulerAngles.x >= MaxAngle)
        //{
        //    transform.rotation = Quaternion.Euler(MaxAngle, transform.rotation.y, transform.rotation.z);
        //}
        //else if (transform.rotation.eulerAngles.x <= -MaxAngle)
        //{
        //    transform.rotation = Quaternion.Euler(-MaxAngle, transform.rotation.y, transform.rotation.z);
        //}
        //if (transform.rotation.eulerAngles.y >= MaxAngle)
        //{
        //    transform.rotation = Quaternion.Euler(transform.rotation.x, MaxAngle, transform.rotation.z);
        //}
        //else if (transform.rotation.eulerAngles.y <= -MaxAngle)
        //{
        //    transform.rotation = Quaternion.Euler(transform.rotation.x, -MaxAngle, transform.rotation.z);
        //}
        //if (transform.rotation.eulerAngles.z >= MaxAngle)
        //{
        //    transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, MaxAngle);
        //}
        //else if (transform.rotation.eulerAngles.z <= -MaxAngle)
        //{
        //    transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -MaxAngle);
        //}
    }
}
