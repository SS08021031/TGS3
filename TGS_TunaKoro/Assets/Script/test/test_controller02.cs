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
        if(Ingame_controll.instance.ingamecontroll == true)
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


            // 回転角度に制限を掛ける---------------------------------------------------------- -

            // 現在の回転を取得
            Vector3 adjustment = transform.eulerAngles;

            // 0～360°を-180～180°に調整
            if (adjustment.x > 180) adjustment.x -= 360;
            if (adjustment.y > 180) adjustment.y -= 360;
            if (adjustment.z > 180) adjustment.z -= 360;

            // x,y,zそれぞれの角度をMaxAngle以下、-MaxAngle以上に調整
            if (adjustment.x > MaxAngle) adjustment.x = MaxAngle;
            else if (adjustment.x < -MaxAngle) adjustment.x = -MaxAngle;
            if (adjustment.y > MaxAngle) adjustment.y = MaxAngle;
            else if (adjustment.y < -MaxAngle) adjustment.y = -MaxAngle;
            if (adjustment.z > MaxAngle) adjustment.z = MaxAngle;
            else if (adjustment.z < -MaxAngle) adjustment.z = -MaxAngle;

            // -180～180°を0～360°に戻す
            if (adjustment.x < 0) adjustment.x += 360;
            if (adjustment.y < 0) adjustment.y += 360;
            if (adjustment.z < 0) adjustment.z += 360;

            // 現在の回転角度を更新
            transform.eulerAngles = adjustment;
        }
        
        //---------------------------------------------------------------------------------

        //if(transform.rotation.eulerAngles.x >= MaxAngle)
        //{
        //  transform.rotation = Quaternion.Euler(MaxAngle, transform.rotation.y, transform.rotation.z);
        // }
        //else if (transform.rotation.eulerAngles.x <= -MaxAngle)
        //{
        //    transform.rotation = Quaternion.Euler(-MaxAngle, transform.rotation.y, transform.rotation.z);
        //}
        //if (transform.rotation.eulerAngles.y >= MaxAngle)
        //{
        //  transform.rotation = Quaternion.Euler(transform.rotation.x, MaxAngle, transform.rotation.z);
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
        //   transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -MaxAngle);
        //}
    }
}
