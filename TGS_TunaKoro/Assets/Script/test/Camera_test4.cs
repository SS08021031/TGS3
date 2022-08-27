using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_test4 : MonoBehaviour
{
    /// <summary>
    /// �v���C���[�I�u�W�F�N�g
    /// </summary>
    [SerializeField] GameObject Player;
    /// <summary>
    /// (����)�N���X�^���I�u�W�F�N�g
    /// </summary>
    [SerializeField] GameObject Crystal;

    /// <summary>
    /// �J��������v���C���[�Ƃ̋���-�㉺
    /// </summary>
    [SerializeField] float cameraUp;
    /// <summary>
    /// �J��������v���C���[�Ƃ̋���-�O��
    /// </summary>
    [SerializeField] float cameraDistance;
    /// <summary>
    /// �O��X�����̃J���������p�i0.0�`1.0�j
    /// </summary>
    [SerializeField] float y;

    public Transform minPos, maxPos;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // �J�������W�ϐ��i�v���C���[���W�����j
        Vector3 cameraPos = Player.transform.position;
        // �O��X�����̊p�x�����i�X�����c���ł���悤�Ɂj
        cameraPos = new Vector3(cameraPos.x, cameraPos.y * y, cameraPos.z);

        // �v���C���[���N���X�^���̕����x�N�g��
        Vector3 ToCrystalVector = (Crystal.transform.position - Player.transform.position).normalized;
        // ���̃x�N�g���̋t�����ɃJ�������W��z�u
        cameraPos -= ToCrystalVector * cameraDistance;
        // �J��������ɂ��炷
        cameraPos += new Vector3(0, cameraUp, 0);

        // �J������position�ɍ��W�ϐ�����
        transform.position = cameraPos;

        // �J�����̕������N���X�^���֌�������
        transform.LookAt(Crystal.transform);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y,minPos.position.y,maxPos.position.y),transform.position.z);
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, minPos.position.x, maxPos.position.x), transform.position.y, Mathf.Clamp(transform.position.z, minPos.position.z, maxPos.position.z));
    }
}
