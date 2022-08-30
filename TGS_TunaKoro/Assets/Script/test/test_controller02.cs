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
    /// �v���C���[�I�u�W�F�N�g
    /// </summary>
    [SerializeField] GameObject Player;
    /// <summary>
    /// (����)�N���X�^���I�u�W�F�N�g
    /// </summary>
    [SerializeField] GameObject Crystal;

    void Start()
    {
        Audio_Manager.instance.PlayinGameMusic();
    }
    void Update()
    {
        //�R���g���[���[����
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        // �X����p�x�ϐ�(angle)
        Vector3 angle = new Vector3(0, 0, 0);// �v���C���[���N���X�^���̕����x�N�g��
        Vector3 ToCrystalVector = (Crystal.transform.position - Player.transform.position).normalized;
        // angle�Ɋp�x��ݒ�i�������@��]���F�v���C���[���N���X�^���̕����x�N�g���j
        angle += Quaternion.AngleAxis(angularSpeed * -inputX * Time.deltaTime, ToCrystalVector).eulerAngles;
        // �v���C���[���N���X�^���̕����x�N�g����90����]
        Vector3 tcv = Quaternion.Euler(0, 90, 0) * ToCrystalVector;
        // angle�Ɋp�x��ݒ�i������@��]���F90����]�����������x�N�g���j
        angle += Quaternion.AngleAxis(angularSpeed * inputY * Time.deltaTime, tcv).eulerAngles;
        // angle�Őݒ肵������]������
        transform.Rotate(angle);
    }
}
