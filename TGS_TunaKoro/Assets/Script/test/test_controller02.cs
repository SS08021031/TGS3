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
    /// <summary>
    /// �X������p�x���E
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


            // ��]�p�x�ɐ������|����---------------------------------------------------------- -

            // ���݂̉�]���擾
            Vector3 adjustment = transform.eulerAngles;

            // 0�`360����-180�`180���ɒ���
            if (adjustment.x > 180) adjustment.x -= 360;
            if (adjustment.y > 180) adjustment.y -= 360;
            if (adjustment.z > 180) adjustment.z -= 360;

            // x,y,z���ꂼ��̊p�x��MaxAngle�ȉ��A-MaxAngle�ȏ�ɒ���
            if (adjustment.x > MaxAngle) adjustment.x = MaxAngle;
            else if (adjustment.x < -MaxAngle) adjustment.x = -MaxAngle;
            if (adjustment.y > MaxAngle) adjustment.y = MaxAngle;
            else if (adjustment.y < -MaxAngle) adjustment.y = -MaxAngle;
            if (adjustment.z > MaxAngle) adjustment.z = MaxAngle;
            else if (adjustment.z < -MaxAngle) adjustment.z = -MaxAngle;

            // -180�`180����0�`360���ɖ߂�
            if (adjustment.x < 0) adjustment.x += 360;
            if (adjustment.y < 0) adjustment.y += 360;
            if (adjustment.z < 0) adjustment.z += 360;

            // ���݂̉�]�p�x���X�V
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
