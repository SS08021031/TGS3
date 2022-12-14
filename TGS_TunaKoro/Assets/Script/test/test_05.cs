using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_05 : MonoBehaviour
{
    [SerializeField]
    float angularSpeed = 1f;

    /// <summary>
    /// プレイヤーオブジェクト
    /// </summary>
    [SerializeField] GameObject Player;
    /// <summary>
    /// (中央)クリスタルオブジェクト
    /// </summary>
    [SerializeField] GameObject Crystal;

    void Update()
    {
        // 傾ける角度変数(angle)
        Vector3 angle = new Vector3(0, 0, 0);
        // プレイヤー→クリスタルの方向ベクトル
        Vector3 ToCrystalVector = (Crystal.transform.position - Player.transform.position).normalized;

        // Aキーが押されたら
        if (Input.GetKey(KeyCode.A))
        {
            // transform.eulerAngles += angularSpeed * Time.deltaTime * Vector3.forward;
            // angleに角度を設定（左方向　回転軸：プレイヤー→クリスタルの方向ベクトル）
            angle += Quaternion.AngleAxis(angularSpeed * Time.deltaTime, ToCrystalVector).eulerAngles;
        }
        if (Input.GetKey(KeyCode.D))
        {
            // transform.eulerAngles -= angularSpeed * Time.deltaTime * Vector3.forward;
            // angleに角度を設定（右方向　回転軸：プレイヤー→クリスタルの方向ベクトル）
            angle += Quaternion.AngleAxis(-angularSpeed * Time.deltaTime, ToCrystalVector).eulerAngles;
        }
        if (Input.GetKey(KeyCode.S))
        {
            // transform.eulerAngles += angularSpeed * Time.deltaTime * Vector3.left;
            // プレイヤー→クリスタルの方向ベクトルを90°回転
            Vector3 tcv = Quaternion.Euler(0, 90, 0) * ToCrystalVector;
            // angleに角度を設定（後方向　回転軸：90°回転させた方向ベクトル）
            angle += Quaternion.AngleAxis(-angularSpeed * Time.deltaTime, tcv).eulerAngles;
        }
        if (Input.GetKey(KeyCode.W))
        {
            // transform.eulerAngles -= angularSpeed * Time.deltaTime * Vector3.left;
            // プレイヤー→クリスタルの方向ベクトルを90°回転
            Vector3 tcv = Quaternion.Euler(0, 90, 0) * ToCrystalVector;
            // angleに角度を設定（前方向　回転軸：90°回転させた方向ベクトル）
            angle += Quaternion.AngleAxis(angularSpeed * Time.deltaTime, tcv).eulerAngles;
        }
        // angleで設定した分回転させる
        transform.Rotate(angle);
    }
}
