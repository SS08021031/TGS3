using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_controller : MonoBehaviour
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
        // �X����p�x�ϐ�(angle)
        Vector3 angle = new Vector3(0, 0, 0);
        // �v���C���[���N���X�^���̕����x�N�g��
        Vector3 ToCrystalVector = (Crystal.transform.position - Player.transform.position).normalized;

        // A�L�[�������ꂽ��
        if (Input.GetKey(KeyCode.A)�@|| inputY == -1)
        {
            // transform.eulerAngles += angularSpeed * Time.deltaTime * Vector3.forward;
            // angle�Ɋp�x��ݒ�i�������@��]���F�v���C���[���N���X�^���̕����x�N�g���j
            angle += Quaternion.AngleAxis(angularSpeed * Time.deltaTime, ToCrystalVector).eulerAngles;
        }
        if (Input.GetKey(KeyCode.D) || inputY == 1)
        {
            // transform.eulerAngles -= angularSpeed * Time.deltaTime * Vector3.forward;
            // angle�Ɋp�x��ݒ�i�E�����@��]���F�v���C���[���N���X�^���̕����x�N�g���j
            angle += Quaternion.AngleAxis(-angularSpeed * Time.deltaTime, ToCrystalVector).eulerAngles;
        }
        if (Input.GetKey(KeyCode.S) || inputX == -1)
        {
            // transform.eulerAngles += angularSpeed * Time.deltaTime * Vector3.left;
            // �v���C���[���N���X�^���̕����x�N�g����90����]
            Vector3 tcv = Quaternion.Euler(0, 90, 0) * ToCrystalVector;
            // angle�Ɋp�x��ݒ�i������@��]���F90����]�����������x�N�g���j
            angle += Quaternion.AngleAxis(-angularSpeed * Time.deltaTime, tcv).eulerAngles;
        }
        if (Input.GetKey(KeyCode.W) || inputX == 1)
        {
            // transform.eulerAngles -= angularSpeed * Time.deltaTime * Vector3.left;
            // �v���C���[���N���X�^���̕����x�N�g����90����]
            Vector3 tcv = Quaternion.Euler(0, 90, 0) * ToCrystalVector;
            // angle�Ɋp�x��ݒ�i�O�����@��]���F90����]�����������x�N�g���j
            angle += Quaternion.AngleAxis(angularSpeed * Time.deltaTime, tcv).eulerAngles;
        }
        // angle�Őݒ肵������]������
        transform.Rotate(angle);

        //�R���g���[���[����
        if (inputY == 0.0f)
            if (Input.GetAxisRaw("Vertical") < 0)
            {
                inputX = -1;
            }
            else if (0 < Input.GetAxisRaw("Vertical"))
            {
                inputX = 1;
            }
            else
            {
                inputX = 0;
            }

        if (inputX == 0.0f)
        {
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                inputY = -1;
            }
            else if (0 < Input.GetAxisRaw("Horizontal"))
            {
                inputY = 1;
            }
            else
            {
                inputY = 0;
            }
        }

    }
}
