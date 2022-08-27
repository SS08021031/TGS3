using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_test5 : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;

    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = this.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //2点の中心点
        Vector3 center = (Player1.transform.position + Player2.transform.position) / 2f;

        //2点を円で囲ったときの半径
        float r = Vector3.Distance(center, Player1.transform.position);

        //カメラの視野角
        float fov = camera.fieldOfView;

        //カメラが中心点から取るべき距離
        float camDistance = r / Mathf.Sin(fov / 2 * Mathf.Deg2Rad);

        //実際にカメラを移動
        this.transform.position = new Vector3(center.x, transform.position.y, center.z - camDistance);
        //中心点の方を向く
        this.transform.LookAt(center);


    }


}
