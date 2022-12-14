using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_test4 : MonoBehaviour
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
    /// カメラからプレイヤーとの距離-上下
    /// </summary>
    [SerializeField] float cameraUp;
    /// <summary>
    /// カメラからプレイヤーとの距離-前後
    /// </summary>
    [SerializeField] float cameraDistance;
    /// <summary>
    /// 前後傾き時のカメラ調整用（0.0〜1.0）
    /// </summary>
    [SerializeField] float y;

    public Transform minPos, maxPos;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
        transform.position = cameraPos;

        // カメラの方向をクリスタルへ向かせる
        transform.LookAt(Crystal.transform);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y,minPos.position.y,maxPos.position.y),transform.position.z);
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, minPos.position.x, maxPos.position.x), transform.position.y, Mathf.Clamp(transform.position.z, minPos.position.z, maxPos.position.z));
    }
}
