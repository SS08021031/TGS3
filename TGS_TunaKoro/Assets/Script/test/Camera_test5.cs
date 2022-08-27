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
        //2�_�̒��S�_
        Vector3 center = (Player1.transform.position + Player2.transform.position) / 2f;

        //2�_���~�ň͂����Ƃ��̔��a
        float r = Vector3.Distance(center, Player1.transform.position);

        //�J�����̎���p
        float fov = camera.fieldOfView;

        //�J���������S�_������ׂ�����
        float camDistance = r / Mathf.Sin(fov / 2 * Mathf.Deg2Rad);

        //���ۂɃJ�������ړ�
        this.transform.position = new Vector3(center.x, transform.position.y, center.z - camDistance);
        //���S�_�̕�������
        this.transform.LookAt(center);


    }


}
