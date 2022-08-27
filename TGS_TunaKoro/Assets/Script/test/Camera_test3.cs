using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_test3 : MonoBehaviour
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
    void Start()
    {
        
    }

    
    void Update()
    {
        // �J�������W�ϐ��i�v���C���[���W�����j
        Vector3 cameraPos = Player.transform.position;
        // �O��X�����̊p�x�����i�X�����c���ł���悤�Ɂj
        cameraPos = new Vector3(cameraPos.x, cameraPos.y * y, cameraPos.z);

        // �v���C���[���N���X�^���̕����x�N�g��
        Vector3 ToCrystalVector = (Crystal.transform.position - Player.transform.position).normalized;
        // ���̃x�N�g���̋t�����ɃJ�������W��z�u
        cameraPos -= ToCrystalVector * cameraDistance ;
        // �J��������ɂ��炷
        cameraPos += new Vector3(0, cameraUp, 0);

        // �J������position�ɍ��W�ϐ�����
        transform.position = cameraPos;

        // �J�����̕������N���X�^���֌�������
        transform.LookAt(Crystal.transform);
    }
}
